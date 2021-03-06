USE [master]
GO
/****** Object:  Database [Fianzapp]    Script Date: 9/03/2021 3:49:49 p. m. ******/
CREATE DATABASE [Fianzapp]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Fianzapp', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Fianzapp.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Fianzapp_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Fianzapp_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Fianzapp] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Fianzapp].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Fianzapp] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Fianzapp] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Fianzapp] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Fianzapp] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Fianzapp] SET ARITHABORT OFF 
GO
ALTER DATABASE [Fianzapp] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Fianzapp] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Fianzapp] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Fianzapp] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Fianzapp] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Fianzapp] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Fianzapp] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Fianzapp] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Fianzapp] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Fianzapp] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Fianzapp] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Fianzapp] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Fianzapp] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Fianzapp] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Fianzapp] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Fianzapp] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Fianzapp] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Fianzapp] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Fianzapp] SET  MULTI_USER 
GO
ALTER DATABASE [Fianzapp] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Fianzapp] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Fianzapp] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Fianzapp] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Fianzapp] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Fianzapp] SET QUERY_STORE = OFF
GO
USE [Fianzapp]
GO
/****** Object:  Table [dbo].[Administrador]    Script Date: 9/03/2021 3:49:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Administrador](
	[id_admin] [int] IDENTITY(1,1) NOT NULL,
	[nombre_administrador] [nvarchar](max) NOT NULL,
	[documento_administrador] [nvarchar](max) NOT NULL,
	[correo_administrador] [nvarchar](max) NOT NULL,
	[usuario_administrador] [nvarchar](max) NOT NULL,
	[contrasena_administrador] [nvarchar](max) NOT NULL,
	[id_rol] [int] NOT NULL,
 CONSTRAINT [PK_Admin_Rol] PRIMARY KEY CLUSTERED 
(
	[id_admin] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 9/03/2021 3:49:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[id_cliente] [int] IDENTITY(1,1) NOT NULL,
	[nombre_cliente] [nvarchar](max) NOT NULL,
	[nit_cliente] [nvarchar](max) NOT NULL,
	[telefono_cliente] [nvarchar](max) NULL,
	[celular_cliente] [nvarchar](max) NULL,
	[direccion_cliente] [nvarchar](max) NULL,
	[correo_cliente] [nvarchar](max) NOT NULL,
	[usuario_cliente] [nvarchar](max) NOT NULL,
	[contrasena_cliente] [nvarchar](max) NOT NULL,
	[numero_fianza] [int] NOT NULL,
	[roles_id] [int] NOT NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[id_cliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Demandado]    Script Date: 9/03/2021 3:49:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Demandado](
	[id_usuario_demandado] [int] IDENTITY(1,1) NOT NULL,
	[nombre_usuario_demandado] [nvarchar](max) NOT NULL,
	[cedula_usuario_demandado] [nvarchar](max) NOT NULL,
	[telefono_usuario_demandado] [nvarchar](max) NULL,
	[celular_usuario_demandado] [nvarchar](max) NOT NULL,
	[correo_usuario_demandado] [nvarchar](max) NOT NULL,
	[direccion_usuario_demandado] [nvarchar](max) NULL,
 CONSTRAINT [PK_Demandado] PRIMARY KEY CLUSTERED 
(
	[id_usuario_demandado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Estado_Proceso]    Script Date: 9/03/2021 3:49:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estado_Proceso](
	[id_estado_solicitud] [int] IDENTITY(1,1) NOT NULL,
	[nombre_estado_solicitud] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Estado_Proceso] PRIMARY KEY CLUSTERED 
(
	[id_estado_solicitud] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Estado_Seguimiento]    Script Date: 9/03/2021 3:49:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estado_Seguimiento](
	[id_estado_segui] [int] IDENTITY(1,1) NOT NULL,
	[estado] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Estado_Seguimiento] PRIMARY KEY CLUSTERED 
(
	[id_estado_segui] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Proceso]    Script Date: 9/03/2021 3:49:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proceso](
	[id_proceso] [int] IDENTITY(1,1) NOT NULL,
	[numero_proceso] [int] NOT NULL,
	[id_estado] [int] NOT NULL,
	[id_demandado] [int] NOT NULL,
	[id_cliente] [int] NOT NULL,
	[descripcion] [nvarchar](max) NOT NULL,
	[archivo_proceso] [nvarchar](max) NOT NULL,
	[id_administrador] [int] NOT NULL,
	[Fecha_creacion] [datetime] NULL,
 CONSTRAINT [PK_Proceso] PRIMARY KEY CLUSTERED 
(
	[id_proceso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rol]    Script Date: 9/03/2021 3:49:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rol](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre_rol] [nvarchar](max) NOT NULL,
	[Fecha_creacion] [datetime] NOT NULL,
	[Fecha_modificado] [datetime] NULL,
 CONSTRAINT [PK_Rol] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Seguimiento_Proceso]    Script Date: 9/03/2021 3:49:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Seguimiento_Proceso](
	[id_seg_proceso] IDENTITY(1,1) [int] NOT NULL,
	[fecha_creacion] [datetime] NOT NULL,
	[fecha_modificado] [datetime] NULL,
	[observaciones] [nvarchar](max) NOT NULL,
	[archivo_seg_proceso] [nvarchar](max) NOT NULL,
	[id_estado] [int] NOT NULL,
	[id_proceso] [int] NOT NULL,
 CONSTRAINT [PK_Seguimiento_Proceso] PRIMARY KEY CLUSTERED 
(
	[id_seg_proceso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Administrador]  WITH CHECK ADD  CONSTRAINT [FK_Admin_Rol] FOREIGN KEY([id_rol])
REFERENCES [dbo].[Rol] ([id])
GO
ALTER TABLE [dbo].[Administrador] CHECK CONSTRAINT [FK_Admin_Rol]
GO
ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD  CONSTRAINT [FK_Cliente_Rol] FOREIGN KEY([roles_id])
REFERENCES [dbo].[Rol] ([id])
GO
ALTER TABLE [dbo].[Cliente] CHECK CONSTRAINT [FK_Cliente_Rol]
GO
ALTER TABLE [dbo].[Proceso]  WITH CHECK ADD  CONSTRAINT [FK_Proceso_Administrador] FOREIGN KEY([id_proceso])
REFERENCES [dbo].[Administrador] ([id_admin])
GO
ALTER TABLE [dbo].[Proceso] CHECK CONSTRAINT [FK_Proceso_Administrador]
GO
ALTER TABLE [dbo].[Proceso]  WITH CHECK ADD  CONSTRAINT [FK_Proceso_Cliente] FOREIGN KEY([[id_cliente]])
REFERENCES [dbo].[Cliente] ([id_cliente])
GO
ALTER TABLE [dbo].[Proceso] CHECK CONSTRAINT [FK_Proceso_Cliente]
GO
ALTER TABLE [dbo].[Proceso]  WITH CHECK ADD  CONSTRAINT [FK_Proceso_Demandado] FOREIGN KEY([id_demandado])
REFERENCES [dbo].[Demandado] ([id_usuario_demandado])
GO
ALTER TABLE [dbo].[Proceso] CHECK CONSTRAINT [FK_Proceso_Demandado]
GO
ALTER TABLE [dbo].[Proceso]  WITH CHECK ADD  CONSTRAINT [FK_Proceso_Estado_Proceso] FOREIGN KEY([id_proceso])
REFERENCES [dbo].[Estado_Proceso] ([id_estado_solicitud])
GO
ALTER TABLE [dbo].[Proceso] CHECK CONSTRAINT [FK_Proceso_Estado_Proceso]
GO
ALTER TABLE [dbo].[Seguimiento_Proceso]  WITH CHECK ADD  CONSTRAINT [FK_Seguimiento_Proceso_Estado_Seguimiento] FOREIGN KEY([id_estado])
REFERENCES [dbo].[Estado_Seguimiento] ([id_estado_segui])
GO
ALTER TABLE [dbo].[Seguimiento_Proceso] CHECK CONSTRAINT [FK_Seguimiento_Proceso_Estado_Seguimiento]
GO
ALTER TABLE [dbo].[Seguimiento_Proceso]  WITH CHECK ADD  CONSTRAINT [FK_Seguimiento_Proceso_Proceso] FOREIGN KEY([id_proceso])
REFERENCES [dbo].[Proceso] ([id_proceso])
GO
ALTER TABLE [dbo].[Seguimiento_Proceso] CHECK CONSTRAINT [FK_Seguimiento_Proceso_Proceso]
GO
USE [master]
GO
ALTER DATABASE [Fianzapp] SET  READ_WRITE 
GO
