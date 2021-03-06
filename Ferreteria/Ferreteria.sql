USE [master]
GO
/****** Object:  Database [Ferreteria]    Script Date: 28/6/2021 14:58:25 ******/
CREATE DATABASE [Ferreteria]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Ferreteria', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Ferreteria.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Ferreteria_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Ferreteria_log.ldf' , SIZE = 73728KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
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
/****** Object:  Table [dbo].[BitacoraMantenimiento]    Script Date: 28/6/2021 14:58:25 ******/
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
/****** Object:  Table [dbo].[Categorias]    Script Date: 28/6/2021 14:58:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categorias](
	[CodCategoria] [int] NOT NULL,
	[Nombre] [varchar](30) NULL,
	[Descripcion] [varchar](70) NULL,
 CONSTRAINT [PK_Categorias] PRIMARY KEY CLUSTERED 
(
	[CodCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 28/6/2021 14:58:25 ******/
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
/****** Object:  Table [dbo].[DetalleVenta]    Script Date: 28/6/2021 14:58:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleVenta](
	[NumeroVenta] [int] NULL,
	[CodProducto] [int] NULL,
	[Cantidad] [int] NULL,
	[Precio] [int] NULL,
	[Total] [int] NULL,
	[CodDetalle] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empleados]    Script Date: 28/6/2021 14:58:25 ******/
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
	[FechaNacimiento] [nvarchar](50) NULL,
	[CodSucursal] [int] NULL,
 CONSTRAINT [PK_Empleados] PRIMARY KEY CLUSTERED 
(
	[CodigoEmpleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Encargados]    Script Date: 28/6/2021 14:58:25 ******/
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
/****** Object:  Table [dbo].[Ingresos]    Script Date: 28/6/2021 14:58:25 ******/
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
/****** Object:  Table [dbo].[Inventario]    Script Date: 28/6/2021 14:58:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inventario](
	[CodTienda] [int] NULL,
	[CodProducto] [int] NULL,
	[Cantidad] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MaestroVentas]    Script Date: 28/6/2021 14:58:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MaestroVentas](
	[CodNumeroVenta] [int] NOT NULL,
	[Fecha] [nvarchar](50) NULL,
	[Subtotal] [int] NULL,
	[IVA] [int] NULL,
	[Total] [int] NULL,
	[CodCliente] [nvarchar](50) NULL,
	[CodTipoPago] [nvarchar](50) NULL,
	[CodigoTienda] [nvarchar](50) NULL,
 CONSTRAINT [PK_MaestroVentas] PRIMARY KEY CLUSTERED 
(
	[CodNumeroVenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ocupaciones]    Script Date: 28/6/2021 14:58:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ocupaciones](
	[CodOcupacion] [int] NOT NULL,
	[Ocupacion] [nvarchar](30) NULL,
	[Descripcion] [nvarchar](50) NULL,
 CONSTRAINT [PK_Ocupaciones] PRIMARY KEY CLUSTERED 
(
	[CodOcupacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Productos]    Script Date: 28/6/2021 14:58:25 ******/
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
	[Nombre] [nvarchar](50) NULL,
	[PrecioVenta] [int] NULL,
	[PrecioCompra] [int] NULL,
 CONSTRAINT [PK_Productos] PRIMARY KEY CLUSTERED 
(
	[CodProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Proveedores]    Script Date: 28/6/2021 14:58:25 ******/
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
/****** Object:  Table [dbo].[Puestos]    Script Date: 28/6/2021 14:58:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Puestos](
	[CodPuesto] [int] NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Descripcion] [nchar](50) NULL,
 CONSTRAINT [PK_Puestos] PRIMARY KEY CLUSTERED 
(
	[CodPuesto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tiendas]    Script Date: 28/6/2021 14:58:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tiendas](
	[CodTienda] [int] NOT NULL,
	[CodEncargado] [int] NULL,
	[CodEmpleado] [int] NULL,
	[Direccion] [nvarchar](50) NULL,
	[NombreTienda] [nvarchar](30) NULL,
	[Telefono] [int] NULL,
	[Correo] [nvarchar](30) NULL,
 CONSTRAINT [PK_Tiendas] PRIMARY KEY CLUSTERED 
(
	[CodTienda] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoPago]    Script Date: 28/6/2021 14:58:25 ******/
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
/****** Object:  Table [dbo].[UnidadesDeMedida]    Script Date: 28/6/2021 14:58:25 ******/
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
ALTER TABLE [dbo].[Empleados]  WITH CHECK ADD FOREIGN KEY([CodSucursal])
REFERENCES [dbo].[Tiendas] ([CodTienda])
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
REFERENCES [dbo].[Tiendas] ([CodTienda])
GO
ALTER TABLE [dbo].[Ingresos] CHECK CONSTRAINT [FK_Ingresos_Tiendas]
GO
ALTER TABLE [dbo].[Inventario]  WITH CHECK ADD  CONSTRAINT [FK_Inventario_Productos] FOREIGN KEY([CodProducto])
REFERENCES [dbo].[Productos] ([CodProducto])
GO
ALTER TABLE [dbo].[Inventario] CHECK CONSTRAINT [FK_Inventario_Productos]
GO
ALTER TABLE [dbo].[Inventario]  WITH CHECK ADD  CONSTRAINT [FK_Inventario_Tiendas] FOREIGN KEY([CodTienda])
REFERENCES [dbo].[Tiendas] ([CodTienda])
GO
ALTER TABLE [dbo].[Inventario] CHECK CONSTRAINT [FK_Inventario_Tiendas]
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
ALTER TABLE [dbo].[Tiendas]  WITH CHECK ADD  CONSTRAINT [FK_Tiendas_Empleados] FOREIGN KEY([CodEmpleado])
REFERENCES [dbo].[Empleados] ([CodigoEmpleado])
GO
ALTER TABLE [dbo].[Tiendas] CHECK CONSTRAINT [FK_Tiendas_Empleados]
GO
ALTER TABLE [dbo].[Tiendas]  WITH CHECK ADD  CONSTRAINT [FK_Tiendas_Encargados] FOREIGN KEY([CodEncargado])
REFERENCES [dbo].[Encargados] ([CodigoEncargado])
GO
ALTER TABLE [dbo].[Tiendas] CHECK CONSTRAINT [FK_Tiendas_Encargados]
GO
/****** Object:  StoredProcedure [dbo].[AgregarCliente]    Script Date: 28/6/2021 14:58:25 ******/
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
/****** Object:  StoredProcedure [dbo].[Aumentarstock]    Script Date: 28/6/2021 14:58:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Aumentarstock]
@CodTienda int,
@CodProducto int,
@Cantidad int
as
begin

update Inventario 
set Cantidad = @Cantidad + Cantidad 
where CodProducto = @CodProducto and CodTienda = @CodTienda
end
GO
/****** Object:  StoredProcedure [dbo].[Disminuirstock]    Script Date: 28/6/2021 14:58:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[Disminuirstock]
@CodTienda int,
@CodProducto int,
@Cantidad int
as
begin

update Inventario 
set Cantidad =  Cantidad - @Cantidad
where CodProducto = @CodProducto and CodTienda = @CodTienda
end
GO
/****** Object:  StoredProcedure [dbo].[MaestroVenta]    Script Date: 28/6/2021 14:58:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[MaestroVenta]

@CodNumeroVenta int,
@Fecha nvarchar(30),
@CodigoTienda nvarchar(50)


as
begin
insert into MaestroVentas(CodNumeroVenta,Fecha,CodigoTienda) values(@CodNumeroVenta,@Fecha,@CodigoTienda)
end

GO
/****** Object:  StoredProcedure [dbo].[ModificarMaestroVentas]    Script Date: 28/6/2021 14:58:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[ModificarMaestroVentas]

@CodNumeroVenta int,
@CodigoTienda nvarchar(50),
@CodTipoPago nvarchar(50),
@CodCliente nvarchar(50),
@Subtotal int, 
@Iva int,
@Total int

as
begin
update MaestroVentas set CodigoTienda = @CodigoTienda,  CodTipoPago=@CodTipoPago ,CodCliente   =@CodCliente,Subtotal=@Subtotal ,Iva= @Iva , Total= @Total
where @CodNumeroVenta = CodNumeroVenta
end
GO
/****** Object:  StoredProcedure [dbo].[MostrarCliente]    Script Date: 28/6/2021 14:58:25 ******/
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
/****** Object:  StoredProcedure [dbo].[psInsertarPuesto]    Script Date: 28/6/2021 14:58:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[psInsertarPuesto] @codCategoria int

as
	-- falta definir
GO
/****** Object:  StoredProcedure [dbo].[sacarTotal]    Script Date: 28/6/2021 14:58:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sacarTotal] 

@CodDetalle int
as
select SUM(Total) as TotalVentas
from DetalleVenta
where NumeroVenta = @CodDetalle
GO
/****** Object:  StoredProcedure [dbo].[spAgregarEmpleado]    Script Date: 28/6/2021 14:58:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spAgregarEmpleado]

@CodEmpleado int,  
@Nombre nvarchar(30), 
@Direccion nvarchar(30), 
@Telefono int, 
@Correo  nvarchar(30),  
@CodOCupacion  int,
@FechaNacimiento  nvarchar(30),
@CodSucursal int
as
begin
insert into Empleados(CodigoEmpleado , Nombre, Direccion ,Telefono, Correo , CodOCupacion , FechaNacimiento,CodSucursal) values(@CodEmpleado,  @Nombre, @Direccion, @Telefono, @Correo,  @CodOCupacion  ,@FechaNacimiento,@CodSucursal)
end
GO
/****** Object:  StoredProcedure [dbo].[spAgregarEncargado]    Script Date: 28/6/2021 14:58:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spAgregarEncargado]

@CodigoEncargado int,
@Nombre nvarchar(50),
@Direccion nvarchar(30),
@Telefono int,
@Correo nvarchar(30)

as
begin
insert into Encargados(CodigoEncargado,Nombre, Direccion, Telefono, Correo) values(@CodigoEncargado,@Nombre, @Direccion, @Telefono, @Correo)
end
GO
/****** Object:  StoredProcedure [dbo].[spAgregarProducto]    Script Date: 28/6/2021 14:58:25 ******/
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
@PrecioVenta int,
@PrecioCompra int, 
@Nombre  nvarchar(30)

as
begin
insert into Productos(CodCategoria,CodProvedor,CodProducto,CodUnidadMedida,Descripcion,PrecioCompra, PrecioVenta,Nombre) values(@CodCategoria,@CodProvedor,@CodProducto,@CodUnidadMedida,@Descripcion,@PrecioCompra,@PrecioVenta,@Nombre)
end
GO
/****** Object:  StoredProcedure [dbo].[spAgregarProvedor]    Script Date: 28/6/2021 14:58:25 ******/
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
/****** Object:  StoredProcedure [dbo].[spAgregarSucursal]    Script Date: 28/6/2021 14:58:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spAgregarSucursal]

@CodTienda int,
@CodEncargado int,
@Direccion nvarchar(50),
@NombreTienda nvarchar(30),
@Telefono int,
@Correo nvarchar(30)

as
begin
insert into Tiendas(CodTienda,CodEncargado, Direccion, NombreTienda,Telefono,Correo) values(@CodTienda,@CodEncargado, @Direccion, @NombreTienda,@Telefono,@Correo)
end


 
 
 
 
 
 
 
GO
/****** Object:  StoredProcedure [dbo].[spAgregarUnidadMedida]    Script Date: 28/6/2021 14:58:25 ******/
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
/****** Object:  StoredProcedure [dbo].[spAgregarVenta]    Script Date: 28/6/2021 14:58:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spAgregarVenta]

@NumeroVenta int,
@CodProducto int,
@Cantidad int,
@Precio int,
@Total int,
@Venta int
as
begin
insert into DetalleVenta(NumeroVenta,CodProducto,Cantidad,Precio,Total,CodDetalle) values(@NumeroVenta,@CodProducto,@Cantidad,@Precio,@Total,@Venta)
end
GO
/****** Object:  StoredProcedure [dbo].[spBuscarInventarioNombre]    Script Date: 28/6/2021 14:58:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spBuscarInventarioNombre] 

@Nombre NVARCHAR(30),
@CodTienda int

AS
select P.CodProducto, P.Nombre, I.Cantidad as Cantidad, P.Descripcion, C.Nombre as Categoria, PR.Nombre as Proveedor,UM.Nombre as Unidad_de_medida,  P.PrecioCompra, P.PrecioVenta
from  Inventario I join Productos P on I.CodProducto = P.CodProducto
				 join Categorias C on P.CodCategoria= C.CodCategoria
				 join Proveedores PR on p.CodProvedor = PR.CodProvedor
				 join UnidadesDeMedida UM on P.CodUnidadMedida = UM.CodUnidadesDeMedida
WHERE P.Nombre LIKE '%' +@Nombre + '%' AND I.CodTienda = @CodTienda
ORDER BY P.CodProducto
GO
/****** Object:  StoredProcedure [dbo].[spCrearInventario]    Script Date: 28/6/2021 14:58:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spCrearInventario]


@CodTienda int,
@CodProducto int,
@Cantidad int


as
begin
insert into Inventario(CodTienda,CodProducto, Cantidad) values(@CodTienda,@CodProducto,@Cantidad)
end

GO
/****** Object:  StoredProcedure [dbo].[spCrearOcupacion]    Script Date: 28/6/2021 14:58:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spCrearOcupacion]

@CodOcupacion int,
@Ocupacion nvarchar(30),
@Descripcion nvarchar(50)


as
begin
insert into Ocupaciones(CodOcupacion,Ocupacion,Descripcion) values(@CodOcupacion,@Ocupacion,@Descripcion)
end

GO
/****** Object:  StoredProcedure [dbo].[spCrearTienda]    Script Date: 28/6/2021 14:58:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spCrearTienda]

@CodTienda int,
@CodEncargado int,
@CodEmpleado int,
@Direccion nvarchar(50),
@NombreTienda nvarchar(50),
@Telefono int,
@Correo nvarchar(30)

as
begin
insert into Tiendas(CodTienda,CodEncargado,CodEmpleado,Direccion,NombreTienda,Telefono,Correo) values(@CodTienda,@CodEncargado,@CodEmpleado,@Direccion,@NombreTienda,@Telefono,@Correo)
end

GO
/****** Object:  StoredProcedure [dbo].[spDevolverProducto]    Script Date: 28/6/2021 14:58:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spDevolverProducto]

@CodDetalle int ,
@NumeroVenta int
AS
DELETE FROM DetalleVenta
where CodDetalle = @CodDetalle and NumeroVenta= @NumeroVenta
GO
/****** Object:  StoredProcedure [dbo].[spElimanarCategoria]    Script Date: 28/6/2021 14:58:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spElimanarCategoria] @CodCategoria int 

AS
DELETE FROM Categorias
where @CodCategoria = CodCategoria
GO
/****** Object:  StoredProcedure [dbo].[spElimanarCliente]    Script Date: 28/6/2021 14:58:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[spElimanarCliente] @Codcliente int 

AS
DELETE FROM Clientes
where @Codcliente = CodCliente
GO
/****** Object:  StoredProcedure [dbo].[spElimanarEmpleado]    Script Date: 28/6/2021 14:58:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[spElimanarEmpleado] @CodEmpleado int 

AS
DELETE FROM Empleados
where @CodEmpleado = CodigoEmpleado
GO
/****** Object:  StoredProcedure [dbo].[spElimanarEncargado]    Script Date: 28/6/2021 14:58:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[spElimanarEncargado] @CodigoEncargado int 

AS
DELETE FROM Encargados
where @CodigoEncargado = CodigoEncargado
GO
/****** Object:  StoredProcedure [dbo].[spElimanarOcupacion]    Script Date: 28/6/2021 14:58:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[spElimanarOcupacion] @CodOcupacion int 

AS
DELETE FROM Ocupaciones
where @CodOcupacion = CodOcupacion
GO
/****** Object:  StoredProcedure [dbo].[spElimanarProducto]    Script Date: 28/6/2021 14:58:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[spElimanarProducto] @CodProducto int 

AS

DELETE FROM DetalleVenta
where CodProducto = @CodProducto 


DELETE FROM Inventario
WHERE @CodProducto = CodProducto


DELETE FROM Productos
where @CodProducto = CodProducto

GO
/****** Object:  StoredProcedure [dbo].[spElimanarProvedor]    Script Date: 28/6/2021 14:58:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[spElimanarProvedor] @CodProvedor int 

AS
DELETE FROM Proveedores
where @CodProvedor = CodProvedor
GO
/****** Object:  StoredProcedure [dbo].[spElimanarSucursal]    Script Date: 28/6/2021 14:58:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spElimanarSucursal] @Tiendas int 

AS
delete from Inventario
where @Tiendas = CodTienda

DELETE FROM Tiendas
where @Tiendas = CodTienda


GO
/****** Object:  StoredProcedure [dbo].[spElimanarUnidadMedida]    Script Date: 28/6/2021 14:58:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[spElimanarUnidadMedida] @CodUnidadesDeMedida int 

AS
DELETE FROM UnidadesDeMedida
where @CodUnidadesDeMedida = CodUnidadesDeMedida
GO
/****** Object:  StoredProcedure [dbo].[spElimanarVenta]    Script Date: 28/6/2021 14:58:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spElimanarVenta] @CodDetalle int 

AS


DELETE FROM DetalleVenta
where NumeroVenta = @CodDetalle


delete from MaestroVentas
where CodNumeroVenta = @CodDetalle

GO
/****** Object:  StoredProcedure [dbo].[spInsertarCategoria]    Script Date: 28/6/2021 14:58:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spInsertarCategoria] @CodCategoria int, @Nombre nvarchar(25), @Descripcion nvarchar(70)

as
insert into Categorias (CodCategoria,Nombre,Descripcion)
values (@CodCategoria, @Nombre,@Descripcion)
GO
/****** Object:  StoredProcedure [dbo].[spModificarCargo]    Script Date: 28/6/2021 14:58:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spModificarCargo]

@CodOcupacion int,
@Nombre nvarchar(50),
@Descripcion nvarchar(70)


as
begin
update Ocupaciones set  Ocupacion = @Nombre,   Descripcion = @Descripcion
where @CodOcupacion = CodOcupacion
end
GO
/****** Object:  StoredProcedure [dbo].[spModificarCategoria]    Script Date: 28/6/2021 14:58:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spModificarCategoria]

@CodCategoria int,
@Nombre nvarchar(30),
@Descripcion nvarchar(70)

as
begin
update Categorias set  Nombre = @Nombre , Descripcion = @Descripcion
where CodCategoria = @CodCategoria
end
GO
/****** Object:  StoredProcedure [dbo].[spModificarCliente]    Script Date: 28/6/2021 14:58:25 ******/
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
/****** Object:  StoredProcedure [dbo].[spModificarEmpleado]    Script Date: 28/6/2021 14:58:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spModificarEmpleado]

@CodEmpleado int


as
select E.CodigoEmpleado, E.Nombre,O.CodOcupacion a, E.Telefono, E.FechaNacimiento, E.Correo  ,E.Direccion, E.CodSucursal
from Empleados E join Ocupaciones O on E.CodOcupacion= O.CodOcupacion
where CodigoEmpleado = @CodEmpleado 
order by CodigoEmpleado
GO
/****** Object:  StoredProcedure [dbo].[spModificarEmpleados]    Script Date: 28/6/2021 14:58:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spModificarEmpleados]

@CodEmpleado int,  
@Nombre nvarchar(30), 
@Direccion nvarchar(30), 
@Telefono int, 
@Correo  nvarchar(30),  
@CodOCupacion  int,
@FechaNacimiento  nvarchar(30),
@CodSucursal int

as
begin
update Empleados set  CodigoEmpleado =@CodEmpleado , Nombre = @Nombre, Direccion =@Direccion,Telefono = @Telefono, Correo =@Correo, CodOCupacion =@CodOCupacion, FechaNacimiento =@FechaNacimiento, CodSucursal = @CodSucursal
end
GO
/****** Object:  StoredProcedure [dbo].[spModificarEncargad]    Script Date: 28/6/2021 14:58:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spModificarEncargad]

@CodigoEncargado int,
@Nombre nvarchar(50),
@Direccion nvarchar(30),
@Telefono int,
@Correo nvarchar(30)

as
begin
update Encargados set   Nombre = @Nombre, Direccion =@Direccion,Telefono = @Telefono, Correo =@Correo
where @CodigoEncargado = CodigoEncargado
end
GO
/****** Object:  StoredProcedure [dbo].[spModificarProducto]    Script Date: 28/6/2021 14:58:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spModificarProducto]

@CodProvedor int,
@CodProducto int,
@CodUnidadMedida int,
@Descripcion nvarchar(50),
@PrecioVenta int,
@PrecioCompra int, 
@Nombre  nvarchar(30),
@CodCategoria int

as
begin
update Productos set  Nombre = @Nombre ,PrecioCompra = @PrecioCompra, PrecioVenta  = @PrecioVenta , Descripcion = @Descripcion, CodUnidadMedida = @CodUnidadMedida, CodProvedor = @CodProvedor, CodCategoria= @CodCategoria
where CodProducto = @CodProducto
end
GO
/****** Object:  StoredProcedure [dbo].[spModificarProvedor]    Script Date: 28/6/2021 14:58:25 ******/
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
/****** Object:  StoredProcedure [dbo].[spModificarPuesto]    Script Date: 28/6/2021 14:58:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[spModificarPuesto] @codCategoria int

as
	-- falta definir
GO
/****** Object:  StoredProcedure [dbo].[spModificarSucursal]    Script Date: 28/6/2021 14:58:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spModificarSucursal]
@CodTienda int,
@CodEncargado int,
@Direccion nvarchar(50),
@NombreTienda nvarchar(30),
@Telefono int,
@Correo nvarchar(30)

as
begin
update Tiendas set  CodEncargado = @CodEncargado ,Direccion = @Direccion,NombreTienda = @NombreTienda, Telefono= @Telefono, Correo= @Correo
where CodTienda = @CodTienda
end
GO
/****** Object:  StoredProcedure [dbo].[spModificarUnidad]    Script Date: 28/6/2021 14:58:25 ******/
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
/****** Object:  StoredProcedure [dbo].[spMostrarEncargados]    Script Date: 28/6/2021 14:58:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spMostrarEncargados]
as
begin
select CodigoEncargado,Nombre,Direccion, Telefono,Correo from Encargados
ORDER BY CodigoEncargado
end
GO
/****** Object:  StoredProcedure [dbo].[spMostrarInfoTiendas]    Script Date: 28/6/2021 14:58:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spMostrarInfoTiendas]

@CodTienda int

as
begin
select T.CodTienda, E.Nombre as Nombre_encargado, T.Direccion, NombreTienda,T.Telefono,T.Correo , E.CodigoEncargado
from Tiendas T join Encargados E on T.CodEncargado = E.CodigoEncargado
where CodTienda = @CodTienda
order by CodTienda
end
GO
/****** Object:  StoredProcedure [dbo].[spMostrarProvedor]    Script Date: 28/6/2021 14:58:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spMostrarProvedor]
as
begin
select CodProvedor,Nombre,Telefono,Correo,Direccion from Proveedores
order by CodProvedor
end
GO
/****** Object:  StoredProcedure [dbo].[spMostrarTiendas]    Script Date: 28/6/2021 14:58:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spMostrarTiendas]
as
begin
select CodTienda,CodEncargado, CodEmpleado, Direccion, NombreTienda,Telefono,Correo from Tiendas
order by CodTienda
end
GO
/****** Object:  StoredProcedure [dbo].[spMostrarUnidades]    Script Date: 28/6/2021 14:58:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spMostrarUnidades]
as
begin
select CodUnidadesDeMedida,Nombre from UnidadesDeMedida
order by CodUnidadesDeMedida
end
GO
/****** Object:  StoredProcedure [dbo].[spMostrarVentas]    Script Date: 28/6/2021 14:58:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spMostrarVentas]

@CodVenta nvarchar(50)

as
begin
select CodNumeroVenta as Numero_Factura, Fecha, CodigoTienda as Tienda, CodCliente as Cliente,Subtotal, IVA, Total, CodTipoPago as Tipo_pago
from MaestroVentas 
where CodNumeroVenta LIKE '%' +@CodVenta + '%'
order by CodNumeroVenta desc
end

GO
/****** Object:  StoredProcedure [dbo].[spObtenerCodigoProductos]    Script Date: 28/6/2021 14:58:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spObtenerCodigoProductos]
as
begin
select CodProvedor from Proveedores
order by CodProvedor
end
GO
/****** Object:  StoredProcedure [dbo].[spObtenerMaximaocupacion]    Script Date: 28/6/2021 14:58:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spObtenerMaximaocupacion]

as
select max(CodOcupacion)
from Ocupaciones
GO
/****** Object:  StoredProcedure [dbo].[spObtenerMaximaSucursal]    Script Date: 28/6/2021 14:58:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spObtenerMaximaSucursal]

as
select max(CodTienda)
from Tiendas
GO
/****** Object:  StoredProcedure [dbo].[spObtenerMaximaUnidad]    Script Date: 28/6/2021 14:58:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[spObtenerMaximaUnidad]

as
select max(CodUnidadesDeMedida)
from UnidadesDeMedida
GO
/****** Object:  StoredProcedure [dbo].[spObtenerMaximoCategoria]    Script Date: 28/6/2021 14:58:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spObtenerMaximoCategoria] 

as
select max(CodCategoria)
from Categorias
GO
/****** Object:  StoredProcedure [dbo].[spObtenerMaximoCliente]    Script Date: 28/6/2021 14:58:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[spObtenerMaximoCliente]

as
select max(CodCliente)
from Clientes
GO
/****** Object:  StoredProcedure [dbo].[spObtenerMaximoEmpleado]    Script Date: 28/6/2021 14:58:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[spObtenerMaximoEmpleado]

as
select max(CodigoEmpleado)
from Empleados
GO
/****** Object:  StoredProcedure [dbo].[spObtenerMaximoEncargado]    Script Date: 28/6/2021 14:58:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spObtenerMaximoEncargado]

as
select max(CodigoEncargado)
from Encargados
GO
/****** Object:  StoredProcedure [dbo].[spObtenerMaximoProducto]    Script Date: 28/6/2021 14:58:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[spObtenerMaximoProducto]

as
select max(CodProducto)
from Productos
GO
/****** Object:  StoredProcedure [dbo].[spObtenerMaximoProvedor]    Script Date: 28/6/2021 14:58:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spObtenerMaximoProvedor]

as
select max(CodProvedor)
from Proveedores
GO
/****** Object:  StoredProcedure [dbo].[spObtenerNroDocumento]    Script Date: 28/6/2021 14:58:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spObtenerNroDocumento]

as
select max(CodNumeroVenta)
from MaestroVentas
GO
/****** Object:  StoredProcedure [dbo].[spSeleccionarCategoria]    Script Date: 28/6/2021 14:58:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spSeleccionarCategoria] @CodCategoria int

as
select*
from Categorias
where CodCategoria =@CodCategoria
order by CodCategoria
GO
/****** Object:  StoredProcedure [dbo].[spSeleccionarCategorias]    Script Date: 28/6/2021 14:58:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spSeleccionarCategorias] 

as
select*
From Categorias
Order by CodCategoria
GO
/****** Object:  StoredProcedure [dbo].[spSeleccionarCategoriasNombre]    Script Date: 28/6/2021 14:58:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spSeleccionarCategoriasNombre] @Nombre NVARCHAR(30)

as
select*
from Categorias
where Nombre LIKE '%' +@Nombre + '%'
order by CodCategoria 
GO
/****** Object:  StoredProcedure [dbo].[spSeleccionarClienteCodigo]    Script Date: 28/6/2021 14:58:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spSeleccionarClienteCodigo] @Nombre nvarchar(50)

as
select*
from Clientes
where CodCliente LIKE '%' +@Nombre + '%'
order by CodCliente 
GO
/****** Object:  StoredProcedure [dbo].[spSeleccionarClientesNombre]    Script Date: 28/6/2021 14:58:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spSeleccionarClientesNombre] @Nombre NVARCHAR(30)

as
select*
from Clientes
where Nombre LIKE '%' +@Nombre + '%'
order by CodCliente 
GO
/****** Object:  StoredProcedure [dbo].[spSeleccionarEmpleado]    Script Date: 28/6/2021 14:58:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spSeleccionarEmpleado]

@CodEmpleado int,
@CodSucursal int

as
select E.CodigoEmpleado, E.Nombre,O.CodOcupacion a, E.Telefono, E.FechaNacimiento, E.Correo  ,E.Direccion
from Empleados E join Ocupaciones O on E.CodOcupacion= O.CodOcupacion
where CodigoEmpleado = @CodEmpleado and CodSucursal=@CodSucursal
order by CodigoEmpleado

GO
/****** Object:  StoredProcedure [dbo].[spSeleccionarEmpleadoNombre]    Script Date: 28/6/2021 14:58:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spSeleccionarEmpleadoNombre] @Nombre NVARCHAR(50)

as
select*
from Empleados
where Nombre LIKE '%' +@Nombre + '%'
order by CodigoEmpleado 
GO
/****** Object:  StoredProcedure [dbo].[spSeleccionarEmpleados]    Script Date: 28/6/2021 14:58:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spSeleccionarEmpleados]

as
select E.CodigoEmpleado, E.Nombre,O.Ocupacion as  Ocupacion, T.NombreTienda as Sucursal, E.Telefono, E.FechaNacimiento, E.Correo  ,E.Direccion
from Empleados E join Ocupaciones O on E.CodOcupacion= O.CodOcupacion
                 join Tiendas T on E.CodSucursal = T.CodTienda
order by E.CodigoEmpleado
	
GO
/****** Object:  StoredProcedure [dbo].[spSeleccionarEmpleadosSucursal]    Script Date: 28/6/2021 14:58:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spSeleccionarEmpleadosSucursal]
@CodTienda int,
@Nombre nvarchar(50)


as
select E.CodigoEmpleado, E.Nombre,O.Ocupacion as  Ocupacion, T.NombreTienda as Sucursal, E.Telefono, E.FechaNacimiento, E.Correo  ,E.Direccion
from Empleados E join Ocupaciones O on E.CodOcupacion= O.CodOcupacion
                 join Tiendas T on E.CodSucursal = T.CodTienda
where CodTienda = @CodTienda and Nombre LIKE '%' +@Nombre + '%'
order by E.CodigoEmpleado
GO
/****** Object:  StoredProcedure [dbo].[spSeleccionarEncargado]    Script Date: 28/6/2021 14:58:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spSeleccionarEncargado] 

as
select*
from Encargados
order by CodigoEncargado 
GO
/****** Object:  StoredProcedure [dbo].[spSeleccionarEncargadoNombre]    Script Date: 28/6/2021 14:58:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spSeleccionarEncargadoNombre] @Nombre nvarchar(50)

as
select*
from Encargados
where Nombre LIKE '%' +@Nombre + '%'
order by CodigoEncargado 
GO
/****** Object:  StoredProcedure [dbo].[spSeleccionarEncargados]    Script Date: 28/6/2021 14:58:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[spSeleccionarEncargados]

@CodigoEncargado int

as
select *
from Encargados
where CodigoEncargado = @CodigoEncargado
order by CodigoEncargado
GO
/****** Object:  StoredProcedure [dbo].[spSeleccionarOcupacion]    Script Date: 28/6/2021 14:58:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spSeleccionarOcupacion] @CodOcupacion int

as
select*
from Ocupaciones
where CodOcupacion =@CodOcupacion
GO
/****** Object:  StoredProcedure [dbo].[spSeleccionarOcupaciones]    Script Date: 28/6/2021 14:58:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spSeleccionarOcupaciones]

as
begin
select CodOcupacion,Ocupacion,Descripcion from Ocupaciones
order by CodOcupacion
end
GO
/****** Object:  StoredProcedure [dbo].[spSeleccionarProducto]    Script Date: 28/6/2021 14:58:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spSeleccionarProducto]
 
@CodProducto int

as
select P.CodProducto, P.Nombre, P.Descripcion, C.CodCategoria, PR.CodProvedor ,UM.CodUnidadesDeMedida ,  P.PrecioCompra, P.PrecioVenta
from Productos P join Categorias C on P.CodCategoria= C.CodCategoria
				 join Proveedores PR on p.CodProvedor = PR.CodProvedor
				 join UnidadesDeMedida UM on P.CodUnidadMedida = UM.CodUnidadesDeMedida
where CodProducto = @CodProducto
order by P.CodProducto
GO
/****** Object:  StoredProcedure [dbo].[spSeleccionarProductoCategoria]    Script Date: 28/6/2021 14:58:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spSeleccionarProductoCategoria] @Nombre NVARCHAR(30)

AS
SELECT P.CodProducto, P.Nombre, P.Descripcion, C.Nombre as categoria, PR.Nombre as Proveedor,UM.Nombre as Unidad_de_medida,  P.PrecioCompra, P.PrecioVenta
FROM Productos P join Categorias C on P.CodCategoria= C.CodCategoria
				 join Proveedores PR on P.CodProvedor = PR.CodProvedor
				 join UnidadesDeMedida UM on P.CodUnidadMedida = UM.CodUnidadesDeMedida
WHERE C.Nombre LIKE '%' +@Nombre + '%'
ORDER BY P.CodProducto
GO
/****** Object:  StoredProcedure [dbo].[spSeleccionarProductoNombre]    Script Date: 28/6/2021 14:58:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spSeleccionarProductoNombre] @Nombre NVARCHAR(30)

AS
SELECT P.CodProducto, P.Nombre, P.Descripcion, C.Nombre as categoria, PR.Nombre as Proveedor,UM.Nombre as Unidad_de_medida,  P.PrecioCompra, P.PrecioVenta
FROM Productos P join Categorias C on P.CodCategoria= C.CodCategoria
				 join Proveedores PR on P.CodProvedor = PR.CodProvedor
				 join UnidadesDeMedida UM on P.CodUnidadMedida = UM.CodUnidadesDeMedida
WHERE P.Nombre LIKE '%' +@Nombre + '%'
ORDER BY CodProducto 
GO
/****** Object:  StoredProcedure [dbo].[spSeleccionarProductoProveedor]    Script Date: 28/6/2021 14:58:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spSeleccionarProductoProveedor] @Nombre NVARCHAR(30)

AS
SELECT P.CodProducto, P.Nombre, P.Descripcion, C.Nombre as categoria, PR.Nombre as Proveedor,UM.Nombre as Unidad_de_medida,  P.PrecioCompra, P.PrecioVenta
FROM Productos P join Categorias C on P.CodCategoria= C.CodCategoria
				 join Proveedores PR on P.CodProvedor = PR.CodProvedor
				 join UnidadesDeMedida UM on P.CodUnidadMedida = UM.CodUnidadesDeMedida
WHERE PR.Nombre LIKE '%' +@Nombre + '%'
ORDER BY P.CodProducto
GO
/****** Object:  StoredProcedure [dbo].[spSeleccionarProductos]    Script Date: 28/6/2021 14:58:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spSeleccionarProductos]

as
select P.CodProducto, P.Nombre, P.Descripcion, C.Nombre as Categoria, PR.Nombre as Proveedor,UM.Nombre as Unidad_de_medida,  P.PrecioCompra, P.PrecioVenta
from Productos P join Categorias C on P.CodCategoria= C.CodCategoria
				 join Proveedores PR on p.CodProvedor = PR.CodProvedor
				 join UnidadesDeMedida UM on P.CodUnidadMedida = UM.CodUnidadesDeMedida
ORDER BY P.CodProducto


GO
/****** Object:  StoredProcedure [dbo].[spSeleccionarProvedorNombre]    Script Date: 28/6/2021 14:58:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spSeleccionarProvedorNombre] @Nombre NVARCHAR(50)

as
select*
from Proveedores
where Nombre LIKE '%' +@Nombre + '%'
order by CodProvedor 

GO
/****** Object:  StoredProcedure [dbo].[spSeleccionarProveedorCodigo]    Script Date: 28/6/2021 14:58:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spSeleccionarProveedorCodigo] @Nombre nvarchar(50)

as
select*
from Proveedores
where CodProvedor LIKE '%' +@Nombre + '%'
order by CodProvedor 
GO
/****** Object:  StoredProcedure [dbo].[spSeleccionarSucursal]    Script Date: 28/6/2021 14:58:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spSeleccionarSucursal] @CodSucursal int

as
select*
from Tiendas
where CodTienda =@CodSucursal
GO
/****** Object:  StoredProcedure [dbo].[spSeleccionarUnidadesNombre]    Script Date: 28/6/2021 14:58:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spSeleccionarUnidadesNombre] @Nombre NVARCHAR(30)

as
select*
from UnidadesDeMedida
where Nombre LIKE '%' +@Nombre + '%'
order by CodUnidadesDeMedida
GO
/****** Object:  StoredProcedure [dbo].[spVerInventario]    Script Date: 28/6/2021 14:58:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spVerInventario]

@CodTienda int

as
select P.CodProducto, P.Nombre, I.Cantidad as Cantidad, P.Descripcion, C.Nombre as Categoria, PR.Nombre as Proveedor,UM.Nombre as Unidad_de_medida,  P.PrecioCompra, P.PrecioVenta
from  Inventario I join Productos P on I.CodProducto = P.CodProducto
				 join Categorias C on P.CodCategoria= C.CodCategoria
				 join Proveedores PR on p.CodProvedor = PR.CodProvedor
				 join UnidadesDeMedida UM on P.CodUnidadMedida = UM.CodUnidadesDeMedida
where CodTienda= @CodTienda
order by I.CodProducto
GO
/****** Object:  StoredProcedure [dbo].[spVerInventarioMayores]    Script Date: 28/6/2021 14:58:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spVerInventarioMayores]

@nombre nvarchar(50),
@CodTienda int

as
select P.CodProducto, P.Nombre, I.Cantidad as Cantidad, P.Descripcion, C.Nombre as Categoria, PR.Nombre as Proveedor,UM.Nombre as Unidad_de_medida,  P.PrecioCompra, P.PrecioVenta
from  Inventario I join Productos P on I.CodProducto = P.CodProducto
				 join Categorias C on P.CodCategoria= C.CodCategoria
				 join Proveedores PR on p.CodProvedor = PR.CodProvedor
				 join UnidadesDeMedida UM on P.CodUnidadMedida = UM.CodUnidadesDeMedida
where P.Nombre LIKE '%' +@Nombre + '%' and CodTienda= @CodTienda and Cantidad>0
order by I.CodProducto
GO
/****** Object:  StoredProcedure [dbo].[verCompras]    Script Date: 28/6/2021 14:58:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[verCompras]

@CodVenta int
as


select P.CodProducto As Codigo_Producto, P.Nombre as Nombre_Producto,  P.PrecioVenta as Precio, P.Descripcion as Descripcion, DV.Cantidad as Cantidad,  DV.Total, DV.CodDetalle
from DetalleVenta DV join Productos P on DV.CodProducto= P.CodProducto
where @CodVenta= NumeroVenta
GO
USE [master]
GO
ALTER DATABASE [Ferreteria] SET  READ_WRITE 
GO
