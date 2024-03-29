USE [CompanyDB]
GO
/****** Object:  StoredProcedure [dbo].[CompanyDB_SP_ReservasConsultar]    Script Date: 21/06/2021 18:01:39 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CompanyDB_SP_ReservasConsultar]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CompanyDB_SP_ReservasConsultar]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Reservas_TipoIdentificacion]') AND parent_object_id = OBJECT_ID(N'[dbo].[Reservas]'))
ALTER TABLE [dbo].[Reservas] DROP CONSTRAINT [FK_Reservas_TipoIdentificacion]
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Reservas_FechaCreacion]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Reservas] DROP CONSTRAINT [DF_Reservas_FechaCreacion]
END

GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Reservas_ReservaId]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Reservas] DROP CONSTRAINT [DF_Reservas_ReservaId]
END

GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_LogApp_DateCreate]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[LogApp] DROP CONSTRAINT [DF_LogApp_DateCreate]
END

GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_LogApp_Id]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[LogApp] DROP CONSTRAINT [DF_LogApp_Id]
END

GO
/****** Object:  Table [dbo].[TipoIdentificacion]    Script Date: 21/06/2021 18:01:39 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TipoIdentificacion]') AND type in (N'U'))
DROP TABLE [dbo].[TipoIdentificacion]
GO
/****** Object:  Table [dbo].[Reservas]    Script Date: 21/06/2021 18:01:39 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Reservas]') AND type in (N'U'))
DROP TABLE [dbo].[Reservas]
GO
/****** Object:  Table [dbo].[LogApp]    Script Date: 21/06/2021 18:01:39 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LogApp]') AND type in (N'U'))
DROP TABLE [dbo].[LogApp]
GO
/****** Object:  Table [dbo].[LogApp]    Script Date: 21/06/2021 18:01:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LogApp]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[LogApp](
	[IdLog] [uniqueidentifier] NOT NULL,
	[DateCreate] [datetime] NULL,
	[ThreadLog] [varchar](255) NULL,
	[LeveLog] [varchar](50) NULL,
	[Logger] [varchar](255) NULL,
	[MessagLog] [varchar](4000) NULL,
	[ExceptionLog] [varchar](4000) NULL,
 CONSTRAINT [PK_LogApp] PRIMARY KEY CLUSTERED 
(
	[IdLog] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Reservas]    Script Date: 21/06/2021 18:01:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Reservas]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Reservas](
	[ReservaId] [uniqueidentifier] NOT NULL,
	[DocumentoIdentidad] [nvarchar](20) NOT NULL,
	[TipoIdentificacionId] [int] NOT NULL,
	[Nombres] [nvarchar](100) NOT NULL,
	[Apellidos] [nvarchar](100) NOT NULL,
	[FechaHoraPickup] [datetime] NOT NULL,
	[FechaHoraDropoff] [datetime] NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[LugarPickup] [nvarchar](500) NOT NULL,
	[LugarDropoff] [nvarchar](500) NOT NULL,
	[Marca] [nvarchar](500) NOT NULL,
	[Modelo] [nvarchar](500) NOT NULL,
	[PrecioPorHora] [decimal](18, 0) NOT NULL,
 CONSTRAINT [PK_Reservas] PRIMARY KEY CLUSTERED 
(
	[ReservaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[TipoIdentificacion]    Script Date: 21/06/2021 18:01:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TipoIdentificacion]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TipoIdentificacion](
	[TipoIdentificacionId] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](500) NOT NULL,
	[Alias] [nvarchar](50) NULL,
 CONSTRAINT [PK_TipoIdentificacion] PRIMARY KEY CLUSTERED 
(
	[TipoIdentificacionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
INSERT [dbo].[Reservas] ([ReservaId], [DocumentoIdentidad], [TipoIdentificacionId], [Nombres], [Apellidos], [FechaHoraPickup], [FechaHoraDropoff], [FechaCreacion], [LugarPickup], [LugarDropoff], [Marca], [Modelo], [PrecioPorHora]) VALUES (N'989d4169-c2af-4d03-af5d-28c24292f499', N'1073675237', 1, N'JUAN RICARDO', N'DIAZ SUANCHA', CAST(N'2021-02-02 13:24:12.000' AS DateTime), CAST(N'2021-02-15 00:00:00.000' AS DateTime), CAST(N'2021-02-02 21:12:10.753' AS DateTime), N'BARRANQUILLA AEROPUERTO OFICINA CENTRO', N'BARRANQUILLA OFICINA CENTRO', N'CHEVROLET ONIX', N'2020', CAST(1000000 AS Decimal(18, 0)))
GO
INSERT [dbo].[Reservas] ([ReservaId], [DocumentoIdentidad], [TipoIdentificacionId], [Nombres], [Apellidos], [FechaHoraPickup], [FechaHoraDropoff], [FechaCreacion], [LugarPickup], [LugarDropoff], [Marca], [Modelo], [PrecioPorHora]) VALUES (N'869b9c44-980b-436e-b7e2-48ba1f882ec9', N'10293837', 1, N'JUAN DAVID', N'AREVALO', CAST(N'2021-02-23 12:34:56.000' AS DateTime), CAST(N'2021-02-25 11:34:56.000' AS DateTime), CAST(N'2021-02-11 23:19:14.863' AS DateTime), N'AEROPUERTO RIONEGRO', N'AEROPUERTO RIONEGRO', N'KIA PICANTO', N'2021', CAST(123500 AS Decimal(18, 0)))
GO
INSERT [dbo].[Reservas] ([ReservaId], [DocumentoIdentidad], [TipoIdentificacionId], [Nombres], [Apellidos], [FechaHoraPickup], [FechaHoraDropoff], [FechaCreacion], [LugarPickup], [LugarDropoff], [Marca], [Modelo], [PrecioPorHora]) VALUES (N'7e3142fd-d8d9-4b09-90f8-4919049a5f66', N'10293837', 1, N'JUAN DAVID', N'AREVALO', CAST(N'2021-02-23 12:34:56.000' AS DateTime), CAST(N'2021-02-25 11:34:56.000' AS DateTime), CAST(N'2021-02-11 23:22:19.330' AS DateTime), N'AEROPUERTO RIONEGRO', N'AEROPUERTO RIONEGRO', N'KIA PICANTO', N'2021', CAST(10 AS Decimal(18, 0)))
GO
INSERT [dbo].[Reservas] ([ReservaId], [DocumentoIdentidad], [TipoIdentificacionId], [Nombres], [Apellidos], [FechaHoraPickup], [FechaHoraDropoff], [FechaCreacion], [LugarPickup], [LugarDropoff], [Marca], [Modelo], [PrecioPorHora]) VALUES (N'efe7f921-2d5d-4c13-a3b1-765d1f2add8f', N'10293837', 1, N'JUAN DAVID', N'AREVALO', CAST(N'2021-02-23 12:34:56.000' AS DateTime), CAST(N'2021-02-25 11:34:56.000' AS DateTime), CAST(N'2021-02-02 23:07:20.027' AS DateTime), N'AEROPUERTO RIONEGRO', N'AEROPUERTO RIONEGRO', N'KIA PICANTO', N'2021', CAST(123500 AS Decimal(18, 0)))
GO
INSERT [dbo].[Reservas] ([ReservaId], [DocumentoIdentidad], [TipoIdentificacionId], [Nombres], [Apellidos], [FechaHoraPickup], [FechaHoraDropoff], [FechaCreacion], [LugarPickup], [LugarDropoff], [Marca], [Modelo], [PrecioPorHora]) VALUES (N'2f6af203-b21e-4040-8829-81d0d1df1d81', N'10293837', 1, N'JUAN DAVID', N'AREVALO', CAST(N'2021-02-23 12:34:56.000' AS DateTime), CAST(N'2021-02-25 11:34:56.000' AS DateTime), CAST(N'2021-02-11 23:20:31.913' AS DateTime), N'AEROPUERTO RIONEGRO', N'AEROPUERTO RIONEGRO', N'KIA PICANTO', N'2021', CAST(123500 AS Decimal(18, 0)))
GO
INSERT [dbo].[Reservas] ([ReservaId], [DocumentoIdentidad], [TipoIdentificacionId], [Nombres], [Apellidos], [FechaHoraPickup], [FechaHoraDropoff], [FechaCreacion], [LugarPickup], [LugarDropoff], [Marca], [Modelo], [PrecioPorHora]) VALUES (N'fd174ddb-77b7-4b38-addf-83b67eb7f007', N'10293837', 1, N'JUAN DAVID', N'AREVALO', CAST(N'2021-02-23 12:34:56.000' AS DateTime), CAST(N'2021-02-25 11:34:56.000' AS DateTime), CAST(N'2021-02-02 23:05:44.360' AS DateTime), N'AEROPUERTO RIONEGRO', N'AEROPUERTO RIONEGRO', N'KIA PICANTO', N'2021', CAST(123000 AS Decimal(18, 0)))
GO
INSERT [dbo].[Reservas] ([ReservaId], [DocumentoIdentidad], [TipoIdentificacionId], [Nombres], [Apellidos], [FechaHoraPickup], [FechaHoraDropoff], [FechaCreacion], [LugarPickup], [LugarDropoff], [Marca], [Modelo], [PrecioPorHora]) VALUES (N'c449f368-7692-45cd-acf4-94e0494b7c7c', N'10293837', 1, N'JUAN DAVID', N'AREVALO', CAST(N'2021-02-23 12:34:56.000' AS DateTime), CAST(N'2021-02-25 11:34:56.000' AS DateTime), CAST(N'2021-02-02 23:22:07.060' AS DateTime), N'AEROPUERTO RIONEGRO', N'AEROPUERTO RIONEGRO', N'KIA PICANTO', N'2021', CAST(123500 AS Decimal(18, 0)))
GO
INSERT [dbo].[Reservas] ([ReservaId], [DocumentoIdentidad], [TipoIdentificacionId], [Nombres], [Apellidos], [FechaHoraPickup], [FechaHoraDropoff], [FechaCreacion], [LugarPickup], [LugarDropoff], [Marca], [Modelo], [PrecioPorHora]) VALUES (N'4fc9a94e-e714-4d8d-92d4-fc9bd7975f6d', N'10293837', 1, N'JUAN DAVID', N'AREVALO', CAST(N'2021-02-23 12:34:56.000' AS DateTime), CAST(N'2021-02-25 11:34:56.000' AS DateTime), CAST(N'2021-02-02 23:12:44.113' AS DateTime), N'AEROPUERTO RIONEGRO', N'AEROPUERTO RIONEGRO', N'KIA PICANTO', N'2021', CAST(123500 AS Decimal(18, 0)))
GO
SET IDENTITY_INSERT [dbo].[TipoIdentificacion] ON 

GO
INSERT [dbo].[TipoIdentificacion] ([TipoIdentificacionId], [Descripcion], [Alias]) VALUES (1, N'CEDULIA CE CIUDADANIA', N'CC')
GO
INSERT [dbo].[TipoIdentificacion] ([TipoIdentificacionId], [Descripcion], [Alias]) VALUES (2, N'CEDULA EXTRANJERA', N'CE')
GO
INSERT [dbo].[TipoIdentificacion] ([TipoIdentificacionId], [Descripcion], [Alias]) VALUES (3, N'TARJETA DE IDENTIDAD', N'TI')
GO
INSERT [dbo].[TipoIdentificacion] ([TipoIdentificacionId], [Descripcion], [Alias]) VALUES (4, N'PASAPORTE', N'PA')
GO
INSERT [dbo].[TipoIdentificacion] ([TipoIdentificacionId], [Descripcion], [Alias]) VALUES (5, N'NIT', N'NIT')
GO
SET IDENTITY_INSERT [dbo].[TipoIdentificacion] OFF
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_LogApp_Id]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[LogApp] ADD  CONSTRAINT [DF_LogApp_Id]  DEFAULT (newid()) FOR [IdLog]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_LogApp_DateCreate]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[LogApp] ADD  CONSTRAINT [DF_LogApp_DateCreate]  DEFAULT (getdate()) FOR [DateCreate]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Reservas_ReservaId]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Reservas] ADD  CONSTRAINT [DF_Reservas_ReservaId]  DEFAULT (newid()) FOR [ReservaId]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Reservas_FechaCreacion]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Reservas] ADD  CONSTRAINT [DF_Reservas_FechaCreacion]  DEFAULT (getdate()) FOR [FechaCreacion]
END

GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Reservas_TipoIdentificacion]') AND parent_object_id = OBJECT_ID(N'[dbo].[Reservas]'))
ALTER TABLE [dbo].[Reservas]  WITH CHECK ADD  CONSTRAINT [FK_Reservas_TipoIdentificacion] FOREIGN KEY([TipoIdentificacionId])
REFERENCES [dbo].[TipoIdentificacion] ([TipoIdentificacionId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Reservas_TipoIdentificacion]') AND parent_object_id = OBJECT_ID(N'[dbo].[Reservas]'))
ALTER TABLE [dbo].[Reservas] CHECK CONSTRAINT [FK_Reservas_TipoIdentificacion]
GO
/****** Object:  StoredProcedure [dbo].[CompanyDB_SP_ReservasConsultar]    Script Date: 21/06/2021 18:01:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CompanyDB_SP_ReservasConsultar]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[CompanyDB_SP_ReservasConsultar] AS' 
END
GO
-- ===============================================================================
-- Author:		JUAN RICARDO DIAZ
-- Create date: 2021-02-02 19:49
-- Description:	CONSULTA LAS RESERVAS POR ID o por fecha de creacion
-- EJEMPLOS:
-- EXEC NetacticaDB_SP_ReservasConsultar -- TODOS
-- EXEC NetacticaDB_SP_ReservasConsultar @ReservaId ='989D4169-C2AF-4D03-AF5D-28C24292F499'
-- EXEC NetacticaDB_SP_ReservasConsultar @FechaCreacionIni ='2021-02-02',@FechaCreacionFin ='2021-02-02'
-- ===============================================================================
ALTER PROCEDURE [dbo].[CompanyDB_SP_ReservasConsultar] @ReservaId        UNIQUEIDENTIFIER = NULL, 
                                                         @FechaCreacionIni DATE             = NULL, 
                                                         @FechaCreacionFin DATE             = NULL
AS
    BEGIN
        -- ===============================================================================
        -- ===============================================================================
        SELECT r.ReservaId, 
               r.DocumentoIdentidad, 
               r.TipoIdentificacionId, 
               r.FechaHoraPickup, 
               r.FechaHoraDropoff, 
               r.FechaCreacion, 
               r.LugarPickup, 
               r.LugarDropoff, 
               r.Marca, 
               r.Modelo, 
               r.PrecioPorHora, 
			   TotalHoras = DATEDIFF(HOUR, r.FechaHoraPickup, r.FechaHoraDropoff),
               PrecioTotal = r.PrecioPorHora * DATEDIFF(HOUR, r.FechaHoraPickup, r.FechaHoraDropoff), 
               r.Nombres, 
               r.Apellidos, 
               split = NULL, 
               ti.TipoIdentificacionId, 
               ti.Descripcion, 
               ti.Alias
        FROM Reservas r
             JOIN TipoIdentificacion ti ON r.TipoIdentificacionId = ti.TipoIdentificacionId
        WHERE(r.ReservaId = @ReservaId
              OR @ReservaId IS NULL)
             AND (CAST(r.FechaCreacion AS DATE) >= @FechaCreacionIni
                  OR @FechaCreacionIni IS NULL)
             AND (CAST(r.FechaCreacion AS DATE) <= @FechaCreacionFin
                  OR @FechaCreacionFin IS NULL);
        -- ===============================================================================
    END;
GO
