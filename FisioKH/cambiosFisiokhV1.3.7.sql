USE [FisioKH_dev]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE OR ALTER   PROCEDURE [dbo].[usp_obtenSaldoPaciente]
    @idPaciente BIGINT,
	@esAdmin BIT = 0 
AS
BEGIN
    SET NOCOUNT ON;
	declare @sql as varchar(2000) 

    SELECT
      sp.[id] 
	,sp.[saldo] 
	,sp.[activo]
	,sp.[idPaciente] 
	,sp.[idCita] 
	,sp.[idVisita]
	,sp.[idPagoVisitaRealizada] 
	,sp.[idUsuario] 
	,sp.[fechaRegistro] AS fechaSaldo

    FROM dbo.[saldoPacienteVisitas] AS sp    

    INNER JOIN Pacientes AS p
        ON sp.idPaciente = p.id

    INNER JOIN dbo.usuarios AS u
        ON sp.idUsuario = u .id

   WHERE sp.idPaciente = @idPaciente
    AND (@esAdmin = 1 OR sp.activo = 1)
    AND sp.saldo > 0
END;
GO

 
/****** Object:  StoredProcedure [dbo].[usp_obtenVisitasPagadasConSaldo]    Script Date: 3/31/2026 11:28:00 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE OR ALTER     PROCEDURE [dbo].[usp_obtenVisitasPagadasConSaldo]
     (
		@idVisita BIGINT,
		@idPaciente BIGINT
	 )
AS
BEGIN
    SET NOCOUNT ON;

   SELECT
	   spv.[id] as idSaldo
      ,spv.[idPaciente]

      ,spv.[idVisita]
      
	  ,pvr.id AS [idPagoVisitaRealizada]
	  ,pvr.idMetodoPago
	  ,pvr.cantidadPago

  FROM [dbo].[saldoPacienteVisitas] AS spv
		INNER JOIN dbo.[pagosVisitasRealizadas] AS pvr
			ON spv.idVisita = pvr.idVisita
	WHERE idMetodoPago = 10
		AND spv.idVisita = @idVisita
		AND spv.idPaciente = @idPaciente
		
END
GO

 




CREATE OR ALTER     PROCEDURE [dbo].[usp_insertPagoVisita]
(

	@idVisita  BIGINT,
	@idUsuario BIGINT,
    @idMetodoPago BIGINT,
	@idPrecio BIGINT,
    @cantidadPago NUMERIC(18,0),
	@idSaldo BIGINT,
    @cantidadSaldoUsar NUMERIC(18,0),
    @rowsAffected INT OUTPUT,
    @idPago BIGINT OUTPUT
)
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    BEGIN TRY
        BEGIN TRAN;

		DECLARE @cantidadPrecio AS BIGINT = 0;

		SELECT @cantidadPrecio = [precio] FROM dbo.precios WHERE id = @idPrecio;

        -- Insert into Citas
        INSERT INTO dbo.pagosVisitasRealizadas
		  (
				[idVisita]
			   ,[idUsuario]
			   ,[idMetodoPago]
			   ,[idPrecio]
			   ,[cantidadPrecio]
			   ,[cantidadPago]
		  )
        VALUES
        (
			 @idVisita
			,@idUsuario
			,@idMetodoPago
			,@idPrecio
			,@cantidadPrecio
			,@cantidadPago
        );

        SET @idPago = SCOPE_IDENTITY();

        -- Insert into visitasRealizadas
        UPDATE dbo.visitasRealizadas
        SET pagado = 1
            WHERE id = @idVisita;

		SET @rowsAffected= @@ROWCOUNT;

        COMMIT;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK;
        THROW;
    END CATCH
END
GO

 
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER   PROCEDURE [dbo].[usp_GuardarSaldoPacienteVisita]
(
    @saldo NUMERIC(18, 0),
    @idPaciente BIGINT,
    @idCita BIGINT,
    @idVisita BIGINT,
    @idPagoVisitaRealizada BIGINT,
    @idUsuario BIGINT,
    @rowsAffected INT OUTPUT,
	@idSaldoGenerado INT OUTPUT
)
AS
BEGIN
    SET NOCOUNT ON;

    -- Validación básica
    IF (@saldo <= 0)
    BEGIN
        RAISERROR('El saldo debe ser mayor a 0.', 16, 1);
        RETURN;
    END

    DECLARE @idExistente BIGINT;

    -- Buscar si ya existe
    SELECT @idExistente = id
    FROM dbo.saldoPacienteVisitas
    WHERE idPaciente = @idPaciente
      AND idCita = @idCita
      AND idVisita = @idVisita
      AND idPagoVisitaRealizada = @idPagoVisitaRealizada
      AND activo = 1;

    -- Si existe → UPDATE
    IF (@idExistente IS NOT NULL)
    BEGIN
        UPDATE dbo.saldoPacienteVisitas
        SET saldo =  @saldo,   -- acumula saldo
            idUsuario = @idUsuario
        WHERE id = @idExistente;

        SET @rowsAffected = @@ROWCOUNT;
		SET @idSaldoGenerado = @idExistente;
        RETURN;
    END

    -- Si no existe → INSERT
    INSERT INTO dbo.saldoPacienteVisitas
    (
        saldo,
        activo,
        idPaciente,
        idCita,
        idVisita,
        idPagoVisitaRealizada,
        idUsuario
    )
    VALUES
    (
        @saldo,
        1,
        @idPaciente,
        @idCita,
        @idVisita,
        @idPagoVisitaRealizada,
        @idUsuario
    );



    SET @rowsAffected = @@ROWCOUNT;
	SET @idSaldoGenerado = SCOPE_IDENTITY();
END
GO

 

ALTER           PROCEDURE [dbo].[usp_insertPagoVisita]
(

	@idVisita  BIGINT,
	@idUsuario BIGINT,
    @idMetodoPago BIGINT,
	@idPrecio BIGINT,
    @cantidadPago NUMERIC(18,0),
	@idSaldo BIGINT,
    @cantidadSaldoUsar NUMERIC(18,0),
    @rowsAffected INT OUTPUT,
    @idPago BIGINT OUTPUT
)
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    BEGIN TRY
        BEGIN TRAN;

		DECLARE @cantidadPrecio AS BIGINT = 0;
		DECLARE @idMetodoPagoSaldo AS BIGINT = 10;
		DECLARE @saldoOriginal AS NUMERIC(18,0) =0;
		DECLARE @saldoNuevo AS NUMERIC(18,0) =0;
		DECLARE @idCita AS BIGINT = 0;
		DECLARE @idPaciente AS BIGINT = 0;
		DECLARE @idPagoVisitaRealizada AS BIGINT = 0;
		DECLARE @activoSaldoNuevo AS TINYINT = 0;

		SELECT @cantidadPrecio = [precio] FROM dbo.precios WHERE id = @idPrecio;

		IF @idSaldo > 0 AND @cantidadSaldoUsar >0 
		BEGIN
			SELECT 
				@saldoOriginal = saldo,
				@idCita = idCita,
				@idPaciente = idPaciente,
				@idPagoVisitaRealizada = idPagoVisitaRealizada
			FROM dbo.saldoPacienteVisitas WHERE id = @idSaldo;

			SET @saldoNuevo = @saldoOriginal - @cantidadSaldoUsar;

			IF @saldoNuevo >0
			BEGIN
				SET @activoSaldoNuevo = 1;
			END

			INSERT INTO [dbo].[saldoPacienteVisitas]
					   ([saldo]
					   ,[activo]
					   ,[idPaciente]
					   ,[idCita]
					   ,[idVisita]
					   ,[idPagoVisitaRealizada]
					   ,[idUsuario]
					   )
				 VALUES
					   ( 
							@saldoNuevo,
							@activoSaldoNuevo,
							@idPaciente,
							@idCita,
							@idVisita,
							@idPagoVisitaRealizada,
							@idUsuario
					   );

				UPDATE  dbo.saldoPacienteVisitas  SET activo = 0 WHERE id = @idSaldo;		 




			 INSERT INTO dbo.pagosVisitasRealizadas
			  (
					[idVisita]
				   ,[idUsuario]
				   ,[idMetodoPago]
				   ,[idPrecio]
				   ,[cantidadPrecio]
				   ,[cantidadPago]
			  )
			VALUES
			(
				 @idVisita
				,@idUsuario
				,@idMetodoPagoSaldo
				,@idPrecio
				,@cantidadPrecio
				,@cantidadSaldoUsar
			);

			IF @idPago IS NULL
				BEGIN 
					SET @idPago = SCOPE_IDENTITY();
				END
		END

    IF(@cantidadSaldoUsar < @cantidadPrecio)
		BEGIN
			--SET @cantidadPago = @cantidadPago - @cantidadSaldoUsar;

			INSERT INTO dbo.pagosVisitasRealizadas
			(
				 [idVisita]
				,[idUsuario]
				,[idMetodoPago]
				,[idPrecio]
				,[cantidadPrecio]
				,[cantidadPago]
			)
			VALUES
			(
				 @idVisita
				,@idUsuario
				,@idMetodoPago
				,@idPrecio
				,@cantidadPrecio
				,@cantidadPago
			);
		END

        SET @idPago = SCOPE_IDENTITY();

        -- Insert into visitasRealizadas
        UPDATE dbo.visitasRealizadas
        SET pagado = 1
            WHERE id = @idVisita;

		SET @rowsAffected= @@ROWCOUNT;

        COMMIT;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK;
        THROW;
    END CATCH
END
GO



CREATE OR ALTER         PROCEDURE [dbo].[usp_updatePagoVisita]
(
	@idPago BIGINT,
	@idVisita  BIGINT,
	@idUsuario BIGINT,
    @idMetodoPago BIGINT,
	@idPrecio BIGINT,
    @cantidadPago NUMERIC(18,0),
	@idSaldo BIGINT,
    @cantidadSaldoUsar NUMERIC(18,0),
    @rowsAffected INT OUTPUT
  

)
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    BEGIN TRY
        BEGIN TRAN;
		print 'idsaldo '
		print @idSaldo
		print 'saldo usado '
		print @cantidadSaldoUsar
		DECLARE @cantidadPrecio AS BIGINT = 0;

		SELECT @cantidadPrecio = [precio] FROM dbo.precios WHERE id = @idPrecio;

        -- Insert into Citas
       UPDATE dbo.pagosVisitasRealizadas
		SET [idUsuario] = @idUsuario
			   ,[idMetodoPago] = @idMetodoPago
			   ,[idPrecio] = @idPrecio
			   ,[cantidadPrecio] = @cantidadPrecio
			   ,[cantidadPago] = @cantidadPago
		  WHERE id = @idPago;

        SET @idPago = SCOPE_IDENTITY();

        -- Insert into visitasRealizadas
        UPDATE dbo.visitasRealizadas
        SET pagado = 1
            WHERE id = @idVisita;

		SET @rowsAffected= @@ROWCOUNT;

        COMMIT;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK;
        THROW;
    END CATCH
END
GO



SET IDENTITY_INSERT dbo.[metodoPago] ON;
INSERT INTO [dbo].[metodoPago]
           (id,[nombre]
           ,[idUsuario]
           
           ,[ocupaReferenciaPago])
     VALUES
           (
		   10,
		   'Saldo Paciente'
           ,1
			,0)

			SET IDENTITY_INSERT dbo.[metodoPago] Off;
GO



CREATE OR ALTER   PROCEDURE [dbo].[usp_obtenerVisitasRealizadas]
    @fechaInicio AS DATE,
	@fechaFin AS DATE,
	@idMetodopago AS BIGINT 
AS
BEGIN
    SET NOCOUNT ON;

    SELECT        
		cFechaCita AS fechaCita
        ,cNombreCompletoPaciente AS Paciente
		,cNombreFisioterapeuta AS [Fisio Terapeuta]
		,
			CASE vPagado 
			WHEN 1 THEN 'Si'
				ELSE 'No'
			END 
			
			AS Pagado
		,pPrecio AS NombrePrecio
		,pCantidadPrecio AS [Cantidad Precio]
		,
			CASE 
				prPacientePaga 
				WHEN 1 THEN 'SI'
				ELSE 'NO'
		END		
		AS [Paciente Paga]
		,vrCantidadPago AS  [Cantidad Pagada]
		,mpMetodoPago AS [Metodo Pago]
		,vrIdMetodoPago AS IdMeTodopago
		,pvrFechaPago AS [Fecha Pago]
		
		-- select * 
    FROM vw_citasVisitasPagos
    WHERE convert(date,vFechaVisita) BETWEEN @fechaInicio AND @fechaFin
		AND (
            @idMetodopago = 0 
            OR vrIdMetodoPago = @idMetodopago
        )
	ORDER BY vFechaVisita DESC
END
GO




 






CREATE OR ALTER view [dbo].[vw_citasVisitasPagos]
AS

    SELECT
        
        c.id AS cIdCita,
        c.idPaciente AS cIdPaciente,
        c.fechaCita AS cFechaCita,
        c.fechaRegistro AS cFechaRegistro,
        c.realizada AS cRealizada,
        c.idUsuario AS cidUsuarioCita,
        c.idGoogleCalendar AS idGoogleCalendar,     
        c.idFisioTerapeuta AS cIdFisioterapeuta,
        p.claveEtiqueta AS cClaveEtiqueta,
		p.notasMedicas AS pNotas,
		p.observaciones AS pObservaciones,
        ft.nombre AS cNombreFisioterapeuta,
        CONCAT(
            p.nombreCompleto, ' ',
            COALESCE(p.apellidoPaterno, ''), ' ',
            COALESCE(p.apellidoMaterno, '')
        ) AS cNombreCompletoPaciente,

		COALESCE(vr.id,0) AS vIdVisita,
		COALESCE(vr.idPaciente,0) AS vIdPaciente,
		COALESCE(vr.fechaVisita,'') AS vFechaVisita,
		COALESCE(vr.idUsuario,0) AS vIdUsuario,
		COALESCE(vr.idPrecio,0) AS vIdPrecio,
		COALESCE(vr.pagado,0) AS vPagado,
		COALESCE(vr.ocupaFactura,0) AS vOcupaFactura,
		COALESCE(pvr.id,0) AS vrIdPago,
		COALESCE(pvr.idUsuario,0) AS vrIdUsuario,
		COALESCE(pvr.idMetodoPago,0) AS vrIdMetodoPago,
		COALESCE(pvr.cantidadPago,0) vrCantidadPago,
		COALESCE(pvr.referenciaPago,0) AS vrReferenciaPago,
		pr.precio AS pCantidadPrecio,
		pr.nombre AS pPrecio,
		pr.pacientePaga AS prPacientePaga,
		mp.nombre AS mpMetodoPago,
		pvr.fechaRegistro AS pvrFechaPago

    FROM Citas c
    INNER JOIN fisioTerapeutas ft ON c.idFisioTerapeuta = ft.id
    INNER JOIN Pacientes p ON c.idPaciente = p.id
	LEFT JOIN visitasRealizadas AS vr ON c.id = vr.idCita
	LEFT JOIN  pagosVisitasRealizadas AS pvr 
		ON (
				vr.id = pvr.idVisita 
				--AND pvr.idMetodoPago <>10 
			)
	LEFT JOIN  precios AS pr ON pr.id = pvr.idPrecio
	LEFT JOIN  metodoPago AS mp ON mp.id = pvr.idMetodoPago


GO





CREATE OR ALTER       PROCEDURE [dbo].[usp_obtenSaldoPaciente]
    @idPaciente BIGINT,
	@esAdmin BIT = 0 
AS
BEGIN
    SET NOCOUNT ON;
	declare @sql as varchar(2000) 

    SELECT
      sp.[id] 
	,sp.[saldo] 
	,sp.[activo]
	,sp.[idPaciente] 
	,sp.[idCita] 
	,sp.[idVisita]
	,sp.[idPagoVisitaRealizada] 
	,sp.[idUsuario] 
	,sp.[fechaRegistro] AS fechaSaldo

    FROM dbo.[saldoPacienteVisitas] AS sp    

    INNER JOIN Pacientes AS p
        ON sp.idPaciente = p.id

    INNER JOIN dbo.usuarios AS u
        ON sp.idUsuario = u .id

   WHERE sp.idPaciente = @idPaciente
    -- AND (@esAdmin = 1 OR ( sp.activo = 1 AND  sp.saldo > 0)	)
    
END;
GO




ALTER     PROCEDURE [dbo].[usp_obtenExpedientePaciente]
    @idPaciente bigint
AS
BEGIN
    SET NOCOUNT ON;

    SELECT        
        cFechaCita AS fechaCita
		,cIdCita AS idCita
		,vIdVisita AS idVisita
		,vrIdPago AS idPago
		,vIdPaciente AS idPaciente
        ,cNombreCompletoPaciente AS Paciente
		,cNombreFisioterapeuta AS [Fisio Terapeuta]
		,
			CASE vPagado 
			WHEN 1 THEN 'Si'
				ELSE 'No'
			END 
			
			AS Pagado
		,pPrecio AS NombrePrecio
		,pCantidadPrecio AS [Cantidad Precio]
		,
			CASE 
				prPacientePaga 
				WHEN 1 THEN 'SI'
				ELSE 'NO'
		END		
		AS [Paciente Paga]
		,vrCantidadPago AS  [Cantidad Pagada]
		,mpMetodoPago AS [Metodo Pago]
		,pvrFechaPago AS [Fecha Pago]
    FROM vw_citasVisitasPagos
    WHERE cIdPaciente = @idPaciente
	ORDER BY cFechaRegistro DESC
END
GO





CREATE OR ALTER   PROCEDURE [dbo].[usp_deletePacienteSiNoTieneCitas]
(
    @idPaciente BIGINT,
    @rowsAffected INT OUTPUT
)
AS
BEGIN
    SET NOCOUNT ON;

    SET @rowsAffected = 0;

    IF EXISTS (SELECT 1 FROM dbo.Citas WHERE idPaciente = @idPaciente)
        RETURN;

	 IF EXISTS (SELECT 1 FROM dbo.visitasRealizadas WHERE idPaciente = @idPaciente)
        RETURN;

	IF EXISTS (SELECT 1 FROM dbo.saldoPacienteVisitas WHERE idPaciente = @idPaciente)
        RETURN;


    DELETE FROM pacientes
    WHERE id = @idPaciente;

    SET @rowsAffected = @@ROWCOUNT;
END
GO


ALTER     PROCEDURE [dbo].[usp_obtenExpedientePaciente]
    @idPaciente bigint
AS
BEGIN
    SET NOCOUNT ON;

    SELECT        
        cFechaCita AS fechaCita
		,cIdCita AS idCita
		,vIdVisita AS idVisita
		,vrIdPago AS idPago
		,vIdPaciente AS idPaciente
        ,cNombreCompletoPaciente AS Paciente
		,cNombreFisioterapeuta AS [Fisio Terapeuta]
		,
			CASE vPagado 
			WHEN 1 THEN 'Si'
				ELSE 'No'
			END 
			
			AS Pagado
		,pPrecio AS NombrePrecio
		,pCantidadPrecio AS [Cantidad Precio]
		,
			CASE 
				prPacientePaga 
				WHEN 1 THEN 'SI'
				ELSE 'NO'
		END		
		AS [Paciente Paga]
		,vrCantidadPago AS  [Cantidad Pagada]
		,mpMetodoPago AS [Metodo Pago]
		,vrIdMetodoPago AS idMetodoPago
		,pvrFechaPago AS [Fecha Pago]
    FROM vw_citasVisitasPagos
    WHERE cIdPaciente = @idPaciente
	ORDER BY cFechaRegistro DESC
END
GO


create or ALTER           PROCEDURE [dbo].[usp_updatePagoVisitaAdmin]
(
	@idPago BIGINT,
	@idUsuario BIGINT,
    @idMetodoPago BIGINT,
    @cantidadPago NUMERIC(18,0),
    @rowsAffected INT OUTPUT
  

)
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    BEGIN TRY
        BEGIN TRAN;
 
       UPDATE dbo.pagosVisitasRealizadas
		SET [idUsuario] = @idUsuario
			   ,[idMetodoPago] = @idMetodoPago			 
			   ,[cantidadPago] = @cantidadPago
		  WHERE id = @idPago;

        

		SET @rowsAffected= @@ROWCOUNT;

        COMMIT;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK;
        THROW;
    END CATCH
END
GO





CREATE OR ALTER   PROCEDURE [dbo].[usp_deletePagoVisitaAdmin]
(
   @idPago BIGINT,	
    @rowsAffected INT OUTPUT
)
AS
BEGIN
    SET NOCOUNT ON;

    SET @rowsAffected = 0;

    IF EXISTS (SELECT 1 FROM dbo.saldoPacienteVisitas WHERE idPagoVisitaRealizada = @idPago)
        RETURN;

	 

       DELETE FROM dbo.pagosVisitasRealizadas		
		  WHERE id = @idPago;

    SET @rowsAffected = @@ROWCOUNT;
END
GO



USE [FisioKH_katy]
GO

/****** Object:  StoredProcedure [dbo].[usp_obtenerVisitasRealizadas]    Script Date: 4/2/2026 5:09:56 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO










ALTER     PROCEDURE [dbo].[usp_obtenerVisitasRealizadas]
    @fechaInicio AS DATE,
	@fechaFin AS DATE,
	@idMetodopago AS BIGINT 
AS
BEGIN
    SET NOCOUNT ON;

    SELECT        
	vidvisita AS idVisita
		,cFechaCita AS fechaCita
        ,cNombreCompletoPaciente AS Paciente
		,cNombreFisioterapeuta AS [Fisio Terapeuta]
		,
			CASE vPagado 
			WHEN 1 THEN 'Si'
				ELSE 'No'
			END 
			
			AS Pagado
		,pPrecio AS NombrePrecio
		,pCantidadPrecio AS [Cantidad Precio]
		,
			CASE 
				prPacientePaga 
				WHEN 1 THEN 'SI'
				ELSE 'NO'
		END		
		AS [Paciente Paga]
		,vrCantidadPago AS  [Cantidad Pagada]
		,mpMetodoPago AS [Metodo Pago]
		,vrIdMetodoPago AS IdMeTodopago
		,pvrFechaPago AS [Fecha Pago]
		
		-- select * 
    FROM vw_citasVisitasPagos
    WHERE convert(date,pvrFechaPago) BETWEEN @fechaInicio AND @fechaFin
		AND (
            @idMetodopago = 0 
            OR vrIdMetodoPago = @idMetodopago
        )
	ORDER BY pvrFechaPago
END
GO


