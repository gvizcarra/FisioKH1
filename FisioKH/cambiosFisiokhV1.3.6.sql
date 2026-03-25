CREATE OR ALTER PROCEDURE dbo.usp_GuardarSaldoPacienteVisita
(
    @saldo NUMERIC(18, 0),
    @idPaciente BIGINT,
    @idCita BIGINT,
    @idVisita BIGINT,
    @idPagoVisitaRealizada BIGINT,
    @idUsuario BIGINT,
    @rowsAffected INT OUTPUT
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
END
GO

USE [FisioKH]
GO

/****** Object:  Table [dbo].[saldoPacienteVisitas]    Script Date: 3/24/2026 9:59:11 PM ******/
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

ALTER TABLE [dbo].[saldoPacienteVisitas] ADD  DEFAULT ((1)) FOR [activo]
GO

ALTER TABLE [dbo].[saldoPacienteVisitas] ADD  CONSTRAINT [DF_saldoPacienteVisitas_fechaRegistro]  DEFAULT (getdate()) FOR [fechaRegistro]
GO

ALTER TABLE [dbo].[saldoPacienteVisitas]  WITH CHECK ADD  CONSTRAINT [FK_saldoPacienteVisitas_Citas] FOREIGN KEY([idCita])
REFERENCES [dbo].[Citas] ([id])
GO

ALTER TABLE [dbo].[saldoPacienteVisitas] CHECK CONSTRAINT [FK_saldoPacienteVisitas_Citas]
GO

ALTER TABLE [dbo].[saldoPacienteVisitas]  WITH CHECK ADD  CONSTRAINT [FK_saldoPacienteVisitas_pagosVisitasRealizadas] FOREIGN KEY([idPagoVisitaRealizada])
REFERENCES [dbo].[pagosVisitasRealizadas] ([id])
GO

ALTER TABLE [dbo].[saldoPacienteVisitas] CHECK CONSTRAINT [FK_saldoPacienteVisitas_pagosVisitasRealizadas]
GO

ALTER TABLE [dbo].[saldoPacienteVisitas]  WITH CHECK ADD  CONSTRAINT [FK_saldoPacienteVisitas_usuarios] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[usuarios] ([id])
GO

ALTER TABLE [dbo].[saldoPacienteVisitas] CHECK CONSTRAINT [FK_saldoPacienteVisitas_usuarios]
GO

ALTER TABLE [dbo].[saldoPacienteVisitas]  WITH CHECK ADD  CONSTRAINT [FK_saldoPacienteVisitas_visitasRealizadas] FOREIGN KEY([idVisita])
REFERENCES [dbo].[visitasRealizadas] ([id])
GO

ALTER TABLE [dbo].[saldoPacienteVisitas] CHECK CONSTRAINT [FK_saldoPacienteVisitas_visitasRealizadas]
GO

USE [FisioKH]
GO

USE [FisioKH]
GO

/****** Object:  Index [PK_saldoPacienteVisitas]    Script Date: 3/24/2026 10:00:22 PM ******/
ALTER TABLE [dbo].[saldoPacienteVisitas] ADD  CONSTRAINT [PK_saldoPacienteVisitas] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO



/****** Object:  Index [unique]    Script Date: 3/24/2026 10:00:10 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [unique] ON [dbo].[saldoPacienteVisitas]
(
	[idPaciente] ASC,
	[idCita] ASC,
	[idVisita] ASC,
	[idPagoVisitaRealizada] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO



