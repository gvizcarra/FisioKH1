USE [FisioKH]
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION dbo.ufn_cantidadSaldoPaciente 
(
	@idPaciente AS  BIGINT
)
RETURNS INT
AS
BEGIN
	
	DECLARE @qty AS DECIMAL(10,2) = 0.0

	SELECT  
		@qty = SUM(saldo)
    FROM dbo.saldoPacienteVisitas
	WHERE id = @idPaciente AND activo = 1
	
	RETURN COALESCE(@qty,0.0)

END



USE [FisioKH]
GO

/****** Object: SqlProcedure [dbo].[usp_ObtenerPacientes] Script Date: 4/21/2026 9:50:10 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP PROCEDURE [dbo].[usp_ObtenerPacientes];


GO






CREATE PROCEDURE [dbo].[usp_ObtenerPacientes]
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
	  ,p.idPrecio AS idPrecio
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
	  ,p.notasMedicas
	  ,p.foto AS Foto
	  ,dbo.ufn_cantidadCitasPaciente(p.id) AS totalCitas
	  ,dbo.ufn_cantidadSaldoPaciente(p.id) AS totalSaldo
	  ,dbo.ufn_cantidadIngresosPaciente(p.id) AS totalIngresos
	  ,dbo.ufn_cantidadIngresosPagadosPaciente(p.id) AS totalIngresosPagados
       
	 FROM dbo.Pacientes AS p
			INNER JOIN dbo.usuarios AS u
				ON p.idUsuario = u.id
			INNER JOIN dbo.fisioTerapeutas AS f
				ON p.idFisioTerapeuta = f.id
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
