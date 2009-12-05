USE [master]
GO
/****** Object:  Database [eTronDB]    Script Date: 12/05/2009 01:44:24 ******/
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'eTronDB')
BEGIN
CREATE DATABASE [eTronDB] ON  PRIMARY 
( NAME = N'eTronDB', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL.1\MSSQL\DATA\eTronDB.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'eTronDB_log', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL.1\MSSQL\DATA\eTronDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
END

GO
EXEC dbo.sp_dbcmptlevel @dbname=N'eTronDB', @new_cmptlevel=90
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [eTronDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [eTronDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [eTronDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [eTronDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [eTronDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [eTronDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [eTronDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [eTronDB] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [eTronDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [eTronDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [eTronDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [eTronDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [eTronDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [eTronDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [eTronDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [eTronDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [eTronDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [eTronDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [eTronDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [eTronDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [eTronDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [eTronDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [eTronDB] SET  READ_WRITE 
GO
ALTER DATABASE [eTronDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [eTronDB] SET  MULTI_USER 
GO
ALTER DATABASE [eTronDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [eTronDB] SET DB_CHAINING OFF 
GO
GRANT CONNECT TO [admin]
/****** Object:  Login [NT AUTHORITY\SYSTEM]    Script Date: 12/05/2009 01:44:25 ******/
/****** Object:  Login [NT AUTHORITY\SYSTEM]    Script Date: 12/05/2009 01:44:25 ******/
IF NOT EXISTS (SELECT * FROM sys.server_principals WHERE name = N'NT AUTHORITY\SYSTEM')
CREATE LOGIN [NT AUTHORITY\SYSTEM] FROM WINDOWS WITH DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[us_english]
GO
/****** Object:  Login [lorien\SQLServer2005MSSQLUser$LORIEN$SQLEXPRESS]    Script Date: 12/05/2009 01:44:25 ******/
/****** Object:  Login [lorien\SQLServer2005MSSQLUser$LORIEN$SQLEXPRESS]    Script Date: 12/05/2009 01:44:25 ******/
IF NOT EXISTS (SELECT * FROM sys.server_principals WHERE name = N'lorien\SQLServer2005MSSQLUser$LORIEN$SQLEXPRESS')
CREATE LOGIN [lorien\SQLServer2005MSSQLUser$LORIEN$SQLEXPRESS] FROM WINDOWS WITH DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[us_english]
GO
/****** Object:  Login [lorien\madrax]    Script Date: 12/05/2009 01:44:25 ******/
/****** Object:  Login [lorien\madrax]    Script Date: 12/05/2009 01:44:25 ******/
IF NOT EXISTS (SELECT * FROM sys.server_principals WHERE name = N'lorien\madrax')
CREATE LOGIN [lorien\madrax] FROM WINDOWS WITH DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[us_english]
GO
/****** Object:  Login [BUILTIN\Users]    Script Date: 12/05/2009 01:44:25 ******/
/****** Object:  Login [BUILTIN\Users]    Script Date: 12/05/2009 01:44:25 ******/
IF NOT EXISTS (SELECT * FROM sys.server_principals WHERE name = N'BUILTIN\Users')
CREATE LOGIN [BUILTIN\Users] FROM WINDOWS WITH DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[us_english]
GO
/****** Object:  Login [BUILTIN\Administrators]    Script Date: 12/05/2009 01:44:25 ******/
/****** Object:  Login [BUILTIN\Administrators]    Script Date: 12/05/2009 01:44:25 ******/
IF NOT EXISTS (SELECT * FROM sys.server_principals WHERE name = N'BUILTIN\Administrators')
CREATE LOGIN [BUILTIN\Administrators] FROM WINDOWS WITH DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[us_english]
GO
/****** Object:  Login [admin]    Script Date: 12/05/2009 01:44:25 ******/
/* For security reasons the login is created disabled and with a random password. */
/****** Object:  Login [admin]    Script Date: 12/05/2009 01:44:25 ******/
IF NOT EXISTS (SELECT * FROM sys.server_principals WHERE name = N'admin')
CREATE LOGIN [admin] WITH PASSWORD=N'¸¸|:b0{LÎ=Ö\¦ÊpJ7WªqG', DEFAULT_DATABASE=[eTronDB], DEFAULT_LANGUAGE=[Norsk], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
GO
EXEC sys.sp_addsrvrolemember @loginame = N'admin', @rolename = N'sysadmin'
GO
EXEC sys.sp_addsrvrolemember @loginame = N'admin', @rolename = N'securityadmin'
GO
EXEC sys.sp_addsrvrolemember @loginame = N'admin', @rolename = N'serveradmin'
GO
EXEC sys.sp_addsrvrolemember @loginame = N'admin', @rolename = N'setupadmin'
GO
EXEC sys.sp_addsrvrolemember @loginame = N'admin', @rolename = N'processadmin'
GO
EXEC sys.sp_addsrvrolemember @loginame = N'admin', @rolename = N'diskadmin'
GO
EXEC sys.sp_addsrvrolemember @loginame = N'admin', @rolename = N'dbcreator'
GO
EXEC sys.sp_addsrvrolemember @loginame = N'admin', @rolename = N'bulkadmin'
GO
ALTER LOGIN [admin] DISABLE
GO
USE [eTronDB]
GO
/****** Object:  User [admin]    Script Date: 12/05/2009 01:44:25 ******/
GO
IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = N'admin')
CREATE USER [admin] FOR LOGIN [admin] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[bitacora]    Script Date: 12/05/2009 01:44:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[bitacora]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[bitacora](
	[id_Log] [int] IDENTITY(5,1) NOT NULL,
	[fecha_Log] [datetime] NOT NULL,
	[usuario_Log] [varchar](50) NOT NULL,
	[descripcion_Log] [nchar](50) NOT NULL,
	[severidad_Log] [nchar](10) NOT NULL,
 CONSTRAINT [PK_bitacora] PRIMARY KEY CLUSTERED 
(
	[id_Log] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[rol]    Script Date: 12/05/2009 01:44:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[rol]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[rol](
	[id] [int] NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[permiso] [varchar](250) NOT NULL,
 CONSTRAINT [PK_permiso] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[usuario]    Script Date: 12/05/2009 01:44:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usuario]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[usuario](
	[nombre] [varchar](50) NOT NULL,
	[email] [varchar](50) NOT NULL,
	[id_usuario] [varchar](50) NOT NULL,
	[contrasena] [varchar](250) NOT NULL,
	[celular] [varchar](50) NULL,
	[telefono] [varchar](50) NULL,
	[f_ingreso] [datetime] NULL,
	[id_rol] [int] NULL,
 CONSTRAINT [PK_usuario] PRIMARY KEY CLUSTERED 
(
	[id_usuario] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[cliente]    Script Date: 12/05/2009 01:44:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[cliente]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[cliente](
	[id_usuario] [varchar](50) NOT NULL,
	[id_agente] [varchar](50) NULL,
 CONSTRAINT [PK_cliente] PRIMARY KEY CLUSTERED 
(
	[id_usuario] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[encuesta]    Script Date: 12/05/2009 01:44:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[encuesta]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[encuesta](
	[nombre] [varchar](50) NOT NULL,
	[contrasena] [nchar](255) NOT NULL,
	[f_ingreso] [datetime] NOT NULL,
	[f_modificacion] [datetime] NULL,
	[f_vigencia] [datetime] NULL,
	[f_cierre] [datetime] NULL,
	[id_cliente] [varchar](50) NOT NULL,
 CONSTRAINT [PK_encuesta] PRIMARY KEY CLUSTERED 
(
	[nombre] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[pregunta]    Script Date: 12/05/2009 01:44:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[pregunta]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[pregunta](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[planteo] [varchar](50) NOT NULL,
	[condicion] [varchar](50) NULL,
	[f_ultima_respuesta] [datetime] NULL,
	[id_encuesta] [varchar](50) NOT NULL,
	[nro_pregunta] [int] NULL,
 CONSTRAINT [PK_pregunta] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[respuesta]    Script Date: 12/05/2009 01:44:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[respuesta]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[respuesta](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[contador] [int] NOT NULL,
	[texto] [varchar](50) NOT NULL,
	[id_pregunta] [int] NOT NULL,
	[id_proxima_pregunta] [int] NULL,
 CONSTRAINT [PK_respuesta] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_usuario_rol]') AND parent_object_id = OBJECT_ID(N'[dbo].[usuario]'))
ALTER TABLE [dbo].[usuario]  WITH CHECK ADD  CONSTRAINT [FK_usuario_rol] FOREIGN KEY([id_rol])
REFERENCES [dbo].[rol] ([id])
GO
ALTER TABLE [dbo].[usuario] CHECK CONSTRAINT [FK_usuario_rol]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_cliente_agente]') AND parent_object_id = OBJECT_ID(N'[dbo].[cliente]'))
ALTER TABLE [dbo].[cliente]  WITH CHECK ADD  CONSTRAINT [FK_cliente_agente] FOREIGN KEY([id_agente])
REFERENCES [dbo].[usuario] ([id_usuario])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[cliente] CHECK CONSTRAINT [FK_cliente_agente]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_cliente_cliente]') AND parent_object_id = OBJECT_ID(N'[dbo].[cliente]'))
ALTER TABLE [dbo].[cliente]  WITH CHECK ADD  CONSTRAINT [FK_cliente_cliente] FOREIGN KEY([id_usuario])
REFERENCES [dbo].[cliente] ([id_usuario])
GO
ALTER TABLE [dbo].[cliente] CHECK CONSTRAINT [FK_cliente_cliente]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_encuesta_cliente]') AND parent_object_id = OBJECT_ID(N'[dbo].[encuesta]'))
ALTER TABLE [dbo].[encuesta]  WITH CHECK ADD  CONSTRAINT [FK_encuesta_cliente] FOREIGN KEY([id_cliente])
REFERENCES [dbo].[cliente] ([id_usuario])
GO
ALTER TABLE [dbo].[encuesta] CHECK CONSTRAINT [FK_encuesta_cliente]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_pregunta_encuesta]') AND parent_object_id = OBJECT_ID(N'[dbo].[pregunta]'))
ALTER TABLE [dbo].[pregunta]  WITH CHECK ADD  CONSTRAINT [FK_pregunta_encuesta] FOREIGN KEY([id_encuesta])
REFERENCES [dbo].[encuesta] ([nombre])
GO
ALTER TABLE [dbo].[pregunta] CHECK CONSTRAINT [FK_pregunta_encuesta]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_respuesta_pregunta]') AND parent_object_id = OBJECT_ID(N'[dbo].[respuesta]'))
ALTER TABLE [dbo].[respuesta]  WITH CHECK ADD  CONSTRAINT [FK_respuesta_pregunta] FOREIGN KEY([id_pregunta])
REFERENCES [dbo].[pregunta] ([id])
GO
ALTER TABLE [dbo].[respuesta] CHECK CONSTRAINT [FK_respuesta_pregunta]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_respuesta_proxima_pregunta]') AND parent_object_id = OBJECT_ID(N'[dbo].[respuesta]'))
ALTER TABLE [dbo].[respuesta]  WITH NOCHECK ADD  CONSTRAINT [FK_respuesta_proxima_pregunta] FOREIGN KEY([id])
REFERENCES [dbo].[pregunta] ([id])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[respuesta] NOCHECK CONSTRAINT [FK_respuesta_proxima_pregunta]
