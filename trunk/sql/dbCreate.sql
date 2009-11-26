SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[permiso]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[permiso](
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
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usuario]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[usuario](
	[nombre] [varchar](50) NOT NULL,
	[email] [varchar](50) NOT NULL,
	[usuario] [varchar](50) NOT NULL,
	[contrasena] [varchar](250) NOT NULL,
	[celular] [varchar](50) NULL,
	[telefono] [varchar](50) NULL,
	[f_ingreso] [datetime] NULL,
 CONSTRAINT [PK_usuario] PRIMARY KEY CLUSTERED 
(
	[usuario] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[respuesta]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[respuesta](
	[id] [int] NOT NULL,
	[contador] [int] NOT NULL,
	[texto] [varchar](50) NOT NULL,
	[id_pregunta] [int] NOT NULL
 CONSTRAINT [PK_respuesta] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]  
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[pregunta]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[pregunta](
	[id] [int] NOT NULL,
	[planteo] [varchar](50) NOT NULL,
	[condicion] [varchar](50) NULL,
	[f_ultima_respuesta] [datetime] NULL,
	[id_encuesta] [varchar](50) NOT NULL,
 CONSTRAINT [PK_pregunta] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[permiso_usuario]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[permiso_usuario](
	[id_usuario] [varchar](50) NOT NULL,
	[id_permiso] [int] NOT NULL,
 CONSTRAINT [PK_permiso_usuario] PRIMARY KEY CLUSTERED 
(
	[id_usuario] ASC,
	[id_permiso] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
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
	[id_agente] [varchar](50) NOT NULL,
	[id_cliente] [varchar](50) NOT NULL,
 CONSTRAINT [PK_encuesta] PRIMARY KEY CLUSTERED 
(
	[nombre] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_respuesta_pregunta]') AND parent_object_id = OBJECT_ID(N'[dbo].[respuesta]'))
ALTER TABLE [dbo].[respuesta]  WITH CHECK ADD  CONSTRAINT [FK_respuesta_pregunta] FOREIGN KEY([id_pregunta])
REFERENCES [dbo].[pregunta] ([id])
GO
ALTER TABLE [dbo].[respuesta] CHECK CONSTRAINT [FK_respuesta_pregunta]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_pregunta_encuesta]') AND parent_object_id = OBJECT_ID(N'[dbo].[pregunta]'))
ALTER TABLE [dbo].[pregunta]  WITH CHECK ADD  CONSTRAINT [FK_pregunta_encuesta] FOREIGN KEY([id_encuesta])
REFERENCES [dbo].[encuesta] ([nombre])
GO
ALTER TABLE [dbo].[pregunta] CHECK CONSTRAINT [FK_pregunta_encuesta]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_permiso_usuario_permiso]') AND parent_object_id = OBJECT_ID(N'[dbo].[permiso_usuario]'))
ALTER TABLE [dbo].[permiso_usuario]  WITH CHECK ADD  CONSTRAINT [FK_permiso_usuario_permiso] FOREIGN KEY([id_permiso])
REFERENCES [dbo].[permiso] ([id])
GO
ALTER TABLE [dbo].[permiso_usuario] CHECK CONSTRAINT [FK_permiso_usuario_permiso]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_permiso_usuario_usuario]') AND parent_object_id = OBJECT_ID(N'[dbo].[permiso_usuario]'))
ALTER TABLE [dbo].[permiso_usuario]  WITH CHECK ADD  CONSTRAINT [FK_permiso_usuario_usuario] FOREIGN KEY([id_usuario])
REFERENCES [dbo].[usuario] ([usuario])
GO
ALTER TABLE [dbo].[permiso_usuario] CHECK CONSTRAINT [FK_permiso_usuario_usuario]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_encuesta_agente]') AND parent_object_id = OBJECT_ID(N'[dbo].[encuesta]'))
ALTER TABLE [dbo].[encuesta]  WITH CHECK ADD  CONSTRAINT [FK_encuesta_agente] FOREIGN KEY([id_agente])
REFERENCES [dbo].[usuario] ([usuario])
GO
ALTER TABLE [dbo].[encuesta] CHECK CONSTRAINT [FK_encuesta_agente]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_encuesta_cliente]') AND parent_object_id = OBJECT_ID(N'[dbo].[encuesta]'))
ALTER TABLE [dbo].[encuesta]  WITH CHECK ADD  CONSTRAINT [FK_encuesta_cliente] FOREIGN KEY([id_cliente])
REFERENCES [dbo].[usuario] ([usuario])
GO
ALTER TABLE [dbo].[encuesta] CHECK CONSTRAINT [FK_encuesta_cliente]
