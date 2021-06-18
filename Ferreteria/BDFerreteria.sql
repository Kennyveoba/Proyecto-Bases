USE [master]
GO
/****** Object:  Database [Ferreteria]    Script Date: 18/6/2021 16:29:59 ******/
CREATE DATABASE [Ferreteria]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Ferreteria', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Ferreteria.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Ferreteria_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Ferreteria_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Ferreteria] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Ferreteria].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Ferreteria] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Ferreteria] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Ferreteria] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Ferreteria] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Ferreteria] SET ARITHABORT OFF 
GO
ALTER DATABASE [Ferreteria] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Ferreteria] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Ferreteria] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Ferreteria] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Ferreteria] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Ferreteria] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Ferreteria] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Ferreteria] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Ferreteria] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Ferreteria] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Ferreteria] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Ferreteria] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Ferreteria] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Ferreteria] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Ferreteria] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Ferreteria] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Ferreteria] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Ferreteria] SET RECOVERY FULL 
GO
ALTER DATABASE [Ferreteria] SET  MULTI_USER 
GO
ALTER DATABASE [Ferreteria] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Ferreteria] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Ferreteria] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Ferreteria] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Ferreteria] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Ferreteria] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Ferreteria', N'ON'
GO
ALTER DATABASE [Ferreteria] SET QUERY_STORE = OFF
GO
USE [Ferreteria]
GO
/****** Object:  Table [dbo].[BitacoraMantenimiento]    Script Date: 18/6/2021 16:29:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BitacoraMantenimiento](
	[Evento] [int] NOT NULL,
	[Fecha] [datetime] NULL,
	[CodEmpleado] [int] NULL,
	[Accion] [varchar](15) NULL,
	[Tabla] [varchar](25) NULL,
 CONSTRAINT [PK_BitacoraMantenimiento] PRIMARY KEY CLUSTERED 
(
	[Evento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categorias]    Script Date: 18/6/2021 16:29:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categorias](
	[CodCategoria] [int] NOT NULL,
	[Nombre] [varchar](30) NULL,
	[Descripcion] [varchar](30) NULL,
 CONSTRAINT [PK_Categorias] PRIMARY KEY CLUSTERED 
(
	[CodCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 18/6/2021 16:29:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[CodCliente] [int] NOT NULL,
	[Nombre] [nvarchar](30) NULL,
	[Telefono] [int] NULL,
	[Correo] [nvarchar](30) NULL,
	[Direccion] [nvarchar](50) NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[CodCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetalleVenta]    Script Date: 18/6/2021 16:29:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleVenta](
	[CodDetalle] [int] NOT NULL,
	[NumeroVenta] [int] NULL,
	[CodProducto] [int] NULL,
	[Cantidad] [int] NULL,
	[Precio] [int] NULL,
 CONSTRAINT [PK_DetalleVenta] PRIMARY KEY CLUSTERED 
(
	[CodDetalle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empleados]    Script Date: 18/6/2021 16:29:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empleados](
	[CodigoEmpleado] [int] NOT NULL,
	[Nombre] [nvarchar](30) NULL,
	[Direccion] [nvarchar](30) NULL,
	[Telefono] [int] NULL,
	[Correo] [nvarchar](30) NULL,
	[CodOcupacion] [int] NULL,
	[FechaNacimiento] [datetime] NULL,
 CONSTRAINT [PK_Empleados] PRIMARY KEY CLUSTERED 
(
	[CodigoEmpleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Encargados]    Script Date: 18/6/2021 16:29:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Encargados](
	[CodigoEncargado] [int] NOT NULL,
	[Nombre] [nvarchar](30) NULL,
	[Direccion] [nvarchar](30) NULL,
	[Telefono] [nvarchar](30) NULL,
	[Correo] [nvarchar](30) NULL,
 CONSTRAINT [PK_Encargados] PRIMARY KEY CLUSTERED 
(
	[CodigoEncargado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ingresos]    Script Date: 18/6/2021 16:29:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ingresos](
	[CodIngreso] [int] NOT NULL,
	[CodigoTienda] [int] NULL,
	[CodProducto] [int] NULL,
	[Ingreso] [int] NULL,
	[Fecha] [datetime] NULL,
	[CodEmpleado] [int] NULL,
	[Descripcion] [nvarchar](50) NULL,
 CONSTRAINT [PK_Ingresos] PRIMARY KEY CLUSTERED 
(
	[CodIngreso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Inventario]    Script Date: 18/6/2021 16:29:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inventario](
	[CodInventario] [int] NOT NULL,
	[CodigoTienda] [int] NULL,
	[CodProducto] [int] NULL,
	[Cantidad] [int] NULL,
 CONSTRAINT [PK_Inventario] PRIMARY KEY CLUSTERED 
(
	[CodInventario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MaestroVentas]    Script Date: 18/6/2021 16:29:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MaestroVentas](
	[CodNumeroVenta] [int] NOT NULL,
	[Fecha] [datetime] NULL,
	[CodigoTienda] [int] NULL,
	[CodTipoPago] [int] NULL,
	[CodCliente] [int] NULL,
	[Subtotal] [int] NULL,
	[IVA] [int] NULL,
	[Total] [int] NULL,
 CONSTRAINT [PK_MaestroVentas] PRIMARY KEY CLUSTERED 
(
	[CodNumeroVenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ocupaciones]    Script Date: 18/6/2021 16:29:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ocupaciones](
	[CodOcupacion] [int] NOT NULL,
	[Ocupacion] [nvarchar](30) NULL,
 CONSTRAINT [PK_Ocupaciones] PRIMARY KEY CLUSTERED 
(
	[CodOcupacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Productos]    Script Date: 18/6/2021 16:29:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Productos](
	[CodProducto] [int] NOT NULL,
	[CodProvedor] [int] NULL,
	[CodCategoria] [int] NULL,
	[CodUnidadMedida] [int] NULL,
	[Descripcion] [nvarchar](50) NULL,
	[Nombre] [nchar](30) NULL,
	[PrecioVenta] [decimal](16, 2) NULL,
	[PrecioCompra] [decimal](16, 2) NULL,
 CONSTRAINT [PK_Productos] PRIMARY KEY CLUSTERED 
(
	[CodProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Proveedores]    Script Date: 18/6/2021 16:29:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proveedores](
	[CodProvedor] [int] NOT NULL,
	[Nombre] [varchar](30) NULL,
	[Correo] [varchar](30) NULL,
	[Direccion] [varchar](50) NULL,
	[Telefono] [int] NULL,
 CONSTRAINT [PK_Proveedores] PRIMARY KEY CLUSTERED 
(
	[CodProvedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Puestos]    Script Date: 18/6/2021 16:29:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Puestos](
	[idPuesto] [int] NOT NULL,
	[Nombre] [varchar](50) NULL,
 CONSTRAINT [PK_Puestos] PRIMARY KEY CLUSTERED 
(
	[idPuesto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tiendas]    Script Date: 18/6/2021 16:29:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tiendas](
	[CodigoTienda] [int] NOT NULL,
	[CodigoEncargado] [int] NULL,
	[CodigoEmpleado] [int] NULL,
	[Direccion] [nvarchar](50) NULL,
	[NombreTienda] [nvarchar](30) NULL,
	[Telefono] [int] NULL,
	[Correo] [nvarchar](30) NULL,
 CONSTRAINT [PK_Tiendas] PRIMARY KEY CLUSTERED 
(
	[CodigoTienda] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoPago]    Script Date: 18/6/2021 16:29:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoPago](
	[CodTipoPago] [int] NOT NULL,
	[Descripcion] [nvarchar](50) NULL,
 CONSTRAINT [PK_TipoPago] PRIMARY KEY CLUSTERED 
(
	[CodTipoPago] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UnidadesDeMedida]    Script Date: 18/6/2021 16:29:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UnidadesDeMedida](
	[CodUnidadesDeMedida] [int] NOT NULL,
	[Nombre] [nvarchar](30) NULL,
 CONSTRAINT [PK_UnidadesDeMedida] PRIMARY KEY CLUSTERED 
(
	[CodUnidadesDeMedida] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Categorias] ([CodCategoria], [Nombre], [Descripcion]) VALUES (1, N'Maderas', N'Hola')
GO
INSERT [dbo].[Categorias] ([CodCategoria], [Nombre], [Descripcion]) VALUES (2, N'Clavos', N'Hola





')
GO
INSERT [dbo].[Categorias] ([CodCategoria], [Nombre], [Descripcion]) VALUES (3, N'Pintura', N'Hola')
GO
INSERT [dbo].[Clientes] ([CodCliente], [Nombre], [Telefono], [Correo], [Direccion]) VALUES (1, N'kenny', 5367685, N'769+', N'ugu')
GO
INSERT [dbo].[Clientes] ([CodCliente], [Nombre], [Telefono], [Correo], [Direccion]) VALUES (2, N'james', 888888, N'kenny', N'
ijiojoijoijuioujhiohio

')
GO
INSERT [dbo].[Productos] ([CodProducto], [CodProvedor], [CodCategoria], [CodUnidadMedida], [Descripcion], [Nombre], [PrecioVenta], [PrecioCompra]) VALUES (1, 1, 2, 1, N'4', N'1                             ', CAST(3.00 AS Decimal(16, 2)), CAST(5.00 AS Decimal(16, 2)))
GO
INSERT [dbo].[Productos] ([CodProducto], [CodProvedor], [CodCategoria], [CodUnidadMedida], [Descripcion], [Nombre], [PrecioVenta], [PrecioCompra]) VALUES (2, 1, 2, 1, N'
2




', N'Tornillos                     ', CAST(1.00 AS Decimal(16, 2)), CAST(3.00 AS Decimal(16, 2)))
GO
INSERT [dbo].[Productos] ([CodProducto], [CodProvedor], [CodCategoria], [CodUnidadMedida], [Descripcion], [Nombre], [PrecioVenta], [PrecioCompra]) VALUES (3, 1, 2, 1, N'
 e




', N'fqw                           ', CAST(15.00 AS Decimal(16, 2)), CAST(15.00 AS Decimal(16, 2)))
GO
INSERT [dbo].[Productos] ([CodProducto], [CodProvedor], [CodCategoria], [CodUnidadMedida], [Descripcion], [Nombre], [PrecioVenta], [PrecioCompra]) VALUES (4, 1, 2, 1, N'
sdg




', N'fds                           ', CAST(21.21 AS Decimal(16, 2)), CAST(21.12 AS Decimal(16, 2)))
GO
INSERT [dbo].[Productos] ([CodProducto], [CodProvedor], [CodCategoria], [CodUnidadMedida], [Descripcion], [Nombre], [PrecioVenta], [PrecioCompra]) VALUES (5, 1, 2, 1, N'dwq', N'ca                            ', CAST(7.00 AS Decimal(16, 2)), CAST(6.00 AS Decimal(16, 2)))
GO
INSERT [dbo].[Productos] ([CodProducto], [CodProvedor], [CodCategoria], [CodUnidadMedida], [Descripcion], [Nombre], [PrecioVenta], [PrecioCompra]) VALUES (6, 1, 2, 1, N'sd', N'ken                           ', CAST(25.00 AS Decimal(16, 2)), CAST(40.00 AS Decimal(16, 2)))
GO
INSERT [dbo].[Productos] ([CodProducto], [CodProvedor], [CodCategoria], [CodUnidadMedida], [Descripcion], [Nombre], [PrecioVenta], [PrecioCompra]) VALUES (7, 1, 2, 1, N'sa', N'clavos                        ', CAST(400.00 AS Decimal(16, 2)), CAST(500.00 AS Decimal(16, 2)))
GO
INSERT [dbo].[Productos] ([CodProducto], [CodProvedor], [CodCategoria], [CodUnidadMedida], [Descripcion], [Nombre], [PrecioVenta], [PrecioCompra]) VALUES (8, 1, 3, 1, N'PINTURA NARANJA', N'PINTURA                       ', CAST(10000.00 AS Decimal(16, 2)), CAST(1025.00 AS Decimal(16, 2)))
GO
INSERT [dbo].[Proveedores] ([CodProvedor], [Nombre], [Correo], [Direccion], [Telefono]) VALUES (1, N'Distribuidor SA', N'S.A@gmail.com', N'Cartago Costa Rica', 88774455)
GO
INSERT [dbo].[Proveedores] ([CodProvedor], [Nombre], [Correo], [Direccion], [Telefono]) VALUES (2, N'Todo herramientas', N'Todo@gmail.com', N'Paraiso de cartago ', 66554488)
GO
INSERT [dbo].[Proveedores] ([CodProvedor], [Nombre], [Correo], [Direccion], [Telefono]) VALUES (3, N'Lanco', N'lanco@hotmail.com', N'San Jose calle me quede sin ideas', 45679865)
GO
INSERT [dbo].[UnidadesDeMedida] ([CodUnidadesDeMedida], [Nombre]) VALUES (1, N'Kilos')
GO
INSERT [dbo].[UnidadesDeMedida] ([CodUnidadesDeMedida], [Nombre]) VALUES (2, N'Unidades')
GO
INSERT [dbo].[UnidadesDeMedida] ([CodUnidadesDeMedida], [Nombre]) VALUES (3, N'Galon')
GO
INSERT [dbo].[UnidadesDeMedida] ([CodUnidadesDeMedida], [Nombre]) VALUES (4, N'Bolsas')
GO
ALTER TABLE [dbo].[DetalleVenta]  WITH CHECK ADD  CONSTRAINT [FK_DetalleVenta_MaestroVentas] FOREIGN KEY([NumeroVenta])
REFERENCES [dbo].[MaestroVentas] ([CodNumeroVenta])
GO
ALTER TABLE [dbo].[DetalleVenta] CHECK CONSTRAINT [FK_DetalleVenta_MaestroVentas]
GO
ALTER TABLE [dbo].[DetalleVenta]  WITH CHECK ADD  CONSTRAINT [FK_DetalleVenta_Productos] FOREIGN KEY([CodProducto])
REFERENCES [dbo].[Productos] ([CodProducto])
GO
ALTER TABLE [dbo].[DetalleVenta] CHECK CONSTRAINT [FK_DetalleVenta_Productos]
GO
ALTER TABLE [dbo].[Empleados]  WITH CHECK ADD  CONSTRAINT [FK_Empleados_Ocupaciones] FOREIGN KEY([CodOcupacion])
REFERENCES [dbo].[Ocupaciones] ([CodOcupacion])
GO
ALTER TABLE [dbo].[Empleados] CHECK CONSTRAINT [FK_Empleados_Ocupaciones]
GO
ALTER TABLE [dbo].[Ingresos]  WITH CHECK ADD  CONSTRAINT [FK_Ingresos_Empleados] FOREIGN KEY([CodEmpleado])
REFERENCES [dbo].[Empleados] ([CodigoEmpleado])
GO
ALTER TABLE [dbo].[Ingresos] CHECK CONSTRAINT [FK_Ingresos_Empleados]
GO
ALTER TABLE [dbo].[Ingresos]  WITH CHECK ADD  CONSTRAINT [FK_Ingresos_Productos] FOREIGN KEY([CodProducto])
REFERENCES [dbo].[Productos] ([CodProducto])
GO
ALTER TABLE [dbo].[Ingresos] CHECK CONSTRAINT [FK_Ingresos_Productos]
GO
ALTER TABLE [dbo].[Ingresos]  WITH CHECK ADD  CONSTRAINT [FK_Ingresos_Tiendas] FOREIGN KEY([CodigoTienda])
REFERENCES [dbo].[Tiendas] ([CodigoTienda])
GO
ALTER TABLE [dbo].[Ingresos] CHECK CONSTRAINT [FK_Ingresos_Tiendas]
GO
ALTER TABLE [dbo].[Inventario]  WITH CHECK ADD  CONSTRAINT [FK_Inventario_Productos] FOREIGN KEY([CodProducto])
REFERENCES [dbo].[Productos] ([CodProducto])
GO
ALTER TABLE [dbo].[Inventario] CHECK CONSTRAINT [FK_Inventario_Productos]
GO
ALTER TABLE [dbo].[Inventario]  WITH CHECK ADD  CONSTRAINT [FK_Inventario_Tiendas] FOREIGN KEY([CodigoTienda])
REFERENCES [dbo].[Tiendas] ([CodigoTienda])
GO
ALTER TABLE [dbo].[Inventario] CHECK CONSTRAINT [FK_Inventario_Tiendas]
GO
ALTER TABLE [dbo].[MaestroVentas]  WITH CHECK ADD  CONSTRAINT [FK_MaestroVentas_Clientes] FOREIGN KEY([CodCliente])
REFERENCES [dbo].[Clientes] ([CodCliente])
GO
ALTER TABLE [dbo].[MaestroVentas] CHECK CONSTRAINT [FK_MaestroVentas_Clientes]
GO
ALTER TABLE [dbo].[MaestroVentas]  WITH CHECK ADD  CONSTRAINT [FK_MaestroVentas_Tiendas] FOREIGN KEY([CodigoTienda])
REFERENCES [dbo].[Tiendas] ([CodigoTienda])
GO
ALTER TABLE [dbo].[MaestroVentas] CHECK CONSTRAINT [FK_MaestroVentas_Tiendas]
GO
ALTER TABLE [dbo].[MaestroVentas]  WITH CHECK ADD  CONSTRAINT [FK_MaestroVentas_TipoPago] FOREIGN KEY([CodTipoPago])
REFERENCES [dbo].[TipoPago] ([CodTipoPago])
GO
ALTER TABLE [dbo].[MaestroVentas] CHECK CONSTRAINT [FK_MaestroVentas_TipoPago]
GO
ALTER TABLE [dbo].[Productos]  WITH CHECK ADD  CONSTRAINT [FK_Productos_Categorias] FOREIGN KEY([CodCategoria])
REFERENCES [dbo].[Categorias] ([CodCategoria])
GO
ALTER TABLE [dbo].[Productos] CHECK CONSTRAINT [FK_Productos_Categorias]
GO
ALTER TABLE [dbo].[Productos]  WITH CHECK ADD  CONSTRAINT [FK_Productos_Proveedores] FOREIGN KEY([CodProvedor])
REFERENCES [dbo].[Proveedores] ([CodProvedor])
GO
ALTER TABLE [dbo].[Productos] CHECK CONSTRAINT [FK_Productos_Proveedores]
GO
ALTER TABLE [dbo].[Productos]  WITH CHECK ADD  CONSTRAINT [FK_Productos_UnidadesDeMedida] FOREIGN KEY([CodUnidadMedida])
REFERENCES [dbo].[UnidadesDeMedida] ([CodUnidadesDeMedida])
GO
ALTER TABLE [dbo].[Productos] CHECK CONSTRAINT [FK_Productos_UnidadesDeMedida]
GO
ALTER TABLE [dbo].[Tiendas]  WITH CHECK ADD  CONSTRAINT [FK_Tiendas_Empleados] FOREIGN KEY([CodigoEmpleado])
REFERENCES [dbo].[Empleados] ([CodigoEmpleado])
GO
ALTER TABLE [dbo].[Tiendas] CHECK CONSTRAINT [FK_Tiendas_Empleados]
GO
ALTER TABLE [dbo].[Tiendas]  WITH CHECK ADD  CONSTRAINT [FK_Tiendas_Encargados] FOREIGN KEY([CodigoEncargado])
REFERENCES [dbo].[Encargados] ([CodigoEncargado])
GO
ALTER TABLE [dbo].[Tiendas] CHECK CONSTRAINT [FK_Tiendas_Encargados]
GO
/****** Object:  StoredProcedure [dbo].[AgregarCliente]    Script Date: 18/6/2021 16:29:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[AgregarCliente]
@CodCliente int,
@Nombre nvarchar(30),
@Telefono int,
@Correo nvarchar(30),
@Direccion nvarchar(50)

as
begin
insert into Clientes(CodCliente,Nombre,Telefono,Correo,Direccion) values(@CodCliente,@Nombre,@Telefono,@Correo,@Direccion)
end
GO
/****** Object:  StoredProcedure [dbo].[MostrarCliente]    Script Date: 18/6/2021 16:29:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[MostrarCliente]
as
begin
select CodCliente,Nombre,Telefono,Correo,Direccion from Clientes
end
GO
/****** Object:  StoredProcedure [dbo].[psInsertarPuesto]    Script Date: 18/6/2021 16:29:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[psInsertarPuesto] @codCategoria int

as
	-- falta definir
GO
/****** Object:  StoredProcedure [dbo].[spAgregarProducto]    Script Date: 18/6/2021 16:29:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spAgregarProducto]
@CodCategoria int,
@CodProvedor int,
@CodProducto int,
@CodUnidadMedida int,
@Descripcion nvarchar(50),
@PrecioVenta decimal(16,2),
@PrecioCompra decimal(16,2), 
@Nombre  nvarchar(30)

as
begin
insert into Productos(CodCategoria,CodProvedor,CodProducto,CodUnidadMedida,Descripcion,PrecioCompra, PrecioVenta,Nombre) values(@CodCategoria,@CodProvedor,@CodProducto,@CodUnidadMedida,@Descripcion,@PrecioVenta,@PrecioCompra,@Nombre)
end
GO
/****** Object:  StoredProcedure [dbo].[spAgregarProvedor]    Script Date: 18/6/2021 16:29:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[spAgregarProvedor]

@CodProvedor int,
@Nombre nvarchar(30),
@Correo nvarchar(30),
@Direccion nvarchar(50),
@Telefono int

as
begin
insert into Proveedores(CodProvedor,Nombre,Telefono,Correo,Direccion) values(@CodProvedor,@Nombre,@Telefono,@Correo,@Direccion)
end
GO
/****** Object:  StoredProcedure [dbo].[spAgregarUnidadMedida]    Script Date: 18/6/2021 16:29:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spAgregarUnidadMedida]
@CodUnidadesDeMedida int,
@Nombre nvarchar(30)

as
begin
insert into UnidadesDeMedida(CodUnidadesDeMedida,Nombre) values(@CodUnidadesDeMedida,@Nombre)
end
GO
/****** Object:  StoredProcedure [dbo].[spElimanarCategoria]    Script Date: 18/6/2021 16:29:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spElimanarCategoria] @CodCategoria int 

AS
DELETE FROM Categorias
where @CodCategoria = CodCategoria
GO
/****** Object:  StoredProcedure [dbo].[spElimanarCliente]    Script Date: 18/6/2021 16:29:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[spElimanarCliente] @Codcliente int 

AS
DELETE FROM Clientes
where @Codcliente = CodCliente
GO
/****** Object:  StoredProcedure [dbo].[spElimanarProvedor]    Script Date: 18/6/2021 16:29:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[spElimanarProvedor] @CodProvedor int 

AS
DELETE FROM Proveedores
where @CodProvedor = CodProvedor
GO
/****** Object:  StoredProcedure [dbo].[spElimanarUnidadMedida]    Script Date: 18/6/2021 16:29:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[spElimanarUnidadMedida] @CodUnidadesDeMedida int 

AS
DELETE FROM UnidadesDeMedida
where @CodUnidadesDeMedida = CodUnidadesDeMedida
GO
/****** Object:  StoredProcedure [dbo].[spInsertarCategoria]    Script Date: 18/6/2021 16:29:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spInsertarCategoria] @CodCategoria int, @Nombre nvarchar(25), @Descripcion nvarchar(30)

as
insert into Categorias (CodCategoria,Nombre,Descripcion)
values (@CodCategoria, @Nombre,@Descripcion)
GO
/****** Object:  StoredProcedure [dbo].[spModificarCategoria]    Script Date: 18/6/2021 16:29:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spModificarCategoria]

@CodCategoria int,
@Nombre nvarchar(30),
@Descripcion nvarchar(50)

as
begin
update Categorias set  Nombre = @Nombre ,@Descripcion = @Descripcion
where CodCategoria = @CodCategoria
end
GO
/****** Object:  StoredProcedure [dbo].[spModificarCliente]    Script Date: 18/6/2021 16:29:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spModificarCliente]
@CodCliente int,
@Nombre nvarchar(30),
@Telefono int,
@Correo nvarchar(30),
@Direccion nvarchar(50)

as
begin
update Clientes set  Nombre = @Nombre ,Telefono = @Telefono,Correo  = @Correo ,Direccion = @Direccion
where CodCliente = @CodCliente
end
GO
/****** Object:  StoredProcedure [dbo].[spModificarProvedor]    Script Date: 18/6/2021 16:29:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spModificarProvedor]
@CodProvedor int,
@Nombre nvarchar(30),
@Telefono int,
@Correo nvarchar(30),
@Direccion nvarchar(50)

as
begin
update Proveedores set  Nombre = @Nombre ,Telefono = @Telefono,Correo  = @Correo ,Direccion = @Direccion
where CodProvedor = @CodProvedor
end
GO
/****** Object:  StoredProcedure [dbo].[spModificarPuesto]    Script Date: 18/6/2021 16:29:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[spModificarPuesto] @codCategoria int

as
	-- falta definir
GO
/****** Object:  StoredProcedure [dbo].[spModificarUnidad]    Script Date: 18/6/2021 16:29:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spModificarUnidad]

@CodUnidadesDeMedida int,
@Nombre nvarchar(30)


as
begin
update UnidadesDeMedida set  Nombre = @Nombre 
where @CodUnidadesDeMedida = CodUnidadesDeMedida
end
GO
/****** Object:  StoredProcedure [dbo].[spMostrarProvedor]    Script Date: 18/6/2021 16:29:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spMostrarProvedor]
as
begin
select CodProvedor,Nombre,Telefono,Correo,Direccion from Proveedores
end
GO
/****** Object:  StoredProcedure [dbo].[spMostrarUnidades]    Script Date: 18/6/2021 16:29:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spMostrarUnidades]
as
begin
select CodUnidadesDeMedida,Nombre from UnidadesDeMedida
end
GO
/****** Object:  StoredProcedure [dbo].[spObtenerMaximaUnidad]    Script Date: 18/6/2021 16:29:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[spObtenerMaximaUnidad]

as
select max(CodUnidadesDeMedida)
from UnidadesDeMedida
GO
/****** Object:  StoredProcedure [dbo].[spObtenerMaximoCategoria]    Script Date: 18/6/2021 16:29:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spObtenerMaximoCategoria] 

as
select max(CodCategoria)
from Categorias
GO
/****** Object:  StoredProcedure [dbo].[spObtenerMaximoCliente]    Script Date: 18/6/2021 16:29:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[spObtenerMaximoCliente]

as
select max(CodCliente)
from Clientes
GO
/****** Object:  StoredProcedure [dbo].[spObtenerMaximoProducto]    Script Date: 18/6/2021 16:29:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[spObtenerMaximoProducto]

as
select max(CodProducto)
from Productos
GO
/****** Object:  StoredProcedure [dbo].[spObtenerMaximoProvedor]    Script Date: 18/6/2021 16:29:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spObtenerMaximoProvedor]

as
select max(CodProvedor)
from Proveedores
GO
/****** Object:  StoredProcedure [dbo].[spSeleccionarCategoria]    Script Date: 18/6/2021 16:29:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spSeleccionarCategoria] @CodCategoria int

as
select*
from Categorias
where CodCategoria =@CodCategoria
GO
/****** Object:  StoredProcedure [dbo].[spSeleccionarCategorias]    Script Date: 18/6/2021 16:29:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[spSeleccionarCategorias] 

as
select*
From Categorias
Order by Nombre
GO
/****** Object:  StoredProcedure [dbo].[spSeleccionarCategoriasNombre]    Script Date: 18/6/2021 16:29:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spSeleccionarCategoriasNombre] @Nombre NVARCHAR(30)

as
select*
from Categorias
where Nombre LIKE '%' +@Nombre + '%'
order by Nombre 
GO
/****** Object:  StoredProcedure [dbo].[spSeleccionarClientesNombre]    Script Date: 18/6/2021 16:29:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spSeleccionarClientesNombre] @Nombre NVARCHAR(30)

as
select*
from Clientes
where Nombre LIKE '%' +@Nombre + '%'
order by Nombre 
GO
/****** Object:  StoredProcedure [dbo].[spSeleccionarProductos]    Script Date: 18/6/2021 16:29:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spSeleccionarProductos]

as
select P.CodProducto, P.Nombre, P.Descripcion, C.Nombre as categoria, PR.Nombre as Proveedor,UM.Nombre as Unidad_de_medida,  P.PrecioCompra, P.PrecioVenta
from Productos P join Categorias C on P.CodCategoria= C.CodCategoria
				 join Proveedores PR on p.CodProvedor = PR.CodProvedor
				 join UnidadesDeMedida UM on P.CodUnidadMedida = UM.CodUnidadesDeMedida



GO
/****** Object:  StoredProcedure [dbo].[spSeleccionarProvedorNombre]    Script Date: 18/6/2021 16:29:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[spSeleccionarProvedorNombre] @Nombre NVARCHAR(30)

as
select*
from Proveedores
where Nombre LIKE '%' +@Nombre + '%'
order by Nombre 
GO
USE [master]
GO
ALTER DATABASE [Ferreteria] SET  READ_WRITE 
GO
