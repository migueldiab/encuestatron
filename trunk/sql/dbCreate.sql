USE [eTronDB]
GO
/****** Object:  User [admin]    Script Date: 12/01/2009 21:19:45 ******/
CREATE USER [admin] FOR LOGIN [admin] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[bitacora]    Script Date: 12/01/2009 21:19:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[bitacora](
	[id_Log] [int] IDENTITY(5,1) NOT NULL,
	[fecha_Log] [datetime] NOT NULL,
	[usuario_Log] [varchar](50) NOT NULL,
	[descripcion_Log] [nchar](50) NOT NULL,
	[severidad_Log] [nchar](10) NOT NULL,
 CONSTRAINT [PK_bitacora] PRIMARY KEY CLUSTERED 
(
	[id_Log] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[rol]    Script Date: 12/01/2009 21:19:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[rol](
	[id] [int] NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[permiso] [varchar](250) NOT NULL,
 CONSTRAINT [PK_permiso] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[usuario]    Script Date: 12/01/2009 21:19:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[cliente]    Script Date: 12/01/2009 21:19:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[cliente](
	[id_usuario] [varchar](50) NOT NULL,
	[id_agente] [varchar](50) NULL,
 CONSTRAINT [PK_cliente] PRIMARY KEY CLUSTERED 
(
	[id_usuario] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[respuesta]    Script Date: 12/01/2009 21:19:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[respuesta](
	[id] [int] NOT NULL,
	[contador] [int] NOT NULL,
	[texto] [varchar](50) NOT NULL,
	[id_pregunta] [int] NOT NULL,
	[id_proxima_pregunta] [int] NULL,
 CONSTRAINT [PK_respuesta] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[pregunta]    Script Date: 12/01/2009 21:19:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[pregunta](
	[id] [int] NOT NULL,
	[planteo] [varchar](50) NOT NULL,
	[condicion] [varchar](50) NULL,
	[f_ultima_respuesta] [datetime] NULL,
	[id_encuesta] [varchar](50) NOT NULL,
	[nro_pregunta] [int] NULL,
 CONSTRAINT [PK_pregunta] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[encuesta]    Script Date: 12/01/2009 21:19:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  ForeignKey [FK_cliente_agente]    Script Date: 12/01/2009 21:19:45 ******/
ALTER TABLE [dbo].[cliente]  WITH CHECK ADD  CONSTRAINT [FK_cliente_agente] FOREIGN KEY([id_agente])
REFERENCES [dbo].[usuario] ([id_usuario])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[cliente] CHECK CONSTRAINT [FK_cliente_agente]
GO
/****** Object:  ForeignKey [FK_cliente_cliente]    Script Date: 12/01/2009 21:19:45 ******/
ALTER TABLE [dbo].[cliente]  WITH CHECK ADD  CONSTRAINT [FK_cliente_cliente] FOREIGN KEY([id_usuario])
REFERENCES [dbo].[cliente] ([id_usuario])
GO
ALTER TABLE [dbo].[cliente] CHECK CONSTRAINT [FK_cliente_cliente]
GO
/****** Object:  ForeignKey [FK_encuesta_cliente]    Script Date: 12/01/2009 21:19:45 ******/
ALTER TABLE [dbo].[encuesta]  WITH CHECK ADD  CONSTRAINT [FK_encuesta_cliente] FOREIGN KEY([id_cliente])
REFERENCES [dbo].[cliente] ([id_usuario])
GO
ALTER TABLE [dbo].[encuesta] CHECK CONSTRAINT [FK_encuesta_cliente]
GO
/****** Object:  ForeignKey [FK_pregunta_encuesta]    Script Date: 12/01/2009 21:19:45 ******/
ALTER TABLE [dbo].[pregunta]  WITH CHECK ADD  CONSTRAINT [FK_pregunta_encuesta] FOREIGN KEY([id_encuesta])
REFERENCES [dbo].[encuesta] ([nombre])
GO
ALTER TABLE [dbo].[pregunta] CHECK CONSTRAINT [FK_pregunta_encuesta]
GO
/****** Object:  ForeignKey [FK_respuesta_pregunta]    Script Date: 12/01/2009 21:19:45 ******/
ALTER TABLE [dbo].[respuesta]  WITH CHECK ADD  CONSTRAINT [FK_respuesta_pregunta] FOREIGN KEY([id_pregunta])
REFERENCES [dbo].[pregunta] ([id])
GO
ALTER TABLE [dbo].[respuesta] CHECK CONSTRAINT [FK_respuesta_pregunta]
GO
/****** Object:  ForeignKey [FK_respuesta_proxima_pregunta]    Script Date: 12/01/2009 21:19:45 ******/
ALTER TABLE [dbo].[respuesta]  WITH CHECK ADD  CONSTRAINT [FK_respuesta_proxima_pregunta] FOREIGN KEY([id])
REFERENCES [dbo].[pregunta] ([id])
GO
ALTER TABLE [dbo].[respuesta] CHECK CONSTRAINT [FK_respuesta_proxima_pregunta]
GO
/****** Object:  ForeignKey [FK_usuario_rol]    Script Date: 12/01/2009 21:19:45 ******/
ALTER TABLE [dbo].[usuario]  WITH CHECK ADD  CONSTRAINT [FK_usuario_rol] FOREIGN KEY([id_rol])
REFERENCES [dbo].[rol] ([id])
GO
ALTER TABLE [dbo].[usuario] CHECK CONSTRAINT [FK_usuario_rol]
GO
