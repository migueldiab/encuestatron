/****** Object:  Table [dbo].[respuesta]    Script Date: 12/05/2009 03:07:18 ******/
DELETE FROM [dbo].[respuesta]
GO
/****** Object:  Table [dbo].[pregunta]    Script Date: 12/05/2009 03:07:18 ******/
DELETE FROM [dbo].[pregunta]
GO
/****** Object:  Table [dbo].[encuesta]    Script Date: 12/05/2009 03:07:18 ******/
DELETE FROM [dbo].[encuesta]
GO
/****** Object:  Table [dbo].[cliente]    Script Date: 12/05/2009 03:07:18 ******/
DELETE FROM [dbo].[cliente]
GO
/****** Object:  Table [dbo].[usuario]    Script Date: 12/05/2009 03:07:18 ******/
DELETE FROM [dbo].[usuario]
GO
/****** Object:  Table [dbo].[rol]    Script Date: 12/05/2009 03:07:18 ******/
DELETE FROM [dbo].[rol]
GO
/****** Object:  Table [dbo].[bitacora]    Script Date: 12/05/2009 03:07:18 ******/
DELETE FROM [dbo].[bitacora]
GO
/****** Object:  Table [dbo].[bitacora]    Script Date: 12/05/2009 03:07:18 ******/
/****** Object:  Table [dbo].[rol]    Script Date: 12/05/2009 03:07:18 ******/
INSERT [dbo].[rol] ([id], [nombre], [permiso]) VALUES (1, N'Administrador', N'admin')
INSERT [dbo].[rol] ([id], [nombre], [permiso]) VALUES (2, N'Agente', N'agente')
INSERT [dbo].[rol] ([id], [nombre], [permiso]) VALUES (3, N'Cliente', N'cliente')
/****** Object:  Table [dbo].[usuario]    Script Date: 12/05/2009 03:07:18 ******/
INSERT [dbo].[usuario] ([nombre], [email], [id_usuario], [contrasena], [celular], [telefono], [f_ingreso], [id_rol]) VALUES (N'Administrador', N'admin@et.com', N'admin', N'admin', N'', N'', NULL, 1)
/****** Object:  Table [dbo].[cliente]    Script Date: 12/05/2009 03:07:18 ******/
/****** Object:  Table [dbo].[encuesta]    Script Date: 12/05/2009 03:07:18 ******/
/****** Object:  Table [dbo].[pregunta]    Script Date: 12/05/2009 03:07:18 ******/
/****** Object:  Table [dbo].[respuesta]    Script Date: 12/05/2009 03:07:18 ******/
