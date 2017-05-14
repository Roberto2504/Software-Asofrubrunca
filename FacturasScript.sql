
En este script lo unico que quito es el signo de colon, ya en la factura si lo muestro de forma visual.

USE [SIGEEA_BD]
GO
/****** Object:  StoredProcedure [dbo].[SIGEEA_spObtenerDetallesFacturaCompletaAsoc]    Script Date: 13/5/2017 11:55:45 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Luis Barrantes Mora
-- Create date: 06/05/2016
-- Description:	Obtiene la factura de entrega completa
-- =============================================
ALTER PROCEDURE [dbo].[SIGEEA_spObtenerDetallesFacturaCompletaAsoc]
	@Factura int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT F.PK_Id_FacAsociado, 
		CONCAT(DF.CanTotal_DetFacAsociado, UM.Nombre_UniMedida) AS CantidadTotalString, 
		CONCAT(DF.CanNeta_DetFacAsociado, UM.Nombre_UniMedida) AS CantidadNetaString,
		CONVERT(VARCHAR, DF.CanTotal_DetFacAsociado - DF.CanNeta_DetFacAsociado) + UM.Nombre_UniMedida + ' (' +
		CONVERT(VARCHAR,CONVERT(DECIMAL(10,2), 100-((100*DF.CanNeta_DetFacAsociado)/DF.CanTotal_DetFacAsociado))) + '%)' AS MERMA,
		   TP.PK_Id_TipProducto, DF.PK_Id_DetFacAsociado, 
		   (CASE DF.Mercado_DetFacAsociado
				 WHEN 1 THEN 'Nacional'
				 WHEN 2 THEN 'Extranjero'
		    END) AS Mercado, 
			tp.Nombre_TipProducto, 
			DF.CanNeta_DetFacAsociado, 
			DF.CanTotal_DetFacAsociado,
			(CASE DF.Mercado_DetFacAsociado
			WHEN 1 THEN PC.PreNacional_PreProCompra	
			WHEN 2 THEN PC.PreExtranjero_PreProCompra
			END) AS Precio,
			DF.CanNeta_DetFacAsociado * (CASE DF.Mercado_DetFacAsociado
			WHEN 1 THEN PC.PreNacional_PreProCompra	
			WHEN 2 THEN PC.PreExtranjero_PreProCompra
			END) AS Neto,
			DF.CanTotal_DetFacAsociado * (CASE DF.Mercado_DetFacAsociado
			WHEN 1 THEN PC.PreNacional_PreProCompra	
			WHEN 2 THEN PC.PreExtranjero_PreProCompra
			END) AS Total

	FROM SIGEEA_DetFacAsociado DF
	JOIN SIGEEA_PreProCompra PC
	ON PC.PK_Id_PreProCompra = DF.FK_Id_PreProCompra
	JOIN SIGEEA_TipProducto TP
	ON TP.PK_Id_TipProducto = PC.FK_Id_TipProducto
	JOIN SIGEEA_DetInvProductos DIP
	ON DIP.FK_Id_TipProducto = TP.PK_Id_TipProducto
	JOIN SIGEEA_UniMedida UM
	ON UM.PK_Id_UniMedida = DIP.FK_Id_UniMedida
	JOIN SIGEEA_FacAsociado F
	ON F.PK_Id_FacAsociado = DF.FK_Id_FacAsociado
	WHERE DF.FK_Id_FacAsociado = @Factura
	AND F.Estado_FacAsociado = 1
	AND F.Incompleta_FacAsociado = 0
	GROUP BY DF.CanNeta_DetFacAsociado, DF.CanTotal_DetFacAsociado, F.PK_Id_FacAsociado, TP.PK_Id_TipProducto, 
			 UM.Nombre_UniMedida, df.Mercado_DetFacAsociado, df.PK_Id_DetFacAsociado, tp.Nombre_TipProducto,
			 PC.PreExtranjero_PreProCompra, PC.PreNacional_PreProCompra;
END


//agrego variales con las iniciales e, significan que son mias,  las cree para no modificar su codigo y este funcionara igual
ya que en el codigo de Luis la factura necesita el signo de colon


USE [SIGEEA_BD]
GO
/****** Object:  StoredProcedure [dbo].[SIGEEA_spObtenerPagosEmpleadosPendientes]    Script Date: 13/5/2017 11:56:25 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Luis Barrantes Mora
-- Create date: 10/02/16
-- Description: Obtiene lo que se le debe a un empleado en específico
-- =============================================
ALTER PROCEDURE [dbo].[SIGEEA_spObtenerPagosEmpleadosPendientes]
	@Empleado varchar(15) = null
AS
BEGIN

	SET NOCOUNT ON;

	SELECT CONVERT(VARCHAR(11), hl.HoraInicio_HorLaboradas,106) as Fecha, 
		   DATEDIFF(mi, hl.HoraInicio_HorLaboradas, hl.HoraFin_HorLaboradas)/60.0 as Diferencia,
		   pu.Nombre_Puesto, 
		   concat('₡',(DATEDIFF(mi, hl.HoraInicio_HorLaboradas, hl.HoraFin_HorLaboradas) * (pu.Tarifa_Puesto/60))) as Total,
		   (DATEDIFF(mi, hl.HoraInicio_HorLaboradas, hl.HoraFin_HorLaboradas) * (pu.Tarifa_Puesto/60)) as eTotal,
		   hl.PK_Id_HorLaboradas, concat('₡',pu.Tarifa_Puesto) as Tarifa,
		   pu.Tarifa_Puesto as eTarifa
	FROM SIGEEA_HorLaboradas hl
	JOIN SIGEEA_PueTemporal pu
	ON pu.PK_Id_Puesto = hl.FK_Id_Puesto
	JOIN SIGEEA_Empleado em
	ON em.PK_Id_Empleado = hl.FK_Id_Empleado
	JOIN SIGEEA_Persona pe
	ON pe.PK_Id_Persona = em.FK_Id_Persona
	WHERE pe.CedParticular_Persona = @Empleado
	AND hl.Estado_HorLaboradas = 0 AND hl.Activo_HorLaboradas = 0
		
END