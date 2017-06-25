USE [SIGEEA_BD]
GO
/****** Object:  StoredProcedure [dbo].[SIGEEA_spDetalleFacturaCliente]    Script Date: 3/6/2017 9:49:21 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[SIGEEA_spDetalleFacturaCliente]
	@idFactura int = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT TP.Nombre_TipProducto, TP.Calidad_TipProducto,
	CONCAT(DF.Moneda_DetFacCliente, format(DF.PreUnidad_DetFacCliente, 'N0')) as PreUnidad_DetFacCliente,
	CONCAT(DF.Moneda_DetFacCliente, format(DF.MonNeto_DetFacCliente, 'N0')) as MonNeto_DetFacCliente,
	CONCAT(DF.Moneda_DetFacCliente, format(DF.MonTotal_DetFacCliente, 'N0')) as MonTotal_DetFacCliente,
	CONCAT(DF.CanProducto_DetFacCliente, UM.Nombre_UniMedida) as CanProducto_DetFacCliente,
	CONCAT(DF.Descuento_DetFacCliente, '%') AS Descuento_DetFacCliente
	FROM SIGEEA_FacClientE F
	JOIN SIGEEA_DetFacCliente DF 
	ON F.PK_Id_FacCliente = DF.FK_Id_FacCliente
	JOIN SIGEEA_TipProducto TP
	ON TP.PK_Id_TipProducto = DF.FK_Id_TipProducto
	JOIN SIGEEA_UniMedida UM
	ON UM.PK_Id_UniMedida = DF.FK_Id_UniMedida
	WHERE F.PK_Id_FacCliente = @idFactura
END

USE [SIGEEA_BD]
GO
/****** Object:  StoredProcedure [dbo].[SIGEEA_spEncabezadoFacturaCliente]    Script Date: 3/6/2017 9:49:34 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[SIGEEA_spEncabezadoFacturaCliente]
 @idFactura int = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT 
	EM.Nombre_Empresa, EM.Direccion_Empresa, 
	EM.CedJuridica_Empresa as CedJuridica,
		  EM.Telefono_Empresa as Telefono,
		   EM.Correo_Empresa AS Correo,
	CONVERT (char(10), F.FecEntrega_FacCliente, 103) AS Fecha_Factura,
	CONVERT(nvarchar(10), F.FecEntrega_FacCliente, 108) AS Hora_Factura,
	CONCAT( EP.PriNombre_Persona,' ', EP.SegNombre_Persona, ' ', EP.PriApellido_Persona, ' ', EP.SegApellido_Persona) AS Atendido_Por,
	CONCAT(CP.PriNombre_Persona, ' ', CP.SegNombre_Persona, ' ', CP.PriApellido_Persona, ' ', CP.SegApellido_Persona) AS Nombre_Cliente,
	F.PK_Id_FacCliente AS Numero_Factura
	FROM SIGEEA_FacCliente F
	JOIN SIGEEA_Cliente C
	ON C.PK_Id_Cliente = F.FK_Id_Cliente
	JOIN SIGEEA_Persona CP
	ON CP.PK_Id_Persona = C.FK_Id_Persona
	JOIN SIGEEA_Empleado E
	ON E.PK_Id_Empleado = F.FK_Id_Empleado
	JOIN SIGEEA_Persona EP
	ON EP.PK_Id_Persona = E.FK_Id_Persona
	JOIN SIGEEA_Empresa EM 
	ON EM.PK_Id_Empresa = F.FK_Id_Empresa
	WHERE F.PK_Id_FacCliente = @idFactura
END

USE [SIGEEA_BD]
GO
/****** Object:  StoredProcedure [dbo].[SIGEEA_spEncabezadoReporteVentasPorCliente]    Script Date: 3/6/2017 9:49:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Roberto Alvarado Fallas
-- Create date: 19/03/2017
-- Description:	Encabezado del reporte de ventas por cliente
-- =============================================
ALTER PROCEDURE [dbo].[SIGEEA_spEncabezadoReporteVentasPorCliente]
	@idCliente int = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT
	CONCAT(pc.PriNombre_Persona, +' '+pc.SegNombre_Persona, ' '+ pc.PriApellido_Persona, ' '+ pc.SegApellido_Persona) as nomCliente,
	CONVERT (char(10), getdate(), 103) AS Fecha,
	CONVERT(nvarchar(10), getdate(), 108) AS Hora,
	emC.Nombre_Empresa, emC.Direccion_Empresa, 
	emC.CedJuridica_Empresa as CedJuridica,
		  emC.Telefono_Empresa as Telefono,
		   emC.Correo_Empresa AS Correo
	 FROM SIGEEA_Cliente c 
	 JOIN SIGEEA_Persona pc
	 ON pc.PK_Id_Persona = c.FK_Id_Persona
	 JOIN SIGEEA_Empresa emC
	 ON emC.PK_Id_Empresa = c.FK_Id_Empresa
	 WHERE (c.PK_Id_Cliente = @idCliente)
	 

END



USE [SIGEEA_BD]
GO
/****** Object:  StoredProcedure [dbo].[SIGEEA_spPieFacturaCliente]    Script Date: 3/6/2017 9:49:58 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[SIGEEA_spPieFacturaCliente]
	@idFactura int = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE   
        @Tipo_Factura nvarchar(3) 
	SELECT @Tipo_Factura = F.Estado_FacCliente
	FROM SIGEEA_FacCliente F
	WHERE F.PK_Id_FacCliente = @idFactura;
	IF @Tipo_Factura = 'CO'
		BEGIN
			SELECT 
			CONCAT('Monto Neto: ',M.Simbolo_Moneda , format(F.MonNeto_FacCliente, 'N0')) AS MonNeto_Cliente,
			CONCAT('Monto Total: ',M.Simbolo_Moneda , format(F.MonTotal_FacCliente, 'N0')) AS MonTotal_FacCliente,
			CONCAT('Descuento: ',F.Descuento_FacCliente, '%') AS Descuento_FacCliente,
			CASE A.Metodo_AboCliente 
			  WHEN 1 THEN 'Metodo de pago: Efectivo'
			  WHEN 2 THEN 'Metodo de pago: Tarjeta' 
			  WHEN 3 THEN CONCAT('Metodo de pago: Cheque. Número de cheque: ', A.Numero_AboCliente)
			  WHEN 4 THEN CONCAT('Metodo de pago: Depósito. Número de cuenta: ', A.Numero_AboCliente)
			END as Metodo_AboCliente,
			CONCAT('Saldo Anterior: ', M.Simbolo_Moneda , format(F.MonTotal_FacCliente, 'N0')) AS Saldo_Anterior,
			CONCAT('Pago Cliente: ', M.Simbolo_Moneda , format(A.Monto_AboCliente, 'N0')) AS Abono_Cliente,
			CONCAT('Saldo Actual: ', M.Simbolo_Moneda , format(A.Monto_AboCliente - F.MonTotal_FacCliente, 'N0')) AS Saldo_Actual,
			CONCAT('Observaciones: ', F.Observaciones_FacCliente) AS Observaciones_FacCliente,
			CONCAT('Tipo de Factura: ', 'Contado') AS Tipo_Factura,
			'' as FecLimPago_CreCliente,
			'' as FecProPago_CreCliente
			FROM SIGEEA_FacCliente F
			JOIN SIGEEA_AboCliente A
			ON A.FK_Id_FacCliente = F.PK_Id_FacCliente
			JOIN SIGEEA_Moneda M
			ON M.PK_Id_Moneda = F.FK_Id_Moneda
			WHERE F.PK_Id_FacCliente = @idFactura
		END
	IF @Tipo_Factura = 'PR'
		BEGIN
			SELECT 
			CONCAT('Monto Neto: ',M.Simbolo_Moneda , format(F.MonNeto_FacCliente, 'N0')) AS MonNeto_Cliente,
			CONCAT('Monto Total: ',M.Simbolo_Moneda , format(F.MonTotal_FacCliente, 'N0')) AS MonTotal_FacCliente,
			CONCAT('Descuento: ',F.Descuento_FacCliente, '%') AS Descuento_FacCliente,
			CONCAT('Observaciones: ', F.Observaciones_FacCliente) AS Observaciones_FacCliente,
			CONCAT('Tipo de factura: ', 'Proforma') AS Tipo_Factura,
			'' AS Saldo_Anterior,
			'' as FecLimPago_CreCliente,
			'' as FecProPago_CreCliente,
			'' as MonTotal_FacCliente,
			'' as Metodo_AboCliente,
			'' as Saldo_Actual,
			'' as Abono_Cliente
			FROM SIGEEA_FacCliente F
			JOIN SIGEEA_Moneda M
			ON M.PK_Id_Moneda = F.FK_Id_Moneda
			WHERE F.PK_Id_FacCliente = @idFactura
		END
	IF @Tipo_Factura = 'CR'
		BEGIN
			SELECT 
			CONCAT('Monto Neto: ',M.Simbolo_Moneda , format(F.MonNeto_FacCliente, 'N0')) AS MonNeto_Cliente,
			CONCAT('Monto Total: ',M.Simbolo_Moneda , format(F.MonTotal_FacCliente, 'N0')) AS MonTotal_FacCliente,
			CONCAT('Descuento: ',F.Descuento_FacCliente, '%') AS Descuento_FacCliente,
			CONCAT('Fecha límite de pago: ', CONVERT (char(10), CF.FecLimPago_CreCliente, 103)) AS FecLimPago_CreCliente,
			CONCAT('Fecha próximo pago: ', CONVERT (char(10), CF.FecProPago_CreCliente, 103)) AS FecProPago_CreCliente,
			CONCAT('Observaciones: ', F.Observaciones_FacCliente) AS Observaciones_FacCliente,
			CONCAT('Tipo de factura: ', 'Crédito') AS Tipo_Factura,
			'' AS Saldo_Actual,
			'' as Metodo_AboCliente,
			'' as Saldo_Anterior,
			'' as Abono_Cliente
			FROM SIGEEA_FacCliente F
			JOIN SIGEEA_Moneda M
			ON M.PK_Id_Moneda = F.FK_Id_Moneda
			JOIN SIGEEA_CreCliente CF
			ON CF.FK_Id_FacCliente = F.PK_Id_FacCliente
			WHERE F.PK_Id_FacCliente = @idFactura
		END
END


USE [SIGEEA_BD]
GO
/****** Object:  StoredProcedure [dbo].[SIGEEA_spPieReporteVentasPorCliente]    Script Date: 3/6/2017 9:50:04 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Roberto Alvarado Fallas
-- Create date: 13/03/2017
-- Description:	Reporte de ventas por cliente
-- =============================================
ALTER PROCEDURE [dbo].[SIGEEA_spPieReporteVentasPorCliente]
	@idCliente int = null,
	@fecInicio dateTime,
	@fecFin dateTime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT
	M.Nombre_Moneda, M.PreCompra_Moneda, M.PreVenta_Moneda,
	CONCAT(M.Simbolo_Moneda , format(SUM(FC.MonNeto_FacCliente), 'N0')) AS MonNeto_Cliente,
    CONCAT(M.Simbolo_Moneda , format(SUM(FC.MonTotal_FacCliente), 'N0')) AS MonTotal_Cliente, 
	FC.Estado_FacCliente
	FROM SIGEEA_FacCliente FC
	JOIN SIGEEA_Cliente C
	ON C.PK_Id_Cliente = FC.FK_Id_Cliente
	JOIN SIGEEA_Moneda M
	ON M.PK_Id_Moneda = FC.FK_Id_Moneda
	WHERE FC.FK_Id_Cliente = @idCliente AND
	FC.FecEntrega_FacCliente BETWEEN @fecInicio AND @fecFin
	GROUP BY M.Nombre_Moneda, M.PreVenta_Moneda, M.PreCompra_Moneda, FC.Estado_FacCliente,  M.Simbolo_Moneda
END


USE [SIGEEA_BD]
GO
/****** Object:  StoredProcedure [dbo].[SIGEEA_spReporteVentasProductoPorCliente]    Script Date: 3/6/2017 9:50:16 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Roberto Alvarado Fallas
-- Create date: 16/04/2017
-- Description:	Reporte de ventas por producto
-- =============================================
ALTER PROCEDURE [dbo].[SIGEEA_spReporteVentasProductoPorCliente]
	@idCliente int = null,
	@fecInicio dateTime,
	@fecFin dateTime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	SELECT
    TP.Nombre_TipProducto, TP.Calidad_TipProducto, @fecInicio AS Fecha_Inicio, @fecFin AS Fecha_Fin,
	CONCAT('₡' , format(M.PreVenta_Moneda, 'N0')) as PreVenta_Moneda,
	CONCAT('₡' , format(M.PreCompra_Moneda, 'N0')) as PreCompra_Moneda,
	CONCAT(M.Simbolo_Moneda , format(DFC.PreUnidad_DetFacCliente, 'N0')) as PreUnidad_DetFacCliente,
	CONCAT(M.Simbolo_Moneda , format(SUM(DFC.MonNeto_DetFacCliente), 'N0')) as MonNeto_Producto,
	CONCAT(M.Simbolo_Moneda , format(SUM(DFC.MonTotal_DetFacCliente), 'N0')) as MonTotal_Producto,
	CONCAT(SUM(DFC.CanProducto_DetFacCliente), UM.Nombre_UniMedida) AS Cantidad,
	CONCAT(M.Simbolo_Moneda ,format(SUM(DFC.MonTotal_DetFacCliente) - SUM(DFC.MonNeto_DetFacCliente), 'N0')) as Descuento,
    FC.Estado_FacCliente
	FROM SIGEEA_FacCliente FC
	JOIN SIGEEA_Cliente C
	ON C.PK_Id_Cliente = FC.FK_Id_Cliente
	JOIN SIGEEA_DetFacCliente DFC
	ON DFC.FK_Id_FacCliente = FC.PK_Id_FacCliente
	JOIN SIGEEA_TipProducto TP
	ON TP.PK_Id_TipProducto = DFC.FK_Id_TipProducto
	JOIN SIGEEA_UniMedida UM
	ON UM.PK_Id_UniMedida = DFC.FK_Id_UniMedida
	JOIN SIGEEA_Moneda M
	ON M.PK_Id_Moneda = FC.FK_Id_Moneda
	WHERE FC.FK_Id_Cliente = @idCliente AND
	FC.FecEntrega_FacCliente BETWEEN @fecInicio AND @fecFin
	GROUP BY M.PreVenta_Moneda, M.PreCompra_Moneda, FC.Estado_FacCliente, TP.Nombre_TipProducto, 
	TP.Calidad_TipProducto, UM.Nombre_UniMedida, DFC.PreUnidad_DetFacCliente, PreUnidad_DetFacCliente, M.Simbolo_Moneda
END

