USE [SIGEEA_BD]
GO
/****** Object:  Table [dbo].[SIGEEA_AboCliente]    Script Date: 18/4/2016 11:55:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SIGEEA_AboCliente](
	[PK_Id_AboCliente] [int] IDENTITY(1,1) NOT NULL,
	[Monto_AboCliente] [float] NOT NULL,
	[Metodo_AboCliente] [int] NOT NULL,
	[Numero_AboCliente] [varchar](25) NULL,
	[Fecha_AboCliente] [datetime] NOT NULL,
	[FK_Id_Moneda] [int] NOT NULL,
	[FK_Id_Empleado] [int] NOT NULL,
	[Estado_AboCliente] [bit] NOT NULL,
	[FK_Id_Cliente] [int] NOT NULL,
	[FK_Id_FacCliente] [int] NOT NULL,
 CONSTRAINT [PK_SIGEEA_PagCliente] PRIMARY KEY CLUSTERED 
(
	[PK_Id_AboCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SIGEEA_Anualidad]    Script Date: 18/4/2016 11:55:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SIGEEA_Anualidad](
	[PK_Id_Anualidad] [int] NOT NULL,
	[Anno_Anualidad] [numeric](4, 0) NOT NULL,
	[FK_Id_Monto] [int] NOT NULL,
	[FK_Id_Asociado] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SIGEEA_Asamblea]    Script Date: 18/4/2016 11:55:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SIGEEA_Asamblea](
	[PK_Id_Asamblea] [int] NOT NULL,
	[Fecha_Asamblea] [date] NOT NULL,
	[Tipo_Asamblea] [int] NOT NULL,
	[NumActa_Asamblea] [varchar](30) NULL,
	[Observaciones_Asamblea] [varchar](100) NULL,
 CONSTRAINT [PK_SIGEEA_Asamblea] PRIMARY KEY CLUSTERED 
(
	[PK_Id_Asamblea] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SIGEEA_AsiAsamblea]    Script Date: 18/4/2016 11:55:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SIGEEA_AsiAsamblea](
	[PK_Id_AsiAsamblea] [int] NOT NULL,
	[FK_Id_Asociado] [int] NOT NULL,
	[FK_Id_Asamblea] [int] NOT NULL,
	[Estado_AsiAsamblea] [int] NOT NULL,
 CONSTRAINT [PK_SIGEEA_AsiAsamblea] PRIMARY KEY CLUSTERED 
(
	[PK_Id_AsiAsamblea] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SIGEEA_Asociado]    Script Date: 18/4/2016 11:55:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SIGEEA_Asociado](
	[Codigo_Asociado] [varchar](10) NOT NULL,
	[Estado_Asociado] [bit] NOT NULL,
	[FecIngreso_Asociado] [date] NOT NULL,
	[FK_Id_Persona] [int] NOT NULL,
	[FK_Id_Representante] [int] NULL,
	[PK_Id_Asociado] [int] IDENTITY(1,1) NOT NULL,
	[FK_Id_Empresa] [int] NOT NULL,
	[FK_Id_CatAsociado] [int] NOT NULL,
 CONSTRAINT [PK_SIGEEA_Asociado] PRIMARY KEY CLUSTERED 
(
	[PK_Id_Asociado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SIGEEA_AsociadoXPagAsociado]    Script Date: 18/4/2016 11:55:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SIGEEA_AsociadoXPagAsociado](
	[PK_Id_AsociadoXPagAsociado] [int] NOT NULL,
	[Fecha_AsociadoXPagAsociado] [datetime] NOT NULL,
	[Cancelado_AsociadoXPagAsociado] [bit] NOT NULL,
	[FK_Id_Asociado] [int] NOT NULL,
	[FK_Id_PagAsociado] [int] NOT NULL,
 CONSTRAINT [PK_SIGEEA_AsociadoXPagAsociado] PRIMARY KEY CLUSTERED 
(
	[PK_Id_AsociadoXPagAsociado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SIGEEA_Banco]    Script Date: 18/4/2016 11:55:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SIGEEA_Banco](
	[PK_Id_Banco] [int] NOT NULL,
	[FK_Id_Empresa] [int] NOT NULL,
 CONSTRAINT [PK_SIGEEA_Banco] PRIMARY KEY CLUSTERED 
(
	[PK_Id_Banco] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SIGEEA_Bodega]    Script Date: 18/4/2016 11:55:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SIGEEA_Bodega](
	[PK_Id_Bodega] [int] IDENTITY(1,1) NOT NULL,
	[Nombre_Bodega] [varchar](50) NOT NULL,
	[Descripcion_Bodega] [varchar](100) NULL,
	[FK_Id_Empresa] [int] NOT NULL,
 CONSTRAINT [PK_SIGEEA_Bodega] PRIMARY KEY CLUSTERED 
(
	[PK_Id_Bodega] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SIGEEA_Canton]    Script Date: 18/4/2016 11:55:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SIGEEA_Canton](
	[PK_Id_Canton] [int] NOT NULL,
	[Nombre_Canton] [varchar](30) NOT NULL,
	[FK_Id_Provincia] [int] NOT NULL,
 CONSTRAINT [PK_SIGEEA_Canton] PRIMARY KEY CLUSTERED 
(
	[PK_Id_Canton] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SIGEEA_CatAsociado]    Script Date: 18/4/2016 11:55:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SIGEEA_CatAsociado](
	[PK_Id_CatAsociado] [int] IDENTITY(1,1) NOT NULL,
	[Nombre_CatAsociado] [varchar](30) NOT NULL,
	[Valor_CatAsociado] [int] NOT NULL,
 CONSTRAINT [PK_SIGEEA_CatAsociado] PRIMARY KEY CLUSTERED 
(
	[PK_Id_CatAsociado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SIGEEA_CatCliente]    Script Date: 18/4/2016 11:55:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SIGEEA_CatCliente](
	[PK_Id_CatCliente] [int] IDENTITY(1,1) NOT NULL,
	[Limite_CatCliente] [float] NOT NULL,
	[RanPagos_CatCliente] [varchar](30) NULL,
	[TieMaximo_CatCliente] [varchar](30) NULL,
	[Nombre_CatCliente] [varchar](25) NULL,
 CONSTRAINT [PK_SIGEEA_CreCliente] PRIMARY KEY CLUSTERED 
(
	[PK_Id_CatCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SIGEEA_Cliente]    Script Date: 18/4/2016 11:55:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SIGEEA_Cliente](
	[PK_Id_Cliente] [int] IDENTITY(1,1) NOT NULL,
	[FK_Id_CatCliente] [int] NOT NULL,
	[FK_Id_Persona] [int] NOT NULL,
	[Estado_Cliente] [bit] NOT NULL,
	[FK_Id_Empresa] [int] NOT NULL,
 CONSTRAINT [PK_SIGEEA_Cliente] PRIMARY KEY CLUSTERED 
(
	[PK_Id_Cliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SIGEEA_CodPostal]    Script Date: 18/4/2016 11:55:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SIGEEA_CodPostal](
	[PK_Id_CodPostal] [int] NOT NULL,
	[Nombre_CodPostal] [varchar](10) NOT NULL,
	[FK_Id_Estado] [int] NOT NULL,
 CONSTRAINT [PK_SIGEEA_CodPostal] PRIMARY KEY CLUSTERED 
(
	[PK_Id_CodPostal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SIGEEA_Contacto]    Script Date: 18/4/2016 11:55:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SIGEEA_Contacto](
	[PK_Id_Contacto] [int] IDENTITY(1,1) NOT NULL,
	[Dato_Contacto] [varchar](30) NOT NULL,
	[FK_Id_TipContacto] [int] NOT NULL,
	[FK_Id_Persona] [int] NOT NULL,
 CONSTRAINT [PK_SIGEEA_Contacto] PRIMARY KEY CLUSTERED 
(
	[PK_Id_Contacto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SIGEEA_CreCliente]    Script Date: 18/4/2016 11:55:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SIGEEA_CreCliente](
	[PK_Id_CreCliente] [int] IDENTITY(1,1) NOT NULL,
	[Monto_CreCliente] [float] NOT NULL,
	[Estado_CreCliente] [bit] NOT NULL,
	[Fecha_CreCliente] [datetime] NOT NULL,
	[Saldo_CreCliente] [float] NOT NULL,
	[FK_Id_Cliente] [int] NOT NULL,
	[FK_Id_Moneda] [int] NULL,
 CONSTRAINT [PK_SIGEEA_CreCliente_1] PRIMARY KEY CLUSTERED 
(
	[PK_Id_CreCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SIGEEA_Cuenta]    Script Date: 18/4/2016 11:55:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SIGEEA_Cuenta](
	[PK_Id_Cuenta] [int] NOT NULL,
	[Numero_Cuenta] [varchar](50) NOT NULL,
	[FK_Id_Moneda] [int] NOT NULL,
	[FK_Id_Banco] [int] NOT NULL,
	[FK_Id_Persona] [int] NULL,
 CONSTRAINT [PK_SIGEEA_Cuenta] PRIMARY KEY CLUSTERED 
(
	[PK_Id_Cuenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SIGEEA_Cuota]    Script Date: 18/4/2016 11:55:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SIGEEA_Cuota](
	[PK_Id_Cuota] [int] IDENTITY(1,1) NOT NULL,
	[Nombre_Cuota] [varchar](50) NOT NULL,
	[Monto_Cuota] [float] NOT NULL,
	[FecInicio_Cuota] [datetime] NOT NULL,
	[FecFin_Cuota] [datetime] NOT NULL,
	[FK_Id_Moneda] [int] NOT NULL,
 CONSTRAINT [PK_SIGEEA_Cuota] PRIMARY KEY CLUSTERED 
(
	[PK_Id_Cuota] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SIGEEA_Cuota_Asociado]    Script Date: 18/4/2016 11:55:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SIGEEA_Cuota_Asociado](
	[PK_Id_Cuota_Asociado] [int] IDENTITY(1,1) NOT NULL,
	[Estado_Cuota_Asociado] [bit] NOT NULL,
	[Saldo_Cuota_Asociado] [float] NOT NULL,
	[FK_Id_Cuota] [int] NOT NULL,
	[FK_Id_Asociado] [int] NOT NULL,
 CONSTRAINT [PK_SIGEEA_Cuota_Asociado] PRIMARY KEY CLUSTERED 
(
	[PK_Id_Cuota_Asociado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SIGEEA_DetFacAsociado]    Script Date: 18/4/2016 11:55:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SIGEEA_DetFacAsociado](
	[PK_Id_DetFacAsociado] [int] IDENTITY(1,1) NOT NULL,
	[CanTotal_DetFacAsociado] [float] NOT NULL,
	[CanNeta_DetFacAsociado] [float] NULL,
	[Mercado_DetFacAsociado] [int] NOT NULL,
	[FK_Id_FacAsociado] [int] NOT NULL,
	[FK_Id_PreProCompra] [int] NOT NULL,
	[FK_Id_Lote] [int] NOT NULL,
 CONSTRAINT [PK_SIGEEA_DetFacAsociado] PRIMARY KEY CLUSTERED 
(
	[PK_Id_DetFacAsociado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SIGEEA_DetFacCliente]    Script Date: 18/4/2016 11:55:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SIGEEA_DetFacCliente](
	[PK_Id_DetFacCliente] [int] IDENTITY(1,1) NOT NULL,
	[MonTotal_DetFacCliente] [float] NOT NULL,
	[MonNeto_DetFacCliente] [float] NOT NULL,
	[CanProducto_DetFacCliente] [float] NOT NULL,
	[Descuento_DetFacCliente] [float] NOT NULL,
	[PreUnidad_DetFacCliente] [float] NOT NULL,
	[Moneda_DetFacCliente] [char](3) NOT NULL,
	[FK_Id_FacCliente] [int] NOT NULL,
	[FK_Id_UniMedida] [int] NOT NULL,
	[FK_Id_TipProducto] [int] NOT NULL,
 CONSTRAINT [PK_SIGEEA_DetFacCliente] PRIMARY KEY CLUSTERED 
(
	[PK_Id_DetFacCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SIGEEA_DetFacInsumo]    Script Date: 18/4/2016 11:55:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SIGEEA_DetFacInsumo](
	[PK_Id_DetFacInsumo] [int] IDENTITY(1,1) NOT NULL,
	[Precio_DetFacInsumo] [float] NOT NULL,
	[Metodo_DetFacInsumo] [int] NOT NULL,
	[Numero_DetFacInsumo] [int] NOT NULL,
	[FK_Id_FacInsumo] [int] NOT NULL,
	[FK_Id_Empleado] [int] NOT NULL,
	[FK_Id_Moneda] [int] NOT NULL,
 CONSTRAINT [PK_SIGEEA_Pago_Compra] PRIMARY KEY CLUSTERED 
(
	[PK_Id_DetFacInsumo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SIGEEA_DetInvProductos]    Script Date: 18/4/2016 11:55:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SIGEEA_DetInvProductos](
	[PK_Id_DetInvProductos] [int] IDENTITY(1,1) NOT NULL,
	[Cantidad_DetInvProductos] [float] NOT NULL,
	[FK_Id_TipProducto] [int] NOT NULL,
	[FK_Id_InvProductos] [int] NOT NULL,
	[FK_Id_UniMedida] [int] NOT NULL,
 CONSTRAINT [PK_SIGEEA_InvProductos] PRIMARY KEY CLUSTERED 
(
	[PK_Id_DetInvProductos] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SIGEEA_DetPagEmpleados]    Script Date: 18/4/2016 11:55:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SIGEEA_DetPagEmpleados](
	[PK_Id_DetPagEmpleados] [int] IDENTITY(1,1) NOT NULL,
	[Total_DetPagEmpleados] [float] NOT NULL,
	[FK_Id_PagEmpleados] [int] NOT NULL,
	[FK_Id_HorLaboradas] [int] NOT NULL,
 CONSTRAINT [PK_SIGEEA_DetPagEmpleados] PRIMARY KEY CLUSTERED 
(
	[PK_Id_DetPagEmpleados] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SIGEEA_Direccion]    Script Date: 18/4/2016 11:55:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SIGEEA_Direccion](
	[PK_Id_Direccion] [int] IDENTITY(1,1) NOT NULL,
	[Detalles_Direccion] [varchar](100) NOT NULL,
	[FK_Id_Distrito] [int] NULL,
	[FK_Id_CodPostal] [int] NULL,
 CONSTRAINT [PK_SIGEEA_Direccion] PRIMARY KEY CLUSTERED 
(
	[PK_Id_Direccion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SIGEEA_Distrito]    Script Date: 18/4/2016 11:55:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SIGEEA_Distrito](
	[PK_Id_Distrito] [int] NOT NULL,
	[Nombre_Distrito] [varchar](30) NOT NULL,
	[FK_Id_Canton] [int] NOT NULL,
 CONSTRAINT [PK_SIGGEA_Distrito] PRIMARY KEY CLUSTERED 
(
	[PK_Id_Distrito] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SIGEEA_Empleado]    Script Date: 18/4/2016 11:55:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SIGEEA_Empleado](
	[FK_Id_Persona] [int] NOT NULL,
	[FK_Id_Puesto] [int] NULL,
	[FK_Id_Escolaridad] [int] NOT NULL,
	[PK_Id_Empleado] [int] IDENTITY(1,1) NOT NULL,
	[Estado_Empleado] [bit] NOT NULL,
	[FK_Id_Empresa] [int] NOT NULL,
 CONSTRAINT [PK_SIGEEA_Empleado] PRIMARY KEY CLUSTERED 
(
	[PK_Id_Empleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SIGEEA_Empresa]    Script Date: 18/4/2016 11:55:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SIGEEA_Empresa](
	[PK_Id_Empresa] [int] IDENTITY(1,1) NOT NULL,
	[Nombre_Empresa] [varchar](50) NOT NULL,
	[CedJuridica_Empresa] [varchar](30) NOT NULL,
	[Direccion_Empresa] [varchar](200) NULL,
	[Telefono_Empresa] [varchar](15) NULL,
	[Correo_Empresa] [varchar](30) NULL,
 CONSTRAINT [PK_SIGEEA_Empresa] PRIMARY KEY CLUSTERED 
(
	[PK_Id_Empresa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SIGEEA_Escolaridad]    Script Date: 18/4/2016 11:55:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SIGEEA_Escolaridad](
	[Leer_Escolaridad] [bit] NOT NULL,
	[Escribir_Escolaridad] [bit] NOT NULL,
	[GradoAcad_Escolaridad] [int] NOT NULL,
	[Observaciones_Escolaridad] [varchar](300) NULL,
	[PK_Id_Escolaridad] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_SIGEEA_Escolaridad] PRIMARY KEY CLUSTERED 
(
	[PK_Id_Escolaridad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SIGEEA_Estado]    Script Date: 18/4/2016 11:55:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SIGEEA_Estado](
	[PK_Id_Estado] [int] IDENTITY(1,1) NOT NULL,
	[Nombre_Estado] [varchar](25) NOT NULL,
	[FK_Id_Pais] [int] NOT NULL,
 CONSTRAINT [PK_SIGEEA_Estado] PRIMARY KEY CLUSTERED 
(
	[PK_Id_Estado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SIGEEA_Experiencia]    Script Date: 18/4/2016 11:55:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SIGEEA_Experiencia](
	[PK_Id_Experiencia] [int] NOT NULL,
	[FecInicio_Experiencia] [date] NOT NULL,
	[FecFin_Experiencia] [date] NOT NULL,
	[NombreJefe_Experiencia] [varchar](100) NULL,
	[CargoJefe_Experiencia] [varchar](50) NULL,
	[DescTrabajo_Experiencia] [varchar](100) NOT NULL,
	[MotSalida_Experiencia] [varchar](100) NULL,
	[Empresa_Experiencia] [varchar](50) NOT NULL,
	[FK_Id_Empleado] [int] NOT NULL,
 CONSTRAINT [PK_SIGEEA_Experiencia] PRIMARY KEY CLUSTERED 
(
	[PK_Id_Experiencia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SIGEEA_FacAsociado]    Script Date: 18/4/2016 11:55:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SIGEEA_FacAsociado](
	[PK_Id_FacAsociado] [int] IDENTITY(1,1) NOT NULL,
	[FecEntrega_FacAsociado] [date] NOT NULL,
	[FecPago_FacAsociado] [date] NOT NULL,
	[CanTotal_FacAsociado] [float] NOT NULL,
	[CanNeta_FacAsociado] [float] NULL,
	[Estado_FacAsociado] [bit] NOT NULL,
	[Observaciones_FacAsociado] [varchar](300) NULL,
	[FK_Id_Asociado] [int] NOT NULL,
	[FK_Id_UniMedida] [int] NOT NULL,
	[Incompleta_FacAsociado] [bit] NOT NULL,
 CONSTRAINT [PK_SIGEEA_FacAsociado] PRIMARY KEY CLUSTERED 
(
	[PK_Id_FacAsociado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SIGEEA_FacCliente]    Script Date: 18/4/2016 11:55:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SIGEEA_FacCliente](
	[PK_Id_FacCliente] [int] IDENTITY(1,1) NOT NULL,
	[FecEntrega_FacCliente] [datetime] NOT NULL,
	[FecPago_FacCliente] [datetime] NOT NULL,
	[FecProPago_FacCliente] [datetime] NULL,
	[Observaciones_FacCliente] [varchar](300) NOT NULL,
	[FK_Id_Cliente] [int] NOT NULL,
	[Estado_FacCliente] [varchar](2) NOT NULL,
	[MonTotal_FacCliente] [float] NOT NULL,
	[MonNeto_FacCliente] [float] NOT NULL,
	[Descuento_FacCliente] [float] NOT NULL,
	[FK_Id_Moneda] [int] NOT NULL,
	[FK_Id_Empresa] [int] NOT NULL,
	[FK_Id_Empleado] [int] NOT NULL,
 CONSTRAINT [PK_SIGEEA_FacCliente] PRIMARY KEY CLUSTERED 
(
	[PK_Id_FacCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SIGEEA_FacInsumo]    Script Date: 18/4/2016 11:55:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SIGEEA_FacInsumo](
	[PK_Id_FacInsumo] [int] IDENTITY(1,1) NOT NULL,
	[MonTotal_FacInsumo] [int] NOT NULL,
	[Descripcion_FacInsumo] [varchar](30) NOT NULL,
	[FK_Id_Insumo] [int] NOT NULL,
	[FK_Id_Proveedor] [int] NOT NULL,
	[FK_Id_Empleado] [int] NOT NULL,
	[Estado_FacInsumo] [bit] NOT NULL,
	[Fecha_FacInsumo] [datetime] NOT NULL,
 CONSTRAINT [PK_SIGEEA_Compra_Producto] PRIMARY KEY CLUSTERED 
(
	[PK_Id_FacInsumo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SIGEEA_Familiar]    Script Date: 18/4/2016 11:55:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SIGEEA_Familiar](
	[PK_Id_Familiar] [int] IDENTITY(1,1) NOT NULL,
	[FK_Id_Asociado] [int] NOT NULL,
	[Nombre_Familiar] [varchar](300) NOT NULL,
	[Escolaridad_Familiar] [int] NOT NULL,
	[DesEstudios_Familiar] [varchar](100) NULL,
 CONSTRAINT [PK_SIGEEA_Familiar] PRIMARY KEY CLUSTERED 
(
	[PK_Id_Familiar] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SIGEEA_Finca]    Script Date: 18/4/2016 11:55:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SIGEEA_Finca](
	[PK_Id_Finca] [int] IDENTITY(1,1) NOT NULL,
	[Alquilada_Finca] [bit] NOT NULL,
	[Codigo_Finca] [varchar](10) NOT NULL,
	[FK_Id_Direccion] [int] NOT NULL,
	[FK_Id_Asociado] [int] NOT NULL,
	[Estado_Finca] [varchar](2) NOT NULL,
	[NomDuenno_Finca] [varchar](30) NOT NULL,
	[ApeDuenno_Finca] [varchar](30) NULL,
	[NumRegistro_Finca] [varchar](15) NOT NULL,
 CONSTRAINT [PK_SIGEEA_Finca] PRIMARY KEY CLUSTERED 
(
	[PK_Id_Finca] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SIGEEA_HisDelictivo]    Script Date: 18/4/2016 11:55:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SIGEEA_HisDelictivo](
	[PK_Id_HisDelictivo] [int] NOT NULL,
	[Descripcion_HisDelictivo] [varchar](100) NOT NULL,
	[FK_Id_Empleado] [int] NOT NULL,
 CONSTRAINT [PK_SIGEEA_HisDelictivo] PRIMARY KEY CLUSTERED 
(
	[PK_Id_HisDelictivo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SIGEEA_HorLaboradas]    Script Date: 18/4/2016 11:55:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SIGEEA_HorLaboradas](
	[PK_Id_HorLaboradas] [int] IDENTITY(1,1) NOT NULL,
	[HoraInicio_HorLaboradas] [datetime] NOT NULL,
	[HoraFin_HorLaboradas] [datetime] NULL,
	[Activo_HorLaboradas] [bit] NOT NULL,
	[Estado_HorLaboradas] [bit] NOT NULL,
	[FK_Id_Empleado] [int] NOT NULL,
	[FK_Id_Puesto] [int] NOT NULL,
 CONSTRAINT [PK_SIGEEA_HorLaboradas] PRIMARY KEY CLUSTERED 
(
	[PK_Id_HorLaboradas] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SIGEEA_Insumo]    Script Date: 18/4/2016 11:55:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SIGEEA_Insumo](
	[PK_Id_Insumo] [int] IDENTITY(1,1) NOT NULL,
	[Nombre_Insumo] [varchar](20) NOT NULL,
	[Descripcion_Insumo] [varchar](30) NOT NULL,
	[Estado_Insumo] [bit] NOT NULL,
 CONSTRAINT [PK_SIGEEA_Producto] PRIMARY KEY CLUSTERED 
(
	[PK_Id_Insumo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SIGEEA_InvInsumo]    Script Date: 18/4/2016 11:55:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SIGEEA_InvInsumo](
	[PK_IdInvInsumo] [int] IDENTITY(1,1) NOT NULL,
	[Cantidad_InvInsumo] [float] NOT NULL,
	[FK_Id_Insumo] [int] NOT NULL,
	[FK_UniMedida] [int] NOT NULL,
 CONSTRAINT [PK_SIGEEA_InvInsumo] PRIMARY KEY CLUSTERED 
(
	[PK_IdInvInsumo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SIGEEA_InvProductos]    Script Date: 18/4/2016 11:55:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SIGEEA_InvProductos](
	[PK_Id_InvProductos] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion_InvProductos] [varchar](100) NULL,
	[FK_Id_Bodega] [int] NOT NULL,
 CONSTRAINT [PK_SIGEEA_InvProductos_1] PRIMARY KEY CLUSTERED 
(
	[PK_Id_InvProductos] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SIGEEA_Lote]    Script Date: 18/4/2016 11:55:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SIGEEA_Lote](
	[PK_Id_Lote] [int] IDENTITY(1,1) NOT NULL,
	[Codigo_Lote] [varchar](15) NOT NULL,
	[Tamanno_Lote] [nchar](10) NULL,
	[FK_Id_Finca] [int] NOT NULL,
 CONSTRAINT [PK_SIGEEA_Lote] PRIMARY KEY CLUSTERED 
(
	[PK_Id_Lote] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SIGEEA_Modulo]    Script Date: 18/4/2016 11:55:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SIGEEA_Modulo](
	[PK_Id_Modulo] [int] NOT NULL,
	[Nombre_Modulo] [varchar](30) NOT NULL,
 CONSTRAINT [PK_SIGEEA_Modulo] PRIMARY KEY CLUSTERED 
(
	[PK_Id_Modulo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SIGEEA_Moneda]    Script Date: 18/4/2016 11:55:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SIGEEA_Moneda](
	[PK_Id_Moneda] [int] IDENTITY(1,1) NOT NULL,
	[PreCompra_Moneda] [float] NOT NULL,
	[PreVenta_Moneda] [float] NOT NULL,
	[Nombre_Moneda] [varchar](15) NOT NULL,
	[FK_Id_Empresa] [int] NOT NULL,
	[Simbolo_Moneda] [varchar](3) NOT NULL,
 CONSTRAINT [PK_SIGEEA_Moneda] PRIMARY KEY CLUSTERED 
(
	[PK_Id_Moneda] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SIGEEA_Nacionalidad]    Script Date: 18/4/2016 11:55:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SIGEEA_Nacionalidad](
	[PK_Id_Nacionalidad] [int] IDENTITY(3,1) NOT NULL,
	[Nombre_Nacionalidad] [varchar](50) NOT NULL,
 CONSTRAINT [PK_SIGEEA_Nacionalidad] PRIMARY KEY CLUSTERED 
(
	[PK_Id_Nacionalidad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SIGEEA_PagAsociado]    Script Date: 18/4/2016 11:55:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SIGEEA_PagAsociado](
	[PK_Id_PagAsociado] [int] NOT NULL,
	[Monto_PagAsociado] [float] NOT NULL,
	[FecActualizacion_PagAsociado] [datetime] NOT NULL,
	[TipPago_PagAsociado] [int] NOT NULL,
	[Descripcion_PagAsociado] [varchar](100) NULL,
 CONSTRAINT [PK_SIGEEA_PagAsociado] PRIMARY KEY CLUSTERED 
(
	[PK_Id_PagAsociado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SIGEEA_PagEmpleados]    Script Date: 18/4/2016 11:55:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SIGEEA_PagEmpleados](
	[PK_Id_PagEmpleados] [int] IDENTITY(1,1) NOT NULL,
	[Fecha_PagEmpleados] [date] NOT NULL,
	[FK_Id_Empleado] [int] NOT NULL,
	[FK_Id_Cuenta] [int] NULL,
 CONSTRAINT [PK_SIGEEA_PagEmpleados] PRIMARY KEY CLUSTERED 
(
	[PK_Id_PagEmpleados] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SIGEEA_Pais]    Script Date: 18/4/2016 11:55:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SIGEEA_Pais](
	[PK_Id_Pais] [int] IDENTITY(1,1) NOT NULL,
	[Nombre_Pais] [varchar](20) NOT NULL,
 CONSTRAINT [PK_SIGEEA_Pais] PRIMARY KEY CLUSTERED 
(
	[PK_Id_Pais] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SIGEEA_Parentesco]    Script Date: 18/4/2016 11:55:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SIGEEA_Parentesco](
	[PK_Id_Parentesco] [int] NOT NULL,
	[Nombre_Parentesco] [varchar](15) NOT NULL,
 CONSTRAINT [PK_SIGEEA_Parentesco] PRIMARY KEY CLUSTERED 
(
	[PK_Id_Parentesco] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SIGEEA_PedInsumo]    Script Date: 18/4/2016 11:55:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SIGEEA_PedInsumo](
	[PK_Id_PedInsumo] [int] IDENTITY(1,1) NOT NULL,
	[Cantidad_PedInsumo] [float] NOT NULL,
	[Fecha_PedInsumo] [datetime] NOT NULL,
	[Descripcion_PedInsumo] [varchar](150) NOT NULL,
	[FK_Id_Insumo] [int] NOT NULL,
	[FK_Id_Empleado] [int] NOT NULL,
	[Estado_Insumo] [bit] NOT NULL,
 CONSTRAINT [PK_SIGEEA_PedInsumo] PRIMARY KEY CLUSTERED 
(
	[PK_Id_PedInsumo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SIGEEA_PerExportacion]    Script Date: 18/4/2016 11:55:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SIGEEA_PerExportacion](
	[PK_Id_Permiso_Exportacion] [int] IDENTITY(1,1) NOT NULL,
	[Permiso_Exportacion] [bit] NOT NULL,
	[Numero_Permiso_Exportacion] [varchar](20) NOT NULL,
	[Descripcion_Permiso_Exportacion] [varbinary](30) NOT NULL,
	[Fecha_Emision_Permiso_Exportacion] [datetime] NOT NULL,
	[Fecha_Vencimiento_Permiso_Exportacion] [datetime] NOT NULL,
	[FK_Id_Lote] [int] NOT NULL,
	[FK_Id_Empleado] [int] NOT NULL,
 CONSTRAINT [PK_SIGEEA_PerExportacion] PRIMARY KEY CLUSTERED 
(
	[PK_Id_Permiso_Exportacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SIGEEA_Permiso]    Script Date: 18/4/2016 11:55:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SIGEEA_Permiso](
	[PK_Id_Permiso] [int] NOT NULL,
	[Nombre_Permiso] [varchar](30) NOT NULL,
 CONSTRAINT [PK_SIGEEA_Permiso] PRIMARY KEY CLUSTERED 
(
	[PK_Id_Permiso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SIGEEA_Permiso-Modulo]    Script Date: 18/4/2016 11:55:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SIGEEA_Permiso-Modulo](
	[FK_Id_Permiso] [int] NOT NULL,
	[FK_Id_Modulo] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SIGEEA_Persona]    Script Date: 18/4/2016 11:55:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SIGEEA_Persona](
	[PriNombre_Persona] [varchar](30) NOT NULL,
	[SegNombre_Persona] [varchar](30) NULL,
	[PriApellido_Persona] [varchar](30) NULL,
	[SegApellido_Persona] [varchar](30) NULL,
	[Genero_Persona] [varchar](30) NULL,
	[FecNacimiento_Persona] [date] NOT NULL,
	[FK_Id_Direccion] [int] NULL,
	[FK_Id_Nacionalidad] [int] NOT NULL,
	[PK_Id_Persona] [int] IDENTITY(1,1) NOT NULL,
	[Tipo_Persona] [bit] NOT NULL,
	[CedJuridica_Persona] [varchar](30) NULL,
	[CedParticular_Persona] [varchar](15) NULL,
PRIMARY KEY CLUSTERED 
(
	[PK_Id_Persona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SIGEEA_PreProCompra]    Script Date: 18/4/2016 11:55:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SIGEEA_PreProCompra](
	[PreNacional_PreProCompra] [float] NULL,
	[PreExtranjero_PreProCompra] [float] NULL,
	[FecRegistro_PreProCompra] [datetime] NOT NULL,
	[FK_Id_TipProducto] [int] NOT NULL,
	[PK_Id_PreProCompra] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_SIGEEA_PreProCompra] PRIMARY KEY CLUSTERED 
(
	[PK_Id_PreProCompra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SIGEEA_PreProVenta]    Script Date: 18/4/2016 11:55:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SIGEEA_PreProVenta](
	[PreNacional_PreProVenta] [float] NULL,
	[PreExtranjero_PreProVenta] [float] NULL,
	[FecRegistro_PreProVenta] [datetime] NOT NULL,
	[FK_Id_TipProducto] [int] NOT NULL,
	[PK_Id_PreProVenta] [int] IDENTITY(1,1) NOT NULL,
	[FK_Id_Moneda] [int] NOT NULL,
 CONSTRAINT [PK_SIGEEA_PreProVenta] PRIMARY KEY CLUSTERED 
(
	[PK_Id_PreProVenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SIGEEA_Proveedor]    Script Date: 18/4/2016 11:55:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SIGEEA_Proveedor](
	[PK_Id_Proveedor] [int] NOT NULL,
	[Nombre_Proveedor] [varbinary](30) NOT NULL,
	[Direccion_Proveedor] [varchar](30) NOT NULL,
	[FK_Id_Insumo] [int] NOT NULL,
	[FK_Id_Persona] [int] NOT NULL,
	[FK_Id_Empresa] [int] NOT NULL,
 CONSTRAINT [PK_SIGEEA_Proveedor] PRIMARY KEY CLUSTERED 
(
	[PK_Id_Proveedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SIGEEA_Provincia]    Script Date: 18/4/2016 11:55:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SIGEEA_Provincia](
	[PK_Id_Provincia] [int] NOT NULL,
	[Nombre_Provincia] [varchar](50) NOT NULL,
	[FK_Id_Pais] [int] NOT NULL,
 CONSTRAINT [PK_SIGEEA_Provincia] PRIMARY KEY CLUSTERED 
(
	[PK_Id_Provincia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SIGEEA_PueTemporal]    Script Date: 18/4/2016 11:55:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SIGEEA_PueTemporal](
	[PK_Id_Puesto] [int] IDENTITY(1,1) NOT NULL,
	[Nombre_Puesto] [varchar](30) NOT NULL,
	[Tarifa_Puesto] [float] NOT NULL,
	[Actualizacion_Puesto] [datetime] NOT NULL,
	[Estado_Puesto] [bit] NOT NULL,
 CONSTRAINT [PK_SIGEEA_PueTemporal] PRIMARY KEY CLUSTERED 
(
	[PK_Id_Puesto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SIGEEA_Representante]    Script Date: 18/4/2016 11:55:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SIGEEA_Representante](
	[PK_Id_Representante] [int] NOT NULL,
	[Id_Asociado] [int] NOT NULL,
	[FK_Id_Persona] [int] NOT NULL,
	[Activo_Representante] [bit] NOT NULL,
 CONSTRAINT [PK_SIGEEA_Representante] PRIMARY KEY CLUSTERED 
(
	[PK_Id_Representante] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SIGEEA_Rol]    Script Date: 18/4/2016 11:55:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SIGEEA_Rol](
	[PK_Id_Rol] [int] NOT NULL,
	[Nombre_Rol] [varchar](30) NOT NULL,
 CONSTRAINT [PK_SIGEEA_Rol] PRIMARY KEY CLUSTERED 
(
	[PK_Id_Rol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SIGEEA_Rol-Permiso]    Script Date: 18/4/2016 11:55:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SIGEEA_Rol-Permiso](
	[FK_Id_Rol] [int] NOT NULL,
	[FK_Id_Permiso] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SIGEEA_TipContacto]    Script Date: 18/4/2016 11:55:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SIGEEA_TipContacto](
	[PK_Id_TipContacto] [int] NOT NULL,
	[Nombre_TipContacto] [varchar](15) NOT NULL,
 CONSTRAINT [PK_SIGEEA_TipoContacto] PRIMARY KEY CLUSTERED 
(
	[PK_Id_TipContacto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SIGEEA_TipProducto]    Script Date: 18/4/2016 11:55:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SIGEEA_TipProducto](
	[Nombre_TipProducto] [varchar](30) NOT NULL,
	[Descripcion_TipProducto] [varchar](100) NULL,
	[Calidad_TipProducto] [int] NOT NULL,
	[PK_Id_TipProducto] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_SIGEEA_TipProducto] PRIMARY KEY CLUSTERED 
(
	[PK_Id_TipProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SIGEEA_UniMedida]    Script Date: 18/4/2016 11:55:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SIGEEA_UniMedida](
	[PK_Id_UniMedida] [int] IDENTITY(1,1) NOT NULL,
	[Nombre_UniMedida] [varchar](25) NOT NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_SIGEEA_UniMedida] PRIMARY KEY CLUSTERED 
(
	[PK_Id_UniMedida] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SIGEEA_Usuario]    Script Date: 18/4/2016 11:55:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SIGEEA_Usuario](
	[PK_Id_Usuario] [int] NOT NULL,
	[Nombre_Usuario] [varchar](50) NOT NULL,
	[Clave_Usuario] [varchar](15) NOT NULL,
	[FK_Id_Rol] [int] NOT NULL,
	[FK_Id_Empleado] [int] NOT NULL,
 CONSTRAINT [PK_SIGEEA_Usuario] PRIMARY KEY CLUSTERED 
(
	[PK_Id_Usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[SIGEEA_AboCliente] ON 

INSERT [dbo].[SIGEEA_AboCliente] ([PK_Id_AboCliente], [Monto_AboCliente], [Metodo_AboCliente], [Numero_AboCliente], [Fecha_AboCliente], [FK_Id_Moneda], [FK_Id_Empleado], [Estado_AboCliente], [FK_Id_Cliente], [FK_Id_FacCliente]) VALUES (1, 1245572, 3, N'23123123', CAST(N'2016-04-17 22:32:02.243' AS DateTime), 2, 2, 1, 3, 6)
SET IDENTITY_INSERT [dbo].[SIGEEA_AboCliente] OFF
SET IDENTITY_INSERT [dbo].[SIGEEA_Asociado] ON 

INSERT [dbo].[SIGEEA_Asociado] ([Codigo_Asociado], [Estado_Asociado], [FecIngreso_Asociado], [FK_Id_Persona], [FK_Id_Representante], [PK_Id_Asociado], [FK_Id_Empresa], [FK_Id_CatAsociado]) VALUES (N'F2LBC', 1, CAST(N'2015-12-22' AS Date), 23, NULL, 2, 1, 5)
INSERT [dbo].[SIGEEA_Asociado] ([Codigo_Asociado], [Estado_Asociado], [FecIngreso_Asociado], [FK_Id_Persona], [FK_Id_Representante], [PK_Id_Asociado], [FK_Id_Empresa], [FK_Id_CatAsociado]) VALUES (N'F3AQV', 1, CAST(N'2016-01-04' AS Date), 24, NULL, 3, 1, 5)
INSERT [dbo].[SIGEEA_Asociado] ([Codigo_Asociado], [Estado_Asociado], [FecIngreso_Asociado], [FK_Id_Persona], [FK_Id_Representante], [PK_Id_Asociado], [FK_Id_Empresa], [FK_Id_CatAsociado]) VALUES (N'F4osk', 0, CAST(N'2016-02-06' AS Date), 34, NULL, 4, 1, 5)
INSERT [dbo].[SIGEEA_Asociado] ([Codigo_Asociado], [Estado_Asociado], [FecIngreso_Asociado], [FK_Id_Persona], [FK_Id_Representante], [PK_Id_Asociado], [FK_Id_Empresa], [FK_Id_CatAsociado]) VALUES (N'F5LRA', 1, CAST(N'2016-02-06' AS Date), 35, NULL, 5, 1, 5)
INSERT [dbo].[SIGEEA_Asociado] ([Codigo_Asociado], [Estado_Asociado], [FecIngreso_Asociado], [FK_Id_Persona], [FK_Id_Representante], [PK_Id_Asociado], [FK_Id_Empresa], [FK_Id_CatAsociado]) VALUES (N'F6JGE', 1, CAST(N'2016-02-20' AS Date), 38, NULL, 6, 1, 5)
SET IDENTITY_INSERT [dbo].[SIGEEA_Asociado] OFF
SET IDENTITY_INSERT [dbo].[SIGEEA_Bodega] ON 

INSERT [dbo].[SIGEEA_Bodega] ([PK_Id_Bodega], [Nombre_Bodega], [Descripcion_Bodega], [FK_Id_Empresa]) VALUES (1, N'Principal', N'Frutas Para Vender', 1)
SET IDENTITY_INSERT [dbo].[SIGEEA_Bodega] OFF
INSERT [dbo].[SIGEEA_Canton] ([PK_Id_Canton], [Nombre_Canton], [FK_Id_Provincia]) VALUES (1, N'Pérez Zeledón', 1)
INSERT [dbo].[SIGEEA_Canton] ([PK_Id_Canton], [Nombre_Canton], [FK_Id_Provincia]) VALUES (2, N'San Carlos', 2)
INSERT [dbo].[SIGEEA_Canton] ([PK_Id_Canton], [Nombre_Canton], [FK_Id_Provincia]) VALUES (3, N'Belén', 3)
INSERT [dbo].[SIGEEA_Canton] ([PK_Id_Canton], [Nombre_Canton], [FK_Id_Provincia]) VALUES (4, N'Paraíso', 4)
INSERT [dbo].[SIGEEA_Canton] ([PK_Id_Canton], [Nombre_Canton], [FK_Id_Provincia]) VALUES (5, N'Escazú', 1)
INSERT [dbo].[SIGEEA_Canton] ([PK_Id_Canton], [Nombre_Canton], [FK_Id_Provincia]) VALUES (6, N'San José', 1)
INSERT [dbo].[SIGEEA_Canton] ([PK_Id_Canton], [Nombre_Canton], [FK_Id_Provincia]) VALUES (7, N'Tibás ', 1)
SET IDENTITY_INSERT [dbo].[SIGEEA_CatAsociado] ON 

INSERT [dbo].[SIGEEA_CatAsociado] ([PK_Id_CatAsociado], [Nombre_CatAsociado], [Valor_CatAsociado]) VALUES (1, N'Pésima', 1)
INSERT [dbo].[SIGEEA_CatAsociado] ([PK_Id_CatAsociado], [Nombre_CatAsociado], [Valor_CatAsociado]) VALUES (2, N'Mala', 2)
INSERT [dbo].[SIGEEA_CatAsociado] ([PK_Id_CatAsociado], [Nombre_CatAsociado], [Valor_CatAsociado]) VALUES (3, N'Regular', 3)
INSERT [dbo].[SIGEEA_CatAsociado] ([PK_Id_CatAsociado], [Nombre_CatAsociado], [Valor_CatAsociado]) VALUES (4, N'Buena', 4)
INSERT [dbo].[SIGEEA_CatAsociado] ([PK_Id_CatAsociado], [Nombre_CatAsociado], [Valor_CatAsociado]) VALUES (5, N'Excelente', 5)
INSERT [dbo].[SIGEEA_CatAsociado] ([PK_Id_CatAsociado], [Nombre_CatAsociado], [Valor_CatAsociado]) VALUES (6, N'Premium', 6)
SET IDENTITY_INSERT [dbo].[SIGEEA_CatAsociado] OFF
SET IDENTITY_INSERT [dbo].[SIGEEA_CatCliente] ON 

INSERT [dbo].[SIGEEA_CatCliente] ([PK_Id_CatCliente], [Limite_CatCliente], [RanPagos_CatCliente], [TieMaximo_CatCliente], [Nombre_CatCliente]) VALUES (1, 5000000, N'15', N'90', N'Excelente')
INSERT [dbo].[SIGEEA_CatCliente] ([PK_Id_CatCliente], [Limite_CatCliente], [RanPagos_CatCliente], [TieMaximo_CatCliente], [Nombre_CatCliente]) VALUES (2, 4000, N'30', N'60', N'Regular')
INSERT [dbo].[SIGEEA_CatCliente] ([PK_Id_CatCliente], [Limite_CatCliente], [RanPagos_CatCliente], [TieMaximo_CatCliente], [Nombre_CatCliente]) VALUES (3, 56000, N'10', N'60', N'Malo')
SET IDENTITY_INSERT [dbo].[SIGEEA_CatCliente] OFF
SET IDENTITY_INSERT [dbo].[SIGEEA_Cliente] ON 

INSERT [dbo].[SIGEEA_Cliente] ([PK_Id_Cliente], [FK_Id_CatCliente], [FK_Id_Persona], [Estado_Cliente], [FK_Id_Empresa]) VALUES (1, 1, 30, 1, 1)
INSERT [dbo].[SIGEEA_Cliente] ([PK_Id_Cliente], [FK_Id_CatCliente], [FK_Id_Persona], [Estado_Cliente], [FK_Id_Empresa]) VALUES (3, 3, 32, 1, 1)
INSERT [dbo].[SIGEEA_Cliente] ([PK_Id_Cliente], [FK_Id_CatCliente], [FK_Id_Persona], [Estado_Cliente], [FK_Id_Empresa]) VALUES (4, 1, 33, 1, 1)
INSERT [dbo].[SIGEEA_Cliente] ([PK_Id_Cliente], [FK_Id_CatCliente], [FK_Id_Persona], [Estado_Cliente], [FK_Id_Empresa]) VALUES (5, 2, 36, 1, 1)
INSERT [dbo].[SIGEEA_Cliente] ([PK_Id_Cliente], [FK_Id_CatCliente], [FK_Id_Persona], [Estado_Cliente], [FK_Id_Empresa]) VALUES (6, 1, 37, 0, 1)
INSERT [dbo].[SIGEEA_Cliente] ([PK_Id_Cliente], [FK_Id_CatCliente], [FK_Id_Persona], [Estado_Cliente], [FK_Id_Empresa]) VALUES (7, 2, 39, 1, 1)
SET IDENTITY_INSERT [dbo].[SIGEEA_Cliente] OFF
SET IDENTITY_INSERT [dbo].[SIGEEA_Contacto] ON 

INSERT [dbo].[SIGEEA_Contacto] ([PK_Id_Contacto], [Dato_Contacto], [FK_Id_TipContacto], [FK_Id_Persona]) VALUES (1, N'83812812', 2, 23)
INSERT [dbo].[SIGEEA_Contacto] ([PK_Id_Contacto], [Dato_Contacto], [FK_Id_TipContacto], [FK_Id_Persona]) VALUES (2, N'89572171', 2, 9)
INSERT [dbo].[SIGEEA_Contacto] ([PK_Id_Contacto], [Dato_Contacto], [FK_Id_TipContacto], [FK_Id_Persona]) VALUES (3, N'luis1456.3@gmail.com', 1, 9)
INSERT [dbo].[SIGEEA_Contacto] ([PK_Id_Contacto], [Dato_Contacto], [FK_Id_TipContacto], [FK_Id_Persona]) VALUES (4, N'27724370', 3, 9)
INSERT [dbo].[SIGEEA_Contacto] ([PK_Id_Contacto], [Dato_Contacto], [FK_Id_TipContacto], [FK_Id_Persona]) VALUES (5, N'1231233', 2, 27)
SET IDENTITY_INSERT [dbo].[SIGEEA_Contacto] OFF
SET IDENTITY_INSERT [dbo].[SIGEEA_Cuota] ON 

INSERT [dbo].[SIGEEA_Cuota] ([PK_Id_Cuota], [Nombre_Cuota], [Monto_Cuota], [FecInicio_Cuota], [FecFin_Cuota], [FK_Id_Moneda]) VALUES (1, N'Anualidad 2016', 10000, CAST(N'2016-03-19 00:00:00.000' AS DateTime), CAST(N'2016-03-30 00:00:00.000' AS DateTime), 2)
INSERT [dbo].[SIGEEA_Cuota] ([PK_Id_Cuota], [Nombre_Cuota], [Monto_Cuota], [FecInicio_Cuota], [FecFin_Cuota], [FK_Id_Moneda]) VALUES (2, N'Extraordinaria 1, 2016', 5000, CAST(N'2016-03-19 00:00:00.000' AS DateTime), CAST(N'2016-06-16 00:00:00.000' AS DateTime), 2)
INSERT [dbo].[SIGEEA_Cuota] ([PK_Id_Cuota], [Nombre_Cuota], [Monto_Cuota], [FecInicio_Cuota], [FecFin_Cuota], [FK_Id_Moneda]) VALUES (6, N'Anualidad 2017', 10000, CAST(N'2016-03-20 00:00:00.000' AS DateTime), CAST(N'2017-03-20 00:00:00.000' AS DateTime), 2)
INSERT [dbo].[SIGEEA_Cuota] ([PK_Id_Cuota], [Nombre_Cuota], [Monto_Cuota], [FecInicio_Cuota], [FecFin_Cuota], [FK_Id_Moneda]) VALUES (7, N'Extraordinaria 2, 2016', 6000, CAST(N'2016-05-11 00:00:00.000' AS DateTime), CAST(N'2016-09-07 00:00:00.000' AS DateTime), 2)
SET IDENTITY_INSERT [dbo].[SIGEEA_Cuota] OFF
SET IDENTITY_INSERT [dbo].[SIGEEA_Cuota_Asociado] ON 

INSERT [dbo].[SIGEEA_Cuota_Asociado] ([PK_Id_Cuota_Asociado], [Estado_Cuota_Asociado], [Saldo_Cuota_Asociado], [FK_Id_Cuota], [FK_Id_Asociado]) VALUES (1, 1, 0, 6, 2)
INSERT [dbo].[SIGEEA_Cuota_Asociado] ([PK_Id_Cuota_Asociado], [Estado_Cuota_Asociado], [Saldo_Cuota_Asociado], [FK_Id_Cuota], [FK_Id_Asociado]) VALUES (2, 1, 0, 6, 3)
INSERT [dbo].[SIGEEA_Cuota_Asociado] ([PK_Id_Cuota_Asociado], [Estado_Cuota_Asociado], [Saldo_Cuota_Asociado], [FK_Id_Cuota], [FK_Id_Asociado]) VALUES (3, 0, 10000, 6, 4)
INSERT [dbo].[SIGEEA_Cuota_Asociado] ([PK_Id_Cuota_Asociado], [Estado_Cuota_Asociado], [Saldo_Cuota_Asociado], [FK_Id_Cuota], [FK_Id_Asociado]) VALUES (4, 0, 4000, 6, 5)
INSERT [dbo].[SIGEEA_Cuota_Asociado] ([PK_Id_Cuota_Asociado], [Estado_Cuota_Asociado], [Saldo_Cuota_Asociado], [FK_Id_Cuota], [FK_Id_Asociado]) VALUES (5, 0, 10000, 6, 6)
INSERT [dbo].[SIGEEA_Cuota_Asociado] ([PK_Id_Cuota_Asociado], [Estado_Cuota_Asociado], [Saldo_Cuota_Asociado], [FK_Id_Cuota], [FK_Id_Asociado]) VALUES (6, 0, 6000, 7, 2)
INSERT [dbo].[SIGEEA_Cuota_Asociado] ([PK_Id_Cuota_Asociado], [Estado_Cuota_Asociado], [Saldo_Cuota_Asociado], [FK_Id_Cuota], [FK_Id_Asociado]) VALUES (7, 0, 6000, 7, 3)
INSERT [dbo].[SIGEEA_Cuota_Asociado] ([PK_Id_Cuota_Asociado], [Estado_Cuota_Asociado], [Saldo_Cuota_Asociado], [FK_Id_Cuota], [FK_Id_Asociado]) VALUES (8, 0, 6000, 7, 5)
INSERT [dbo].[SIGEEA_Cuota_Asociado] ([PK_Id_Cuota_Asociado], [Estado_Cuota_Asociado], [Saldo_Cuota_Asociado], [FK_Id_Cuota], [FK_Id_Asociado]) VALUES (9, 0, 6000, 7, 6)
SET IDENTITY_INSERT [dbo].[SIGEEA_Cuota_Asociado] OFF
SET IDENTITY_INSERT [dbo].[SIGEEA_DetFacAsociado] ON 

INSERT [dbo].[SIGEEA_DetFacAsociado] ([PK_Id_DetFacAsociado], [CanTotal_DetFacAsociado], [CanNeta_DetFacAsociado], [Mercado_DetFacAsociado], [FK_Id_FacAsociado], [FK_Id_PreProCompra], [FK_Id_Lote]) VALUES (1, 100, 50, 1, 3, 1, 5)
INSERT [dbo].[SIGEEA_DetFacAsociado] ([PK_Id_DetFacAsociado], [CanTotal_DetFacAsociado], [CanNeta_DetFacAsociado], [Mercado_DetFacAsociado], [FK_Id_FacAsociado], [FK_Id_PreProCompra], [FK_Id_Lote]) VALUES (2, 100, 75, 1, 4, 1, 5)
INSERT [dbo].[SIGEEA_DetFacAsociado] ([PK_Id_DetFacAsociado], [CanTotal_DetFacAsociado], [CanNeta_DetFacAsociado], [Mercado_DetFacAsociado], [FK_Id_FacAsociado], [FK_Id_PreProCompra], [FK_Id_Lote]) VALUES (3, 200, 100, 2, 4, 1, 5)
SET IDENTITY_INSERT [dbo].[SIGEEA_DetFacAsociado] OFF
SET IDENTITY_INSERT [dbo].[SIGEEA_DetFacCliente] ON 

INSERT [dbo].[SIGEEA_DetFacCliente] ([PK_Id_DetFacCliente], [MonTotal_DetFacCliente], [MonNeto_DetFacCliente], [CanProducto_DetFacCliente], [Descuento_DetFacCliente], [PreUnidad_DetFacCliente], [Moneda_DetFacCliente], [FK_Id_FacCliente], [FK_Id_UniMedida], [FK_Id_TipProducto]) VALUES (5, 800, 776, 4, 3, 200, N'¢  ', 6, 2, 2)
INSERT [dbo].[SIGEEA_DetFacCliente] ([PK_Id_DetFacCliente], [MonTotal_DetFacCliente], [MonNeto_DetFacCliente], [CanProducto_DetFacCliente], [Descuento_DetFacCliente], [PreUnidad_DetFacCliente], [Moneda_DetFacCliente], [FK_Id_FacCliente], [FK_Id_UniMedida], [FK_Id_TipProducto]) VALUES (6, 1270200, 1244796, 4234, 2, 300, N'¢  ', 6, 1, 1)
SET IDENTITY_INSERT [dbo].[SIGEEA_DetFacCliente] OFF
SET IDENTITY_INSERT [dbo].[SIGEEA_DetInvProductos] ON 

INSERT [dbo].[SIGEEA_DetInvProductos] ([PK_Id_DetInvProductos], [Cantidad_DetInvProductos], [FK_Id_TipProducto], [FK_Id_InvProductos], [FK_Id_UniMedida]) VALUES (1, 6288, 1, 1, 1)
INSERT [dbo].[SIGEEA_DetInvProductos] ([PK_Id_DetInvProductos], [Cantidad_DetInvProductos], [FK_Id_TipProducto], [FK_Id_InvProductos], [FK_Id_UniMedida]) VALUES (2, 21966, 2, 1, 2)
SET IDENTITY_INSERT [dbo].[SIGEEA_DetInvProductos] OFF
SET IDENTITY_INSERT [dbo].[SIGEEA_DetPagEmpleados] ON 

INSERT [dbo].[SIGEEA_DetPagEmpleados] ([PK_Id_DetPagEmpleados], [Total_DetPagEmpleados], [FK_Id_PagEmpleados], [FK_Id_HorLaboradas]) VALUES (0, 1200, 0, 21)
INSERT [dbo].[SIGEEA_DetPagEmpleados] ([PK_Id_DetPagEmpleados], [Total_DetPagEmpleados], [FK_Id_PagEmpleados], [FK_Id_HorLaboradas]) VALUES (1, 105600, 2, 24)
INSERT [dbo].[SIGEEA_DetPagEmpleados] ([PK_Id_DetPagEmpleados], [Total_DetPagEmpleados], [FK_Id_PagEmpleados], [FK_Id_HorLaboradas]) VALUES (3, 0, 4, 1)
INSERT [dbo].[SIGEEA_DetPagEmpleados] ([PK_Id_DetPagEmpleados], [Total_DetPagEmpleados], [FK_Id_PagEmpleados], [FK_Id_HorLaboradas]) VALUES (4, 0, 4, 2)
INSERT [dbo].[SIGEEA_DetPagEmpleados] ([PK_Id_DetPagEmpleados], [Total_DetPagEmpleados], [FK_Id_PagEmpleados], [FK_Id_HorLaboradas]) VALUES (5, 0, 4, 4)
INSERT [dbo].[SIGEEA_DetPagEmpleados] ([PK_Id_DetPagEmpleados], [Total_DetPagEmpleados], [FK_Id_PagEmpleados], [FK_Id_HorLaboradas]) VALUES (6, 0, 4, 5)
INSERT [dbo].[SIGEEA_DetPagEmpleados] ([PK_Id_DetPagEmpleados], [Total_DetPagEmpleados], [FK_Id_PagEmpleados], [FK_Id_HorLaboradas]) VALUES (7, 0, 4, 6)
INSERT [dbo].[SIGEEA_DetPagEmpleados] ([PK_Id_DetPagEmpleados], [Total_DetPagEmpleados], [FK_Id_PagEmpleados], [FK_Id_HorLaboradas]) VALUES (8, 0, 4, 9)
INSERT [dbo].[SIGEEA_DetPagEmpleados] ([PK_Id_DetPagEmpleados], [Total_DetPagEmpleados], [FK_Id_PagEmpleados], [FK_Id_HorLaboradas]) VALUES (9, 0, 4, 10)
INSERT [dbo].[SIGEEA_DetPagEmpleados] ([PK_Id_DetPagEmpleados], [Total_DetPagEmpleados], [FK_Id_PagEmpleados], [FK_Id_HorLaboradas]) VALUES (10, 0, 4, 11)
INSERT [dbo].[SIGEEA_DetPagEmpleados] ([PK_Id_DetPagEmpleados], [Total_DetPagEmpleados], [FK_Id_PagEmpleados], [FK_Id_HorLaboradas]) VALUES (11, 0, 4, 14)
INSERT [dbo].[SIGEEA_DetPagEmpleados] ([PK_Id_DetPagEmpleados], [Total_DetPagEmpleados], [FK_Id_PagEmpleados], [FK_Id_HorLaboradas]) VALUES (12, 0, 4, 17)
INSERT [dbo].[SIGEEA_DetPagEmpleados] ([PK_Id_DetPagEmpleados], [Total_DetPagEmpleados], [FK_Id_PagEmpleados], [FK_Id_HorLaboradas]) VALUES (13, 0, 4, 18)
INSERT [dbo].[SIGEEA_DetPagEmpleados] ([PK_Id_DetPagEmpleados], [Total_DetPagEmpleados], [FK_Id_PagEmpleados], [FK_Id_HorLaboradas]) VALUES (14, 0, 4, 20)
SET IDENTITY_INSERT [dbo].[SIGEEA_DetPagEmpleados] OFF
SET IDENTITY_INSERT [dbo].[SIGEEA_Direccion] ON 

INSERT [dbo].[SIGEEA_Direccion] ([PK_Id_Direccion], [Detalles_Direccion], [FK_Id_Distrito], [FK_Id_CodPostal]) VALUES (1, N'750 metros noroeste de la Escuela Valencia', 11, NULL)
INSERT [dbo].[SIGEEA_Direccion] ([PK_Id_Direccion], [Detalles_Direccion], [FK_Id_Distrito], [FK_Id_CodPostal]) VALUES (4, N'San Andrés', 1, NULL)
INSERT [dbo].[SIGEEA_Direccion] ([PK_Id_Direccion], [Detalles_Direccion], [FK_Id_Distrito], [FK_Id_CodPostal]) VALUES (5, N'Pueblo Nuevo', 4, NULL)
INSERT [dbo].[SIGEEA_Direccion] ([PK_Id_Direccion], [Detalles_Direccion], [FK_Id_Distrito], [FK_Id_CodPostal]) VALUES (6, N'San Pedro', 7, NULL)
INSERT [dbo].[SIGEEA_Direccion] ([PK_Id_Direccion], [Detalles_Direccion], [FK_Id_Distrito], [FK_Id_CodPostal]) VALUES (7, N'SAN RAFAEL', 1, NULL)
SET IDENTITY_INSERT [dbo].[SIGEEA_Direccion] OFF
INSERT [dbo].[SIGEEA_Distrito] ([PK_Id_Distrito], [Nombre_Distrito], [FK_Id_Canton]) VALUES (1, N'San Isidro', 1)
INSERT [dbo].[SIGEEA_Distrito] ([PK_Id_Distrito], [Nombre_Distrito], [FK_Id_Canton]) VALUES (2, N'General Viejo', 1)
INSERT [dbo].[SIGEEA_Distrito] ([PK_Id_Distrito], [Nombre_Distrito], [FK_Id_Canton]) VALUES (3, N'Daniel Flores', 1)
INSERT [dbo].[SIGEEA_Distrito] ([PK_Id_Distrito], [Nombre_Distrito], [FK_Id_Canton]) VALUES (4, N'Rivas', 1)
INSERT [dbo].[SIGEEA_Distrito] ([PK_Id_Distrito], [Nombre_Distrito], [FK_Id_Canton]) VALUES (5, N'San Pedro', 1)
INSERT [dbo].[SIGEEA_Distrito] ([PK_Id_Distrito], [Nombre_Distrito], [FK_Id_Canton]) VALUES (6, N'Platanares', 1)
INSERT [dbo].[SIGEEA_Distrito] ([PK_Id_Distrito], [Nombre_Distrito], [FK_Id_Canton]) VALUES (7, N'Pejibaye', 1)
INSERT [dbo].[SIGEEA_Distrito] ([PK_Id_Distrito], [Nombre_Distrito], [FK_Id_Canton]) VALUES (8, N'Cajón', 1)
INSERT [dbo].[SIGEEA_Distrito] ([PK_Id_Distrito], [Nombre_Distrito], [FK_Id_Canton]) VALUES (9, N'Barú', 1)
INSERT [dbo].[SIGEEA_Distrito] ([PK_Id_Distrito], [Nombre_Distrito], [FK_Id_Canton]) VALUES (10, N'Río Nuevo', 1)
INSERT [dbo].[SIGEEA_Distrito] ([PK_Id_Distrito], [Nombre_Distrito], [FK_Id_Canton]) VALUES (11, N'Páramo', 1)
SET IDENTITY_INSERT [dbo].[SIGEEA_Empleado] ON 

INSERT [dbo].[SIGEEA_Empleado] ([FK_Id_Persona], [FK_Id_Puesto], [FK_Id_Escolaridad], [PK_Id_Empleado], [Estado_Empleado], [FK_Id_Empresa]) VALUES (27, NULL, 2, 2, 1, 1)
SET IDENTITY_INSERT [dbo].[SIGEEA_Empleado] OFF
SET IDENTITY_INSERT [dbo].[SIGEEA_Empresa] ON 

INSERT [dbo].[SIGEEA_Empresa] ([PK_Id_Empresa], [Nombre_Empresa], [CedJuridica_Empresa], [Direccion_Empresa], [Telefono_Empresa], [Correo_Empresa]) VALUES (1, N'ASOFRUBRUNCA', N'3002411544', N'Pueblo Nuevo de Cajón, Pérez Zeledón, San José', N'21001313', N'info@costafresh.co.cr')
SET IDENTITY_INSERT [dbo].[SIGEEA_Empresa] OFF
SET IDENTITY_INSERT [dbo].[SIGEEA_Escolaridad] ON 

INSERT [dbo].[SIGEEA_Escolaridad] ([Leer_Escolaridad], [Escribir_Escolaridad], [GradoAcad_Escolaridad], [Observaciones_Escolaridad], [PK_Id_Escolaridad]) VALUES (1, 1, 2, N'', 1)
INSERT [dbo].[SIGEEA_Escolaridad] ([Leer_Escolaridad], [Escribir_Escolaridad], [GradoAcad_Escolaridad], [Observaciones_Escolaridad], [PK_Id_Escolaridad]) VALUES (1, 1, 2, N'', 2)
SET IDENTITY_INSERT [dbo].[SIGEEA_Escolaridad] OFF
SET IDENTITY_INSERT [dbo].[SIGEEA_FacAsociado] ON 

INSERT [dbo].[SIGEEA_FacAsociado] ([PK_Id_FacAsociado], [FecEntrega_FacAsociado], [FecPago_FacAsociado], [CanTotal_FacAsociado], [CanNeta_FacAsociado], [Estado_FacAsociado], [Observaciones_FacAsociado], [FK_Id_Asociado], [FK_Id_UniMedida], [Incompleta_FacAsociado]) VALUES (1, CAST(N'2016-04-18' AS Date), CAST(N'0001-01-01' AS Date), 300, -1, 1, NULL, 3, 2, 1)
INSERT [dbo].[SIGEEA_FacAsociado] ([PK_Id_FacAsociado], [FecEntrega_FacAsociado], [FecPago_FacAsociado], [CanTotal_FacAsociado], [CanNeta_FacAsociado], [Estado_FacAsociado], [Observaciones_FacAsociado], [FK_Id_Asociado], [FK_Id_UniMedida], [Incompleta_FacAsociado]) VALUES (2, CAST(N'2016-04-18' AS Date), CAST(N'0001-01-01' AS Date), 100, -1, 1, NULL, 3, 2, 1)
INSERT [dbo].[SIGEEA_FacAsociado] ([PK_Id_FacAsociado], [FecEntrega_FacAsociado], [FecPago_FacAsociado], [CanTotal_FacAsociado], [CanNeta_FacAsociado], [Estado_FacAsociado], [Observaciones_FacAsociado], [FK_Id_Asociado], [FK_Id_UniMedida], [Incompleta_FacAsociado]) VALUES (3, CAST(N'2016-04-18' AS Date), CAST(N'0001-01-01' AS Date), 100, -1, 1, NULL, 3, 2, 0)
INSERT [dbo].[SIGEEA_FacAsociado] ([PK_Id_FacAsociado], [FecEntrega_FacAsociado], [FecPago_FacAsociado], [CanTotal_FacAsociado], [CanNeta_FacAsociado], [Estado_FacAsociado], [Observaciones_FacAsociado], [FK_Id_Asociado], [FK_Id_UniMedida], [Incompleta_FacAsociado]) VALUES (4, CAST(N'2016-04-18' AS Date), CAST(N'0001-01-01' AS Date), 300, -1, 1, NULL, 3, 2, 0)
SET IDENTITY_INSERT [dbo].[SIGEEA_FacAsociado] OFF
SET IDENTITY_INSERT [dbo].[SIGEEA_FacCliente] ON 

INSERT [dbo].[SIGEEA_FacCliente] ([PK_Id_FacCliente], [FecEntrega_FacCliente], [FecPago_FacCliente], [FecProPago_FacCliente], [Observaciones_FacCliente], [FK_Id_Cliente], [Estado_FacCliente], [MonTotal_FacCliente], [MonNeto_FacCliente], [Descuento_FacCliente], [FK_Id_Moneda], [FK_Id_Empresa], [FK_Id_Empleado]) VALUES (5, CAST(N'2016-04-17 22:29:11.697' AS DateTime), CAST(N'2016-04-17 22:29:11.697' AS DateTime), NULL, N'gfhjkvhjn', 3, N'Co', 1464, 1405.44, 4, 2, 1, 2)
INSERT [dbo].[SIGEEA_FacCliente] ([PK_Id_FacCliente], [FecEntrega_FacCliente], [FecPago_FacCliente], [FecProPago_FacCliente], [Observaciones_FacCliente], [FK_Id_Cliente], [Estado_FacCliente], [MonTotal_FacCliente], [MonNeto_FacCliente], [Descuento_FacCliente], [FK_Id_Moneda], [FK_Id_Empresa], [FK_Id_Empleado]) VALUES (6, CAST(N'2016-04-17 22:32:02.210' AS DateTime), CAST(N'2016-04-17 22:32:02.210' AS DateTime), NULL, N'Dale mostro que esta si funciono, gano el Sapri y esta funciona', 3, N'Co', 1245572, 1208204.84, 3, 2, 1, 2)
SET IDENTITY_INSERT [dbo].[SIGEEA_FacCliente] OFF
SET IDENTITY_INSERT [dbo].[SIGEEA_Familiar] ON 

INSERT [dbo].[SIGEEA_Familiar] ([PK_Id_Familiar], [FK_Id_Asociado], [Nombre_Familiar], [Escolaridad_Familiar], [DesEstudios_Familiar]) VALUES (5, 2, N'Pablo Barrantes Mora', 3, N'Administración de empresas, Universidad Nacional')
INSERT [dbo].[SIGEEA_Familiar] ([PK_Id_Familiar], [FK_Id_Asociado], [Nombre_Familiar], [Escolaridad_Familiar], [DesEstudios_Familiar]) VALUES (10, 2, N'Luis Barrantes', 3, N'Ingeniería en Sistemas, Universidad Nacional')
INSERT [dbo].[SIGEEA_Familiar] ([PK_Id_Familiar], [FK_Id_Asociado], [Nombre_Familiar], [Escolaridad_Familiar], [DesEstudios_Familiar]) VALUES (11, 2, N'Neydi Mora Vargas', 1, N'Escuela Valencia')
INSERT [dbo].[SIGEEA_Familiar] ([PK_Id_Familiar], [FK_Id_Asociado], [Nombre_Familiar], [Escolaridad_Familiar], [DesEstudios_Familiar]) VALUES (12, 5, N'Maryorie Alcácer', 3, N'Universidad de Sevilla')
INSERT [dbo].[SIGEEA_Familiar] ([PK_Id_Familiar], [FK_Id_Asociado], [Nombre_Familiar], [Escolaridad_Familiar], [DesEstudios_Familiar]) VALUES (16, 5, N'María Romero Alcácer', 2, N'Liceo Unesco')
INSERT [dbo].[SIGEEA_Familiar] ([PK_Id_Familiar], [FK_Id_Asociado], [Nombre_Familiar], [Escolaridad_Familiar], [DesEstudios_Familiar]) VALUES (56, 2, N'Claudia Barrantes Mora', 2, N'Colegio Calderón Guardia')
INSERT [dbo].[SIGEEA_Familiar] ([PK_Id_Familiar], [FK_Id_Asociado], [Nombre_Familiar], [Escolaridad_Familiar], [DesEstudios_Familiar]) VALUES (60, 2, N'Joz Daniel Ticoco Barrantes', 0, N'')
INSERT [dbo].[SIGEEA_Familiar] ([PK_Id_Familiar], [FK_Id_Asociado], [Nombre_Familiar], [Escolaridad_Familiar], [DesEstudios_Familiar]) VALUES (63, 2, N'Ericka Castro Mendez', 3, N'Administración de empresas, UMCA')
INSERT [dbo].[SIGEEA_Familiar] ([PK_Id_Familiar], [FK_Id_Asociado], [Nombre_Familiar], [Escolaridad_Familiar], [DesEstudios_Familiar]) VALUES (71, 2, N'Carlos Tinoco Jaramillo', 3, N'Diseño gráfico, UMD')
INSERT [dbo].[SIGEEA_Familiar] ([PK_Id_Familiar], [FK_Id_Asociado], [Nombre_Familiar], [Escolaridad_Familiar], [DesEstudios_Familiar]) VALUES (72, 2, N'María Paula Barrantes Castro', 0, N'')
INSERT [dbo].[SIGEEA_Familiar] ([PK_Id_Familiar], [FK_Id_Asociado], [Nombre_Familiar], [Escolaridad_Familiar], [DesEstudios_Familiar]) VALUES (74, 6, N'Gerardo', 2, N'Incompleta')
SET IDENTITY_INSERT [dbo].[SIGEEA_Familiar] OFF
SET IDENTITY_INSERT [dbo].[SIGEEA_Finca] ON 

INSERT [dbo].[SIGEEA_Finca] ([PK_Id_Finca], [Alquilada_Finca], [Codigo_Finca], [FK_Id_Direccion], [FK_Id_Asociado], [Estado_Finca], [NomDuenno_Finca], [ApeDuenno_Finca], [NumRegistro_Finca]) VALUES (3, 0, N'F1234594', 4, 3, N'1', N'Aureliano', N'Vargas', N'293939')
SET IDENTITY_INSERT [dbo].[SIGEEA_Finca] OFF
SET IDENTITY_INSERT [dbo].[SIGEEA_HorLaboradas] ON 

INSERT [dbo].[SIGEEA_HorLaboradas] ([PK_Id_HorLaboradas], [HoraInicio_HorLaboradas], [HoraFin_HorLaboradas], [Activo_HorLaboradas], [Estado_HorLaboradas], [FK_Id_Empleado], [FK_Id_Puesto]) VALUES (1, CAST(N'2016-02-10 13:11:23.727' AS DateTime), CAST(N'2016-02-10 13:13:30.323' AS DateTime), 0, 1, 2, 5)
INSERT [dbo].[SIGEEA_HorLaboradas] ([PK_Id_HorLaboradas], [HoraInicio_HorLaboradas], [HoraFin_HorLaboradas], [Activo_HorLaboradas], [Estado_HorLaboradas], [FK_Id_Empleado], [FK_Id_Puesto]) VALUES (2, CAST(N'2016-02-10 13:13:42.910' AS DateTime), CAST(N'2016-02-10 13:13:48.607' AS DateTime), 0, 1, 2, 5)
INSERT [dbo].[SIGEEA_HorLaboradas] ([PK_Id_HorLaboradas], [HoraInicio_HorLaboradas], [HoraFin_HorLaboradas], [Activo_HorLaboradas], [Estado_HorLaboradas], [FK_Id_Empleado], [FK_Id_Puesto]) VALUES (4, CAST(N'2016-02-10 17:25:11.173' AS DateTime), CAST(N'2016-02-10 17:26:25.990' AS DateTime), 0, 1, 2, 5)
INSERT [dbo].[SIGEEA_HorLaboradas] ([PK_Id_HorLaboradas], [HoraInicio_HorLaboradas], [HoraFin_HorLaboradas], [Activo_HorLaboradas], [Estado_HorLaboradas], [FK_Id_Empleado], [FK_Id_Puesto]) VALUES (5, CAST(N'2016-02-10 18:03:49.767' AS DateTime), CAST(N'2016-02-10 18:07:09.180' AS DateTime), 0, 1, 2, 5)
INSERT [dbo].[SIGEEA_HorLaboradas] ([PK_Id_HorLaboradas], [HoraInicio_HorLaboradas], [HoraFin_HorLaboradas], [Activo_HorLaboradas], [Estado_HorLaboradas], [FK_Id_Empleado], [FK_Id_Puesto]) VALUES (6, CAST(N'2016-02-10 19:38:52.280' AS DateTime), CAST(N'2016-02-10 19:43:45.303' AS DateTime), 0, 1, 2, 5)
INSERT [dbo].[SIGEEA_HorLaboradas] ([PK_Id_HorLaboradas], [HoraInicio_HorLaboradas], [HoraFin_HorLaboradas], [Activo_HorLaboradas], [Estado_HorLaboradas], [FK_Id_Empleado], [FK_Id_Puesto]) VALUES (9, CAST(N'2016-02-10 20:11:51.847' AS DateTime), CAST(N'2016-02-10 20:12:26.147' AS DateTime), 0, 1, 2, 5)
INSERT [dbo].[SIGEEA_HorLaboradas] ([PK_Id_HorLaboradas], [HoraInicio_HorLaboradas], [HoraFin_HorLaboradas], [Activo_HorLaboradas], [Estado_HorLaboradas], [FK_Id_Empleado], [FK_Id_Puesto]) VALUES (10, CAST(N'2016-02-10 20:12:52.670' AS DateTime), CAST(N'2016-02-10 20:13:03.357' AS DateTime), 0, 1, 2, 5)
INSERT [dbo].[SIGEEA_HorLaboradas] ([PK_Id_HorLaboradas], [HoraInicio_HorLaboradas], [HoraFin_HorLaboradas], [Activo_HorLaboradas], [Estado_HorLaboradas], [FK_Id_Empleado], [FK_Id_Puesto]) VALUES (11, CAST(N'2016-02-10 20:15:50.817' AS DateTime), CAST(N'2016-02-10 20:16:57.777' AS DateTime), 0, 1, 2, 4)
INSERT [dbo].[SIGEEA_HorLaboradas] ([PK_Id_HorLaboradas], [HoraInicio_HorLaboradas], [HoraFin_HorLaboradas], [Activo_HorLaboradas], [Estado_HorLaboradas], [FK_Id_Empleado], [FK_Id_Puesto]) VALUES (14, CAST(N'2016-02-10 20:25:49.147' AS DateTime), CAST(N'2016-02-10 20:26:26.260' AS DateTime), 0, 1, 2, 5)
INSERT [dbo].[SIGEEA_HorLaboradas] ([PK_Id_HorLaboradas], [HoraInicio_HorLaboradas], [HoraFin_HorLaboradas], [Activo_HorLaboradas], [Estado_HorLaboradas], [FK_Id_Empleado], [FK_Id_Puesto]) VALUES (17, CAST(N'2016-02-10 22:26:13.950' AS DateTime), CAST(N'2016-02-10 22:33:31.627' AS DateTime), 0, 1, 2, 5)
INSERT [dbo].[SIGEEA_HorLaboradas] ([PK_Id_HorLaboradas], [HoraInicio_HorLaboradas], [HoraFin_HorLaboradas], [Activo_HorLaboradas], [Estado_HorLaboradas], [FK_Id_Empleado], [FK_Id_Puesto]) VALUES (18, CAST(N'2016-02-10 22:33:44.550' AS DateTime), CAST(N'2016-02-10 22:33:49.627' AS DateTime), 0, 1, 2, 5)
INSERT [dbo].[SIGEEA_HorLaboradas] ([PK_Id_HorLaboradas], [HoraInicio_HorLaboradas], [HoraFin_HorLaboradas], [Activo_HorLaboradas], [Estado_HorLaboradas], [FK_Id_Empleado], [FK_Id_Puesto]) VALUES (20, CAST(N'2016-02-10 22:40:35.380' AS DateTime), CAST(N'2016-02-10 22:42:10.863' AS DateTime), 0, 1, 2, 6)
INSERT [dbo].[SIGEEA_HorLaboradas] ([PK_Id_HorLaboradas], [HoraInicio_HorLaboradas], [HoraFin_HorLaboradas], [Activo_HorLaboradas], [Estado_HorLaboradas], [FK_Id_Empleado], [FK_Id_Puesto]) VALUES (21, CAST(N'2016-02-10 23:53:45.017' AS DateTime), CAST(N'2016-02-11 00:54:01.790' AS DateTime), 0, 1, 2, 6)
INSERT [dbo].[SIGEEA_HorLaboradas] ([PK_Id_HorLaboradas], [HoraInicio_HorLaboradas], [HoraFin_HorLaboradas], [Activo_HorLaboradas], [Estado_HorLaboradas], [FK_Id_Empleado], [FK_Id_Puesto]) VALUES (22, CAST(N'2016-02-11 12:26:34.257' AS DateTime), CAST(N'2016-03-14 15:37:28.763' AS DateTime), 0, 1, 2, 4)
INSERT [dbo].[SIGEEA_HorLaboradas] ([PK_Id_HorLaboradas], [HoraInicio_HorLaboradas], [HoraFin_HorLaboradas], [Activo_HorLaboradas], [Estado_HorLaboradas], [FK_Id_Empleado], [FK_Id_Puesto]) VALUES (23, CAST(N'2016-02-15 12:27:34.700' AS DateTime), CAST(N'2016-02-15 15:27:42.093' AS DateTime), 0, 1, 2, 6)
INSERT [dbo].[SIGEEA_HorLaboradas] ([PK_Id_HorLaboradas], [HoraInicio_HorLaboradas], [HoraFin_HorLaboradas], [Activo_HorLaboradas], [Estado_HorLaboradas], [FK_Id_Empleado], [FK_Id_Puesto]) VALUES (24, CAST(N'2016-03-14 15:37:48.330' AS DateTime), CAST(N'2016-03-18 15:47:23.980' AS DateTime), 0, 1, 2, 4)
INSERT [dbo].[SIGEEA_HorLaboradas] ([PK_Id_HorLaboradas], [HoraInicio_HorLaboradas], [HoraFin_HorLaboradas], [Activo_HorLaboradas], [Estado_HorLaboradas], [FK_Id_Empleado], [FK_Id_Puesto]) VALUES (1024, CAST(N'2016-03-18 16:01:46.757' AS DateTime), CAST(N'2016-04-16 19:57:56.903' AS DateTime), 0, 0, 2, 6)
SET IDENTITY_INSERT [dbo].[SIGEEA_HorLaboradas] OFF
SET IDENTITY_INSERT [dbo].[SIGEEA_Insumo] ON 

INSERT [dbo].[SIGEEA_Insumo] ([PK_Id_Insumo], [Nombre_Insumo], [Descripcion_Insumo], [Estado_Insumo]) VALUES (2, N'Bolsas', N'Plasticas 2x2', 1)
INSERT [dbo].[SIGEEA_Insumo] ([PK_Id_Insumo], [Nombre_Insumo], [Descripcion_Insumo], [Estado_Insumo]) VALUES (3, N'Caja', N'2x2', 1)
INSERT [dbo].[SIGEEA_Insumo] ([PK_Id_Insumo], [Nombre_Insumo], [Descripcion_Insumo], [Estado_Insumo]) VALUES (4, N'Caja', N'4x2', 1)
INSERT [dbo].[SIGEEA_Insumo] ([PK_Id_Insumo], [Nombre_Insumo], [Descripcion_Insumo], [Estado_Insumo]) VALUES (5, N'Botellas', N'Cloro', 1)
INSERT [dbo].[SIGEEA_Insumo] ([PK_Id_Insumo], [Nombre_Insumo], [Descripcion_Insumo], [Estado_Insumo]) VALUES (6, N'Empaques', N'De 5kg', 1)
SET IDENTITY_INSERT [dbo].[SIGEEA_Insumo] OFF
SET IDENTITY_INSERT [dbo].[SIGEEA_InvInsumo] ON 

INSERT [dbo].[SIGEEA_InvInsumo] ([PK_IdInvInsumo], [Cantidad_InvInsumo], [FK_Id_Insumo], [FK_UniMedida]) VALUES (1, 2000, 2, 1)
INSERT [dbo].[SIGEEA_InvInsumo] ([PK_IdInvInsumo], [Cantidad_InvInsumo], [FK_Id_Insumo], [FK_UniMedida]) VALUES (2, 897, 3, 2)
INSERT [dbo].[SIGEEA_InvInsumo] ([PK_IdInvInsumo], [Cantidad_InvInsumo], [FK_Id_Insumo], [FK_UniMedida]) VALUES (3, 23123, 4, 3)
INSERT [dbo].[SIGEEA_InvInsumo] ([PK_IdInvInsumo], [Cantidad_InvInsumo], [FK_Id_Insumo], [FK_UniMedida]) VALUES (4, 600, 5, 2)
INSERT [dbo].[SIGEEA_InvInsumo] ([PK_IdInvInsumo], [Cantidad_InvInsumo], [FK_Id_Insumo], [FK_UniMedida]) VALUES (5, 400, 6, 1)
SET IDENTITY_INSERT [dbo].[SIGEEA_InvInsumo] OFF
SET IDENTITY_INSERT [dbo].[SIGEEA_InvProductos] ON 

INSERT [dbo].[SIGEEA_InvProductos] ([PK_Id_InvProductos], [Descripcion_InvProductos], [FK_Id_Bodega]) VALUES (1, N'A la venta', 1)
SET IDENTITY_INSERT [dbo].[SIGEEA_InvProductos] OFF
SET IDENTITY_INSERT [dbo].[SIGEEA_Lote] ON 

INSERT [dbo].[SIGEEA_Lote] ([PK_Id_Lote], [Codigo_Lote], [Tamanno_Lote], [FK_Id_Finca]) VALUES (5, N'12323', N'700       ', 3)
SET IDENTITY_INSERT [dbo].[SIGEEA_Lote] OFF
SET IDENTITY_INSERT [dbo].[SIGEEA_Moneda] ON 

INSERT [dbo].[SIGEEA_Moneda] ([PK_Id_Moneda], [PreCompra_Moneda], [PreVenta_Moneda], [Nombre_Moneda], [FK_Id_Empresa], [Simbolo_Moneda]) VALUES (1, 528.95, 541.43, N'Dolar', 1, N'$')
INSERT [dbo].[SIGEEA_Moneda] ([PK_Id_Moneda], [PreCompra_Moneda], [PreVenta_Moneda], [Nombre_Moneda], [FK_Id_Empresa], [Simbolo_Moneda]) VALUES (2, 1, 1, N'Colón', 1, N'¢')
SET IDENTITY_INSERT [dbo].[SIGEEA_Moneda] OFF
SET IDENTITY_INSERT [dbo].[SIGEEA_Nacionalidad] ON 

INSERT [dbo].[SIGEEA_Nacionalidad] ([PK_Id_Nacionalidad], [Nombre_Nacionalidad]) VALUES (4, N'Canadiense')
INSERT [dbo].[SIGEEA_Nacionalidad] ([PK_Id_Nacionalidad], [Nombre_Nacionalidad]) VALUES (1, N'Costarricense')
INSERT [dbo].[SIGEEA_Nacionalidad] ([PK_Id_Nacionalidad], [Nombre_Nacionalidad]) VALUES (6, N'Española')
INSERT [dbo].[SIGEEA_Nacionalidad] ([PK_Id_Nacionalidad], [Nombre_Nacionalidad]) VALUES (3, N'Estadounidense')
INSERT [dbo].[SIGEEA_Nacionalidad] ([PK_Id_Nacionalidad], [Nombre_Nacionalidad]) VALUES (2, N'Nicaragüense ')
INSERT [dbo].[SIGEEA_Nacionalidad] ([PK_Id_Nacionalidad], [Nombre_Nacionalidad]) VALUES (5, N'Panameña')
INSERT [dbo].[SIGEEA_Nacionalidad] ([PK_Id_Nacionalidad], [Nombre_Nacionalidad]) VALUES (7, N'Portugues')
SET IDENTITY_INSERT [dbo].[SIGEEA_Nacionalidad] OFF
SET IDENTITY_INSERT [dbo].[SIGEEA_PagEmpleados] ON 

INSERT [dbo].[SIGEEA_PagEmpleados] ([PK_Id_PagEmpleados], [Fecha_PagEmpleados], [FK_Id_Empleado], [FK_Id_Cuenta]) VALUES (0, CAST(N'2016-03-14' AS Date), 2, NULL)
INSERT [dbo].[SIGEEA_PagEmpleados] ([PK_Id_PagEmpleados], [Fecha_PagEmpleados], [FK_Id_Empleado], [FK_Id_Cuenta]) VALUES (1, CAST(N'2016-03-18' AS Date), 2, NULL)
INSERT [dbo].[SIGEEA_PagEmpleados] ([PK_Id_PagEmpleados], [Fecha_PagEmpleados], [FK_Id_Empleado], [FK_Id_Cuenta]) VALUES (2, CAST(N'2016-03-18' AS Date), 2, NULL)
INSERT [dbo].[SIGEEA_PagEmpleados] ([PK_Id_PagEmpleados], [Fecha_PagEmpleados], [FK_Id_Empleado], [FK_Id_Cuenta]) VALUES (3, CAST(N'2016-03-18' AS Date), 2, NULL)
INSERT [dbo].[SIGEEA_PagEmpleados] ([PK_Id_PagEmpleados], [Fecha_PagEmpleados], [FK_Id_Empleado], [FK_Id_Cuenta]) VALUES (4, CAST(N'2016-03-18' AS Date), 2, NULL)
INSERT [dbo].[SIGEEA_PagEmpleados] ([PK_Id_PagEmpleados], [Fecha_PagEmpleados], [FK_Id_Empleado], [FK_Id_Cuenta]) VALUES (5, CAST(N'2016-03-18' AS Date), 2, NULL)
SET IDENTITY_INSERT [dbo].[SIGEEA_PagEmpleados] OFF
SET IDENTITY_INSERT [dbo].[SIGEEA_Pais] ON 

INSERT [dbo].[SIGEEA_Pais] ([PK_Id_Pais], [Nombre_Pais]) VALUES (1, N'Costa Rica')
INSERT [dbo].[SIGEEA_Pais] ([PK_Id_Pais], [Nombre_Pais]) VALUES (2, N'Estados Unidos')
INSERT [dbo].[SIGEEA_Pais] ([PK_Id_Pais], [Nombre_Pais]) VALUES (3, N'Canadá')
INSERT [dbo].[SIGEEA_Pais] ([PK_Id_Pais], [Nombre_Pais]) VALUES (4, N'España')
INSERT [dbo].[SIGEEA_Pais] ([PK_Id_Pais], [Nombre_Pais]) VALUES (5, N'Italia')
SET IDENTITY_INSERT [dbo].[SIGEEA_Pais] OFF
SET IDENTITY_INSERT [dbo].[SIGEEA_Persona] ON 

INSERT [dbo].[SIGEEA_Persona] ([PriNombre_Persona], [SegNombre_Persona], [PriApellido_Persona], [SegApellido_Persona], [Genero_Persona], [FecNacimiento_Persona], [FK_Id_Direccion], [FK_Id_Nacionalidad], [PK_Id_Persona], [Tipo_Persona], [CedJuridica_Persona], [CedParticular_Persona]) VALUES (N'Luis', N'', N'Barrantes', N'Mora', N'M', CAST(N'1995-02-28' AS Date), NULL, 1, 9, 1, NULL, N'115990900')
INSERT [dbo].[SIGEEA_Persona] ([PriNombre_Persona], [SegNombre_Persona], [PriApellido_Persona], [SegApellido_Persona], [Genero_Persona], [FecNacimiento_Persona], [FK_Id_Direccion], [FK_Id_Nacionalidad], [PK_Id_Persona], [Tipo_Persona], [CedJuridica_Persona], [CedParticular_Persona]) VALUES (N'Pablo', N'Daniel', N'Barrantes', N'Mora', N'M', CAST(N'1986-11-18' AS Date), NULL, 1, 22, 1, NULL, N'113000086')
INSERT [dbo].[SIGEEA_Persona] ([PriNombre_Persona], [SegNombre_Persona], [PriApellido_Persona], [SegApellido_Persona], [Genero_Persona], [FecNacimiento_Persona], [FK_Id_Direccion], [FK_Id_Nacionalidad], [PK_Id_Persona], [Tipo_Persona], [CedJuridica_Persona], [CedParticular_Persona]) VALUES (N'Lesmes', N'Guillermo', N'Barrantes', N'Calderón', N'M', CAST(N'1966-11-05' AS Date), NULL, 1, 23, 1, NULL, N'16190373')
INSERT [dbo].[SIGEEA_Persona] ([PriNombre_Persona], [SegNombre_Persona], [PriApellido_Persona], [SegApellido_Persona], [Genero_Persona], [FecNacimiento_Persona], [FK_Id_Direccion], [FK_Id_Nacionalidad], [PK_Id_Persona], [Tipo_Persona], [CedJuridica_Persona], [CedParticular_Persona]) VALUES (N'Aureliano', N'', N'Quesada', N'Vargas', N'M', CAST(N'1978-08-16' AS Date), 5, 1, 24, 1, NULL, N'120301922')
INSERT [dbo].[SIGEEA_Persona] ([PriNombre_Persona], [SegNombre_Persona], [PriApellido_Persona], [SegApellido_Persona], [Genero_Persona], [FecNacimiento_Persona], [FK_Id_Direccion], [FK_Id_Nacionalidad], [PK_Id_Persona], [Tipo_Persona], [CedJuridica_Persona], [CedParticular_Persona]) VALUES (N'Guarro', N'', N'Jiménez', N'Picado', N'M', CAST(N'1983-07-13' AS Date), 6, 1, 27, 1, NULL, N'123456789')
INSERT [dbo].[SIGEEA_Persona] ([PriNombre_Persona], [SegNombre_Persona], [PriApellido_Persona], [SegApellido_Persona], [Genero_Persona], [FecNacimiento_Persona], [FK_Id_Direccion], [FK_Id_Nacionalidad], [PK_Id_Persona], [Tipo_Persona], [CedJuridica_Persona], [CedParticular_Persona]) VALUES (N'Wallmart', NULL, NULL, NULL, NULL, CAST(N'1975-03-01' AS Date), NULL, 1, 29, 0, N'1212121212121212', NULL)
INSERT [dbo].[SIGEEA_Persona] ([PriNombre_Persona], [SegNombre_Persona], [PriApellido_Persona], [SegApellido_Persona], [Genero_Persona], [FecNacimiento_Persona], [FK_Id_Direccion], [FK_Id_Nacionalidad], [PK_Id_Persona], [Tipo_Persona], [CedJuridica_Persona], [CedParticular_Persona]) VALUES (N'Manuel', N'Antonio', N'Alvarado', N'Fallas', N'M', CAST(N'1995-04-25' AS Date), NULL, 1, 30, 1, NULL, N'116060659')
INSERT [dbo].[SIGEEA_Persona] ([PriNombre_Persona], [SegNombre_Persona], [PriApellido_Persona], [SegApellido_Persona], [Genero_Persona], [FecNacimiento_Persona], [FK_Id_Direccion], [FK_Id_Nacionalidad], [PK_Id_Persona], [Tipo_Persona], [CedJuridica_Persona], [CedParticular_Persona]) VALUES (N'Rayo', N'Antonio', N'Fallas', N'Alvarado', N'M', CAST(N'1995-04-25' AS Date), NULL, 1, 31, 1, NULL, N'111111111')
INSERT [dbo].[SIGEEA_Persona] ([PriNombre_Persona], [SegNombre_Persona], [PriApellido_Persona], [SegApellido_Persona], [Genero_Persona], [FecNacimiento_Persona], [FK_Id_Direccion], [FK_Id_Nacionalidad], [PK_Id_Persona], [Tipo_Persona], [CedJuridica_Persona], [CedParticular_Persona]) VALUES (N'Elvis', N'Jesus', N'Alvarado', N'Fallas', N'M', CAST(N'1992-10-16' AS Date), NULL, 1, 32, 1, NULL, N'115210895')
INSERT [dbo].[SIGEEA_Persona] ([PriNombre_Persona], [SegNombre_Persona], [PriApellido_Persona], [SegApellido_Persona], [Genero_Persona], [FecNacimiento_Persona], [FK_Id_Direccion], [FK_Id_Nacionalidad], [PK_Id_Persona], [Tipo_Persona], [CedJuridica_Persona], [CedParticular_Persona]) VALUES (N'Yisus', N'', N'Cruz', N'Olivo', N'M', CAST(N'1981-12-10' AS Date), NULL, 1, 33, 1, NULL, N'14912123')
INSERT [dbo].[SIGEEA_Persona] ([PriNombre_Persona], [SegNombre_Persona], [PriApellido_Persona], [SegApellido_Persona], [Genero_Persona], [FecNacimiento_Persona], [FK_Id_Direccion], [FK_Id_Nacionalidad], [PK_Id_Persona], [Tipo_Persona], [CedJuridica_Persona], [CedParticular_Persona]) VALUES (N'osososos', N'', N'skksksks', N'ksksksks', N'F', CAST(N'2016-02-02' AS Date), NULL, 1, 34, 1, NULL, N'28282882')
INSERT [dbo].[SIGEEA_Persona] ([PriNombre_Persona], [SegNombre_Persona], [PriApellido_Persona], [SegApellido_Persona], [Genero_Persona], [FecNacimiento_Persona], [FK_Id_Direccion], [FK_Id_Nacionalidad], [PK_Id_Persona], [Tipo_Persona], [CedJuridica_Persona], [CedParticular_Persona]) VALUES (N'Lucía', N'María', N'Romero', N'Alcácer', N'F', CAST(N'1989-06-12' AS Date), NULL, 6, 35, 1, NULL, N'293919293')
INSERT [dbo].[SIGEEA_Persona] ([PriNombre_Persona], [SegNombre_Persona], [PriApellido_Persona], [SegApellido_Persona], [Genero_Persona], [FecNacimiento_Persona], [FK_Id_Direccion], [FK_Id_Nacionalidad], [PK_Id_Persona], [Tipo_Persona], [CedJuridica_Persona], [CedParticular_Persona]) VALUES (N'Ramiro', N'', N'Delgado', N'Moreno', N'M', CAST(N'1990-06-12' AS Date), NULL, 1, 36, 1, NULL, N'2929292')
INSERT [dbo].[SIGEEA_Persona] ([PriNombre_Persona], [SegNombre_Persona], [PriApellido_Persona], [SegApellido_Persona], [Genero_Persona], [FecNacimiento_Persona], [FK_Id_Direccion], [FK_Id_Nacionalidad], [PK_Id_Persona], [Tipo_Persona], [CedJuridica_Persona], [CedParticular_Persona]) VALUES (N'Maria', N'Magndalena', N'Fallas', N'Ureña', N'F', CAST(N'1968-02-27' AS Date), NULL, 1, 37, 1, NULL, N'107480319')
INSERT [dbo].[SIGEEA_Persona] ([PriNombre_Persona], [SegNombre_Persona], [PriApellido_Persona], [SegApellido_Persona], [Genero_Persona], [FecNacimiento_Persona], [FK_Id_Direccion], [FK_Id_Nacionalidad], [PK_Id_Persona], [Tipo_Persona], [CedJuridica_Persona], [CedParticular_Persona]) VALUES (N'Javier', N'Jose', N'Garro', N'Elizondo', N'M', CAST(N'1994-03-14' AS Date), 7, 6, 38, 1, NULL, N'115660099')
INSERT [dbo].[SIGEEA_Persona] ([PriNombre_Persona], [SegNombre_Persona], [PriApellido_Persona], [SegApellido_Persona], [Genero_Persona], [FecNacimiento_Persona], [FK_Id_Direccion], [FK_Id_Nacionalidad], [PK_Id_Persona], [Tipo_Persona], [CedJuridica_Persona], [CedParticular_Persona]) VALUES (N'Maria', N'Magdalena', N'Fallas', N'Ureña', N'F', CAST(N'1968-02-27' AS Date), NULL, 1, 39, 1, NULL, N'10748319')
SET IDENTITY_INSERT [dbo].[SIGEEA_Persona] OFF
SET IDENTITY_INSERT [dbo].[SIGEEA_PreProCompra] ON 

INSERT [dbo].[SIGEEA_PreProCompra] ([PreNacional_PreProCompra], [PreExtranjero_PreProCompra], [FecRegistro_PreProCompra], [FK_Id_TipProducto], [PK_Id_PreProCompra]) VALUES (1000, 1200, CAST(N'2016-04-18 11:38:40.900' AS DateTime), 1, 1)
SET IDENTITY_INSERT [dbo].[SIGEEA_PreProCompra] OFF
SET IDENTITY_INSERT [dbo].[SIGEEA_PreProVenta] ON 

INSERT [dbo].[SIGEEA_PreProVenta] ([PreNacional_PreProVenta], [PreExtranjero_PreProVenta], [FecRegistro_PreProVenta], [FK_Id_TipProducto], [PK_Id_PreProVenta], [FK_Id_Moneda]) VALUES (300, 1, CAST(N'2016-02-12 00:00:00.000' AS DateTime), 1, 2, 1)
INSERT [dbo].[SIGEEA_PreProVenta] ([PreNacional_PreProVenta], [PreExtranjero_PreProVenta], [FecRegistro_PreProVenta], [FK_Id_TipProducto], [PK_Id_PreProVenta], [FK_Id_Moneda]) VALUES (200, 0.26, CAST(N'2016-02-12 00:00:00.000' AS DateTime), 2, 3, 1)
SET IDENTITY_INSERT [dbo].[SIGEEA_PreProVenta] OFF
INSERT [dbo].[SIGEEA_Provincia] ([PK_Id_Provincia], [Nombre_Provincia], [FK_Id_Pais]) VALUES (1, N'San José', 1)
INSERT [dbo].[SIGEEA_Provincia] ([PK_Id_Provincia], [Nombre_Provincia], [FK_Id_Pais]) VALUES (2, N'Alajuela', 1)
INSERT [dbo].[SIGEEA_Provincia] ([PK_Id_Provincia], [Nombre_Provincia], [FK_Id_Pais]) VALUES (3, N'Heredia', 1)
INSERT [dbo].[SIGEEA_Provincia] ([PK_Id_Provincia], [Nombre_Provincia], [FK_Id_Pais]) VALUES (4, N'Cartago', 1)
INSERT [dbo].[SIGEEA_Provincia] ([PK_Id_Provincia], [Nombre_Provincia], [FK_Id_Pais]) VALUES (5, N'Guanacaste', 1)
INSERT [dbo].[SIGEEA_Provincia] ([PK_Id_Provincia], [Nombre_Provincia], [FK_Id_Pais]) VALUES (6, N'Limón', 1)
INSERT [dbo].[SIGEEA_Provincia] ([PK_Id_Provincia], [Nombre_Provincia], [FK_Id_Pais]) VALUES (7, N'Puntarenas', 1)
SET IDENTITY_INSERT [dbo].[SIGEEA_PueTemporal] ON 

INSERT [dbo].[SIGEEA_PueTemporal] ([PK_Id_Puesto], [Nombre_Puesto], [Tarifa_Puesto], [Actualizacion_Puesto], [Estado_Puesto]) VALUES (1, N'Empacador', 1200, CAST(N'2016-02-06 16:36:48.487' AS DateTime), 0)
INSERT [dbo].[SIGEEA_PueTemporal] ([PK_Id_Puesto], [Nombre_Puesto], [Tarifa_Puesto], [Actualizacion_Puesto], [Estado_Puesto]) VALUES (2, N'Empacador', 1300, CAST(N'2016-02-06 16:37:25.383' AS DateTime), 0)
INSERT [dbo].[SIGEEA_PueTemporal] ([PK_Id_Puesto], [Nombre_Puesto], [Tarifa_Puesto], [Actualizacion_Puesto], [Estado_Puesto]) VALUES (3, N'Empacador', 1400, CAST(N'2016-02-06 16:39:03.310' AS DateTime), 0)
INSERT [dbo].[SIGEEA_PueTemporal] ([PK_Id_Puesto], [Nombre_Puesto], [Tarifa_Puesto], [Actualizacion_Puesto], [Estado_Puesto]) VALUES (4, N'Conserje', 1100, CAST(N'2016-02-06 16:52:47.330' AS DateTime), 1)
INSERT [dbo].[SIGEEA_PueTemporal] ([PK_Id_Puesto], [Nombre_Puesto], [Tarifa_Puesto], [Actualizacion_Puesto], [Estado_Puesto]) VALUES (5, N'Empacador', 1500, CAST(N'2016-02-06 16:59:59.027' AS DateTime), 0)
INSERT [dbo].[SIGEEA_PueTemporal] ([PK_Id_Puesto], [Nombre_Puesto], [Tarifa_Puesto], [Actualizacion_Puesto], [Estado_Puesto]) VALUES (6, N'Empacador', 1200, CAST(N'2016-02-10 22:40:21.870' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[SIGEEA_PueTemporal] OFF
INSERT [dbo].[SIGEEA_TipContacto] ([PK_Id_TipContacto], [Nombre_TipContacto]) VALUES (1, N'Correo')
INSERT [dbo].[SIGEEA_TipContacto] ([PK_Id_TipContacto], [Nombre_TipContacto]) VALUES (2, N'Tel. Movil')
INSERT [dbo].[SIGEEA_TipContacto] ([PK_Id_TipContacto], [Nombre_TipContacto]) VALUES (3, N'Tel. Residencia')
INSERT [dbo].[SIGEEA_TipContacto] ([PK_Id_TipContacto], [Nombre_TipContacto]) VALUES (4, N'Tel. Trabajo')
INSERT [dbo].[SIGEEA_TipContacto] ([PK_Id_TipContacto], [Nombre_TipContacto]) VALUES (5, N'Fax')
INSERT [dbo].[SIGEEA_TipContacto] ([PK_Id_TipContacto], [Nombre_TipContacto]) VALUES (6, N'Otro')
SET IDENTITY_INSERT [dbo].[SIGEEA_TipProducto] ON 

INSERT [dbo].[SIGEEA_TipProducto] ([Nombre_TipProducto], [Descripcion_TipProducto], [Calidad_TipProducto], [PK_Id_TipProducto]) VALUES (N'Rambutan', N'Rojas', 1, 1)
INSERT [dbo].[SIGEEA_TipProducto] ([Nombre_TipProducto], [Descripcion_TipProducto], [Calidad_TipProducto], [PK_Id_TipProducto]) VALUES (N'Mango', N'Verde', 3, 2)
SET IDENTITY_INSERT [dbo].[SIGEEA_TipProducto] OFF
SET IDENTITY_INSERT [dbo].[SIGEEA_UniMedida] ON 

INSERT [dbo].[SIGEEA_UniMedida] ([PK_Id_UniMedida], [Nombre_UniMedida], [Estado]) VALUES (1, N'Uni', 1)
INSERT [dbo].[SIGEEA_UniMedida] ([PK_Id_UniMedida], [Nombre_UniMedida], [Estado]) VALUES (2, N'Kg', 1)
INSERT [dbo].[SIGEEA_UniMedida] ([PK_Id_UniMedida], [Nombre_UniMedida], [Estado]) VALUES (3, N'Gr', 1)
SET IDENTITY_INSERT [dbo].[SIGEEA_UniMedida] OFF
SET ANSI_PADDING ON

GO
/****** Object:  Index [UK_SIGEEA_Nacionalidad]    Script Date: 18/4/2016 11:55:41 a. m. ******/
ALTER TABLE [dbo].[SIGEEA_Nacionalidad] ADD  CONSTRAINT [UK_SIGEEA_Nacionalidad] UNIQUE NONCLUSTERED 
(
	[Nombre_Nacionalidad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UK_CedParticular_Persona]    Script Date: 18/4/2016 11:55:41 a. m. ******/
ALTER TABLE [dbo].[SIGEEA_Persona] ADD  CONSTRAINT [UK_CedParticular_Persona] UNIQUE NONCLUSTERED 
(
	[CedParticular_Persona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[SIGEEA_AboCliente]  WITH CHECK ADD  CONSTRAINT [FK_SIGEEA_AboCliente_SIGEEA_Cliente] FOREIGN KEY([FK_Id_Cliente])
REFERENCES [dbo].[SIGEEA_Cliente] ([PK_Id_Cliente])
GO
ALTER TABLE [dbo].[SIGEEA_AboCliente] CHECK CONSTRAINT [FK_SIGEEA_AboCliente_SIGEEA_Cliente]
GO
ALTER TABLE [dbo].[SIGEEA_AboCliente]  WITH CHECK ADD  CONSTRAINT [FK_SIGEEA_AboCliente_SIGEEA_FacCliente] FOREIGN KEY([FK_Id_FacCliente])
REFERENCES [dbo].[SIGEEA_FacCliente] ([PK_Id_FacCliente])
GO
ALTER TABLE [dbo].[SIGEEA_AboCliente] CHECK CONSTRAINT [FK_SIGEEA_AboCliente_SIGEEA_FacCliente]
GO
ALTER TABLE [dbo].[SIGEEA_AboCliente]  WITH CHECK ADD  CONSTRAINT [FK_SIGEEA_PagCliente_SIGEEA_Empleado] FOREIGN KEY([FK_Id_Empleado])
REFERENCES [dbo].[SIGEEA_Empleado] ([PK_Id_Empleado])
GO
ALTER TABLE [dbo].[SIGEEA_AboCliente] CHECK CONSTRAINT [FK_SIGEEA_PagCliente_SIGEEA_Empleado]
GO
ALTER TABLE [dbo].[SIGEEA_AboCliente]  WITH CHECK ADD  CONSTRAINT [FK_SIGEEA_PagCliente_SIGEEA_Moneda] FOREIGN KEY([FK_Id_Moneda])
REFERENCES [dbo].[SIGEEA_Moneda] ([PK_Id_Moneda])
GO
ALTER TABLE [dbo].[SIGEEA_AboCliente] CHECK CONSTRAINT [FK_SIGEEA_PagCliente_SIGEEA_Moneda]
GO
ALTER TABLE [dbo].[SIGEEA_AsiAsamblea]  WITH CHECK ADD  CONSTRAINT [FK_SIGEEA_AsiAsamblea_SIGEEA_Asamblea] FOREIGN KEY([FK_Id_Asamblea])
REFERENCES [dbo].[SIGEEA_Asamblea] ([PK_Id_Asamblea])
GO
ALTER TABLE [dbo].[SIGEEA_AsiAsamblea] CHECK CONSTRAINT [FK_SIGEEA_AsiAsamblea_SIGEEA_Asamblea]
GO
ALTER TABLE [dbo].[SIGEEA_AsiAsamblea]  WITH CHECK ADD  CONSTRAINT [FK_SIGEEA_AsiAsamblea_SIGEEA_Asociado] FOREIGN KEY([FK_Id_Asociado])
REFERENCES [dbo].[SIGEEA_Asociado] ([PK_Id_Asociado])
GO
ALTER TABLE [dbo].[SIGEEA_AsiAsamblea] CHECK CONSTRAINT [FK_SIGEEA_AsiAsamblea_SIGEEA_Asociado]
GO
ALTER TABLE [dbo].[SIGEEA_Asociado]  WITH CHECK ADD  CONSTRAINT [FK_SIGEEA_Asociado_SIGEEA_CatAsociado] FOREIGN KEY([FK_Id_CatAsociado])
REFERENCES [dbo].[SIGEEA_CatAsociado] ([PK_Id_CatAsociado])
GO
ALTER TABLE [dbo].[SIGEEA_Asociado] CHECK CONSTRAINT [FK_SIGEEA_Asociado_SIGEEA_CatAsociado]
GO
ALTER TABLE [dbo].[SIGEEA_Asociado]  WITH CHECK ADD  CONSTRAINT [FK_SIGEEA_Asociado_SIGEEA_Empresa] FOREIGN KEY([FK_Id_Empresa])
REFERENCES [dbo].[SIGEEA_Empresa] ([PK_Id_Empresa])
GO
ALTER TABLE [dbo].[SIGEEA_Asociado] CHECK CONSTRAINT [FK_SIGEEA_Asociado_SIGEEA_Empresa]
GO
ALTER TABLE [dbo].[SIGEEA_Asociado]  WITH CHECK ADD  CONSTRAINT [FK_SIGEEA_Asociado_SIGEEA_Persona] FOREIGN KEY([FK_Id_Persona])
REFERENCES [dbo].[SIGEEA_Persona] ([PK_Id_Persona])
GO
ALTER TABLE [dbo].[SIGEEA_Asociado] CHECK CONSTRAINT [FK_SIGEEA_Asociado_SIGEEA_Persona]
GO
ALTER TABLE [dbo].[SIGEEA_Asociado]  WITH CHECK ADD  CONSTRAINT [FK_SIGEEA_Asociado_SIGEEA_Representante] FOREIGN KEY([FK_Id_Representante])
REFERENCES [dbo].[SIGEEA_Representante] ([PK_Id_Representante])
GO
ALTER TABLE [dbo].[SIGEEA_Asociado] CHECK CONSTRAINT [FK_SIGEEA_Asociado_SIGEEA_Representante]
GO
ALTER TABLE [dbo].[SIGEEA_AsociadoXPagAsociado]  WITH CHECK ADD  CONSTRAINT [FK_SIGEEA_AsociadoXPagAsociado_SIGEEA_Asociado] FOREIGN KEY([FK_Id_Asociado])
REFERENCES [dbo].[SIGEEA_Asociado] ([PK_Id_Asociado])
GO
ALTER TABLE [dbo].[SIGEEA_AsociadoXPagAsociado] CHECK CONSTRAINT [FK_SIGEEA_AsociadoXPagAsociado_SIGEEA_Asociado]
GO
ALTER TABLE [dbo].[SIGEEA_AsociadoXPagAsociado]  WITH CHECK ADD  CONSTRAINT [FK_SIGEEA_AsociadoXPagAsociado_SIGEEA_PagAsociado] FOREIGN KEY([FK_Id_PagAsociado])
REFERENCES [dbo].[SIGEEA_PagAsociado] ([PK_Id_PagAsociado])
GO
ALTER TABLE [dbo].[SIGEEA_AsociadoXPagAsociado] CHECK CONSTRAINT [FK_SIGEEA_AsociadoXPagAsociado_SIGEEA_PagAsociado]
GO
ALTER TABLE [dbo].[SIGEEA_Banco]  WITH CHECK ADD  CONSTRAINT [FK_SIGEEA_Banco_SIGEEA_Empresa] FOREIGN KEY([FK_Id_Empresa])
REFERENCES [dbo].[SIGEEA_Empresa] ([PK_Id_Empresa])
GO
ALTER TABLE [dbo].[SIGEEA_Banco] CHECK CONSTRAINT [FK_SIGEEA_Banco_SIGEEA_Empresa]
GO
ALTER TABLE [dbo].[SIGEEA_Bodega]  WITH CHECK ADD  CONSTRAINT [FK_SIGEEA_Bodega_SIGEEA_Empresa] FOREIGN KEY([FK_Id_Empresa])
REFERENCES [dbo].[SIGEEA_Empresa] ([PK_Id_Empresa])
GO
ALTER TABLE [dbo].[SIGEEA_Bodega] CHECK CONSTRAINT [FK_SIGEEA_Bodega_SIGEEA_Empresa]
GO
ALTER TABLE [dbo].[SIGEEA_Canton]  WITH CHECK ADD  CONSTRAINT [FK_SIGEEA_Canton_SIGEEA_Provincia] FOREIGN KEY([FK_Id_Provincia])
REFERENCES [dbo].[SIGEEA_Provincia] ([PK_Id_Provincia])
GO
ALTER TABLE [dbo].[SIGEEA_Canton] CHECK CONSTRAINT [FK_SIGEEA_Canton_SIGEEA_Provincia]
GO
ALTER TABLE [dbo].[SIGEEA_Cliente]  WITH CHECK ADD  CONSTRAINT [FK_SIGEEA_Cliente_SIGEEA_CreCliente] FOREIGN KEY([FK_Id_CatCliente])
REFERENCES [dbo].[SIGEEA_CatCliente] ([PK_Id_CatCliente])
GO
ALTER TABLE [dbo].[SIGEEA_Cliente] CHECK CONSTRAINT [FK_SIGEEA_Cliente_SIGEEA_CreCliente]
GO
ALTER TABLE [dbo].[SIGEEA_Cliente]  WITH CHECK ADD  CONSTRAINT [FK_SIGEEA_Cliente_SIGEEA_Empresa] FOREIGN KEY([FK_Id_Empresa])
REFERENCES [dbo].[SIGEEA_Empresa] ([PK_Id_Empresa])
GO
ALTER TABLE [dbo].[SIGEEA_Cliente] CHECK CONSTRAINT [FK_SIGEEA_Cliente_SIGEEA_Empresa]
GO
ALTER TABLE [dbo].[SIGEEA_Cliente]  WITH CHECK ADD  CONSTRAINT [FK_SIGEEA_Cliente_SIGEEA_Persona] FOREIGN KEY([FK_Id_Persona])
REFERENCES [dbo].[SIGEEA_Persona] ([PK_Id_Persona])
GO
ALTER TABLE [dbo].[SIGEEA_Cliente] CHECK CONSTRAINT [FK_SIGEEA_Cliente_SIGEEA_Persona]
GO
ALTER TABLE [dbo].[SIGEEA_CodPostal]  WITH CHECK ADD  CONSTRAINT [FK_SIGEEA_CodPostal_SIGEEA_Estado] FOREIGN KEY([FK_Id_Estado])
REFERENCES [dbo].[SIGEEA_Estado] ([PK_Id_Estado])
GO
ALTER TABLE [dbo].[SIGEEA_CodPostal] CHECK CONSTRAINT [FK_SIGEEA_CodPostal_SIGEEA_Estado]
GO
ALTER TABLE [dbo].[SIGEEA_Contacto]  WITH CHECK ADD  CONSTRAINT [FK_SIGEEA_Contacto_SIGEEA_Persona] FOREIGN KEY([FK_Id_Persona])
REFERENCES [dbo].[SIGEEA_Persona] ([PK_Id_Persona])
GO
ALTER TABLE [dbo].[SIGEEA_Contacto] CHECK CONSTRAINT [FK_SIGEEA_Contacto_SIGEEA_Persona]
GO
ALTER TABLE [dbo].[SIGEEA_Contacto]  WITH CHECK ADD  CONSTRAINT [FK_SIGEEA_Contacto_SIGEEA_TipoContacto] FOREIGN KEY([FK_Id_TipContacto])
REFERENCES [dbo].[SIGEEA_TipContacto] ([PK_Id_TipContacto])
GO
ALTER TABLE [dbo].[SIGEEA_Contacto] CHECK CONSTRAINT [FK_SIGEEA_Contacto_SIGEEA_TipoContacto]
GO
ALTER TABLE [dbo].[SIGEEA_CreCliente]  WITH CHECK ADD  CONSTRAINT [FK_SIGEEA_CreCliente_SIGEEA_Cliente] FOREIGN KEY([FK_Id_Cliente])
REFERENCES [dbo].[SIGEEA_Cliente] ([PK_Id_Cliente])
GO
ALTER TABLE [dbo].[SIGEEA_CreCliente] CHECK CONSTRAINT [FK_SIGEEA_CreCliente_SIGEEA_Cliente]
GO
ALTER TABLE [dbo].[SIGEEA_CreCliente]  WITH CHECK ADD  CONSTRAINT [FK_SIGEEA_CreCliente_SIGEEA_Moneda] FOREIGN KEY([FK_Id_Moneda])
REFERENCES [dbo].[SIGEEA_Moneda] ([PK_Id_Moneda])
GO
ALTER TABLE [dbo].[SIGEEA_CreCliente] CHECK CONSTRAINT [FK_SIGEEA_CreCliente_SIGEEA_Moneda]
GO
ALTER TABLE [dbo].[SIGEEA_Cuenta]  WITH CHECK ADD  CONSTRAINT [FK_SIGEEA_Cuenta_SIGEEA_Banco] FOREIGN KEY([FK_Id_Banco])
REFERENCES [dbo].[SIGEEA_Banco] ([PK_Id_Banco])
GO
ALTER TABLE [dbo].[SIGEEA_Cuenta] CHECK CONSTRAINT [FK_SIGEEA_Cuenta_SIGEEA_Banco]
GO
ALTER TABLE [dbo].[SIGEEA_Cuenta]  WITH CHECK ADD  CONSTRAINT [FK_SIGEEA_Cuenta_SIGEEA_Persona] FOREIGN KEY([FK_Id_Persona])
REFERENCES [dbo].[SIGEEA_Persona] ([PK_Id_Persona])
GO
ALTER TABLE [dbo].[SIGEEA_Cuenta] CHECK CONSTRAINT [FK_SIGEEA_Cuenta_SIGEEA_Persona]
GO
ALTER TABLE [dbo].[SIGEEA_Cuota]  WITH CHECK ADD  CONSTRAINT [FK_SIGEEA_Cuota_SIGEEA_Moneda] FOREIGN KEY([FK_Id_Moneda])
REFERENCES [dbo].[SIGEEA_Moneda] ([PK_Id_Moneda])
GO
ALTER TABLE [dbo].[SIGEEA_Cuota] CHECK CONSTRAINT [FK_SIGEEA_Cuota_SIGEEA_Moneda]
GO
ALTER TABLE [dbo].[SIGEEA_Cuota_Asociado]  WITH CHECK ADD  CONSTRAINT [FK_SIGEEA_Cuota_Asociado_SIGEEA_Asociado] FOREIGN KEY([FK_Id_Asociado])
REFERENCES [dbo].[SIGEEA_Asociado] ([PK_Id_Asociado])
GO
ALTER TABLE [dbo].[SIGEEA_Cuota_Asociado] CHECK CONSTRAINT [FK_SIGEEA_Cuota_Asociado_SIGEEA_Asociado]
GO
ALTER TABLE [dbo].[SIGEEA_Cuota_Asociado]  WITH CHECK ADD  CONSTRAINT [FK_SIGEEA_Cuota_Asociado_SIGEEA_Cuota] FOREIGN KEY([FK_Id_Cuota])
REFERENCES [dbo].[SIGEEA_Cuota] ([PK_Id_Cuota])
GO
ALTER TABLE [dbo].[SIGEEA_Cuota_Asociado] CHECK CONSTRAINT [FK_SIGEEA_Cuota_Asociado_SIGEEA_Cuota]
GO
ALTER TABLE [dbo].[SIGEEA_DetFacAsociado]  WITH CHECK ADD  CONSTRAINT [FK_SIGEEA_DetFacAsociado_SIGEEA_FacAsociado] FOREIGN KEY([FK_Id_FacAsociado])
REFERENCES [dbo].[SIGEEA_FacAsociado] ([PK_Id_FacAsociado])
GO
ALTER TABLE [dbo].[SIGEEA_DetFacAsociado] CHECK CONSTRAINT [FK_SIGEEA_DetFacAsociado_SIGEEA_FacAsociado]
GO
ALTER TABLE [dbo].[SIGEEA_DetFacAsociado]  WITH CHECK ADD  CONSTRAINT [FK_SIGEEA_DetFacAsociado_SIGEEA_PreProCompra] FOREIGN KEY([FK_Id_PreProCompra])
REFERENCES [dbo].[SIGEEA_PreProCompra] ([PK_Id_PreProCompra])
GO
ALTER TABLE [dbo].[SIGEEA_DetFacAsociado] CHECK CONSTRAINT [FK_SIGEEA_DetFacAsociado_SIGEEA_PreProCompra]
GO
ALTER TABLE [dbo].[SIGEEA_DetFacCliente]  WITH CHECK ADD  CONSTRAINT [FK_SIGEEA_DetFacCliente_SIGEEA_FacCliente] FOREIGN KEY([FK_Id_FacCliente])
REFERENCES [dbo].[SIGEEA_FacCliente] ([PK_Id_FacCliente])
GO
ALTER TABLE [dbo].[SIGEEA_DetFacCliente] CHECK CONSTRAINT [FK_SIGEEA_DetFacCliente_SIGEEA_FacCliente]
GO
ALTER TABLE [dbo].[SIGEEA_DetFacCliente]  WITH CHECK ADD  CONSTRAINT [FK_SIGEEA_DetFacCliente_SIGEEA_TipProducto] FOREIGN KEY([FK_Id_TipProducto])
REFERENCES [dbo].[SIGEEA_TipProducto] ([PK_Id_TipProducto])
GO
ALTER TABLE [dbo].[SIGEEA_DetFacCliente] CHECK CONSTRAINT [FK_SIGEEA_DetFacCliente_SIGEEA_TipProducto]
GO
ALTER TABLE [dbo].[SIGEEA_DetFacCliente]  WITH CHECK ADD  CONSTRAINT [FK_SIGEEA_DetFacCliente_SIGEEA_UniMedida] FOREIGN KEY([FK_Id_UniMedida])
REFERENCES [dbo].[SIGEEA_UniMedida] ([PK_Id_UniMedida])
GO
ALTER TABLE [dbo].[SIGEEA_DetFacCliente] CHECK CONSTRAINT [FK_SIGEEA_DetFacCliente_SIGEEA_UniMedida]
GO
ALTER TABLE [dbo].[SIGEEA_DetFacInsumo]  WITH CHECK ADD  CONSTRAINT [FK_SIGEEA_DetFacInsumo_SIGEEA_Moneda] FOREIGN KEY([FK_Id_Moneda])
REFERENCES [dbo].[SIGEEA_Moneda] ([PK_Id_Moneda])
GO
ALTER TABLE [dbo].[SIGEEA_DetFacInsumo] CHECK CONSTRAINT [FK_SIGEEA_DetFacInsumo_SIGEEA_Moneda]
GO
ALTER TABLE [dbo].[SIGEEA_DetFacInsumo]  WITH CHECK ADD  CONSTRAINT [FK_SIGEEA_Pago_Compra_SIGEEA_Compra_Producto] FOREIGN KEY([FK_Id_FacInsumo])
REFERENCES [dbo].[SIGEEA_FacInsumo] ([PK_Id_FacInsumo])
GO
ALTER TABLE [dbo].[SIGEEA_DetFacInsumo] CHECK CONSTRAINT [FK_SIGEEA_Pago_Compra_SIGEEA_Compra_Producto]
GO
ALTER TABLE [dbo].[SIGEEA_DetInvProductos]  WITH CHECK ADD  CONSTRAINT [FK_SIGEEA_DetInvProductos_SIGEEA_InvProductos] FOREIGN KEY([FK_Id_InvProductos])
REFERENCES [dbo].[SIGEEA_InvProductos] ([PK_Id_InvProductos])
GO
ALTER TABLE [dbo].[SIGEEA_DetInvProductos] CHECK CONSTRAINT [FK_SIGEEA_DetInvProductos_SIGEEA_InvProductos]
GO
ALTER TABLE [dbo].[SIGEEA_DetInvProductos]  WITH CHECK ADD  CONSTRAINT [FK_SIGEEA_DetInvProductos_SIGEEA_TipProducto] FOREIGN KEY([FK_Id_TipProducto])
REFERENCES [dbo].[SIGEEA_TipProducto] ([PK_Id_TipProducto])
GO
ALTER TABLE [dbo].[SIGEEA_DetInvProductos] CHECK CONSTRAINT [FK_SIGEEA_DetInvProductos_SIGEEA_TipProducto]
GO
ALTER TABLE [dbo].[SIGEEA_DetInvProductos]  WITH CHECK ADD  CONSTRAINT [FK_SIGEEA_DetInvProductos_SIGEEA_UniMedida] FOREIGN KEY([FK_Id_UniMedida])
REFERENCES [dbo].[SIGEEA_UniMedida] ([PK_Id_UniMedida])
GO
ALTER TABLE [dbo].[SIGEEA_DetInvProductos] CHECK CONSTRAINT [FK_SIGEEA_DetInvProductos_SIGEEA_UniMedida]
GO
ALTER TABLE [dbo].[SIGEEA_DetPagEmpleados]  WITH CHECK ADD  CONSTRAINT [FK_SIGEEA_DetPagEmpleados_SIGEEA_HorLaboradas] FOREIGN KEY([FK_Id_HorLaboradas])
REFERENCES [dbo].[SIGEEA_HorLaboradas] ([PK_Id_HorLaboradas])
GO
ALTER TABLE [dbo].[SIGEEA_DetPagEmpleados] CHECK CONSTRAINT [FK_SIGEEA_DetPagEmpleados_SIGEEA_HorLaboradas]
GO
ALTER TABLE [dbo].[SIGEEA_DetPagEmpleados]  WITH CHECK ADD  CONSTRAINT [FK_SIGEEA_DetPagEmpleados_SIGEEA_PagEmpleados] FOREIGN KEY([FK_Id_PagEmpleados])
REFERENCES [dbo].[SIGEEA_PagEmpleados] ([PK_Id_PagEmpleados])
GO
ALTER TABLE [dbo].[SIGEEA_DetPagEmpleados] CHECK CONSTRAINT [FK_SIGEEA_DetPagEmpleados_SIGEEA_PagEmpleados]
GO
ALTER TABLE [dbo].[SIGEEA_Direccion]  WITH CHECK ADD  CONSTRAINT [FK_SIGEEA_Direccion_SIGEEA_CodPostal] FOREIGN KEY([FK_Id_CodPostal])
REFERENCES [dbo].[SIGEEA_CodPostal] ([PK_Id_CodPostal])
GO
ALTER TABLE [dbo].[SIGEEA_Direccion] CHECK CONSTRAINT [FK_SIGEEA_Direccion_SIGEEA_CodPostal]
GO
ALTER TABLE [dbo].[SIGEEA_Direccion]  WITH CHECK ADD  CONSTRAINT [FK_SIGEEA_Direccion_SIGGEA_Distrito] FOREIGN KEY([FK_Id_Distrito])
REFERENCES [dbo].[SIGEEA_Distrito] ([PK_Id_Distrito])
GO
ALTER TABLE [dbo].[SIGEEA_Direccion] CHECK CONSTRAINT [FK_SIGEEA_Direccion_SIGGEA_Distrito]
GO
ALTER TABLE [dbo].[SIGEEA_Distrito]  WITH CHECK ADD  CONSTRAINT [FK_SIGGEA_Distrito_SIGEEA_Canton] FOREIGN KEY([FK_Id_Canton])
REFERENCES [dbo].[SIGEEA_Canton] ([PK_Id_Canton])
GO
ALTER TABLE [dbo].[SIGEEA_Distrito] CHECK CONSTRAINT [FK_SIGGEA_Distrito_SIGEEA_Canton]
GO
ALTER TABLE [dbo].[SIGEEA_Empleado]  WITH CHECK ADD  CONSTRAINT [FK_SIGEEA_Empleado_SIGEEA_Empresa] FOREIGN KEY([FK_Id_Empresa])
REFERENCES [dbo].[SIGEEA_Empresa] ([PK_Id_Empresa])
GO
ALTER TABLE [dbo].[SIGEEA_Empleado] CHECK CONSTRAINT [FK_SIGEEA_Empleado_SIGEEA_Empresa]
GO
ALTER TABLE [dbo].[SIGEEA_Empleado]  WITH CHECK ADD  CONSTRAINT [FK_SIGEEA_Empleado_SIGEEA_Escolaridad] FOREIGN KEY([FK_Id_Escolaridad])
REFERENCES [dbo].[SIGEEA_Escolaridad] ([PK_Id_Escolaridad])
GO
ALTER TABLE [dbo].[SIGEEA_Empleado] CHECK CONSTRAINT [FK_SIGEEA_Empleado_SIGEEA_Escolaridad]
GO
ALTER TABLE [dbo].[SIGEEA_Empleado]  WITH CHECK ADD  CONSTRAINT [FK_SIGEEA_Empleado_SIGEEA_Persona] FOREIGN KEY([FK_Id_Persona])
REFERENCES [dbo].[SIGEEA_Persona] ([PK_Id_Persona])
GO
ALTER TABLE [dbo].[SIGEEA_Empleado] CHECK CONSTRAINT [FK_SIGEEA_Empleado_SIGEEA_Persona]
GO
ALTER TABLE [dbo].[SIGEEA_Empleado]  WITH CHECK ADD  CONSTRAINT [FK_SIGEEA_Empleado_SIGEEA_PueTemporal] FOREIGN KEY([FK_Id_Puesto])
REFERENCES [dbo].[SIGEEA_PueTemporal] ([PK_Id_Puesto])
GO
ALTER TABLE [dbo].[SIGEEA_Empleado] CHECK CONSTRAINT [FK_SIGEEA_Empleado_SIGEEA_PueTemporal]
GO
ALTER TABLE [dbo].[SIGEEA_Estado]  WITH CHECK ADD  CONSTRAINT [FK_SIGEEA_Estado_SIGEEA_Pais] FOREIGN KEY([FK_Id_Pais])
REFERENCES [dbo].[SIGEEA_Pais] ([PK_Id_Pais])
GO
ALTER TABLE [dbo].[SIGEEA_Estado] CHECK CONSTRAINT [FK_SIGEEA_Estado_SIGEEA_Pais]
GO
ALTER TABLE [dbo].[SIGEEA_Experiencia]  WITH CHECK ADD  CONSTRAINT [FK_SIGEEA_Experiencia_SIGEEA_Empleado] FOREIGN KEY([FK_Id_Empleado])
REFERENCES [dbo].[SIGEEA_Empleado] ([PK_Id_Empleado])
GO
ALTER TABLE [dbo].[SIGEEA_Experiencia] CHECK CONSTRAINT [FK_SIGEEA_Experiencia_SIGEEA_Empleado]
GO
ALTER TABLE [dbo].[SIGEEA_FacAsociado]  WITH CHECK ADD  CONSTRAINT [FK_SIGEEA_FacAsociado_SIGEEA_Asociado] FOREIGN KEY([FK_Id_Asociado])
REFERENCES [dbo].[SIGEEA_Asociado] ([PK_Id_Asociado])
GO
ALTER TABLE [dbo].[SIGEEA_FacAsociado] CHECK CONSTRAINT [FK_SIGEEA_FacAsociado_SIGEEA_Asociado]
GO
ALTER TABLE [dbo].[SIGEEA_FacAsociado]  WITH CHECK ADD  CONSTRAINT [FK_SIGEEA_FacAsociado_SIGEEA_UniMedida] FOREIGN KEY([FK_Id_UniMedida])
REFERENCES [dbo].[SIGEEA_UniMedida] ([PK_Id_UniMedida])
GO
ALTER TABLE [dbo].[SIGEEA_FacAsociado] CHECK CONSTRAINT [FK_SIGEEA_FacAsociado_SIGEEA_UniMedida]
GO
ALTER TABLE [dbo].[SIGEEA_FacCliente]  WITH CHECK ADD  CONSTRAINT [FK_SIGEEA_FacCliente_SIGEEA_Cliente] FOREIGN KEY([FK_Id_Cliente])
REFERENCES [dbo].[SIGEEA_Cliente] ([PK_Id_Cliente])
GO
ALTER TABLE [dbo].[SIGEEA_FacCliente] CHECK CONSTRAINT [FK_SIGEEA_FacCliente_SIGEEA_Cliente]
GO
ALTER TABLE [dbo].[SIGEEA_FacCliente]  WITH CHECK ADD  CONSTRAINT [FK_SIGEEA_FacCliente_SIGEEA_Empleado] FOREIGN KEY([FK_Id_Empleado])
REFERENCES [dbo].[SIGEEA_Empleado] ([PK_Id_Empleado])
GO
ALTER TABLE [dbo].[SIGEEA_FacCliente] CHECK CONSTRAINT [FK_SIGEEA_FacCliente_SIGEEA_Empleado]
GO
ALTER TABLE [dbo].[SIGEEA_FacCliente]  WITH CHECK ADD  CONSTRAINT [FK_SIGEEA_FacCliente_SIGEEA_Empresa] FOREIGN KEY([FK_Id_Empresa])
REFERENCES [dbo].[SIGEEA_Empresa] ([PK_Id_Empresa])
GO
ALTER TABLE [dbo].[SIGEEA_FacCliente] CHECK CONSTRAINT [FK_SIGEEA_FacCliente_SIGEEA_Empresa]
GO
ALTER TABLE [dbo].[SIGEEA_FacCliente]  WITH CHECK ADD  CONSTRAINT [FK_SIGEEA_FacCliente_SIGEEA_Moneda] FOREIGN KEY([FK_Id_Moneda])
REFERENCES [dbo].[SIGEEA_Moneda] ([PK_Id_Moneda])
GO
ALTER TABLE [dbo].[SIGEEA_FacCliente] CHECK CONSTRAINT [FK_SIGEEA_FacCliente_SIGEEA_Moneda]
GO
ALTER TABLE [dbo].[SIGEEA_FacInsumo]  WITH CHECK ADD  CONSTRAINT [FK_SIGEEA_Compra_Producto_SIGEEA_Producto] FOREIGN KEY([FK_Id_Insumo])
REFERENCES [dbo].[SIGEEA_Insumo] ([PK_Id_Insumo])
GO
ALTER TABLE [dbo].[SIGEEA_FacInsumo] CHECK CONSTRAINT [FK_SIGEEA_Compra_Producto_SIGEEA_Producto]
GO
ALTER TABLE [dbo].[SIGEEA_FacInsumo]  WITH CHECK ADD  CONSTRAINT [FK_SIGEEA_Compra_Producto_SIGEEA_Proveedor] FOREIGN KEY([FK_Id_Proveedor])
REFERENCES [dbo].[SIGEEA_Proveedor] ([PK_Id_Proveedor])
GO
ALTER TABLE [dbo].[SIGEEA_FacInsumo] CHECK CONSTRAINT [FK_SIGEEA_Compra_Producto_SIGEEA_Proveedor]
GO
ALTER TABLE [dbo].[SIGEEA_FacInsumo]  WITH CHECK ADD  CONSTRAINT [FK_SIGEEA_FacInsumo_SIGEEA_Empleado] FOREIGN KEY([FK_Id_Empleado])
REFERENCES [dbo].[SIGEEA_Empleado] ([PK_Id_Empleado])
GO
ALTER TABLE [dbo].[SIGEEA_FacInsumo] CHECK CONSTRAINT [FK_SIGEEA_FacInsumo_SIGEEA_Empleado]
GO
ALTER TABLE [dbo].[SIGEEA_Familiar]  WITH CHECK ADD  CONSTRAINT [FK_SIGEEA_Familiar_SIGEEA_Asociado] FOREIGN KEY([FK_Id_Asociado])
REFERENCES [dbo].[SIGEEA_Asociado] ([PK_Id_Asociado])
GO
ALTER TABLE [dbo].[SIGEEA_Familiar] CHECK CONSTRAINT [FK_SIGEEA_Familiar_SIGEEA_Asociado]
GO
ALTER TABLE [dbo].[SIGEEA_Finca]  WITH CHECK ADD  CONSTRAINT [FK_SIGEEA_Finca_SIGEEA_Asociado] FOREIGN KEY([FK_Id_Asociado])
REFERENCES [dbo].[SIGEEA_Asociado] ([PK_Id_Asociado])
GO
ALTER TABLE [dbo].[SIGEEA_Finca] CHECK CONSTRAINT [FK_SIGEEA_Finca_SIGEEA_Asociado]
GO
ALTER TABLE [dbo].[SIGEEA_Finca]  WITH CHECK ADD  CONSTRAINT [FK_SIGEEA_Finca_SIGEEA_Direccion] FOREIGN KEY([FK_Id_Direccion])
REFERENCES [dbo].[SIGEEA_Direccion] ([PK_Id_Direccion])
GO
ALTER TABLE [dbo].[SIGEEA_Finca] CHECK CONSTRAINT [FK_SIGEEA_Finca_SIGEEA_Direccion]
GO
ALTER TABLE [dbo].[SIGEEA_HisDelictivo]  WITH CHECK ADD  CONSTRAINT [FK_SIGEEA_HisDelictivo_SIGEEA_Empleado] FOREIGN KEY([FK_Id_Empleado])
REFERENCES [dbo].[SIGEEA_Empleado] ([PK_Id_Empleado])
GO
ALTER TABLE [dbo].[SIGEEA_HisDelictivo] CHECK CONSTRAINT [FK_SIGEEA_HisDelictivo_SIGEEA_Empleado]
GO
ALTER TABLE [dbo].[SIGEEA_HorLaboradas]  WITH CHECK ADD  CONSTRAINT [FK_SIGEEA_HorLaboradas_SIGEEA_Empleado] FOREIGN KEY([FK_Id_Empleado])
REFERENCES [dbo].[SIGEEA_Empleado] ([PK_Id_Empleado])
GO
ALTER TABLE [dbo].[SIGEEA_HorLaboradas] CHECK CONSTRAINT [FK_SIGEEA_HorLaboradas_SIGEEA_Empleado]
GO
ALTER TABLE [dbo].[SIGEEA_HorLaboradas]  WITH CHECK ADD  CONSTRAINT [FK_SIGEEA_HorLaboradas_SIGEEA_PueTemporal] FOREIGN KEY([FK_Id_Puesto])
REFERENCES [dbo].[SIGEEA_PueTemporal] ([PK_Id_Puesto])
GO
ALTER TABLE [dbo].[SIGEEA_HorLaboradas] CHECK CONSTRAINT [FK_SIGEEA_HorLaboradas_SIGEEA_PueTemporal]
GO
ALTER TABLE [dbo].[SIGEEA_InvInsumo]  WITH CHECK ADD  CONSTRAINT [FK_SIGEEA_InvInsumo_SIGEEA_Insumo] FOREIGN KEY([FK_Id_Insumo])
REFERENCES [dbo].[SIGEEA_Insumo] ([PK_Id_Insumo])
GO
ALTER TABLE [dbo].[SIGEEA_InvInsumo] CHECK CONSTRAINT [FK_SIGEEA_InvInsumo_SIGEEA_Insumo]
GO
ALTER TABLE [dbo].[SIGEEA_InvInsumo]  WITH CHECK ADD  CONSTRAINT [FK_SIGEEA_InvInsumo_SIGEEA_UniMedida] FOREIGN KEY([FK_UniMedida])
REFERENCES [dbo].[SIGEEA_UniMedida] ([PK_Id_UniMedida])
GO
ALTER TABLE [dbo].[SIGEEA_InvInsumo] CHECK CONSTRAINT [FK_SIGEEA_InvInsumo_SIGEEA_UniMedida]
GO
ALTER TABLE [dbo].[SIGEEA_InvProductos]  WITH CHECK ADD  CONSTRAINT [FK_SIGEEA_InvProductos_SIGEEA_Bodega] FOREIGN KEY([FK_Id_Bodega])
REFERENCES [dbo].[SIGEEA_Bodega] ([PK_Id_Bodega])
GO
ALTER TABLE [dbo].[SIGEEA_InvProductos] CHECK CONSTRAINT [FK_SIGEEA_InvProductos_SIGEEA_Bodega]
GO
ALTER TABLE [dbo].[SIGEEA_Lote]  WITH CHECK ADD  CONSTRAINT [FK_SIGEEA_Lote_SIGEEA_Finca] FOREIGN KEY([FK_Id_Finca])
REFERENCES [dbo].[SIGEEA_Finca] ([PK_Id_Finca])
GO
ALTER TABLE [dbo].[SIGEEA_Lote] CHECK CONSTRAINT [FK_SIGEEA_Lote_SIGEEA_Finca]
GO
ALTER TABLE [dbo].[SIGEEA_PagEmpleados]  WITH CHECK ADD  CONSTRAINT [FK_SIGEEA_PagEmpleados_SIGEEA_Empleado] FOREIGN KEY([FK_Id_Empleado])
REFERENCES [dbo].[SIGEEA_Empleado] ([PK_Id_Empleado])
GO
ALTER TABLE [dbo].[SIGEEA_PagEmpleados] CHECK CONSTRAINT [FK_SIGEEA_PagEmpleados_SIGEEA_Empleado]
GO
ALTER TABLE [dbo].[SIGEEA_PedInsumo]  WITH CHECK ADD  CONSTRAINT [FK_SIGEEA_PedInsumo_SIGEEA_Empleado] FOREIGN KEY([FK_Id_Empleado])
REFERENCES [dbo].[SIGEEA_Empleado] ([PK_Id_Empleado])
GO
ALTER TABLE [dbo].[SIGEEA_PedInsumo] CHECK CONSTRAINT [FK_SIGEEA_PedInsumo_SIGEEA_Empleado]
GO
ALTER TABLE [dbo].[SIGEEA_PedInsumo]  WITH CHECK ADD  CONSTRAINT [FK_SIGEEA_PedInsumo_SIGEEA_Insumo] FOREIGN KEY([FK_Id_Insumo])
REFERENCES [dbo].[SIGEEA_Insumo] ([PK_Id_Insumo])
GO
ALTER TABLE [dbo].[SIGEEA_PedInsumo] CHECK CONSTRAINT [FK_SIGEEA_PedInsumo_SIGEEA_Insumo]
GO
ALTER TABLE [dbo].[SIGEEA_Permiso-Modulo]  WITH CHECK ADD  CONSTRAINT [FK_SIGEEA_Permiso-Modulo_SIGEEA_Modulo] FOREIGN KEY([FK_Id_Modulo])
REFERENCES [dbo].[SIGEEA_Modulo] ([PK_Id_Modulo])
GO
ALTER TABLE [dbo].[SIGEEA_Permiso-Modulo] CHECK CONSTRAINT [FK_SIGEEA_Permiso-Modulo_SIGEEA_Modulo]
GO
ALTER TABLE [dbo].[SIGEEA_Permiso-Modulo]  WITH CHECK ADD  CONSTRAINT [FK_SIGEEA_Permiso-Modulo_SIGEEA_Permiso] FOREIGN KEY([FK_Id_Permiso])
REFERENCES [dbo].[SIGEEA_Permiso] ([PK_Id_Permiso])
GO
ALTER TABLE [dbo].[SIGEEA_Permiso-Modulo] CHECK CONSTRAINT [FK_SIGEEA_Permiso-Modulo_SIGEEA_Permiso]
GO
ALTER TABLE [dbo].[SIGEEA_Persona]  WITH CHECK ADD  CONSTRAINT [FK_SIGEEA_Persona_SIGEEA_Direccion] FOREIGN KEY([FK_Id_Direccion])
REFERENCES [dbo].[SIGEEA_Direccion] ([PK_Id_Direccion])
GO
ALTER TABLE [dbo].[SIGEEA_Persona] CHECK CONSTRAINT [FK_SIGEEA_Persona_SIGEEA_Direccion]
GO
ALTER TABLE [dbo].[SIGEEA_Persona]  WITH CHECK ADD  CONSTRAINT [FK_SIGEEA_Persona_SIGEEA_Nacionalidad] FOREIGN KEY([FK_Id_Nacionalidad])
REFERENCES [dbo].[SIGEEA_Nacionalidad] ([PK_Id_Nacionalidad])
GO
ALTER TABLE [dbo].[SIGEEA_Persona] CHECK CONSTRAINT [FK_SIGEEA_Persona_SIGEEA_Nacionalidad]
GO
ALTER TABLE [dbo].[SIGEEA_PreProCompra]  WITH CHECK ADD  CONSTRAINT [FK_SIGEEA_PreProCompra_SIGEEA_TipProducto] FOREIGN KEY([FK_Id_TipProducto])
REFERENCES [dbo].[SIGEEA_TipProducto] ([PK_Id_TipProducto])
GO
ALTER TABLE [dbo].[SIGEEA_PreProCompra] CHECK CONSTRAINT [FK_SIGEEA_PreProCompra_SIGEEA_TipProducto]
GO
ALTER TABLE [dbo].[SIGEEA_PreProVenta]  WITH CHECK ADD  CONSTRAINT [FK_SIGEEA_PreProVenta_SIGEEA_Moneda] FOREIGN KEY([FK_Id_Moneda])
REFERENCES [dbo].[SIGEEA_Moneda] ([PK_Id_Moneda])
GO
ALTER TABLE [dbo].[SIGEEA_PreProVenta] CHECK CONSTRAINT [FK_SIGEEA_PreProVenta_SIGEEA_Moneda]
GO
ALTER TABLE [dbo].[SIGEEA_PreProVenta]  WITH CHECK ADD  CONSTRAINT [FK_SIGEEA_PreProVenta_SIGEEA_TipProducto] FOREIGN KEY([FK_Id_TipProducto])
REFERENCES [dbo].[SIGEEA_TipProducto] ([PK_Id_TipProducto])
GO
ALTER TABLE [dbo].[SIGEEA_PreProVenta] CHECK CONSTRAINT [FK_SIGEEA_PreProVenta_SIGEEA_TipProducto]
GO
ALTER TABLE [dbo].[SIGEEA_Proveedor]  WITH CHECK ADD  CONSTRAINT [FK_SIGEEA_Proveedor_SIGEEA_Empresa] FOREIGN KEY([FK_Id_Empresa])
REFERENCES [dbo].[SIGEEA_Empresa] ([PK_Id_Empresa])
GO
ALTER TABLE [dbo].[SIGEEA_Proveedor] CHECK CONSTRAINT [FK_SIGEEA_Proveedor_SIGEEA_Empresa]
GO
ALTER TABLE [dbo].[SIGEEA_Proveedor]  WITH CHECK ADD  CONSTRAINT [FK_SIGEEA_Proveedor_SIGEEA_Persona] FOREIGN KEY([FK_Id_Persona])
REFERENCES [dbo].[SIGEEA_Persona] ([PK_Id_Persona])
GO
ALTER TABLE [dbo].[SIGEEA_Proveedor] CHECK CONSTRAINT [FK_SIGEEA_Proveedor_SIGEEA_Persona]
GO
ALTER TABLE [dbo].[SIGEEA_Proveedor]  WITH CHECK ADD  CONSTRAINT [FK_SIGEEA_Proveedor_SIGEEA_Persona1] FOREIGN KEY([FK_Id_Persona])
REFERENCES [dbo].[SIGEEA_Persona] ([PK_Id_Persona])
GO
ALTER TABLE [dbo].[SIGEEA_Proveedor] CHECK CONSTRAINT [FK_SIGEEA_Proveedor_SIGEEA_Persona1]
GO
ALTER TABLE [dbo].[SIGEEA_Proveedor]  WITH CHECK ADD  CONSTRAINT [FK_SIGEEA_Proveedor_SIGEEA_Producto] FOREIGN KEY([FK_Id_Insumo])
REFERENCES [dbo].[SIGEEA_Insumo] ([PK_Id_Insumo])
GO
ALTER TABLE [dbo].[SIGEEA_Proveedor] CHECK CONSTRAINT [FK_SIGEEA_Proveedor_SIGEEA_Producto]
GO
ALTER TABLE [dbo].[SIGEEA_Provincia]  WITH CHECK ADD  CONSTRAINT [FK_SIGEEA_Provincia_SIGEEA_Pais] FOREIGN KEY([FK_Id_Pais])
REFERENCES [dbo].[SIGEEA_Pais] ([PK_Id_Pais])
GO
ALTER TABLE [dbo].[SIGEEA_Provincia] CHECK CONSTRAINT [FK_SIGEEA_Provincia_SIGEEA_Pais]
GO
ALTER TABLE [dbo].[SIGEEA_Representante]  WITH CHECK ADD  CONSTRAINT [FK_SIGEEA_Representante_SIGEEA_Persona] FOREIGN KEY([FK_Id_Persona])
REFERENCES [dbo].[SIGEEA_Persona] ([PK_Id_Persona])
GO
ALTER TABLE [dbo].[SIGEEA_Representante] CHECK CONSTRAINT [FK_SIGEEA_Representante_SIGEEA_Persona]
GO
ALTER TABLE [dbo].[SIGEEA_Rol-Permiso]  WITH CHECK ADD  CONSTRAINT [FK_SIGEEA_Rol-Permiso_SIGEEA_Permiso] FOREIGN KEY([FK_Id_Permiso])
REFERENCES [dbo].[SIGEEA_Permiso] ([PK_Id_Permiso])
GO
ALTER TABLE [dbo].[SIGEEA_Rol-Permiso] CHECK CONSTRAINT [FK_SIGEEA_Rol-Permiso_SIGEEA_Permiso]
GO
ALTER TABLE [dbo].[SIGEEA_Rol-Permiso]  WITH CHECK ADD  CONSTRAINT [FK_SIGEEA_Rol-Permiso_SIGEEA_Rol] FOREIGN KEY([FK_Id_Rol])
REFERENCES [dbo].[SIGEEA_Rol] ([PK_Id_Rol])
GO
ALTER TABLE [dbo].[SIGEEA_Rol-Permiso] CHECK CONSTRAINT [FK_SIGEEA_Rol-Permiso_SIGEEA_Rol]
GO
ALTER TABLE [dbo].[SIGEEA_Usuario]  WITH CHECK ADD  CONSTRAINT [FK_SIGEEA_Usuario_SIGEEA_Empleado] FOREIGN KEY([FK_Id_Empleado])
REFERENCES [dbo].[SIGEEA_Empleado] ([PK_Id_Empleado])
GO
ALTER TABLE [dbo].[SIGEEA_Usuario] CHECK CONSTRAINT [FK_SIGEEA_Usuario_SIGEEA_Empleado]
GO
ALTER TABLE [dbo].[SIGEEA_Usuario]  WITH CHECK ADD  CONSTRAINT [FK_SIGEEA_Usuario_SIGEEA_Rol] FOREIGN KEY([FK_Id_Rol])
REFERENCES [dbo].[SIGEEA_Rol] ([PK_Id_Rol])
GO
ALTER TABLE [dbo].[SIGEEA_Usuario] CHECK CONSTRAINT [FK_SIGEEA_Usuario_SIGEEA_Rol]
GO
ALTER TABLE [dbo].[SIGEEA_Asamblea]  WITH CHECK ADD  CONSTRAINT [CK_SIGEEA_Asamblea] CHECK  (([Tipo_Asamblea]=(2) OR [Tipo_Asamblea]=(1)))
GO
ALTER TABLE [dbo].[SIGEEA_Asamblea] CHECK CONSTRAINT [CK_SIGEEA_Asamblea]
GO
ALTER TABLE [dbo].[SIGEEA_AsiAsamblea]  WITH CHECK ADD  CONSTRAINT [CK_SIGEEA_AsiAsamblea] CHECK  (([Estado_AsiAsamblea]>(0) AND [Estado_AsiAsamblea]<=(3)))
GO
ALTER TABLE [dbo].[SIGEEA_AsiAsamblea] CHECK CONSTRAINT [CK_SIGEEA_AsiAsamblea]
GO
ALTER TABLE [dbo].[SIGEEA_DetFacAsociado]  WITH CHECK ADD  CONSTRAINT [CK_SIGEEA_DetFacAsociado] CHECK  (([CanTotal_DetFacAsociado]>(0) AND ([Mercado_DetFacAsociado]=(2) OR [Mercado_DetFacAsociado]=(1))))
GO
ALTER TABLE [dbo].[SIGEEA_DetFacAsociado] CHECK CONSTRAINT [CK_SIGEEA_DetFacAsociado]
GO
ALTER TABLE [dbo].[SIGEEA_DetPagEmpleados]  WITH CHECK ADD  CONSTRAINT [CK_SIGEEA_DetPagEmpleados] CHECK  (([Total_DetPagEmpleados]>=(0)))
GO
ALTER TABLE [dbo].[SIGEEA_DetPagEmpleados] CHECK CONSTRAINT [CK_SIGEEA_DetPagEmpleados]
GO
ALTER TABLE [dbo].[SIGEEA_FacAsociado]  WITH CHECK ADD  CONSTRAINT [CK_SIGEEA_FacAsociado] CHECK  (([CanTotal_FacAsociado]>(0)))
GO
ALTER TABLE [dbo].[SIGEEA_FacAsociado] CHECK CONSTRAINT [CK_SIGEEA_FacAsociado]
GO
ALTER TABLE [dbo].[SIGEEA_Familiar]  WITH CHECK ADD  CONSTRAINT [CK_SIGEEA_Familiar] CHECK  (([Escolaridad_Familiar]=(4) OR [Escolaridad_Familiar]=(3) OR [Escolaridad_Familiar]=(2) OR [Escolaridad_Familiar]=(1) OR [Escolaridad_Familiar]=(0)))
GO
ALTER TABLE [dbo].[SIGEEA_Familiar] CHECK CONSTRAINT [CK_SIGEEA_Familiar]
GO
ALTER TABLE [dbo].[SIGEEA_PagAsociado]  WITH CHECK ADD  CONSTRAINT [CK_SIGEEA_PagAsociado] CHECK  (([Monto_PagAsociado]>(0)))
GO
ALTER TABLE [dbo].[SIGEEA_PagAsociado] CHECK CONSTRAINT [CK_SIGEEA_PagAsociado]
GO
ALTER TABLE [dbo].[SIGEEA_Persona]  WITH CHECK ADD  CONSTRAINT [CK_Razon_Persona] CHECK  (([Tipo_Persona]=(1) AND [CedJuridica_Persona] IS NULL AND [CedParticular_Persona] IS NOT NULL OR [Tipo_Persona]=(0) AND [CedJuridica_Persona] IS NOT NULL AND [CedParticular_Persona] IS NULL))
GO
ALTER TABLE [dbo].[SIGEEA_Persona] CHECK CONSTRAINT [CK_Razon_Persona]
GO
ALTER TABLE [dbo].[SIGEEA_Persona]  WITH CHECK ADD  CONSTRAINT [CK_SIGEEA_Persona] CHECK  (([Genero_Persona]='F' OR [Genero_Persona]='M'))
GO
ALTER TABLE [dbo].[SIGEEA_Persona] CHECK CONSTRAINT [CK_SIGEEA_Persona]
GO
ALTER TABLE [dbo].[SIGEEA_PreProCompra]  WITH CHECK ADD  CONSTRAINT [CK_SIGEEA_PreProCompra] CHECK  (([PreNacional_PreProCompra]>(0) AND [PreExtranjero_PreProCompra]>(0)))
GO
ALTER TABLE [dbo].[SIGEEA_PreProCompra] CHECK CONSTRAINT [CK_SIGEEA_PreProCompra]
GO
ALTER TABLE [dbo].[SIGEEA_PreProCompra]  WITH CHECK ADD  CONSTRAINT [CK_SIGEEA_PreProCompra_NoNulo] CHECK  (([PreNacional_PreProCompra] IS NOT NULL OR [PreExtranjero_PreProCompra] IS NOT NULL))
GO
ALTER TABLE [dbo].[SIGEEA_PreProCompra] CHECK CONSTRAINT [CK_SIGEEA_PreProCompra_NoNulo]
GO
ALTER TABLE [dbo].[SIGEEA_PreProVenta]  WITH CHECK ADD  CONSTRAINT [CK_SIGEEA_PreProVenta_NoNulo] CHECK  (([PreNacional_PreProVenta] IS NOT NULL OR [PreExtranjero_PreProVenta] IS NOT NULL))
GO
ALTER TABLE [dbo].[SIGEEA_PreProVenta] CHECK CONSTRAINT [CK_SIGEEA_PreProVenta_NoNulo]
GO
ALTER TABLE [dbo].[SIGEEA_PreProVenta]  WITH CHECK ADD  CONSTRAINT [CK_SIGEEA_PreProVenta_Precios] CHECK  (([PreNacional_PreProVenta]>(0) AND [PreExtranjero_PreProVenta]>(0)))
GO
ALTER TABLE [dbo].[SIGEEA_PreProVenta] CHECK CONSTRAINT [CK_SIGEEA_PreProVenta_Precios]
GO
/****** Object:  StoredProcedure [dbo].[SIGEEA_spAutenticaPersona]    Script Date: 18/4/2016 11:55:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Luis Barrantes Mora
-- Create date: 14/01/16
-- Description:	Autentica persona (jurídica o particular)
-- =============================================
CREATE PROCEDURE [dbo].[SIGEEA_spAutenticaPersona]
	@Cedula varchar(30) = null
AS
BEGIN

	SET NOCOUNT ON;

	SELECT PK_Id_Persona
	FROM SIGEEA_Persona
	WHERE CedJuridica_Persona = @Cedula
	OR CedParticular_Persona = @Cedula;
END









GO
/****** Object:  StoredProcedure [dbo].[SIGEEA_spCancelarPagoEmpleado]    Script Date: 18/4/2016 11:55:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Luis Barrantes Mora
-- Create date: 13/02/16
-- Description:	Cancela el pago de un día laborado
-- =============================================
CREATE PROCEDURE [dbo].[SIGEEA_spCancelarPagoEmpleado]
	@IdHoras int = null,
	@IdEmpleado int = null,
	@Total float = null
AS
BEGIN

	SET NOCOUNT ON;

    UPDATE SIGEEA_HorLaboradas
	SET Estado_HorLaboradas = 1
	WHERE PK_Id_HorLaboradas = @IdHoras;	

END





GO
/****** Object:  StoredProcedure [dbo].[SIGEEA_spEditarDireccion]    Script Date: 18/4/2016 11:55:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Luis Barrantes Mora
-- Create date: 5/01/15
-- Description:	Permite editar las direcciones de las personas
-- =============================================
CREATE PROCEDURE [dbo].[SIGEEA_spEditarDireccion]
	@Persona int = null,
	@Detalles varchar(100) = null,
	@Distrito int = null
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE SIGEEA_Direccion
	SET Detalles_Direccion = @Detalles
	FROM SIGEEA_Persona p  
	JOIN SIGEEA_Direccion d
	ON d.PK_Id_Direccion = p.FK_Id_Direccion and p.PK_Id_Persona = @Persona;
	
	UPDATE SIGEEA_Direccion
	SET FK_Id_Distrito = @Distrito
	FROM SIGEEA_Persona p
	JOIN SIGEEA_Direccion d
	ON d.PK_Id_Direccion = p.FK_Id_Direccion and p.PK_Id_Persona = @Persona;
END









GO
/****** Object:  StoredProcedure [dbo].[SIGEEA_spEditarPuesto]    Script Date: 18/4/2016 11:55:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Luis Barrantes Mora
-- Create date: 06/02/16
-- Description:	Agrega un puesto temporal y el registro anterior se desactiva
-- =============================================
CREATE PROCEDURE [dbo].[SIGEEA_spEditarPuesto]
	@Puesto varchar(30) = null,
	@Tarifa float = null
AS
BEGIN

	SET NOCOUNT ON;
	
	UPDATE SIGEEA_PueTemporal
	SET Estado_Puesto = 0
	WHERE Nombre_Puesto = @Puesto and Estado_Puesto = 1;

	INSERT INTO SIGEEA_PueTemporal(Nombre_Puesto, Tarifa_Puesto, Actualizacion_Puesto, Estado_Puesto)
	Values(@Puesto, @Tarifa, GETDATE(), 1);
    
END







GO
/****** Object:  StoredProcedure [dbo].[SIGEEA_spGenerarFacturaCuota]    Script Date: 18/4/2016 11:55:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Luis Barrantes Mora
-- Create date: 20/03/2016
-- Description:	Genera la factura de pago de cuota
-- =============================================
CREATE PROCEDURE [dbo].[SIGEEA_spGenerarFacturaCuota]
	@CuotaAsociado int = null,
	@Monto float = null, 
	@SaldoAnterior float = null
AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT E.Nombre_Empresa, CONCAT('Ced. Jurídica: ', E.CedJuridica_Empresa) as CedJuridica,
		   E.Direccion_Empresa, CONCAT('Num. Teléfono: ', E.Telefono_Empresa) as Telefono,
		   CONCAT('EMAIL: ', E.Correo_Empresa) AS Correo, 
		   CONVERT(varchar,GETDATE(),103) as Fecha, CONVERT(VARCHAR(8),GETDATE(),108) AS Hora,
		   CONCAT('Nombre de asociado: ', P.PriNombre_Persona, ' ', P.PriApellido_Persona, ' ',
				  P.SegApellido_Persona, '.') AS NombreAsociado,
		   CONCAT('Número de cédula: ', P.CedParticular_Persona) AS CedPersona,
		   CONCAT('Código: ', A.Codigo_Asociado) AS CodigoAsociado,
		   CONCAT('Cuota: ', c.Nombre_Cuota) AS NombreCuota,
		   CONCAT('Total a pagar: ',M.Simbolo_Moneda, c.Monto_Cuota) AS Total,
		   CONCAT('Monto pagado: ', M.Simbolo_Moneda, @Monto) AS Monto,		   
		   CONCAT('Saldo actual: ', M.Simbolo_Moneda, @SaldoAnterior - @Monto) AS Saldo
	FROM SIGEEA_Cuota_Asociado CA
	JOIN SIGEEA_Cuota C
	ON C.PK_Id_Cuota = CA.FK_Id_Cuota
	JOIN SIGEEA_Asociado A
	ON A.PK_Id_Asociado = CA.FK_Id_Asociado
	JOIN SIGEEA_Persona P
	ON P.PK_Id_Persona = A.FK_Id_Persona
	JOIN SIGEEA_Empresa E
	ON E.PK_Id_Empresa = A.FK_Id_Empresa
	JOIN SIGEEA_Moneda M
	ON M.PK_Id_Moneda = C.FK_Id_Moneda
	WHERE CA.PK_Id_Cuota_Asociado = @CuotaAsociado;
END



GO
/****** Object:  StoredProcedure [dbo].[SIGEEA_spGenerarFacturaEntrega]    Script Date: 18/4/2016 11:55:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Luis Barrantes Mora
-- Create date: 17/04/2016
-- Description:	Genera la factura
-- =============================================
CREATE PROCEDURE [dbo].[SIGEEA_spGenerarFacturaEntrega]
	@Factura int = null
AS
BEGIN

	SET NOCOUNT ON;
	SELECT E.Nombre_Empresa, CONCAT('Ced. Jurídica: ', E.CedJuridica_Empresa) as CedJuridica,
		   E.Direccion_Empresa, CONCAT('Num. Teléfono: ', E.Telefono_Empresa) as Telefono,
		   CONCAT('EMAIL: ', E.Correo_Empresa) AS Correo,
		   CONCAT('Factura número: ', f.PK_Id_FacAsociado) as NumFactura, 
		   CONVERT(varchar,GETDATE(),103) as Fecha, CONVERT(VARCHAR(8),GETDATE(),108) AS Hora,
		   CONCAT('Nombre de asociado: ', P.PriNombre_Persona, ' ', P.PriApellido_Persona, ' ',
				  P.SegApellido_Persona, '.') AS NombreAsociado,
		   CONCAT('Número de cédula: ', P.CedParticular_Persona) AS CedPersona,
		   CONCAT('Código: ', A.Codigo_Asociado) AS CodigoAsociado		   
	FROM SIGEEA_FacAsociado f
	JOIN SIGEEA_Asociado a
	ON a.PK_Id_Asociado = f.FK_Id_Asociado
	JOIN SIGEEA_Persona p
	ON p.PK_Id_Persona = a.FK_Id_Persona
	JOIN SIGEEA_Empresa e
	ON e.PK_Id_Empresa = a.FK_Id_Empresa
	WHERE f.PK_Id_FacAsociado = @Factura;
END

GO
/****** Object:  StoredProcedure [dbo].[SIGEEA_spListarAsociado]    Script Date: 18/4/2016 11:55:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Luis Barrantes Mora
-- Create date: 17/02/2016
-- Description:	Lista los asociados por nombre, apellido, cédula o código
-- =============================================
CREATE PROCEDURE [dbo].[SIGEEA_spListarAsociado]
	@CedNombreCod varchar(30) = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT CONCAT(p.PriNombre_Persona, ' ', p.SegNombre_Persona, ' ', p.PriApellido_Persona, ' ', p.SegApellido_Persona) as Nombre,
		   p.CedParticular_Persona, a.Codigo_Asociado, p.PK_Id_Persona, a.PK_Id_Asociado, a.Estado_Asociado	   
	FROM SIGEEA_Persona p
	JOIN SIGEEA_Asociado a
	ON a.FK_Id_Persona = p.PK_Id_Persona
	WHERE p.PriNombre_Persona LIKE @CedNombreCod + '%' OR p.PriApellido_Persona LIKE @CedNombreCod + '%' OR
		  p.CedParticular_Persona LIKE @CedNombreCod + '%' OR a.Codigo_Asociado LIKE @CedNombreCod + '%';

END





GO
/****** Object:  StoredProcedure [dbo].[SIGEEA_spListarCliente]    Script Date: 18/4/2016 11:55:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SIGEEA_spListarCliente] 
	@CedNombre varchar(30) = null
AS
BEGIN
	
	SET NOCOUNT ON;
	

		select p.CedParticular_Persona, p.PK_Id_Persona,
		   clie.PK_Id_Cliente, clie.Estado_Cliente, catClie.Limite_CatCliente, catClie.Nombre_CatCliente, catClie.RanPagos_CatCliente, catClie.TieMaximo_CatCliente,	   
		   CONCAT (p.PriNombre_Persona,' ',p.SegNombre_Persona,' ',p.PriApellido_Persona, ' ',p.SegApellido_Persona) as nombreCompleto
		   
	     from SIGEEA_Persona p
		join SIGEEA_Cliente clie
		on clie.FK_Id_Persona = p.PK_Id_Persona
		join SIGEEA_CatCliente catClie
		on clie.FK_Id_CatCliente = catClie.PK_Id_CatCliente
		
		where p.CedParticular_Persona LIKE @CedNombre + '%' or p.PriNombre_Persona LIKE @CedNombre + '%';
	
	
END









GO
/****** Object:  StoredProcedure [dbo].[SIGEEA_spListarFamiliares]    Script Date: 18/4/2016 11:55:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Luis Barrantes Mora
-- Create date: 19/02/2016
-- Description:	Listar familiares de los asociados
-- =============================================
CREATE PROCEDURE [dbo].[SIGEEA_spListarFamiliares]
	@CedAsociado varchar(15) = null
AS
BEGIN

	SET NOCOUNT ON;

    SELECT f.PK_Id_Familiar, f.Nombre_Familiar, f.Escolaridad_Familiar, f.DesEstudios_Familiar
	FROM SIGEEA_Familiar f
	JOIN SIGEEA_Asociado a
	ON a.PK_Id_Asociado = f.FK_Id_Asociado
	JOIN SIGEEA_Persona p
	ON p.PK_Id_Persona = a.FK_Id_Persona
	WHERE p.CedParticular_Persona = @CedAsociado;

END





GO
/****** Object:  StoredProcedure [dbo].[SIGEEA_spListarInsumos]    Script Date: 18/4/2016 11:55:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SIGEEA_spListarInsumos] 
  @NomInsumo Varchar(20) = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT 
	i.Nombre_Insumo, i.Estado_Insumo, i.Descripcion_Insumo, 
	ii.Cantidad_InvInsumo, uni.Nombre_UniMedida, i.PK_Id_Insumo

	from SIGEEA_Insumo i
	join SIGEEA_InvInsumo ii
	on ii.FK_Id_Insumo = i.PK_Id_Insumo
	join SIGEEA_UniMedida uni
	on uni.PK_Id_UniMedida = ii.FK_UniMedida
	where i.Nombre_Insumo LIKE @NomInsumo + '%';
END








GO
/****** Object:  StoredProcedure [dbo].[SIGEEA_spListarProductos]    Script Date: 18/4/2016 11:55:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SIGEEA_spListarProductos] 
	@nomProducto varchar(30) = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT 
	tipPro.Nombre_TipProducto, tipPro.Descripcion_TipProducto, tipPro.Calidad_TipProducto, tipPro.PK_Id_TipProducto
	,detInvPro.Cantidad_DetInvProductos, detInvPro.FK_Id_InvProductos,detInvPro.FK_Id_TipProducto,detInvPro.PK_Id_DetInvProductos,
	invPro.Descripcion_InvProductos, invPro.FK_Id_Bodega, invPro.PK_Id_InvProductos,
	preProVen.PK_Id_PreProVenta,preProVen.PreNacional_PreProVenta, preProVen.PreExtranjero_PreProVenta,
	bod.PK_Id_Bodega, bod.FK_Id_Empresa,
	mon.PK_Id_Moneda, uniMed.Nombre_UniMedida
	FROM
	SIGEEA_InvProductos invPro
	JOIN SIGEEA_DetInvProductos detInvPro
	ON detInvPro.FK_Id_InvProductos = invPro.PK_Id_InvProductos
	JOIN SIGEEA_TipProducto tipPro
	ON detInvPro.FK_Id_TipProducto = tipPro.PK_Id_TipProducto
	JOIN SIGEEA_Bodega bod
	ON invPro.FK_Id_Bodega  = bod.PK_Id_Bodega
	JOIN SIGEEA_PreProVenta preProVen
	ON preProVen.FK_Id_TipProducto = tipPro.PK_Id_TipProducto
	JOIN SIGEEA_Moneda mon
	ON preProVen.FK_Id_Moneda = mon.PK_Id_Moneda
	JOIN SIGEEA_UniMedida uniMed
	ON detInvPro.FK_Id_UniMedida = uniMed.PK_Id_UniMedida
	WHERE tipPro.Nombre_TipProducto LIKE @nomProducto +'%'; 



END






GO
/****** Object:  StoredProcedure [dbo].[SIGEEA_spListarPuestos]    Script Date: 18/4/2016 11:55:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SIGEEA_spListarPuestos]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT p.PK_Id_Puesto, p.Nombre_Puesto, p.Tarifa_Puesto
	FROM SIGEEA_PueTemporal p
	WHERE p.Estado_Puesto = 1;
END







GO
/****** Object:  StoredProcedure [dbo].[SIGEEA_spListarTiposDeProducto]    Script Date: 18/4/2016 11:55:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SIGEEA_spListarTiposDeProducto]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    
	SELECT
    tipProc.Nombre_TipProducto, tipProc.Descripcion_TipProducto, tipProc.Calidad_TipProducto 
	FROM 
	SIGEEA_TipProducto tipProc
END






GO
/****** Object:  StoredProcedure [dbo].[SIGEEA_spObtenerAsociado]    Script Date: 18/4/2016 11:55:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Author:		Luis Barrantes Mora
-- Create date: 15/12/15
-- Description:	Obtiene los datos del asociado a partir de su cédula o código único
-- =============================================
CREATE PROCEDURE [dbo].[SIGEEA_spObtenerAsociado] 
	@Cedula_Codigo varchar(30) = null
AS
BEGIN
	SET NOCOUNT ON;
	if @Cedula_Codigo is not null 
		select p.CedJuridica_Persona,p.CedParticular_Persona,p.FecNacimiento_Persona,
			   p.FK_Id_Direccion, p.FK_Id_Nacionalidad, p.Genero_Persona, p.PK_Id_Persona,
			   p.PriApellido_Persona,p.PriNombre_Persona,p.SegApellido_Persona,p.SegNombre_Persona,
			   p.Tipo_Persona, a.Codigo_Asociado, a.PK_Id_Asociado 
		from SIGEEA_Persona p
		join SIGEEA_Asociado a
		on a.FK_Id_Persona = p.PK_Id_Persona
		where CedParticular_Persona = @Cedula_Codigo OR a.Codigo_Asociado = @Cedula_Codigo;

END















GO
/****** Object:  StoredProcedure [dbo].[SIGEEA_spObtenerAsociadoFactura]    Script Date: 18/4/2016 11:55:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Luis Barrantes Mora
-- Create date: 17/04/2016
-- Description:	Obtiene la información del asociado a partir del PK de la factura
-- =============================================
CREATE PROCEDURE [dbo].[SIGEEA_spObtenerAsociadoFactura]
	@Factura int = null
AS
BEGIN
	SET NOCOUNT ON;

	SELECT CONCAT(P.PriNombre_Persona, ' ', P.PriApellido_Persona, ' ', P.SegApellido_Persona) as NombreAsociado,
		   P.CedParticular_Persona, CONVERT(varchar,F.FecEntrega_FacAsociado,103) as Fecha, A.Codigo_Asociado
	FROM SIGEEA_FacAsociado F
	JOIN SIGEEA_Asociado A
	ON A.PK_Id_Asociado = F.FK_Id_Asociado
	JOIN SIGEEA_Persona P
	ON P.PK_Id_Persona = A.FK_Id_Persona
	WHERE F.PK_Id_FacAsociado = @Factura;
END

GO
/****** Object:  StoredProcedure [dbo].[SIGEEA_spObtenerCantones]    Script Date: 18/4/2016 11:55:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SIGEEA_spObtenerCantones]
	@Provincia varchar(30)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT C.Nombre_Canton
	FROM SIGEEA_Canton C
	JOIN SIGEEA_Provincia P
	ON P.PK_Id_Provincia = C.FK_Id_Provincia
	WHERE P.Nombre_Provincia = @Provincia;
END









GO
/****** Object:  StoredProcedure [dbo].[SIGEEA_spObtenerCategoria]    Script Date: 18/4/2016 11:55:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SIGEEA_spObtenerCategoria]
	@PkCatCliente int = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT 
	cat.Limite_CatCliente, cat.RanPagos_CatCliente, cat.PK_Id_CatCliente, cat.TieMaximo_CatCliente
	from SIGEEA_CatCliente cat
	where cat.PK_Id_CatCliente = @PkCatCliente
END








GO
/****** Object:  StoredProcedure [dbo].[SIGEEA_spObtenerCliente]    Script Date: 18/4/2016 11:55:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SIGEEA_spObtenerCliente]
	@pkIdCliente int = null
AS
BEGIN
	
	SET NOCOUNT ON;
	

		select p.CedParticular_Persona,p.FecNacimiento_Persona, p.FK_Id_Nacionalidad, p.Genero_Persona, p.PK_Id_Persona,
		   p.PriApellido_Persona, p.PriNombre_Persona, p.SegApellido_Persona, p.SegNombre_Persona,
		   clie.PK_Id_Cliente, catClie.Nombre_CatCliente, clie.Estado_Cliente,catClie.Nombre_CatCliente,
		   catClie.Limite_CatCliente,catClie.RanPagos_CatCliente, catClie.TieMaximo_CatCliente, catClie.PK_Id_CatCliente
	     from SIGEEA_Persona p
		join SIGEEA_Cliente clie
		on clie.FK_Id_Persona = p.PK_Id_Persona
		join SIGEEA_CatCliente catClie
		on clie.FK_Id_CatCliente = catClie.PK_Id_CatCliente
		where clie.PK_Id_Cliente = @pkIdCliente;
	
	
END









GO
/****** Object:  StoredProcedure [dbo].[SIGEEA_spObtenerContacto]    Script Date: 18/4/2016 11:55:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Luis Barrantes Mora
-- Create date: 14/01/16
-- Description:	Obtiene los diferentes contactos de una persona en específico
-- =============================================
CREATE PROCEDURE [dbo].[SIGEEA_spObtenerContacto]
	@Persona int = null
AS
BEGIN
	SET NOCOUNT ON;

    SELECT p.PK_Id_Persona, c.PK_Id_Contacto, c.Dato_Contacto, tc.Nombre_TipContacto
	FROM SIGEEA_Persona p
	JOIN SIGEEA_Contacto c
	ON c.FK_Id_Persona = p.PK_Id_Persona
	JOIN SIGEEA_TipContacto tc
	ON tc.PK_Id_TipContacto = c.FK_Id_TipContacto
	WHERE p.PK_Id_Persona = @Persona;
END









GO
/****** Object:  StoredProcedure [dbo].[SIGEEA_spObtenerCuotas]    Script Date: 18/4/2016 11:55:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Luis Barrantes Mora
-- Create date: 18/3/2016
-- Description:	Obtiene las cuotas que se encuentran actualmente activos
-- =============================================
CREATE PROCEDURE [dbo].[SIGEEA_spObtenerCuotas]
AS
BEGIN
	SET NOCOUNT ON;
	SELECT C.PK_ID_CUOTA, C.NOMBRE_CUOTA, CONCAT(M.SIMBOLO_MONEDA,C.MONTO_CUOTA) AS MONTO,
		   CONCAT(CONVERT(VARCHAR, C.FECINICIO_CUOTA, 103),' - ',CONVERT(VARCHAR, C.FECFIN_CUOTA,103)) AS RANGO
	FROM SIGEEA_CUOTA C
	JOIN SIGEEA_MONEDA M
	ON M.PK_ID_MONEDA = C.FK_ID_MONEDA
	WHERE FECFIN_CUOTA > GETDATE();
END



GO
/****** Object:  StoredProcedure [dbo].[SIGEEA_spObtenerDetalleFacturaAsociado]    Script Date: 18/4/2016 11:55:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Luis Barrantes Mora
-- Create date: 18/04/2016
-- Description:	Obtiene el detalle de una factura
-- =============================================
CREATE PROCEDURE [dbo].[SIGEEA_spObtenerDetalleFacturaAsociado]
	@Factura int = null
AS
BEGIN
	SET NOCOUNT ON;

    SELECT *
	FROM SIGEEA_DetFacAsociado 
	WHERE FK_Id_FacAsociado = @Factura;
END

GO
/****** Object:  StoredProcedure [dbo].[SIGEEA_spObtenerDetallesEntrega]    Script Date: 18/4/2016 11:55:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Luis Barrantes Mora
-- Create date: 18/04/2016
-- Description:	Obtiene detalles de una factura
-- =============================================
CREATE PROCEDURE [dbo].[SIGEEA_spObtenerDetallesEntrega]
	@Factura int = null
AS
BEGIN

	SET NOCOUNT ON;

    SELECT TP.Nombre_TipProducto, DF.CanTotal_DetFacAsociado, 
			(CASE DF.Mercado_DetFacAsociado
			WHEN 1 THEN CONCAT('₡',PC.PreNacional_PreProCompra)
			WHEN 2 THEN CONCAT('₡',PC.PreExtranjero_PreProCompra)
			END) AS Precio
	FROM SIGEEA_DetFacAsociado DF
	JOIN SIGEEA_FacAsociado F
	ON F.PK_Id_FacAsociado = DF.FK_Id_FacAsociado
	JOIN SIGEEA_PreProCompra PC
	ON PC.PK_Id_PreProCompra = DF.FK_Id_PreProCompra
	JOIN SIGEEA_TipProducto TP
	ON TP.PK_Id_TipProducto = PC.FK_Id_TipProducto
	WHERE F.PK_Id_FacAsociado = @Factura;
END

GO
/****** Object:  StoredProcedure [dbo].[SIGEEA_spObtenerDeudoresCuotas]    Script Date: 18/4/2016 11:55:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Luis Barrantes Mora
-- Create date: 19/03/2016
-- Description:	Obtiene todos los asociados que tienen cuotas pendientes de pago y sus detalles
-- =============================================
CREATE PROCEDURE [dbo].[SIGEEA_spObtenerDeudoresCuotas]
	@Cuota int = null
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT CONCAT(p.PriNombre_Persona,' ', p.PriApellido_Persona,' ', p.SegApellido_Persona) as NombrePersona,
		   p.CedParticular_Persona as Cedula, ca.PK_Id_Cuota_Asociado, c.Nombre_Cuota as NombreCuota, 
		   CONCAT(m.Simbolo_Moneda,c.Monto_Cuota) as MontoCuota, 
		   CONCAT(m.Simbolo_Moneda,ca.Saldo_Cuota_Asociado) as SaldoPendiente
	FROM SIGEEA_Cuota_Asociado ca
	JOIN SIGEEA_Cuota c
	ON c.PK_Id_Cuota = ca.FK_Id_Cuota
	JOIN SIGEEA_Asociado a
	ON a.PK_Id_Asociado = ca.FK_Id_Asociado
	JOIN SIGEEA_Persona p
	ON p.PK_Id_Persona = a.FK_Id_Persona  
	JOIN SIGEEA_Moneda m
	ON m.PK_Id_Moneda = c.FK_Id_Moneda  
	WHERE ca.FK_Id_Cuota = @Cuota
	and ca.Estado_Cuota_Asociado = 0;
END



GO
/****** Object:  StoredProcedure [dbo].[SIGEEA_spObtenerDiaLaboral]    Script Date: 18/4/2016 11:55:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Luis Barrantes Mora
-- Create date: 10/02/16
-- Description:	Determina si existe un día laboral no completado (sin hora de salida)
-- =============================================
CREATE PROCEDURE [dbo].[SIGEEA_spObtenerDiaLaboral]
	@Empleado varchar(15) = null
AS
BEGIN
	SET NOCOUNT ON;

	SELECT hl.PK_Id_HorLaboradas
	FROM SIGEEA_HorLaboradas hl
	JOIN SIGEEA_Empleado em
	ON em.PK_Id_Empleado = hl.FK_Id_Empleado
	JOIN SIGEEA_Persona pe
	ON pe.PK_Id_Persona = em.FK_Id_Persona
	WHERE hl.Activo_HorLaboradas = 1;
END







GO
/****** Object:  StoredProcedure [dbo].[SIGEEA_spObtenerDireccionAsociado]    Script Date: 18/4/2016 11:55:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SIGEEA_spObtenerDireccionAsociado]
	@Cedula varchar(30) = null,
	@Codigo varchar(10) = null
AS
BEGIN
	SET NOCOUNT ON;

    if @Cedula is not null
		select p.PK_Id_Persona, a.PK_Id_Asociado, d.Detalles_Direccion, di.Nombre_Distrito, c.Nombre_Canton, pr.Nombre_Provincia
		from SIGEEA_Persona p
		join SIGEEA_Asociado a 
		on a.FK_Id_Persona = p.PK_Id_Persona
		join SIGEEA_Direccion d
		on d.PK_Id_Direccion = p.FK_Id_Direccion
		join SIGEEA_Distrito di
		on di.PK_Id_Distrito = d.FK_Id_Distrito
		join SIGEEA_Canton c
		on c.PK_Id_Canton = di.FK_Id_Canton
		join SIGEEA_Provincia pr
		on pr.PK_Id_Provincia = c.FK_Id_Provincia
		where p.CedParticular_Persona = @Cedula;

	else if @Codigo is not null
		select p.PK_Id_Persona, a.PK_Id_Asociado, d.Detalles_Direccion, di.Nombre_Distrito, c.Nombre_Canton, pr.Nombre_Provincia
		from SIGEEA_Persona p
		join SIGEEA_Asociado a 
		on a.FK_Id_Persona = p.PK_Id_Persona
		join SIGEEA_Direccion d
		on d.PK_Id_Direccion = p.FK_Id_Direccion
		join SIGEEA_Distrito di
		on di.PK_Id_Distrito = d.FK_Id_Distrito
		join SIGEEA_Canton c
		on c.PK_Id_Canton = di.FK_Id_Canton
		join SIGEEA_Provincia pr
		on pr.PK_Id_Provincia = c.FK_Id_Provincia
		where a.Codigo_Asociado = @Codigo;


END









GO
/****** Object:  StoredProcedure [dbo].[SIGEEA_spObtenerDireccionEmpleado]    Script Date: 18/4/2016 11:55:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Luis Barrantes Mora
-- Create date: 07/01/2015
-- Description:	Obtiene los datos de la dirección de un empleado
-- =============================================
CREATE PROCEDURE [dbo].[SIGEEA_spObtenerDireccionEmpleado] 
	@Cedula varchar(15) = null
AS
BEGIN	
	SET NOCOUNT ON;
    if @Cedula is not null
		select p.PK_Id_Persona, e.PK_Id_Empleado, d.Detalles_Direccion, di.Nombre_Distrito, c.Nombre_Canton, pr.Nombre_Provincia
		from SIGEEA_Persona p
		join SIGEEA_Empleado e
		on e.FK_Id_Persona = p.PK_Id_Persona
		join SIGEEA_Direccion d
		on d.PK_Id_Direccion = p.FK_Id_Direccion
		join SIGEEA_Distrito di
		on di.PK_Id_Distrito = d.FK_Id_Distrito
		join SIGEEA_Canton c
		on c.PK_Id_Canton = di.FK_Id_Canton
		join SIGEEA_Provincia pr
		on pr.PK_Id_Provincia = c.FK_Id_Provincia
		where p.CedParticular_Persona = @Cedula;
END









GO
/****** Object:  StoredProcedure [dbo].[SIGEEA_spObtenerDistritos]    Script Date: 18/4/2016 11:55:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SIGEEA_spObtenerDistritos]
	@Canton varchar(30)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT D.Nombre_Distrito
	FROM SIGEEA_Distrito D
	JOIN SIGEEA_Canton C
	ON C.PK_Id_Canton = D.FK_Id_Canton
	WHERE C.Nombre_Canton = @Canton;
END









GO
/****** Object:  StoredProcedure [dbo].[SIGEEA_spObtenerEmpleado]    Script Date: 18/4/2016 11:55:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Luis Barrantes Mora
-- Create date: 07/01/2016
-- Description:	Retorna la información personal y laborar de un empleado
-- =============================================
CREATE PROCEDURE [dbo].[SIGEEA_spObtenerEmpleado]
	@Cedula varchar(15) = null
AS
BEGIN

	SET NOCOUNT ON;

    SELECT p.CedParticular_Persona, p.FecNacimiento_Persona, n.Nombre_Nacionalidad, p.Genero_Persona, p.PriApellido_Persona,
		   p.PriNombre_Persona, p.SegApellido_Persona, p.SegNombre_Persona, es.GradoAcad_Escolaridad, es.Escribir_Escolaridad,
		   es.Leer_Escolaridad, es.Observaciones_Escolaridad, p.PK_Id_Persona, e.PK_Id_Empleado
	FROM SIGEEA_Persona p
	JOIN SIGEEA_Empleado e
	on e.FK_Id_Persona = p.PK_Id_Persona
	JOIN SIGEEA_Escolaridad es
	on es.PK_Id_Escolaridad = e.FK_Id_Escolaridad
	JOIN SIGEEA_Nacionalidad n
	on n.PK_Id_Nacionalidad = p.FK_Id_Nacionalidad
	WHERE p.CedParticular_Persona = @Cedula;
END









GO
/****** Object:  StoredProcedure [dbo].[SIGEEA_spObtenerFacturasIncompletas]    Script Date: 18/4/2016 11:55:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Luis Barrantes Mora
-- Create date: 18/04/2016
-- Description:	Obtiene las facturas incompletas
-- =============================================
CREATE PROCEDURE [dbo].[SIGEEA_spObtenerFacturasIncompletas]
	@Asociado varchar(30) = null
AS
BEGIN

	SET NOCOUNT ON;

	IF(@Asociado IS NULL)
		SELECT F.PK_Id_FacAsociado, F.CanTotal_FacAsociado,UM.Nombre_UniMedida, CONVERT(VARCHAR(10),F.FecEntrega_FacAsociado,103) AS FECHA
		FROM SIGEEA_FacAsociado F
		JOIN SIGEEA_UniMedida UM
		ON UM.PK_Id_UniMedida = F.FK_Id_UniMedida
		WHERE F.Incompleta_FacAsociado  = 1;

	IF(@Asociado IS NOT NULL)
		SELECT F.PK_Id_FacAsociado, F.CanTotal_FacAsociado,UM.Nombre_UniMedida, CONVERT(VARCHAR(10),F.FecEntrega_FacAsociado,103) AS FECHA
		FROM SIGEEA_FacAsociado F
		JOIN SIGEEA_Asociado A
		ON A.PK_Id_Asociado = F.FK_Id_Asociado
		JOIN SIGEEA_Persona P
		ON P.PK_Id_Persona = A.FK_Id_Persona
		JOIN SIGEEA_UniMedida UM
		ON UM.PK_Id_UniMedida = F.FK_Id_UniMedida
		WHERE P.CedParticular_Persona = @Asociado OR
			A.Codigo_Asociado = @Asociado
			AND F.Incompleta_FacAsociado = 1;
END

GO
/****** Object:  StoredProcedure [dbo].[SIGEEA_spObtenerFincas]    Script Date: 18/4/2016 11:55:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Luis Barrantes Mora
-- Create date: 11/4/16
-- Description:	Obtiene un listado de las fincas, a partir del código o de la cédula del asociado
-- =============================================
CREATE PROCEDURE [dbo].[SIGEEA_spObtenerFincas]
	@CedulaCodigo varchar(30) = null
AS
BEGIN

	SET NOCOUNT ON;

    SELECT F.PK_Id_Finca, F.Codigo_Finca
	FROM SIGEEA_Finca F
	JOIN SIGEEA_Asociado A
	ON A.PK_Id_Asociado = F.FK_Id_Asociado
	JOIN SIGEEA_Persona P
	ON P.PK_Id_Persona = A.FK_Id_Persona
	WHERE A.Codigo_Asociado = @CedulaCodigo OR 
		  P.CedParticular_Persona = @CedulaCodigo;
END

GO
/****** Object:  StoredProcedure [dbo].[SIGEEA_spObtenerInformacionEntrega]    Script Date: 18/4/2016 11:55:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Luis Barrantes Mora
-- Create date: 17/04/2016
-- Description:	Obtiene la información de cada detalle de la factura de entrega
-- =============================================
CREATE PROCEDURE [dbo].[SIGEEA_spObtenerInformacionEntrega]
	@Factura int = null
AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT CONCAT(df.CanTotal_DetFacAsociado,UM.Nombre_UniMedida, ' de ', tp.Nombre_TipProducto, 
				  ' destinados para el mercado ', (SELECT CASE DF.Mercado_DetFacAsociado
														 WHEN 1 THEN 'nacional'
														 WHEN 2 THEN 'extranjero'
														 END),
			(SELECT CASE DF.Mercado_DetFacAsociado
			WHEN 1 THEN '. Precio: ₡' + Convert(varchar(15),PC.PreNacional_PreProCompra)
			WHEN 2 THEN '. Precio: ₡' + Convert(varchar(15),PC.PreExtranjero_PreProCompra)
			END)) as Informacion, DF.PK_Id_DetFacAsociado
	FROM SIGEEA_FacAsociado F
	JOIN SIGEEA_DetFacAsociado DF
	ON DF.FK_Id_FacAsociado = F.PK_Id_FacAsociado
	JOIN SIGEEA_UniMedida UM
	ON UM.PK_Id_UniMedida = F.FK_Id_UniMedida
	JOIN SIGEEA_PreProCompra PC
	ON PC.PK_Id_PreProCompra = DF.FK_Id_PreProCompra
	JOIN SIGEEA_TipProducto TP
	ON TP.PK_Id_TipProducto = PC.FK_Id_TipProducto
	WHERE F.PK_Id_FacAsociado = @Factura;
END

GO
/****** Object:  StoredProcedure [dbo].[SIGEEA_spObtenerInsumo]    Script Date: 18/4/2016 11:55:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SIGEEA_spObtenerInsumo]
@Nombre varchar(20) = null
AS
BEGIN
	
	SET NOCOUNT ON;
	select i.PK_Id_Insumo, i.Nombre_Insumo, i.Descripcion_Insumo, i.Estado_Insumo,
	invi.Cantidad_InvInsumo, unim.Nombre_UniMedida

	from SIGEEA_Insumo i
	join SIGEEA_InvInsumo invi
	on i.PK_Id_Insumo = invi.FK_Id_Insumo
	join SIGEEA_UniMedida unim
	on unim.PK_Id_UniMedida = invi.PK_IdInvInsumo
			where Nombre_Insumo = @Nombre;
END











GO
/****** Object:  StoredProcedure [dbo].[SIGEEA_spObtenerLotes]    Script Date: 18/4/2016 11:55:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Luis Barrantes Mora
-- Create date: 11/4/2016
-- Description:	Obtiene un listado de los lotes, de acuerdo a su finca
-- =============================================
CREATE PROCEDURE [dbo].[SIGEEA_spObtenerLotes]
	@IdFinca int = null
AS
BEGIN

	SET NOCOUNT ON;

	SELECT L.Codigo_Lote, L.PK_Id_Lote
	FROM SIGEEA_Finca F
	JOIN SIGEEA_Lote L
	ON L.FK_Id_Finca = F.PK_Id_Finca
	WHERE F.PK_Id_Finca = @IdFinca
END

GO
/****** Object:  StoredProcedure [dbo].[SIGEEA_spObtenerMonedaCuota]    Script Date: 18/4/2016 11:55:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Luis Barrantes Mora
-- Create date: 20/03/2016
-- Description:	Obtiene el símbolo de la moneda a partir de la cuota_asociado 
-- =============================================
CREATE PROCEDURE [dbo].[SIGEEA_spObtenerMonedaCuota]
	@IdCuotaAsociado int = null
AS
BEGIN

	SET NOCOUNT ON;

	SELECT M.Simbolo_Moneda
	FROM SIGEEA_Cuota_Asociado CA
	JOIN SIGEEA_Cuota C
	ON C.PK_Id_Cuota = CA.FK_Id_Cuota
	JOIN SIGEEA_Moneda M
	ON M.PK_Id_Moneda = C.FK_Id_Moneda
	WHERE CA.PK_Id_Cuota_Asociado = @IdCuotaAsociado;
END



GO
/****** Object:  StoredProcedure [dbo].[SIGEEA_spObtenerPagosEmpleadosPendientes]    Script Date: 18/4/2016 11:55:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Luis Barrantes Mora
-- Create date: 10/02/16
-- Description: Obtiene lo que se le debe a un empleado en específico
-- =============================================
CREATE PROCEDURE [dbo].[SIGEEA_spObtenerPagosEmpleadosPendientes]
	@Empleado varchar(15) = null
AS
BEGIN

	SET NOCOUNT ON;

	SELECT CONVERT(VARCHAR(11), hl.HoraInicio_HorLaboradas,106) as Fecha, 
		   DATEDIFF(hh, hl.HoraInicio_HorLaboradas, hl.HoraFin_HorLaboradas) as Diferencia,
		   pu.Nombre_Puesto, concat('₡',(DATEDIFF(hh, hl.HoraInicio_HorLaboradas, hl.HoraFin_HorLaboradas) * pu.Tarifa_Puesto)) as Total,
		   hl.PK_Id_HorLaboradas, concat('₡',pu.Tarifa_Puesto) as Tarifa
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







GO
/****** Object:  StoredProcedure [dbo].[SIGEEA_spObtenerPrecioCompra]    Script Date: 18/4/2016 11:55:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Luis Barrantes Mora
-- Create date: 16/04/2016
-- Description:	Obtiene el registro más reciente del precio de compra de un producto
-- =============================================
CREATE PROCEDURE [dbo].[SIGEEA_spObtenerPrecioCompra]
	@Producto int = null
AS
BEGIN
	SET NOCOUNT ON;

	SELECT TOP 1 p.PK_Id_PreProCompra, p.FecRegistro_PreProCompra
	FROM SIGEEA_PreProCompra p
	WHERE p.FecRegistro_PreProCompra = (SELECT MAX(pp.FecRegistro_PreProCompra)
										FROM SIGEEA_PreProCompra pp
										WHERE pp.PK_Id_PreProCompra = p.PK_Id_PreProCompra
										GROUP BY pp.FecRegistro_PreProCompra)
		  AND p.FK_Id_TipProducto = @Producto
	ORDER BY p.PK_Id_PreProCompra desc
	
END

GO
/****** Object:  StoredProcedure [dbo].[SIGEEA_spObtenerPrecioVentaMoneda]    Script Date: 18/4/2016 11:55:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SIGEEA_spObtenerPrecioVentaMoneda]
	@nombreMoneda varchar(15) = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT 
	mo.PreVenta_Moneda
	from SIGEEA_Moneda mo
	where
	mo.Nombre_Moneda = @nombreMoneda
END


GO
/****** Object:  StoredProcedure [dbo].[SIGEEA_spObtenerUnidadesMedida]    Script Date: 18/4/2016 11:55:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SIGEEA_spObtenerUnidadesMedida]

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT 
	uni.Nombre_UniMedida
	FROM
	SIGEEA_UniMedida uni
	where uni.Estado = 1 
END








GO
/****** Object:  StoredProcedure [dbo].[SIGEEA_spRegistraHorasLaboradas]    Script Date: 18/4/2016 11:55:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Luis Barrantes Mora
-- Create date: 10/02/16
-- Description:	Registra las horas laboradas de un empleado en específico
-- =============================================
CREATE PROCEDURE [dbo].[SIGEEA_spRegistraHorasLaboradas]
	@Empleado varchar(15) = null,
	@Puesto varchar(30) = null
AS
BEGIN
	SET NOCOUNT ON;

	if (SELECT hl.PK_Id_HorLaboradas
		FROM SIGEEA_HorLaboradas hl
		JOIN SIGEEA_Empleado em
		ON em.PK_Id_Empleado = hl.FK_Id_Empleado
		JOIN SIGEEA_Persona pe
		ON pe.PK_Id_Persona = em.FK_Id_Persona
		WHERE pe.CedParticular_Persona LIKE @Empleado AND
			  hl.Activo_HorLaboradas = 1 AND
			  hl.Estado_HorLaboradas = 0) is not null
	
		UPDATE SIGEEA_HorLaboradas 
		SET HoraFin_HorLaboradas = GETDATE(), Activo_HorLaboradas = 0
		WHERE FK_Id_Empleado = (SELECT em.PK_Id_Empleado
								FROM SIGEEA_Empleado em
								JOIN SIGEEA_Persona pe
								ON pe.PK_Id_Persona = em.FK_Id_Persona
								AND pe.CedParticular_Persona = @Empleado)
			  AND Activo_HorLaboradas = 1 AND Estado_HorLaboradas = 0;


	else
		INSERT INTO SIGEEA_HorLaboradas(Activo_HorLaboradas,Estado_HorLaboradas,FK_Id_Empleado,FK_Id_Puesto,
										HoraInicio_HorLaboradas,HoraFin_HorLaboradas)
		VALUES(1,0,(SELECT em.PK_Id_Empleado
					FROM SIGEEA_Empleado em
					JOIN SIGEEA_Persona pe
					ON pe.PK_Id_Persona = em.FK_Id_Persona
					AND pe.CedParticular_Persona = @Empleado),
					(SELECT p.PK_Id_Puesto
					 FROM SIGEEA_PueTemporal p
					 WHERE p.Actualizacion_Puesto in (SELECT MAX(g.Actualizacion_Puesto)
													  FROM SIGEEA_PueTemporal g
													  WHERE g.Nombre_Puesto LIKE @Puesto)), 
					GETDATE(), null);


END







GO
