USE [master]
GO
/****** Object:  Database [Tienda]    Script Date: 12/4/2022 8:01:39 AM ******/
CREATE DATABASE [Tienda]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Tienda', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Tienda.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Tienda_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Tienda_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Tienda] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Tienda].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Tienda] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Tienda] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Tienda] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Tienda] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Tienda] SET ARITHABORT OFF 
GO
ALTER DATABASE [Tienda] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Tienda] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Tienda] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Tienda] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Tienda] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Tienda] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Tienda] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Tienda] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Tienda] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Tienda] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Tienda] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Tienda] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Tienda] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Tienda] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Tienda] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Tienda] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Tienda] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Tienda] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Tienda] SET  MULTI_USER 
GO
ALTER DATABASE [Tienda] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Tienda] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Tienda] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Tienda] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Tienda] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Tienda] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Tienda] SET QUERY_STORE = OFF
GO
USE [Tienda]
GO
/****** Object:  Table [dbo].[Abastecimiento]    Script Date: 12/4/2022 8:01:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Abastecimiento](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdSucursalEnv] [varchar](50) NULL,
	[IdSucursalRec] [varchar](50) NULL,
	[IdProducto] [int] NULL,
	[Fecha] [date] NULL,
	[IdUser] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Area]    Script Date: 12/4/2022 8:01:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Area](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AreaTrabajo] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 12/4/2022 8:01:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NULL,
	[Direccion] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetalleFactura]    Script Date: 12/4/2022 8:01:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleFactura](
	[IdDetalle] [int] NULL,
	[Precio] [float] NULL,
	[Cantidad] [int] NULL,
	[IdProducto] [int] NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdFactura] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Factura]    Script Date: 12/4/2022 8:01:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Factura](
	[IdFactura] [int] IDENTITY(1,1) NOT NULL,
	[IdCliente] [int] NULL,
	[Fecha] [date] NULL,
	[TipoPago] [varchar](25) NULL,
	[TipoFactura] [varchar](25) NULL,
	[IdVendedor] [int] NULL,
	[IdSucursal] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdFactura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 12/4/2022 8:01:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Marca] [varchar](50) NULL,
	[Codigo] [varchar](100) NULL,
	[Descripcion] [varchar](100) NULL,
	[PrecioVenta] [float] NULL,
	[PrecioCosto] [float] NULL,
	[Stock] [int] NULL,
	[IdTienda] [int] NOT NULL,
	[IdProveedor] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Proveedores]    Script Date: 12/4/2022 8:01:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proveedores](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Proveedor] [varchar](50) NULL,
	[Contacto] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reporte]    Script Date: 12/4/2022 8:01:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reporte](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdSucursal] [int] NULL,
	[Fecha] [date] NULL,
	[Memo] [varchar](125) NULL,
	[Total] [float] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tienda]    Script Date: 12/4/2022 8:01:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tienda](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Sucursal] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 12/4/2022 8:01:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Usuario] [varchar](50) NULL,
	[Contraseña] [varchar](50) NULL,
	[IdArea] [int] NOT NULL,
	[IdTienda] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DetalleFactura]  WITH CHECK ADD FOREIGN KEY([IdFactura])
REFERENCES [dbo].[Factura] ([IdFactura])
GO
ALTER TABLE [dbo].[DetalleFactura]  WITH CHECK ADD FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Producto] ([Id])
GO
ALTER TABLE [dbo].[Factura]  WITH CHECK ADD FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Cliente] ([Id])
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD FOREIGN KEY([IdProveedor])
REFERENCES [dbo].[Proveedores] ([Id])
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD FOREIGN KEY([IdArea])
REFERENCES [dbo].[Area] ([Id])
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD FOREIGN KEY([IdTienda])
REFERENCES [dbo].[Tienda] ([Id])
GO
USE [master]
GO
ALTER DATABASE [Tienda] SET  READ_WRITE 
GO
