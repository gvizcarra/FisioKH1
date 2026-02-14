USE [FisioKH]
GO

/****** Object:  StoredProcedure [dbo].[usp_ObtenerPacientes]    Script Date: 2/9/2026 10:29:26 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO










ALTER PROCEDURE [dbo].[usp_ObtenerPacientes]
    @nombreCompleto NVARCHAR(100) = NULL,
	@celular AS VARCHAR(50) = NULL,
	@email AS VARCHAR(150) = NULL
AS
BEGIN
    SET NOCOUNT ON;
 

    DECLARE @sql NVARCHAR(4000);
    DECLARE @params NVARCHAR(4000);

    -- Base query
    SET @sql = N'
	SELECT p.[id] AS Id
	  , p.nombreCompleto AS Nombre
	  , CONCAT(p.nombreCompleto, '' '', p.apellidoPaterno, '' '', p.apellidoMaterno) AS NombreCompleto
	  ,p.[apellidoPaterno] AS apellidoPaterno
	  ,p.[apellidoMaterno] AS apellidoMaterno
	  ,p.[celular] AS Celular
      ,p.[ciudad] AS Ciudad
      ,p.[sexo] AS Sexo
      ,p.[edad] AS Edad
	  ,p.[medicoTratante] AS MedicoTratante
	  ,f.nombreCorto AS Fisio
	  ,p.[claveEtiqueta] AS Etiqueta
      ,p.[email] AS Email
      ,u.nombre AS Usuario
      ,p.[fechaRegistro] AS [FechaRegistro]
      ,p.[rfc] AS Rfc
      ,p.[domicilioFiscal] AS [DFiscal]
      ,p.[nombreFiscal] AS [NFiscal]
	  ,p.[fechaNacimiento] AS FechaNacimiento
	  ,p.observaciones
	  ,p.foto AS Foto
	  ,dbo.ufn_cantidadCitasPaciente(p.id) AS totalCitas
	  ,dbo.ufn_cantidadIngresosPaciente(p.id) AS totalIngresos
	  ,dbo.ufn_cantidadIngresosPagadosPaciente(p.id) AS totalIngresosPagados
       
	 FROM dbo.Pacientes AS p
			INNER JOIN dbo.usuarios AS u
				ON p.idUsuario = u.id
			INNER JOIN dbo.fisioTerapeutas AS f
				ON p.idUsuario = f.id
        WHERE 1 = 1 
    ';
  
  IF @nombreCompleto IS NOT NULL
BEGIN
    SET @sql += N' AND CONCAT(p.nombreCompleto, '' '', p.apellidoPaterno, '' '', p.apellidoMaterno) LIKE ''%'' + @nombreCompleto + ''%'' '
END


	IF @celular IS NOT NULL
	BEGIN
		SET @sql += N' AND p.celular LIKE ''%'' + @celular + ''%'''
	END

	IF @email IS NOT NULL
	BEGIN
	 	SET @sql += N' AND p.email LIKE ''%'' + @email + ''%'''
	END

    SET @params = N'@nombreCompleto NVARCHAR(100),
					@celular AS VARCHAR(50) ,
					@email AS VARCHAR(150)';
					 
 
    EXEC sp_executesql
        @sql,
        @params,
        @nombreCompleto = @nombreCompleto,
		@celular = @celular,
		@email = @email;

		 print @sql
END
GO




USE [FisioKH]
GO

/****** Object:  StoredProcedure [dbo].[usp_UpdatePaciente]    Script Date: 2/9/2026 10:36:24 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




ALTER   PROCEDURE [dbo].[usp_UpdatePaciente]
(
    @id                 BIGINT,
    @nombreCompleto     NVARCHAR(100) = NULL,
	@apellidoPaterno     NVARCHAR(100),
	@apellidoMaterno     NVARCHAR(100),
    @celular            NVARCHAR(15)   = NULL,
    @ciudad             NVARCHAR(100)  = NULL,
    @sexo               NVARCHAR(10)   = NULL,
	@fechaNacimiento    DATE           = NULL,
	@edad               NVARCHAR(2)   = NULL,
    @email              NVARCHAR(100)  = NULL,
	@idUsuario			BIGINT,
    @rfc                NVARCHAR(100)  = NULL,
    @domicilioFiscal    NVARCHAR(150)  = NULL,
    @nombreFiscal       NVARCHAR(150)  = NULL,
    @medicoTratante     NVARCHAR(250)  = NULL,
    @idFisioTerapeuta   BIGINT          = NULL,
    @claveEtiqueta      NVARCHAR(10)   = NULL,
    @observaciones      NVARCHAR(4000) = NULL,
    @foto               VARBINARY(MAX) = NULL,
    @rowsAffected       INT OUTPUT 
)
AS
BEGIN
    SET NOCOUNT ON;

    /*DECLARE @EdadCalculada SMALLINT = NULL;

    IF @fechaNacimiento IS NOT NULL
    BEGIN
        SET @EdadCalculada =
            DATEDIFF(YEAR, @fechaNacimiento, CAST(GETDATE() AS DATE))
            - CASE
                WHEN DATEADD(YEAR,
                             DATEDIFF(YEAR, @fechaNacimiento, CAST(GETDATE() AS DATE)),
                             @fechaNacimiento) > CAST(GETDATE() AS DATE)
                THEN 1
                ELSE 0
              END;
	 
    END; */

    BEGIN TRY
        UPDATE dbo.Pacientes
        SET
            nombreCompleto   = COALESCE(@nombreCompleto, nombreCompleto),
			apellidoPaterno   = COALESCE(@apellidoPaterno, apellidoPaterno),
			apellidoMaterno   = COALESCE(@apellidoMaterno, apellidoMaterno),
            celular          = COALESCE(@celular, celular),
            ciudad           = COALESCE(@ciudad, ciudad),
            sexo             = COALESCE(@sexo, sexo),
            fechaNacimiento  = COALESCE(@fechaNacimiento, fechaNacimiento),
            edad             = COALESCE(@edad, edad),
            email            = COALESCE(@email, email),
            idUsuario        = COALESCE(@idUsuario, idUsuario),
			rfc              = COALESCE(@rfc, rfc),
            domicilioFiscal  = COALESCE(@domicilioFiscal, domicilioFiscal),
            nombreFiscal     = COALESCE(@nombreFiscal, nombreFiscal),
            medicoTratante   = COALESCE(@medicoTratante, medicoTratante),
            idFisioTerapeuta = COALESCE(@idFisioTerapeuta, idFisioTerapeuta),
            claveEtiqueta    = COALESCE(@claveEtiqueta, claveEtiqueta),
            observaciones    = COALESCE(@observaciones, observaciones),
            foto             = COALESCE(@foto, foto)
        WHERE id = @id;

        SET @rowsAffected = @@ROWCOUNT;

        IF @rowsAffected = 0
		SET @rowsAffected = 0;
    END TRY
    BEGIN CATCH
        SET @rowsAffected = 0;
        THROW;
    END CATCH
END;
GO




USE [FisioKH]
GO

/****** Object:  StoredProcedure [dbo].[usp_InsertPaciente]    Script Date: 2/9/2026 10:41:44 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




ALTER   PROCEDURE [dbo].[usp_InsertPaciente]
(
    @nombreCompleto     NVARCHAR(100),
	@apellidoPaterno     NVARCHAR(100),
	@apellidoMaterno     NVARCHAR(100),
    @celular            NVARCHAR(15),
    @ciudad             NVARCHAR(100)  = NULL,
    @sexo               NVARCHAR(10)   = NULL,
    @email              NVARCHAR(100)  = NULL,
    @idUsuario          BIGINT,
    @rfc                NVARCHAR(100)  = NULL,
    @domicilioFiscal    NVARCHAR(150)  = NULL,
    @nombreFiscal       NVARCHAR(150)  = NULL,
    @fechaNacimiento    DATE           = NULL,
	@edad               NVARCHAR(2)   = NULL,
    @medicoTratante     NVARCHAR(250)  = NULL,
    @idFisioTerapeuta   BIGINT          = NULL,
    @claveEtiqueta      NVARCHAR(10)   = NULL,
    @observaciones      NVARCHAR(4000) = NULL,
    @foto               VARBINARY(MAX) = NULL,
    @rowsAffected       INT OUTPUT 
)
AS
BEGIN
    SET NOCOUNT ON;
	/*DECLARE @edad SMALLINT;
 

SET @edad =
    DATEDIFF(YEAR, @fechaNacimiento, CAST(GETDATE() AS DATE))
    - CASE
        WHEN DATEADD(YEAR,
                     DATEDIFF(YEAR, @fechaNacimiento, CAST(GETDATE() AS DATE)),
                     @fechaNacimiento) > CAST(GETDATE() AS DATE)
        THEN 1
        ELSE 0
      END; */


    BEGIN TRY
        INSERT INTO dbo.Pacientes
        (
            nombreCompleto,
			apellidoPaterno,
			apellidoMaterno,
            celular,
            ciudad,
            sexo,
            edad,
            email,
            idUsuario,
            fechaRegistro,
            rfc,
            domicilioFiscal,
            nombreFiscal,
            fechaNacimiento,
            medicoTratante,
            idFisioTerapeuta,
            claveEtiqueta,
            observaciones,
            foto
        )
        VALUES
        (
            @nombreCompleto,
			@apellidoPaterno,
			@apellidoMaterno,
            @celular,
            @ciudad,
            @sexo,
            @edad,
            @email,
            @idUsuario,
            GETDATE(),
            @rfc,
            @domicilioFiscal,
            @nombreFiscal,
            @fechaNacimiento,
            @medicoTratante,
            @idFisioTerapeuta,
            @claveEtiqueta,
            @observaciones,
            @foto
        );

        SET @rowsAffected = @@ROWCOUNT;
       -- SET @NewId = SCOPE_IDENTITY();
    END TRY
    BEGIN CATCH
        SET @rowsAffected = 0;
        THROW;
    END CATCH
END;
GO



/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Pacientes
	DROP CONSTRAINT FK_Pacientes_usuarios
GO
ALTER TABLE dbo.usuarios SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Pacientes
	DROP CONSTRAINT FK_Pacientes_fisioTerapeutas
GO
ALTER TABLE dbo.fisioTerapeutas SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Pacientes
	DROP CONSTRAINT DF_Pacientes_fechaRegistro
GO
CREATE TABLE dbo.Tmp_Pacientes
	(
	id bigint NOT NULL IDENTITY (1, 1),
	nombreCompleto nvarchar(100) NOT NULL,
	celular nvarchar(15) NOT NULL,
	ciudad nvarchar(100) NULL,
	sexo nvarchar(10) NULL,
	edad nvarchar(50) NOT NULL,
	email nvarchar(100) NULL,
	idUsuario bigint NOT NULL,
	fechaRegistro datetime NOT NULL,
	rfc nvarchar(100) NULL,
	domicilioFiscal nvarchar(150) NULL,
	nombreFiscal nvarchar(150) NULL,
	fechaNacimiento date NULL,
	medicoTratante nvarchar(250) NULL,
	idFisioTerapeuta bigint NOT NULL,
	claveEtiqueta nvarchar(10) NULL,
	observaciones nvarchar(4000) NULL,
	foto varbinary(MAX) NULL,
	apellidoPaterno varchar(100) NULL,
	apellidoMaterno varchar(100) NULL
	)  ON [PRIMARY]
	 TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_Pacientes SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE dbo.Tmp_Pacientes ADD CONSTRAINT
	DF_Pacientes_fechaRegistro DEFAULT (getdate()) FOR fechaRegistro
GO
SET IDENTITY_INSERT dbo.Tmp_Pacientes ON
GO
IF EXISTS(SELECT * FROM dbo.Pacientes)
	 EXEC('INSERT INTO dbo.Tmp_Pacientes (id, nombreCompleto, celular, ciudad, sexo, edad, email, idUsuario, fechaRegistro, rfc, domicilioFiscal, nombreFiscal, fechaNacimiento, medicoTratante, idFisioTerapeuta, claveEtiqueta, observaciones, foto, apellidoPaterno, apellidoMaterno)
		SELECT id, nombreCompleto, celular, ciudad, sexo, CONVERT(nvarchar(50), edad), email, idUsuario, fechaRegistro, rfc, domicilioFiscal, nombreFiscal, fechaNacimiento, medicoTratante, idFisioTerapeuta, claveEtiqueta, observaciones, foto, apellidoPaterno, apellidoMaterno FROM dbo.Pacientes WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_Pacientes OFF
GO
ALTER TABLE dbo.visitasRealizadas
	DROP CONSTRAINT FK_visitasRealizadas_Pacientes
GO
ALTER TABLE dbo.polizaPaciente
	DROP CONSTRAINT FK_polizaPaciente_Pacientes
GO
DROP TABLE dbo.Pacientes
GO
EXECUTE sp_rename N'dbo.Tmp_Pacientes', N'Pacientes', 'OBJECT' 
GO
ALTER TABLE dbo.Pacientes ADD CONSTRAINT
	PK_Pacientes PRIMARY KEY CLUSTERED 
	(
	id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Pacientes ADD CONSTRAINT
	FK_Pacientes_fisioTerapeutas FOREIGN KEY
	(
	idFisioTerapeuta
	) REFERENCES dbo.fisioTerapeutas
	(
	id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Pacientes ADD CONSTRAINT
	FK_Pacientes_usuarios FOREIGN KEY
	(
	idUsuario
	) REFERENCES dbo.usuarios
	(
	id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.polizaPaciente ADD CONSTRAINT
	FK_polizaPaciente_Pacientes FOREIGN KEY
	(
	idPaciente
	) REFERENCES dbo.Pacientes
	(
	id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.polizaPaciente SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.visitasRealizadas WITH NOCHECK ADD CONSTRAINT
	FK_visitasRealizadas_Pacientes FOREIGN KEY
	(
	idPaciente
	) REFERENCES dbo.Pacientes
	(
	id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	 NOT FOR REPLICATION

GO
ALTER TABLE dbo.visitasRealizadas SET (LOCK_ESCALATION = TABLE)
GO
COMMIT



USE [FisioKH]
GO

/****** Object:  StoredProcedure [dbo].[usp_obtenCitasPorGoogleEventIds]    Script Date: 2/9/2026 11:32:06 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



ALTER   PROCEDURE [dbo].[usp_obtenCitasPorGoogleEventIds]
    @eventIds dbo.GoogleEventIdList READONLY
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        c.id AS idCita,
        c.idPaciente AS cidPaciente,
        c.fechaCita AS cfechaCita,
        c.fechaRegistro,
        c.realizada  AS cRealizada,
        c.idUsuario AS cidUsuarioCita,
        c.idTipoTratamiento AS cidTipoTratamiento,
        c.idGoogleCalendar AS cidGoogleCalendar,     
        c.idFisioTerapeuta AS cidFisioterapeuta,
        ft.nombre AS nombreFisioterapeuta,
 

        CONCAT(
            p.nombreCompleto, ' ',
            COALESCE(p.apellidoPaterno, ''), ' ',
            COALESCE(p.apellidoMaterno, '')
        ) AS nombreCompletoPaciente,
        tt.nombre AS nombreTratamiento,
		vr.id AS vidVisita,
		vr.idPaciente AS vidPAciente,
		vr.fechaVisita AS vfechaVisita,
		vr.idUsuario AS vidUsuario,
		vr.idTipoTratamiento AS vidTipoTratamiento,
		vr.idPrecio AS vidPrecio,
		vr.pagado AS vpagado,
		vr.ocupaFactura AS vocupaFactura,
		vr.notas AS vnotas,
		pvr.id AS pidPago,
		pvr.idUsuario AS pidUsuario,
		pvr.idMetodoPago AS pidMetodoPago,
		pvr.cantidadPago pcantidadPago,
		pvr.referenciaPago AS preferenciaPago

    FROM Citas c
		INNER JOIN fisioTerapeutas AS ft ON c.idFisioTerapeuta = ft.id
		INNER JOIN Pacientes AS p ON c.idPaciente = p.id
		INNER JOIN tipoTratamiento AS tt ON c.idTipoTratamiento = tt.id
		LEFT JOIN visitasRealizadas AS vr ON c.id = vr.idCita
		LEFT JOIN  pagosVisitasRealizadas AS pvr ON vr.id = pvr.idVisita
    WHERE c.idGoogleCalendar IN (SELECT EventId FROM @eventIds);
END
GO


USE [FisioKH]
GO

/****** Object:  StoredProcedure [dbo].[usp_obtenCitasPorGoogleEventIds]    Script Date: 2/12/2026 7:20:08 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


ALTER   PROCEDURE [dbo].[usp_obtenCitasPorGoogleEventIds]
    @eventIds dbo.GoogleEventIdList READONLY
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        
        c.id AS cIdCita,
        c.idPaciente AS cIdPaciente,
        c.fechaCita AS cFechaCita,
        c.fechaRegistro AS cFechaRegistro,
        c.realizada AS cRealizada,
        COALESCE(c.idUsuario,0) AS cidUsuarioCita,
        COALESCE(c.idTipoTratamiento,0) AS cIdTipoTratamiento,
        c.idGoogleCalendar AS idGoogleCalendar,     
        COALESCE(c.idFisioTerapeuta,0) AS cIdFisioterapeuta,
        ft.nombre AS cNombreFisioterapeuta,
        p.claveEtiqueta AS cClaveEtiqueta,
        ft.nombre AS cNombreFisioterapeuta,
        CONCAT(
            p.nombreCompleto, ' ',
            COALESCE(p.apellidoPaterno, ''), ' ',
            COALESCE(p.apellidoMaterno, '')
        ) AS cNombreCompletoPaciente,

        COALESCE(tt.nombre,'') AS cNombreTratamiento,
		COALESCE(vr.id,0) AS vIdVisita,
		COALESCE(vr.idPaciente,0) AS vIdPaciente,
		COALESCE(vr.fechaVisita,'') AS vFechaVisita,
		COALESCE(vr.idUsuario,0) AS vIdUsuario,
		COALESCE(vr.idTipoTratamiento,0) AS vIdTipoTratamiento,
		COALESCE(vr.idPrecio,0) AS vIdPrecio,
		COALESCE(vr.pagado,0) AS vPagado,
		COALESCE(vr.ocupaFactura,0) AS vOcupaFactura,
		COALESCE(vr.notas,'') AS vNotas,
		COALESCE(pvr.id,0) AS vrIdPago,
		COALESCE(pvr.idUsuario,0) AS vrIdUsuario,
		COALESCE(pvr.idMetodoPago,0) AS vrIdMetodoPago,
		COALESCE(pvr.cantidadPago,0) vrCantidadPago,
		COALESCE(pvr.referenciaPago,0) AS vrReferenciaPago

    FROM Citas c
    INNER JOIN fisioTerapeutas ft ON c.idFisioTerapeuta = ft.id
    INNER JOIN Pacientes p ON c.idPaciente = p.id
    INNER JOIN tipoTratamiento tt ON c.idTipoTratamiento = tt.id
	LEFT JOIN visitasRealizadas AS vr ON c.id = vr.idCita
	LEFT JOIN  pagosVisitasRealizadas AS pvr ON vr.id = pvr.idVisita
    WHERE c.idGoogleCalendar IN (SELECT EventId FROM @eventIds);
END
GO


create view vw_citasVisitasPagos
AS

    SELECT
        
        c.id AS cIdCita,
        c.idPaciente AS cIdPaciente,
        c.fechaCita AS cFechaCita,
        c.fechaRegistro AS cFechaRegistro,
        c.realizada AS cRealizada,
        c.idUsuario AS cidUsuarioCita,
        c.idTipoTratamiento AS cIdTipoTratamiento,
        c.idGoogleCalendar AS idGoogleCalendar,     
        c.idFisioTerapeuta AS cIdFisioterapeuta,
        p.claveEtiqueta AS cClaveEtiqueta,
        ft.nombre AS cNombreFisioterapeuta,
        CONCAT(
            p.nombreCompleto, ' ',
            COALESCE(p.apellidoPaterno, ''), ' ',
            COALESCE(p.apellidoMaterno, '')
        ) AS cNombreCompletoPaciente,

        COALESCE(tt.nombre,'') AS cNombreTratamiento,
		COALESCE(vr.id,0) AS vIdVisita,
		COALESCE(vr.idPaciente,0) AS vIdPaciente,
		COALESCE(vr.fechaVisita,'') AS vFechaVisita,
		COALESCE(vr.idUsuario,0) AS vIdUsuario,
		COALESCE(vr.idTipoTratamiento,0) AS vIdTipoTratamiento,
		COALESCE(vr.idPrecio,0) AS vIdPrecio,
		COALESCE(vr.pagado,0) AS vPagado,
		COALESCE(vr.ocupaFactura,0) AS vOcupaFactura,
		COALESCE(vr.notas,'') AS vNotas,
		COALESCE(pvr.id,0) AS vrIdPago,
		COALESCE(pvr.idUsuario,0) AS vrIdUsuario,
		COALESCE(pvr.idMetodoPago,0) AS vrIdMetodoPago,
		COALESCE(pvr.cantidadPago,0) vrCantidadPago,
		COALESCE(pvr.referenciaPago,0) AS vrReferenciaPago

    FROM Citas c
    INNER JOIN fisioTerapeutas ft ON c.idFisioTerapeuta = ft.id
    INNER JOIN Pacientes p ON c.idPaciente = p.id
    INNER JOIN tipoTratamiento tt ON c.idTipoTratamiento = tt.id
	LEFT JOIN visitasRealizadas AS vr ON c.id = vr.idCita
	LEFT JOIN  pagosVisitasRealizadas AS pvr ON vr.id = pvr.idVisita

GO


USE [FisioKH]
GO

/****** Object:  StoredProcedure [dbo].[usp_obtenCitasPorGoogleEventIds]    Script Date: 2/12/2026 7:20:08 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


ALTER   PROCEDURE [dbo].[usp_obtenCitasPorGoogleEventIds]
    @eventIds dbo.GoogleEventIdList READONLY
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        
        *

    FROM vw_citasVisitasPagos
    WHERE idGoogleCalendar IN (SELECT EventId FROM @eventIds);
END
GO



USE [FisioKH]
GO

/****** Object:  StoredProcedure [dbo].[usp_ObtenerPacientes]    Script Date: 2/13/2026 6:12:10 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO











ALTER PROCEDURE [dbo].[usp_ObtenerPacientes]
    @nombreCompleto NVARCHAR(100) = NULL,
	@celular AS VARCHAR(50) = NULL,
	@email AS VARCHAR(150) = NULL
AS
BEGIN
    SET NOCOUNT ON;
 

    DECLARE @sql NVARCHAR(4000);
    DECLARE @params NVARCHAR(4000);

    -- Base query
    SET @sql = N'
	SELECT p.[id] AS Id
	  , p.nombreCompleto AS Nombre
	  , CONCAT(p.nombreCompleto, '' '', p.apellidoPaterno, '' '', p.apellidoMaterno) AS NombreCompleto
	  ,p.[apellidoPaterno] AS apellidoPaterno
	  ,p.[apellidoMaterno] AS apellidoMaterno
	  ,p.[celular] AS Celular
      ,p.[ciudad] AS Ciudad
      ,p.[sexo] AS Sexo
      ,p.[edad] AS Edad
	  ,p.[medicoTratante] AS MedicoTratante
	  ,p.idFisioTerapeuta AS  idFisioTerapeuta
	  ,f.nombreCorto AS Fisio
	  ,p.[claveEtiqueta] AS Etiqueta
      ,p.[email] AS Email
      ,u.nombre AS Usuario
      ,p.[fechaRegistro] AS [FechaRegistro]
      ,p.[rfc] AS Rfc
      ,p.[domicilioFiscal] AS [DFiscal]
      ,p.[nombreFiscal] AS [NFiscal]
	  ,p.[fechaNacimiento] AS FechaNacimiento
	  ,p.observaciones
	  ,p.foto AS Foto
	  ,dbo.ufn_cantidadCitasPaciente(p.id) AS totalCitas
	  ,dbo.ufn_cantidadIngresosPaciente(p.id) AS totalIngresos
	  ,dbo.ufn_cantidadIngresosPagadosPaciente(p.id) AS totalIngresosPagados
       
	 FROM dbo.Pacientes AS p
			INNER JOIN dbo.usuarios AS u
				ON p.idUsuario = u.id
			INNER JOIN dbo.fisioTerapeutas AS f
				ON p.idUsuario = f.id
        WHERE 1 = 1 
    ';
  
  IF @nombreCompleto IS NOT NULL
BEGIN
    SET @sql += N' AND CONCAT(p.nombreCompleto, '' '', p.apellidoPaterno, '' '', p.apellidoMaterno) LIKE ''%'' + @nombreCompleto + ''%'' '
END


	IF @celular IS NOT NULL
	BEGIN
		SET @sql += N' AND p.celular LIKE ''%'' + @celular + ''%'''
	END

	IF @email IS NOT NULL
	BEGIN
	 	SET @sql += N' AND p.email LIKE ''%'' + @email + ''%'''
	END

    SET @params = N'@nombreCompleto NVARCHAR(100),
					@celular AS VARCHAR(50) ,
					@email AS VARCHAR(150)';
					 
 
    EXEC sp_executesql
        @sql,
        @params,
        @nombreCompleto = @nombreCompleto,
		@celular = @celular,
		@email = @email;

		 print @sql
END
GO


/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.precios SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Pacientes
	DROP CONSTRAINT FK_Pacientes_usuarios
GO
ALTER TABLE dbo.usuarios SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Pacientes
	DROP CONSTRAINT FK_Pacientes_fisioTerapeutas
GO
ALTER TABLE dbo.fisioTerapeutas SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Pacientes
	DROP CONSTRAINT DF_Pacientes_fechaRegistro
GO
CREATE TABLE dbo.Tmp_Pacientes
	(
	id bigint NOT NULL IDENTITY (1, 1),
	nombreCompleto nvarchar(100) NOT NULL,
	celular nvarchar(15) NOT NULL,
	ciudad nvarchar(100) NULL,
	sexo nvarchar(10) NULL,
	edad nvarchar(50) NOT NULL,
	email nvarchar(100) NULL,
	idUsuario bigint NOT NULL,
	fechaRegistro datetime NOT NULL,
	rfc nvarchar(100) NULL,
	domicilioFiscal nvarchar(150) NULL,
	nombreFiscal nvarchar(150) NULL,
	fechaNacimiento date NULL,
	medicoTratante nvarchar(250) NULL,
	idFisioTerapeuta bigint NOT NULL,
	claveEtiqueta nvarchar(10) NULL,
	observaciones nvarchar(4000) NULL,
	foto varbinary(MAX) NULL,
	apellidoPaterno varchar(100) NULL,
	apellidoMaterno varchar(100) NULL,
	idPrecio bigint NOT NULL
	)  ON [PRIMARY]
	 TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_Pacientes SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE dbo.Tmp_Pacientes ADD CONSTRAINT
	DF_Pacientes_fechaRegistro DEFAULT (getdate()) FOR fechaRegistro
GO
SET IDENTITY_INSERT dbo.Tmp_Pacientes ON
GO
IF EXISTS(SELECT * FROM dbo.Pacientes)
	 EXEC('INSERT INTO dbo.Tmp_Pacientes (id, nombreCompleto, celular, ciudad, sexo, edad, email, idUsuario, fechaRegistro, rfc, domicilioFiscal, nombreFiscal, fechaNacimiento, medicoTratante, idFisioTerapeuta, claveEtiqueta, observaciones, foto, apellidoPaterno, apellidoMaterno)
		SELECT id, nombreCompleto, celular, ciudad, sexo, edad, email, idUsuario, fechaRegistro, rfc, domicilioFiscal, nombreFiscal, fechaNacimiento, medicoTratante, idFisioTerapeuta, claveEtiqueta, observaciones, foto, apellidoPaterno, apellidoMaterno FROM dbo.Pacientes WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_Pacientes OFF
GO
ALTER TABLE dbo.polizaPaciente
	DROP CONSTRAINT FK_polizaPaciente_Pacientes
GO
ALTER TABLE dbo.visitasRealizadas
	DROP CONSTRAINT FK_visitasRealizadas_Pacientes
GO
DROP TABLE dbo.Pacientes
GO
EXECUTE sp_rename N'dbo.Tmp_Pacientes', N'Pacientes', 'OBJECT' 
GO
ALTER TABLE dbo.Pacientes ADD CONSTRAINT
	PK_Pacientes PRIMARY KEY CLUSTERED 
	(
	id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Pacientes ADD CONSTRAINT
	FK_Pacientes_fisioTerapeutas FOREIGN KEY
	(
	idFisioTerapeuta
	) REFERENCES dbo.fisioTerapeutas
	(
	id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Pacientes ADD CONSTRAINT
	FK_Pacientes_usuarios FOREIGN KEY
	(
	idUsuario
	) REFERENCES dbo.usuarios
	(
	id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Pacientes ADD CONSTRAINT
	FK_Pacientes_precios FOREIGN KEY
	(
	idPrecio
	) REFERENCES dbo.precios
	(
	id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.visitasRealizadas WITH NOCHECK ADD CONSTRAINT
	FK_visitasRealizadas_Pacientes FOREIGN KEY
	(
	idPaciente
	) REFERENCES dbo.Pacientes
	(
	id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	 NOT FOR REPLICATION

GO
ALTER TABLE dbo.visitasRealizadas SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.polizaPaciente ADD CONSTRAINT
	FK_polizaPaciente_Pacientes FOREIGN KEY
	(
	idPaciente
	) REFERENCES dbo.Pacientes
	(
	id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.polizaPaciente SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
