USE [FisioKH]
GO

/****** Object:  UserDefinedFunction [dbo].[ufn_cantidadIngresosPagadosPaciente]    Script Date: 2/4/2026 9:55:47 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[ufn_cantidadIngresosPagadosPaciente] 
(
	@idPaciente AS  BIGINT
)
RETURNS INT
AS
BEGIN
	
	DECLARE @qty AS INT

	SELECT  
		@qty = COUNT(id)
    FROM dbo.visitasRealizadas
	WHERE idPaciente = @idPaciente AND pagado = 1
	
	RETURN COALESCE(@qty,0)

END
GO



USE [FisioKH]
GO

/****** Object:  UserDefinedFunction [dbo].[ufn_cantidadIngresosPaciente]    Script Date: 2/4/2026 9:55:37 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[ufn_cantidadIngresosPaciente] 
(
	@idPaciente AS  BIGINT
)
RETURNS INT
AS
BEGIN
	
	DECLARE @qty AS INT

	SELECT  
		@qty = COUNT(id)
    FROM dbo.visitasRealizadas
	WHERE idPaciente = @idPaciente
	
	RETURN COALESCE(@qty,0)

END
GO



USE [FisioKH]
GO

/****** Object:  UserDefinedFunction [dbo].[ufn_cantidadCitasPaciente]    Script Date: 2/4/2026 9:55:20 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[ufn_cantidadCitasPaciente] 
(
	@idPaciente AS  BIGINT
)
RETURNS INT
AS
BEGIN
	
	DECLARE @qty AS INT

	SELECT  
		@qty = COUNT(id)
    FROM dbo.citas
	WHERE idPaciente = @idPaciente
	
	RETURN COALESCE(@qty,0)

END
GO



USE [FisioKH]
GO

/****** Object:  StoredProcedure [dbo].[usp_ObtenerPacientes]    Script Date: 2/4/2026 9:05:28 PM ******/
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
	  ,p.[nombreCompleto] AS Nombre
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
        SET @sql += N' AND p.nombreCompleto LIKE ''%'' + @nombreCompleto + ''%'''
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


