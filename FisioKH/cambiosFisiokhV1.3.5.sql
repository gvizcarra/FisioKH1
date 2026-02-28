USE [FisioKH]
GO

/****** Object:  StoredProcedure [dbo].[usp_InsertPrecios]    Script Date: 27/02/2026 05:18:59 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




ALTER PROCEDURE [dbo].[usp_InsertPrecios]
    @nombre NVARCHAR(100),
	@precio numeric(18,0),
	@activo bit,
	@pacientePaga bit,
	@citaCancelableMismoDia bit,
    @idUsuario BIGINT,
    @rowsAffected INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO dbo.precios 
		(
			nombre ,
			idUsuario,
			precio,
			pacientePaga,
			citaCancelableMismoDia,
			activo 
		)
   VALUES
        (  
			@nombre,
			@idUsuario,
			@precio,
			COALESCE(@pacientePaga,0),
			COALESCE(@citaCancelableMismoDia,0),
			COALESCE(@activo,0)
		);

SET @rowsAffected= @@ROWCOUNT;
END;
GO





USE [FisioKH]
GO

 
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[saldoPacienteVisitas](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[saldo] [numeric](18, 0) NOT NULL,
	[activo] [bit] NOT NULL,
	[idPaciente] [bigint] NOT NULL,
	[idCita] [bigint] NOT NULL,
	[idVisita] [bigint] NOT NULL,
	[idPagoVisitaRealizada] [bigint] NOT NULL,
	[idUsuario] [bigint] NOT NULL,
	[fechaRegistro] [datetime] NOT NULL,
 CONSTRAINT [PK_saldoPacienteVisitas] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[saldoPacienteVisitas] ADD  CONSTRAINT [DF_saldoPacienteVisitas_fechaRegistro]  DEFAULT (getdate()) FOR [fechaRegistro]
GO

ALTER TABLE [dbo].[saldoPacienteVisitas] ADD  DEFAULT ((1)) FOR [activo]
GO

ALTER TABLE [dbo].[saldoPacienteVisitas]  WITH CHECK ADD  CONSTRAINT [FK_saldoPacienteVisitas_usuarios] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[usuarios] ([id])
GO

ALTER TABLE [dbo].[saldoPacienteVisitas] CHECK CONSTRAINT [FK_saldoPacienteVisitas_usuarios]
GO




USE [FisioKH]
GO

 
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

 

CREATE OR ALTER PROCEDURE [dbo].[usp_obtenSaldoPaciente]
    @idPaciente BIGINT
AS
BEGIN
    SET NOCOUNT ON;

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
		AND sp.activo =1
		AND sp.saldo > 0
END;
GO



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
ALTER TABLE dbo.pagosVisitasRealizadas SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.visitasRealizadas SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Citas SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.saldoPacienteVisitas ADD CONSTRAINT
	FK_saldoPacienteVisitas_Citas FOREIGN KEY
	(
	idCita
	) REFERENCES dbo.Citas
	(
	id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.saldoPacienteVisitas ADD CONSTRAINT
	FK_saldoPacienteVisitas_visitasRealizadas FOREIGN KEY
	(
	idVisita
	) REFERENCES dbo.visitasRealizadas
	(
	id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.saldoPacienteVisitas ADD CONSTRAINT
	FK_saldoPacienteVisitas_pagosVisitasRealizadas FOREIGN KEY
	(
	idPagoVisitaRealizada
	) REFERENCES dbo.pagosVisitasRealizadas
	(
	id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.saldoPacienteVisitas SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


USE [FisioKH]
GO

 
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

 

CREATE OR ALTER PROCEDURE [dbo].[usp_obtenSaldos]    
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
      sp.[id] 
	,sp.[saldo] 
	,sp.[activo]
	,sp.[idPaciente] 
	,sp.[idCita] 
	,sp.[idVisita]
	,sp.[idPagoVisitaRealizada] 
	,u.nombre AS usuario
	,p.nombreCompleto nombrePaciente
	,c.fechaCita
	,v.fechaVisita
	,sp.[fechaRegistro] AS fechaSaldoPaciente
	,pvr.fechaRegistro AS fechaPagoVisita

    FROM dbo.[saldoPacienteVisitas] AS sp    

    INNER JOIN Pacientes AS p
        ON sp.idPaciente = p.id

    INNER JOIN dbo.usuarios AS u
        ON sp.idUsuario = u .id

	INNER JOIN dbo.citas AS c
        ON c.id = sp.idCita

	INNER JOIN dbo.visitasRealizadas AS v
        ON v.id = sp.idVisita
	
	INNER JOIN dbo.pagosVisitasRealizadas AS pvr
        ON pvr.id = sp.[idPagoVisitaRealizada]



END;
GO



USE [FisioKH]
GO

/****** Object:  StoredProcedure [dbo].[usp_obtenerVisitasRealizadas]    Script Date: 27/02/2026 05:55:00 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





ALTER   PROCEDURE [dbo].[usp_obtenerVisitasRealizadas]
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


