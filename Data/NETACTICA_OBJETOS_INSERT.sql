USE [NetacticaDB]
GO
/****** Object:  StoredProcedure [dbo].[NetaticaDB_SP_CreateClass]    Script Date: 14/03/2021 1:43:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NetaticaDB_SP_CreateClass]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[NetaticaDB_SP_CreateClass]
GO
/****** Object:  StoredProcedure [dbo].[NetacticaDB_SP_UsuariosConsultar_NoAdmon]    Script Date: 14/03/2021 1:43:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NetacticaDB_SP_UsuariosConsultar_NoAdmon]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[NetacticaDB_SP_UsuariosConsultar_NoAdmon]
GO
/****** Object:  StoredProcedure [dbo].[NetacticaDB_SP_UsuariosConsultar_Admon]    Script Date: 14/03/2021 1:43:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NetacticaDB_SP_UsuariosConsultar_Admon]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[NetacticaDB_SP_UsuariosConsultar_Admon]
GO
/****** Object:  StoredProcedure [dbo].[NetacticaDB_SP_UsuarioInfoPorId]    Script Date: 14/03/2021 1:43:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NetacticaDB_SP_UsuarioInfoPorId]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[NetacticaDB_SP_UsuarioInfoPorId]
GO
/****** Object:  StoredProcedure [dbo].[NetacticaDB_SP_UsuarioConsultar]    Script Date: 14/03/2021 1:43:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NetacticaDB_SP_UsuarioConsultar]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[NetacticaDB_SP_UsuarioConsultar]
GO
/****** Object:  StoredProcedure [dbo].[NetacticaDB_SP_Usuario_Insertar]    Script Date: 14/03/2021 1:43:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NetacticaDB_SP_Usuario_Insertar]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[NetacticaDB_SP_Usuario_Insertar]
GO
/****** Object:  StoredProcedure [dbo].[NetacticaDB_SP_TercerosRolesPorUsuario]    Script Date: 14/03/2021 1:43:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NetacticaDB_SP_TercerosRolesPorUsuario]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[NetacticaDB_SP_TercerosRolesPorUsuario]
GO
/****** Object:  StoredProcedure [dbo].[NetacticaDB_SP_TercerosConsultar]    Script Date: 14/03/2021 1:43:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NetacticaDB_SP_TercerosConsultar]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[NetacticaDB_SP_TercerosConsultar]
GO
/****** Object:  StoredProcedure [dbo].[NetacticaDB_SP_RolesConsultar]    Script Date: 14/03/2021 1:43:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NetacticaDB_SP_RolesConsultar]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[NetacticaDB_SP_RolesConsultar]
GO
/****** Object:  StoredProcedure [dbo].[NetacticaDB_SP_ReservasConsultar]    Script Date: 14/03/2021 1:43:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NetacticaDB_SP_ReservasConsultar]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[NetacticaDB_SP_ReservasConsultar]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_UsuarioRoles_Usuario]') AND parent_object_id = OBJECT_ID(N'[dbo].[UsuarioRoles]'))
ALTER TABLE [dbo].[UsuarioRoles] DROP CONSTRAINT [FK_UsuarioRoles_Usuario]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_UsuarioRoles_Terceros]') AND parent_object_id = OBJECT_ID(N'[dbo].[UsuarioRoles]'))
ALTER TABLE [dbo].[UsuarioRoles] DROP CONSTRAINT [FK_UsuarioRoles_Terceros]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_UsuarioRoles_Roles]') AND parent_object_id = OBJECT_ID(N'[dbo].[UsuarioRoles]'))
ALTER TABLE [dbo].[UsuarioRoles] DROP CONSTRAINT [FK_UsuarioRoles_Roles]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_UsuarioInfo_Usuario]') AND parent_object_id = OBJECT_ID(N'[dbo].[UsuarioInfo]'))
ALTER TABLE [dbo].[UsuarioInfo] DROP CONSTRAINT [FK_UsuarioInfo_Usuario]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_UsuarioInfo_TipoIdentificacion]') AND parent_object_id = OBJECT_ID(N'[dbo].[UsuarioInfo]'))
ALTER TABLE [dbo].[UsuarioInfo] DROP CONSTRAINT [FK_UsuarioInfo_TipoIdentificacion]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Usuario_UsuariosEstado]') AND parent_object_id = OBJECT_ID(N'[dbo].[Usuario]'))
ALTER TABLE [dbo].[Usuario] DROP CONSTRAINT [FK_Usuario_UsuariosEstado]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Usuario_Lenguaje]') AND parent_object_id = OBJECT_ID(N'[dbo].[Usuario]'))
ALTER TABLE [dbo].[Usuario] DROP CONSTRAINT [FK_Usuario_Lenguaje]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TraduccionControles_Lenguaje]') AND parent_object_id = OBJECT_ID(N'[dbo].[TraduccionControles]'))
ALTER TABLE [dbo].[TraduccionControles] DROP CONSTRAINT [FK_TraduccionControles_Lenguaje]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Terceros_TipoTercero]') AND parent_object_id = OBJECT_ID(N'[dbo].[Terceros]'))
ALTER TABLE [dbo].[Terceros] DROP CONSTRAINT [FK_Terceros_TipoTercero]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Roles_Terceros]') AND parent_object_id = OBJECT_ID(N'[dbo].[Roles]'))
ALTER TABLE [dbo].[Roles] DROP CONSTRAINT [FK_Roles_Terceros]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Reservas_TipoIdentificacion]') AND parent_object_id = OBJECT_ID(N'[dbo].[Reservas]'))
ALTER TABLE [dbo].[Reservas] DROP CONSTRAINT [FK_Reservas_TipoIdentificacion]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_MenuRoles_Roles]') AND parent_object_id = OBJECT_ID(N'[dbo].[MenuRoles]'))
ALTER TABLE [dbo].[MenuRoles] DROP CONSTRAINT [FK_MenuRoles_Roles]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_MenuRoles_Menu]') AND parent_object_id = OBJECT_ID(N'[dbo].[MenuRoles]'))
ALTER TABLE [dbo].[MenuRoles] DROP CONSTRAINT [FK_MenuRoles_Menu]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Menu_Menu_MenuPadre]') AND parent_object_id = OBJECT_ID(N'[dbo].[Menu]'))
ALTER TABLE [dbo].[Menu] DROP CONSTRAINT [FK_Menu_Menu_MenuPadre]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Clientes_TercerosPadre]') AND parent_object_id = OBJECT_ID(N'[dbo].[Clientes]'))
ALTER TABLE [dbo].[Clientes] DROP CONSTRAINT [FK_Clientes_TercerosPadre]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Clientes_TercerosCliente]') AND parent_object_id = OBJECT_ID(N'[dbo].[Clientes]'))
ALTER TABLE [dbo].[Clientes] DROP CONSTRAINT [FK_Clientes_TercerosCliente]
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_UsuarioRoles_FechaCreacion]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[UsuarioRoles] DROP CONSTRAINT [DF_UsuarioRoles_FechaCreacion]
END

GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_UsuarioRoles_Estado]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[UsuarioRoles] DROP CONSTRAINT [DF_UsuarioRoles_Estado]
END

GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_UsuarioRoles_UsuarioRolId]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[UsuarioRoles] DROP CONSTRAINT [DF_UsuarioRoles_UsuarioRolId]
END

GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Usuario_LenguajeId]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Usuario] DROP CONSTRAINT [DF_Usuario_LenguajeId]
END

GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Usuario_RestauraClave]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Usuario] DROP CONSTRAINT [DF_Usuario_RestauraClave]
END

GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Usuario_FechaUltimoIngreso]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Usuario] DROP CONSTRAINT [DF_Usuario_FechaUltimoIngreso]
END

GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Usuario_NumItentos]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Usuario] DROP CONSTRAINT [DF_Usuario_NumItentos]
END

GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Usuario_FechaModificacion]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Usuario] DROP CONSTRAINT [DF_Usuario_FechaModificacion]
END

GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Usuario_FechaCreacion]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Usuario] DROP CONSTRAINT [DF_Usuario_FechaCreacion]
END

GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Usuario_UsuarioEstadoId]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Usuario] DROP CONSTRAINT [DF_Usuario_UsuarioEstadoId]
END

GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Usuario_UsuarioId]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Usuario] DROP CONSTRAINT [DF_Usuario_UsuarioId]
END

GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Terceros_FechaModifica]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Terceros] DROP CONSTRAINT [DF_Terceros_FechaModifica]
END

GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Terceros_FechaCreacion]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Terceros] DROP CONSTRAINT [DF_Terceros_FechaCreacion]
END

GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Terceros_TipoTerceroId]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Terceros] DROP CONSTRAINT [DF_Terceros_TipoTerceroId]
END

GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Terceros_TipoIdentificacionId]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Terceros] DROP CONSTRAINT [DF_Terceros_TipoIdentificacionId]
END

GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Terceros_TerceroId]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Terceros] DROP CONSTRAINT [DF_Terceros_TerceroId]
END

GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Roles_FechaModifica]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Roles] DROP CONSTRAINT [DF_Roles_FechaModifica]
END

GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Roles_FechaCreacion]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Roles] DROP CONSTRAINT [DF_Roles_FechaCreacion]
END

GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Roles_Estado]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Roles] DROP CONSTRAINT [DF_Roles_Estado]
END

GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Roles_EsSuperAdmon]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Roles] DROP CONSTRAINT [DF_Roles_EsSuperAdmon]
END

GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Roles_RolId]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Roles] DROP CONSTRAINT [DF_Roles_RolId]
END

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
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_MenuRoles_FechaModifica]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[MenuRoles] DROP CONSTRAINT [DF_MenuRoles_FechaModifica]
END

GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_MenuRoles_FechaCreacion]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[MenuRoles] DROP CONSTRAINT [DF_MenuRoles_FechaCreacion]
END

GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Menu_FechaModificacion]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Menu] DROP CONSTRAINT [DF_Menu_FechaModificacion]
END

GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Menu_FechaCreacion]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Menu] DROP CONSTRAINT [DF_Menu_FechaCreacion]
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
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Clientes_FechaModifica]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Clientes] DROP CONSTRAINT [DF_Clientes_FechaModifica]
END

GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Clientes_FechaCreacion]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Clientes] DROP CONSTRAINT [DF_Clientes_FechaCreacion]
END

GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Clientes_ClienteId]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Clientes] DROP CONSTRAINT [DF_Clientes_ClienteId]
END

GO
/****** Object:  Index [IX_Usuario]    Script Date: 14/03/2021 1:43:05 ******/
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Usuario]') AND name = N'IX_Usuario')
ALTER TABLE [dbo].[Usuario] DROP CONSTRAINT [IX_Usuario]
GO
/****** Object:  Index [IX_Terceros]    Script Date: 14/03/2021 1:43:05 ******/
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Terceros]') AND name = N'IX_Terceros')
ALTER TABLE [dbo].[Terceros] DROP CONSTRAINT [IX_Terceros]
GO
/****** Object:  Table [dbo].[UsuariosEstado]    Script Date: 14/03/2021 1:43:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UsuariosEstado]') AND type in (N'U'))
DROP TABLE [dbo].[UsuariosEstado]
GO
/****** Object:  Table [dbo].[UsuarioRoles]    Script Date: 14/03/2021 1:43:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UsuarioRoles]') AND type in (N'U'))
DROP TABLE [dbo].[UsuarioRoles]
GO
/****** Object:  Table [dbo].[UsuarioInfo]    Script Date: 14/03/2021 1:43:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UsuarioInfo]') AND type in (N'U'))
DROP TABLE [dbo].[UsuarioInfo]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 14/03/2021 1:43:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Usuario]') AND type in (N'U'))
DROP TABLE [dbo].[Usuario]
GO
/****** Object:  Table [dbo].[TraduccionControles]    Script Date: 14/03/2021 1:43:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TraduccionControles]') AND type in (N'U'))
DROP TABLE [dbo].[TraduccionControles]
GO
/****** Object:  Table [dbo].[TipoTercero]    Script Date: 14/03/2021 1:43:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TipoTercero]') AND type in (N'U'))
DROP TABLE [dbo].[TipoTercero]
GO
/****** Object:  Table [dbo].[TipoIdentificacion]    Script Date: 14/03/2021 1:43:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TipoIdentificacion]') AND type in (N'U'))
DROP TABLE [dbo].[TipoIdentificacion]
GO
/****** Object:  Table [dbo].[Terceros]    Script Date: 14/03/2021 1:43:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Terceros]') AND type in (N'U'))
DROP TABLE [dbo].[Terceros]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 14/03/2021 1:43:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Roles]') AND type in (N'U'))
DROP TABLE [dbo].[Roles]
GO
/****** Object:  Table [dbo].[Reservas]    Script Date: 14/03/2021 1:43:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Reservas]') AND type in (N'U'))
DROP TABLE [dbo].[Reservas]
GO
/****** Object:  Table [dbo].[MenuRoles]    Script Date: 14/03/2021 1:43:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MenuRoles]') AND type in (N'U'))
DROP TABLE [dbo].[MenuRoles]
GO
/****** Object:  Table [dbo].[Menu]    Script Date: 14/03/2021 1:43:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Menu]') AND type in (N'U'))
DROP TABLE [dbo].[Menu]
GO
/****** Object:  Table [dbo].[LogApp]    Script Date: 14/03/2021 1:43:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LogApp]') AND type in (N'U'))
DROP TABLE [dbo].[LogApp]
GO
/****** Object:  Table [dbo].[Lenguaje]    Script Date: 14/03/2021 1:43:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Lenguaje]') AND type in (N'U'))
DROP TABLE [dbo].[Lenguaje]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 14/03/2021 1:43:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Clientes]') AND type in (N'U'))
DROP TABLE [dbo].[Clientes]
GO
/****** Object:  UserDefinedFunction [dbo].[IsAdmonRol]    Script Date: 14/03/2021 1:43:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[IsAdmonRol]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[IsAdmonRol]
GO
/****** Object:  UserDefinedFunction [dbo].[IsAdmonRol]    Script Date: 14/03/2021 1:43:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[IsAdmonRol]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'-- =============================================
-- Author:		JUAN RICARDO DIAZ
-- Create date: 2021-03-13
-- Description:	DETERMINA SI EL ID DE UN ROL ES ADMINISTRADOR
-- =============================================
CREATE FUNCTION [dbo].[IsAdmonRol]
(@RolId UNIQUEIDENTIFIER
)
RETURNS BIT
AS
     BEGIN
         --===========================================================================
         DECLARE @IsAdmin BIT= 0;
         SELECT @IsAdmin = CASE
                               WHEN
         (
             SELECT Total = COUNT(1)
             FROM Roles r
             WHERE r.RolId = @RolId
                   AND r.EsSuperAdmon = 1
         ) > 0
                               THEN 1
                               ELSE 0
                           END;
         RETURN @IsAdmin;
         --===========================================================================
     END;
' 
END

GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 14/03/2021 1:43:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Clientes]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Clientes](
	[ClienteId] [uniqueidentifier] NOT NULL,
	[TerceroPadreId] [uniqueidentifier] NOT NULL,
	[TerceroId] [uniqueidentifier] NOT NULL,
	[Estado] [bit] NOT NULL,
	[FechaCreacion] [datetime] NULL,
	[UsuarioCrea] [uniqueidentifier] NULL,
	[FechaModifica] [datetime] NULL,
	[UsuarioModifica] [uniqueidentifier] NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[ClienteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Lenguaje]    Script Date: 14/03/2021 1:43:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Lenguaje]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Lenguaje](
	[LenguajeId] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](50) NOT NULL,
	[Codigo] [nvarchar](10) NOT NULL,
	[CodigoHtml] [nvarchar](50) NULL,
 CONSTRAINT [PK_Lenguaje] PRIMARY KEY CLUSTERED 
(
	[LenguajeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[LogApp]    Script Date: 14/03/2021 1:43:05 ******/
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
/****** Object:  Table [dbo].[Menu]    Script Date: 14/03/2021 1:43:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Menu]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Menu](
	[MenuId] [int] IDENTITY(1,1) NOT NULL,
	[MenuNombre] [nvarchar](50) NOT NULL,
	[MenuPadreId] [int] NULL,
	[MenuUrl] [nvarchar](50) NULL,
	[MenuClass] [nvarchar](50) NULL,
	[MenuOrden] [int] NULL,
	[Estado] [bit] NOT NULL,
	[FechaCreacion] [datetime] NULL,
	[UsuarioCrea] [uniqueidentifier] NULL,
	[UsuarioModifica] [uniqueidentifier] NULL,
	[FechaModificacion] [datetime] NULL,
 CONSTRAINT [PK_Menu] PRIMARY KEY CLUSTERED 
(
	[MenuId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[MenuRoles]    Script Date: 14/03/2021 1:43:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MenuRoles]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[MenuRoles](
	[MenuRolId] [int] IDENTITY(1,1) NOT NULL,
	[MenuId] [int] NOT NULL,
	[RolId] [uniqueidentifier] NOT NULL,
	[Estado] [bit] NULL,
	[FechaCreacion] [datetime] NULL,
	[UsuarioCrea] [uniqueidentifier] NULL,
	[FechaModifica] [datetime] NULL,
	[UsuarioModifica] [uniqueidentifier] NULL,
 CONSTRAINT [PK_MenuRoles] PRIMARY KEY CLUSTERED 
(
	[MenuRolId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Reservas]    Script Date: 14/03/2021 1:43:05 ******/
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
/****** Object:  Table [dbo].[Roles]    Script Date: 14/03/2021 1:43:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Roles]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Roles](
	[RolId] [uniqueidentifier] NOT NULL,
	[Descripcion] [nvarchar](50) NOT NULL,
	[TerceroId] [uniqueidentifier] NULL,
	[EsSuperAdmon] [bit] NOT NULL,
	[Estado] [bit] NOT NULL,
	[FechaCreacion] [datetime] NULL,
	[UsuarioCrea] [uniqueidentifier] NULL,
	[FechaModifica] [datetime] NULL,
	[UsuarioModifica] [uniqueidentifier] NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[RolId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Terceros]    Script Date: 14/03/2021 1:43:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Terceros]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Terceros](
	[TerceroId] [uniqueidentifier] NOT NULL,
	[TipoIdentificacionId] [int] NULL,
	[TipoTerceroId] [int] NOT NULL,
	[Documento] [nvarchar](50) NULL,
	[RazonSocial] [nvarchar](100) NULL,
	[NombreComercial] [nvarchar](100) NULL,
	[FechaCreacion] [datetime] NULL,
	[UsuarioCrea] [uniqueidentifier] NULL,
	[FechaModifica] [datetime] NULL,
	[UsuarioModifica] [uniqueidentifier] NULL,
 CONSTRAINT [PK_Terceros] PRIMARY KEY CLUSTERED 
(
	[TerceroId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[TipoIdentificacion]    Script Date: 14/03/2021 1:43:05 ******/
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
/****** Object:  Table [dbo].[TipoTercero]    Script Date: 14/03/2021 1:43:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TipoTercero]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TipoTercero](
	[TipoTerceroId] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_TipoTercero] PRIMARY KEY CLUSTERED 
(
	[TipoTerceroId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[TraduccionControles]    Script Date: 14/03/2021 1:43:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TraduccionControles]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TraduccionControles](
	[NombreControl] [nvarchar](50) NOT NULL,
	[LenguajeId] [int] NOT NULL,
	[Texto] [nvarchar](50) NOT NULL,
	[FechaCreacion] [datetime] NULL,
	[UsuarioCrea] [uniqueidentifier] NULL,
	[FechaModifica] [datetime] NULL,
	[UsuarioModifica] [uniqueidentifier] NULL,
 CONSTRAINT [PK_TraduccionControles_1] PRIMARY KEY CLUSTERED 
(
	[NombreControl] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 14/03/2021 1:43:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Usuario]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Usuario](
	[UsuarioId] [uniqueidentifier] NOT NULL,
	[UsuarioNombre] [nvarchar](100) NOT NULL,
	[UsuarioCorreo] [nvarchar](200) NOT NULL,
	[UsuarioEstadoId] [int] NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[UsuarioCrea] [uniqueidentifier] NULL,
	[UsuarioModifica] [uniqueidentifier] NULL,
	[FechaModificacion] [datetime] NULL,
	[NumItentos] [int] NULL,
	[Pw] [nvarchar](500) NULL,
	[FechaUltimoIngreso] [datetime] NULL,
	[RestauraClave] [bit] NULL,
	[LenguajeId] [int] NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[UsuarioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[UsuarioInfo]    Script Date: 14/03/2021 1:43:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UsuarioInfo]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[UsuarioInfo](
	[UsuarioId] [uniqueidentifier] NOT NULL,
	[TipoIdentificacionId] [int] NULL,
	[Documento] [nvarchar](50) NULL,
	[Nombres] [nvarchar](100) NULL,
	[Apellidos] [nvarchar](100) NULL,
	[CorreoAlternativo] [nvarchar](300) NULL,
	[Telefono] [nvarchar](50) NULL,
	[Direccion] [nvarchar](500) NULL,
	[FechaNacimiento] [date] NULL,
	[FechaCreacion] [datetime] NULL,
	[UsuarioCrea] [uniqueidentifier] NULL,
	[FechaModificacion] [datetime] NULL,
	[UsuarioModifica] [uniqueidentifier] NULL,
 CONSTRAINT [PK_UsuarioInfo] PRIMARY KEY CLUSTERED 
(
	[UsuarioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[UsuarioRoles]    Script Date: 14/03/2021 1:43:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UsuarioRoles]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[UsuarioRoles](
	[UsuarioRolId] [uniqueidentifier] NOT NULL,
	[UsuarioId] [uniqueidentifier] NOT NULL,
	[RolId] [uniqueidentifier] NOT NULL,
	[TerceroId] [uniqueidentifier] NOT NULL,
	[Estado] [bit] NOT NULL,
	[FechaCreacion] [datetime] NULL,
	[UsuarioCrea] [uniqueidentifier] NULL,
	[FechaModifica] [datetime] NULL,
	[UsuarioModifica] [uniqueidentifier] NULL,
 CONSTRAINT [PK_UsuarioRoles] PRIMARY KEY CLUSTERED 
(
	[UsuarioRolId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[UsuariosEstado]    Script Date: 14/03/2021 1:43:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UsuariosEstado]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[UsuariosEstado](
	[UsuarioEstadoId] [int] IDENTITY(1,1) NOT NULL,
	[DescripcionEstado] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_UsuarioEstado] PRIMARY KEY CLUSTERED 
(
	[UsuarioEstadoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET IDENTITY_INSERT [dbo].[Lenguaje] ON 

GO
INSERT [dbo].[Lenguaje] ([LenguajeId], [Descripcion], [Codigo], [CodigoHtml]) VALUES (1, N'Español Colombia', N'es-CO', NULL)
GO
INSERT [dbo].[Lenguaje] ([LenguajeId], [Descripcion], [Codigo], [CodigoHtml]) VALUES (2, N'Ingles', N'en-US', NULL)
GO
SET IDENTITY_INSERT [dbo].[Lenguaje] OFF
GO
INSERT [dbo].[LogApp] ([IdLog], [DateCreate], [ThreadLog], [LeveLog], [Logger], [MessagLog], [ExceptionLog]) VALUES (N'd01a9b3f-6896-452c-8144-067689de60a4', CAST(N'2021-03-13 20:29:55.930' AS DateTime), N'5', N'ERROR', N'Netactica.Tools.Logger', N'UsuarioServices  GuardarUsuario', N'AutoMapper.AutoMapperMappingException: Error mapping types.

Mapping types:
UsuarioResponse -> Usuario
Netactica.Services.Response.UsuarioResponse -> Netactica.Models.Usuario

Type Map configuration:
UsuarioResponse -> Usuario
Netactica.Services.Response.UsuarioResponse -> Netactica.Models.Usuario

Property:
Lenguaje ---> AutoMapper.AutoMapperMappingException: Missing type map configuration or unsupported mapping.

Mapping types:
String -> Lenguaje
System.String -> Netactica.Models.Lenguaje
   en lambda_method(Closure , String , Lenguaje , ResolutionContext )
   en AutoMapper.ResolutionContext.Map[TSource,TDestination](TSource source, TDestination destination)
   en lambda_method(Closure , UsuarioResponse , Usuario , ResolutionContext )
   --- Fin del seguimiento de la pila de la excepción interna ---
   en lambda_method(Closure , UsuarioResponse , Usuario , ResolutionContext )
   en AutoMapper.Mapper.AutoMapper.IMapper.Map[TSource,TDestination](TSource source)
   en AutoMapper.Mapper.Map[TSource,TDestination](TSource source)
   en Netactica.Services.UsuarioServices.GuardarUsuario(UsuarioResponse userResponse) en C:\Users\juanr\source\repos\NetacticaSolutions\Netactica.Services\UsuarioServices.cs:línea 67')
GO
INSERT [dbo].[LogApp] ([IdLog], [DateCreate], [ThreadLog], [LeveLog], [Logger], [MessagLog], [ExceptionLog]) VALUES (N'28d41016-3791-40a2-9f28-06a1b726cdab', CAST(N'2021-02-11 23:18:43.297' AS DateTime), N'6', N'ERROR', N'Netactica.Tools.Logger', N'ReservasServices GuardarReserva', N'System.Exception: El tipo de documento no puede ser menor o igual a 0
   en Netactica.Services.ReservasServices.ValidarReserva(Reservas reservas) en C:\Users\juanr\source\repos\NetacticaSolutions\Netactica.Services\ReservasServices.cs:línea 141
   en Netactica.Services.ReservasServices.GuardarReserva(Reservas reserva) en C:\Users\juanr\source\repos\NetacticaSolutions\Netactica.Services\ReservasServices.cs:línea 67')
GO
INSERT [dbo].[LogApp] ([IdLog], [DateCreate], [ThreadLog], [LeveLog], [Logger], [MessagLog], [ExceptionLog]) VALUES (N'2c7ab6f6-70b0-43c0-810f-1167532b46bc', CAST(N'2021-02-11 23:03:29.183' AS DateTime), N'5', N'ERROR', N'Netactica.Tools.Logger', N'ReservasServices GuardarReserva', N'System.Exception: El id de la reservar no pueder ser vacio o igual a 00000000-0000-0000-0000-000000000000,El tipo de documento no puede ser menor o igual a 0
   en Netactica.Services.ReservasServices.ValidarReserva(Reservas reservas) en C:\Users\juanr\source\repos\NetacticaSolutions\Netactica.Services\ReservasServices.cs:línea 130
   en Netactica.Services.ReservasServices.GuardarReserva(Reservas reserva) en C:\Users\juanr\source\repos\NetacticaSolutions\Netactica.Services\ReservasServices.cs:línea 58')
GO
INSERT [dbo].[LogApp] ([IdLog], [DateCreate], [ThreadLog], [LeveLog], [Logger], [MessagLog], [ExceptionLog]) VALUES (N'031ce028-091a-49cd-9a42-1eea64186cc5', CAST(N'2021-02-11 23:22:12.910' AS DateTime), N'6', N'ERROR', N'Netactica.Tools.Logger', N'ReservasServices GuardarReserva', N'System.Exception: El Lugar de entrega del vehiculo no pueder ser vacio
   en Netactica.Services.ReservasServices.ValidarReserva(Reservas reservas) en C:\Users\juanr\source\repos\NetacticaSolutions\Netactica.Services\ReservasServices.cs:línea 141
   en Netactica.Services.ReservasServices.GuardarReserva(Reservas reserva) en C:\Users\juanr\source\repos\NetacticaSolutions\Netactica.Services\ReservasServices.cs:línea 67')
GO
INSERT [dbo].[LogApp] ([IdLog], [DateCreate], [ThreadLog], [LeveLog], [Logger], [MessagLog], [ExceptionLog]) VALUES (N'00730ba7-cdb5-408a-9ffc-41b291c582e8', CAST(N'2021-02-11 23:20:56.053' AS DateTime), N'6', N'ERROR', N'Netactica.Tools.Logger', N'ReservasServices GuardarReserva', N'System.Exception: El precio por hora no puede ser vacio o 0,El precio por hora no puede ser menor o igual a 0
   en Netactica.Services.ReservasServices.ValidarReserva(Reservas reservas) en C:\Users\juanr\source\repos\NetacticaSolutions\Netactica.Services\ReservasServices.cs:línea 141
   en Netactica.Services.ReservasServices.GuardarReserva(Reservas reserva) en C:\Users\juanr\source\repos\NetacticaSolutions\Netactica.Services\ReservasServices.cs:línea 67')
GO
INSERT [dbo].[LogApp] ([IdLog], [DateCreate], [ThreadLog], [LeveLog], [Logger], [MessagLog], [ExceptionLog]) VALUES (N'423a0311-ef83-4ec6-977b-5857d85c2847', CAST(N'2021-03-13 21:04:54.223' AS DateTime), N'7', N'ERROR', N'Netactica.Tools.Logger', N'UsuarioServices  GuardarUsuario', N'System.Security.Cryptography.CryptographicException: Vector de inicialización (IV) especificado no coincide con el tamaño del bloque para este algoritmo.
   en System.Security.Cryptography.SymmetricAlgorithm.set_IV(Byte[] value)
   en Netactica.Tools.StringTools.StringUtil.Encode(String value, String key) en C:\Users\juanr\source\repos\NetacticaSolutions\Netactica.Tools\StringUtil.cs:línea 305
   en Netactica.Services.UsuarioServices.GuardarUsuario(UsuarioResponse userResponse) en C:\Users\juanr\source\repos\NetacticaSolutions\Netactica.Services\UsuarioServices.cs:línea 75')
GO
INSERT [dbo].[LogApp] ([IdLog], [DateCreate], [ThreadLog], [LeveLog], [Logger], [MessagLog], [ExceptionLog]) VALUES (N'd7a68303-fdc6-4e7e-a15e-590c1345c675', CAST(N'2021-03-13 20:31:51.020' AS DateTime), N'6', N'ERROR', N'Netactica.Tools.Logger', N'UsuarioServices  GuardarUsuario', N'AutoMapper.AutoMapperMappingException: Error mapping types.

Mapping types:
UsuarioResponse -> Usuario
Netactica.Services.Response.UsuarioResponse -> Netactica.Models.Usuario

Type Map configuration:
UsuarioResponse -> Usuario
Netactica.Services.Response.UsuarioResponse -> Netactica.Models.Usuario

Property:
Lenguaje ---> AutoMapper.AutoMapperMappingException: Missing type map configuration or unsupported mapping.

Mapping types:
String -> Lenguaje
System.String -> Netactica.Models.Lenguaje
   en lambda_method(Closure , String , Lenguaje , ResolutionContext )
   en AutoMapper.ResolutionContext.Map[TSource,TDestination](TSource source, TDestination destination)
   en lambda_method(Closure , UsuarioResponse , Usuario , ResolutionContext )
   --- Fin del seguimiento de la pila de la excepción interna ---
   en lambda_method(Closure , UsuarioResponse , Usuario , ResolutionContext )
   en AutoMapper.Mapper.AutoMapper.IMapper.Map[TSource,TDestination](TSource source)
   en AutoMapper.Mapper.Map[TSource,TDestination](TSource source)
   en Netactica.Services.UsuarioServices.GuardarUsuario(UsuarioResponse userResponse) en C:\Users\juanr\source\repos\NetacticaSolutions\Netactica.Services\UsuarioServices.cs:línea 67')
GO
INSERT [dbo].[LogApp] ([IdLog], [DateCreate], [ThreadLog], [LeveLog], [Logger], [MessagLog], [ExceptionLog]) VALUES (N'a594c953-83ed-439e-8b72-5a0d0a807750', CAST(N'2021-02-02 23:21:46.657' AS DateTime), N'6', N'INFO', N'Netactica.Tools.Logger', N'Filtro {"ReservaId":null,"FechaCreacionIni":"2021-01-01T00:00:00","FechaCreacionFin":"2022-02-03T00:00:00"}', N'')
GO
INSERT [dbo].[LogApp] ([IdLog], [DateCreate], [ThreadLog], [LeveLog], [Logger], [MessagLog], [ExceptionLog]) VALUES (N'6981e8bd-aab2-41f4-954a-5b472b02566e', CAST(N'2021-03-13 20:34:44.423' AS DateTime), N'5', N'ERROR', N'Netactica.Tools.Logger', N'UsuarioServices  GuardarUsuario', N'AutoMapper.AutoMapperMappingException: Error mapping types.

Mapping types:
UsuarioResponse -> Usuario
Netactica.Services.Response.UsuarioResponse -> Netactica.Models.Usuario

Type Map configuration:
UsuarioResponse -> Usuario
Netactica.Services.Response.UsuarioResponse -> Netactica.Models.Usuario

Property:
Lenguaje ---> AutoMapper.AutoMapperMappingException: Missing type map configuration or unsupported mapping.

Mapping types:
String -> Lenguaje
System.String -> Netactica.Models.Lenguaje
   en lambda_method(Closure , String , Lenguaje , ResolutionContext )
   en AutoMapper.ResolutionContext.Map[TSource,TDestination](TSource source, TDestination destination)
   en lambda_method(Closure , UsuarioResponse , Usuario , ResolutionContext )
   --- Fin del seguimiento de la pila de la excepción interna ---
   en lambda_method(Closure , UsuarioResponse , Usuario , ResolutionContext )
   en AutoMapper.Mapper.AutoMapper.IMapper.Map[TSource,TDestination](TSource source)
   en AutoMapper.Mapper.Map[TSource,TDestination](TSource source)
   en Netactica.Services.UsuarioServices.GuardarUsuario(UsuarioResponse userResponse) en C:\Users\juanr\source\repos\NetacticaSolutions\Netactica.Services\UsuarioServices.cs:línea 67')
GO
INSERT [dbo].[LogApp] ([IdLog], [DateCreate], [ThreadLog], [LeveLog], [Logger], [MessagLog], [ExceptionLog]) VALUES (N'b22d1a62-620b-4756-b32e-60a0c140a664', CAST(N'2021-02-11 23:01:06.360' AS DateTime), N'11', N'ERROR', N'Netactica.Tools.Logger', N'ReservasServices GuardarReserva', N'System.Exception: El id de la reservar no pueder ser vacio o igual a 00000000-0000-0000-0000-000000000000,El tipo de documento de identidad no pueder ser vacio o igual a 0,El tipo de documento no puede ser menor o igual a 0
   en Netactica.Services.ReservasServices.ValidarReserva(Reservas reservas) en C:\Users\juanr\source\repos\NetacticaSolutions\Netactica.Services\ReservasServices.cs:línea 130
   en Netactica.Services.ReservasServices.GuardarReserva(Reservas reserva) en C:\Users\juanr\source\repos\NetacticaSolutions\Netactica.Services\ReservasServices.cs:línea 54')
GO
INSERT [dbo].[LogApp] ([IdLog], [DateCreate], [ThreadLog], [LeveLog], [Logger], [MessagLog], [ExceptionLog]) VALUES (N'0b0ea0b0-d3f7-42f1-82d3-9177a6605e76', CAST(N'2021-03-13 21:06:27.313' AS DateTime), N'7', N'ERROR', N'Netactica.Tools.Logger', N'UsuarioServices  GuardarUsuario', N'System.Security.Cryptography.CryptographicException: Vector de inicialización (IV) especificado no coincide con el tamaño del bloque para este algoritmo.
   en System.Security.Cryptography.SymmetricAlgorithm.set_IV(Byte[] value)
   en Netactica.Tools.StringTools.StringUtil.Encode(String value, String key) en C:\Users\juanr\source\repos\NetacticaSolutions\Netactica.Tools\StringUtil.cs:línea 305
   en Netactica.Services.UsuarioServices.GuardarUsuario(UsuarioResponse userResponse) en C:\Users\juanr\source\repos\NetacticaSolutions\Netactica.Services\UsuarioServices.cs:línea 75')
GO
INSERT [dbo].[LogApp] ([IdLog], [DateCreate], [ThreadLog], [LeveLog], [Logger], [MessagLog], [ExceptionLog]) VALUES (N'60a23af5-0986-4b2a-a001-9c5292439e5c', CAST(N'2021-02-11 23:06:36.383' AS DateTime), N'7', N'ERROR', N'Netactica.Tools.Logger', N'ReservasServices GuardarReserva', N'System.Exception: El tipo de documento no puede ser menor o igual a 0
   en Netactica.Services.ReservasServices.ValidarReserva(Reservas reservas) en C:\Users\juanr\source\repos\NetacticaSolutions\Netactica.Services\ReservasServices.cs:línea 130
   en Netactica.Services.ReservasServices.GuardarReserva(Reservas reserva) en C:\Users\juanr\source\repos\NetacticaSolutions\Netactica.Services\ReservasServices.cs:línea 59')
GO
INSERT [dbo].[LogApp] ([IdLog], [DateCreate], [ThreadLog], [LeveLog], [Logger], [MessagLog], [ExceptionLog]) VALUES (N'6e0317b8-dfd9-4c14-800a-ac9fe0dbe8ad', CAST(N'2021-03-13 20:38:47.020' AS DateTime), N'6', N'ERROR', N'Netactica.Tools.Logger', N'UsuarioServices  GuardarUsuario', N'AutoMapper.AutoMapperMappingException: Error mapping types.

Mapping types:
UsuarioResponse -> Usuario
Netactica.Services.Response.UsuarioResponse -> Netactica.Models.Usuario

Type Map configuration:
UsuarioResponse -> Usuario
Netactica.Services.Response.UsuarioResponse -> Netactica.Models.Usuario

Property:
Lenguaje ---> AutoMapper.AutoMapperMappingException: Missing type map configuration or unsupported mapping.

Mapping types:
String -> Lenguaje
System.String -> Netactica.Models.Lenguaje
   en lambda_method(Closure , String , Lenguaje , ResolutionContext )
   en AutoMapper.ResolutionContext.Map[TSource,TDestination](TSource source, TDestination destination)
   en lambda_method(Closure , UsuarioResponse , Usuario , ResolutionContext )
   --- Fin del seguimiento de la pila de la excepción interna ---
   en lambda_method(Closure , UsuarioResponse , Usuario , ResolutionContext )
   en AutoMapper.Mapper.AutoMapper.IMapper.Map[TSource,TDestination](TSource source)
   en AutoMapper.Mapper.Map[TSource,TDestination](TSource source)
   en Netactica.Services.UsuarioServices.GuardarUsuario(UsuarioResponse userResponse) en C:\Users\juanr\source\repos\NetacticaSolutions\Netactica.Services\UsuarioServices.cs:línea 67')
GO
INSERT [dbo].[LogApp] ([IdLog], [DateCreate], [ThreadLog], [LeveLog], [Logger], [MessagLog], [ExceptionLog]) VALUES (N'ede9bb78-2e94-47de-94e2-c1c9d4022fe4', CAST(N'2021-03-13 21:35:28.617' AS DateTime), N'6', N'ERROR', N'Netactica.Tools.Logger', N'UsuarioServices  ModificarUsuario', N'System.Data.SqlClient.SqlException (0x80131904): Instrucción UPDATE en conflicto con la restricción FOREIGN KEY "FK_Usuario_UsuariosEstado". El conflicto ha aparecido en la base de datos "NetacticaDB", tabla "dbo.UsuariosEstado", column ''UsuarioEstadoId''.
Se terminó la instrucción.
   en System.Data.SqlClient.SqlConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   en System.Data.SqlClient.SqlInternalConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   en System.Data.SqlClient.TdsParser.ThrowExceptionAndWarning(TdsParserStateObject stateObj, Boolean callerHasConnectionLock, Boolean asyncClose)
   en System.Data.SqlClient.TdsParser.TryRun(RunBehavior runBehavior, SqlCommand cmdHandler, SqlDataReader dataStream, BulkCopySimpleResultSet bulkCopyHandler, TdsParserStateObject stateObj, Boolean& dataReady)
   en System.Data.SqlClient.SqlCommand.FinishExecuteReader(SqlDataReader ds, RunBehavior runBehavior, String resetOptionsString, Boolean isInternal, Boolean forDescribeParameterEncryption, Boolean shouldCacheForAlwaysEncrypted)
   en System.Data.SqlClient.SqlCommand.RunExecuteReaderTds(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, Boolean async, Int32 timeout, Task& task, Boolean asyncWrite, Boolean inRetry, SqlDataReader ds, Boolean describeParameterEncryptionRequest)
   en System.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, String method, TaskCompletionSource`1 completion, Int32 timeout, Task& task, Boolean& usedCache, Boolean asyncWrite, Boolean inRetry)
   en System.Data.SqlClient.SqlCommand.InternalExecuteNonQuery(TaskCompletionSource`1 completion, String methodName, Boolean sendToPipe, Int32 timeout, Boolean& usedCache, Boolean asyncWrite, Boolean inRetry)
   en System.Data.SqlClient.SqlCommand.ExecuteNonQuery()
   en Dapper.SqlMapper.ExecuteCommand(IDbConnectio')
GO
INSERT [dbo].[LogApp] ([IdLog], [DateCreate], [ThreadLog], [LeveLog], [Logger], [MessagLog], [ExceptionLog]) VALUES (N'7bf1f3ea-dc09-48a8-9095-d192fece7168', CAST(N'2021-02-11 23:26:20.263' AS DateTime), N'6', N'ERROR', N'Netactica.Tools.Logger', N'ReservasServices ModificarReserva', N'System.Exception: El tipo de documento no puede ser menor o igual a 0
   en Netactica.Services.ReservasServices.ValidarReserva(Reservas reservas) en C:\Users\juanr\source\repos\NetacticaSolutions\Netactica.Services\ReservasServices.cs:línea 144
   en Netactica.Services.ReservasServices.ModificarReserva(Reservas reserva) en C:\Users\juanr\source\repos\NetacticaSolutions\Netactica.Services\ReservasServices.cs:línea 109')
GO
INSERT [dbo].[LogApp] ([IdLog], [DateCreate], [ThreadLog], [LeveLog], [Logger], [MessagLog], [ExceptionLog]) VALUES (N'1220561c-ff45-475e-adf1-d3a3fed2a4f2', CAST(N'2021-02-11 23:21:41.993' AS DateTime), N'6', N'ERROR', N'Netactica.Tools.Logger', N'ReservasServices GuardarReserva', N'System.Exception: El precio por hora no puede ser menor o igual a 0
   en Netactica.Services.ReservasServices.ValidarReserva(Reservas reservas) en C:\Users\juanr\source\repos\NetacticaSolutions\Netactica.Services\ReservasServices.cs:línea 141
   en Netactica.Services.ReservasServices.GuardarReserva(Reservas reserva) en C:\Users\juanr\source\repos\NetacticaSolutions\Netactica.Services\ReservasServices.cs:línea 67')
GO
INSERT [dbo].[LogApp] ([IdLog], [DateCreate], [ThreadLog], [LeveLog], [Logger], [MessagLog], [ExceptionLog]) VALUES (N'396a0b91-603b-4079-b371-dd40f7a09c99', CAST(N'2021-02-11 23:18:58.897' AS DateTime), N'7', N'ERROR', N'Netactica.Tools.Logger', N'ReservasServices GuardarReserva', N'System.Exception: Fecha de recogida inválida
   en Netactica.Services.ReservasServices.ValidarReserva(Reservas reservas) en C:\Users\juanr\source\repos\NetacticaSolutions\Netactica.Services\ReservasServices.cs:línea 141
   en Netactica.Services.ReservasServices.GuardarReserva(Reservas reserva) en C:\Users\juanr\source\repos\NetacticaSolutions\Netactica.Services\ReservasServices.cs:línea 67')
GO
INSERT [dbo].[LogApp] ([IdLog], [DateCreate], [ThreadLog], [LeveLog], [Logger], [MessagLog], [ExceptionLog]) VALUES (N'51f0b1fe-4831-4012-92c9-dd68d588f42d', CAST(N'2021-03-13 21:01:20.907' AS DateTime), N'6', N'ERROR', N'Netactica.Tools.Logger', N'UsuarioServices  GuardarUsuario', N'System.Security.Cryptography.CryptographicException: Vector de inicialización (IV) especificado no coincide con el tamaño del bloque para este algoritmo.
   en System.Security.Cryptography.SymmetricAlgorithm.set_IV(Byte[] value)
   en Netactica.Tools.StringTools.StringUtil.Encode(String value, String key) en C:\Users\juanr\source\repos\NetacticaSolutions\Netactica.Tools\StringUtil.cs:línea 305
   en Netactica.Services.UsuarioServices.GuardarUsuario(UsuarioResponse userResponse) en C:\Users\juanr\source\repos\NetacticaSolutions\Netactica.Services\UsuarioServices.cs:línea 75')
GO
INSERT [dbo].[LogApp] ([IdLog], [DateCreate], [ThreadLog], [LeveLog], [Logger], [MessagLog], [ExceptionLog]) VALUES (N'e294237a-e357-4b5e-8f64-e0ad4b7415a0', CAST(N'2021-03-13 21:03:28.707' AS DateTime), N'6', N'ERROR', N'Netactica.Tools.Logger', N'UsuarioServices  GuardarUsuario', N'System.Security.Cryptography.CryptographicException: Vector de inicialización (IV) especificado no coincide con el tamaño del bloque para este algoritmo.
   en System.Security.Cryptography.SymmetricAlgorithm.set_IV(Byte[] value)
   en Netactica.Tools.StringTools.StringUtil.Encode(String value, String key) en C:\Users\juanr\source\repos\NetacticaSolutions\Netactica.Tools\StringUtil.cs:línea 305
   en Netactica.Services.UsuarioServices.GuardarUsuario(UsuarioResponse userResponse) en C:\Users\juanr\source\repos\NetacticaSolutions\Netactica.Services\UsuarioServices.cs:línea 75')
GO
INSERT [dbo].[LogApp] ([IdLog], [DateCreate], [ThreadLog], [LeveLog], [Logger], [MessagLog], [ExceptionLog]) VALUES (N'1c2c4db0-7d8c-45b7-ab86-fc136ac2ad5c', CAST(N'2021-02-11 23:17:41.467' AS DateTime), N'6', N'ERROR', N'Netactica.Tools.Logger', N'ReservasServices GuardarReserva', N'System.Exception: El tipo de documento no puede ser menor o igual a 0
   en Netactica.Services.ReservasServices.ValidarReserva(Reservas reservas) en C:\Users\juanr\source\repos\NetacticaSolutions\Netactica.Services\ReservasServices.cs:línea 141
   en Netactica.Services.ReservasServices.GuardarReserva(Reservas reserva) en C:\Users\juanr\source\repos\NetacticaSolutions\Netactica.Services\ReservasServices.cs:línea 67')
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
INSERT [dbo].[Roles] ([RolId], [Descripcion], [TerceroId], [EsSuperAdmon], [Estado], [FechaCreacion], [UsuarioCrea], [FechaModifica], [UsuarioModifica]) VALUES (N'0e677492-1b9e-46f4-8c80-a3510014b517', N'ADMINISTRDOR CLIENTE', NULL, 0, 1, CAST(N'2021-03-14 00:43:59.333' AS DateTime), NULL, CAST(N'2021-03-14 00:43:59.333' AS DateTime), NULL)
GO
INSERT [dbo].[Roles] ([RolId], [Descripcion], [TerceroId], [EsSuperAdmon], [Estado], [FechaCreacion], [UsuarioCrea], [FechaModifica], [UsuarioModifica]) VALUES (N'9640a9fd-7224-44a2-9161-de596487167e', N'SUPER ADMINISTRADOR', NULL, 1, 1, CAST(N'2021-02-12 00:23:50.247' AS DateTime), NULL, CAST(N'2021-02-12 00:23:50.247' AS DateTime), NULL)
GO
INSERT [dbo].[Terceros] ([TerceroId], [TipoIdentificacionId], [TipoTerceroId], [Documento], [RazonSocial], [NombreComercial], [FechaCreacion], [UsuarioCrea], [FechaModifica], [UsuarioModifica]) VALUES (N'00000000-0000-0000-0000-000000000000', 5, 2, N'0000000000', N'SIN EMPRESA', N'SIN EMPRESA', CAST(N'2021-02-12 00:30:31.773' AS DateTime), NULL, CAST(N'2021-02-12 00:30:31.773' AS DateTime), NULL)
GO
INSERT [dbo].[Terceros] ([TerceroId], [TipoIdentificacionId], [TipoTerceroId], [Documento], [RazonSocial], [NombreComercial], [FechaCreacion], [UsuarioCrea], [FechaModifica], [UsuarioModifica]) VALUES (N'167c2ad2-80af-423b-8ccf-908cca2fa2e3', 5, 2, N'890903938', N'BANCOLOMBIA S.A', N'BANCOLOMBIA', CAST(N'2021-03-14 00:00:00.000' AS DateTime), NULL, CAST(N'2021-03-14 00:43:20.517' AS DateTime), NULL)
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
SET IDENTITY_INSERT [dbo].[TipoTercero] ON 

GO
INSERT [dbo].[TipoTercero] ([TipoTerceroId], [Descripcion]) VALUES (1, N'Cliente')
GO
INSERT [dbo].[TipoTercero] ([TipoTerceroId], [Descripcion]) VALUES (2, N'Empresa')
GO
INSERT [dbo].[TipoTercero] ([TipoTerceroId], [Descripcion]) VALUES (3, N'Tercero')
GO
INSERT [dbo].[TipoTercero] ([TipoTerceroId], [Descripcion]) VALUES (4, N'Grupo Empresarial')
GO
SET IDENTITY_INSERT [dbo].[TipoTercero] OFF
GO
INSERT [dbo].[Usuario] ([UsuarioId], [UsuarioNombre], [UsuarioCorreo], [UsuarioEstadoId], [FechaCreacion], [UsuarioCrea], [UsuarioModifica], [FechaModificacion], [NumItentos], [Pw], [FechaUltimoIngreso], [RestauraClave], [LenguajeId]) VALUES (N'6761776d-772b-4c86-9ea2-25a8a5c6958b', N'eduardo.diaz', N'eduado.diaz@hotmail.com', 1, CAST(N'2021-03-14 00:47:09.410' AS DateTime), N'8ac96764-be50-400b-9900-7d813e660c78', NULL, CAST(N'2021-03-14 00:47:09.410' AS DateTime), 0, N'zZHJRlZZS46u0NX/7fP0hA==', CAST(N'2021-03-14 00:47:09.410' AS DateTime), 0, 1)
GO
INSERT [dbo].[Usuario] ([UsuarioId], [UsuarioNombre], [UsuarioCorreo], [UsuarioEstadoId], [FechaCreacion], [UsuarioCrea], [UsuarioModifica], [FechaModificacion], [NumItentos], [Pw], [FechaUltimoIngreso], [RestauraClave], [LenguajeId]) VALUES (N'8ac96764-be50-400b-9900-7d813e660c78', N'jrdiaz123', N'juanricardo200@hotmail.com', 1, CAST(N'2021-02-12 00:25:06.933' AS DateTime), NULL, NULL, CAST(N'2021-03-13 21:53:22.023' AS DateTime), 0, N'Q2FtYmlhcjEyMy0=', NULL, NULL, 1)
GO
INSERT [dbo].[Usuario] ([UsuarioId], [UsuarioNombre], [UsuarioCorreo], [UsuarioEstadoId], [FechaCreacion], [UsuarioCrea], [UsuarioModifica], [FechaModificacion], [NumItentos], [Pw], [FechaUltimoIngreso], [RestauraClave], [LenguajeId]) VALUES (N'722d4091-926a-49b7-a1ab-e2310dfa0f6a', N'andres.diaz', N'andres.diaz@hotmail.com', 1, CAST(N'2021-03-14 00:25:21.387' AS DateTime), N'8ac96764-be50-400b-9900-7d813e660c78', NULL, CAST(N'2021-03-14 00:25:21.387' AS DateTime), 0, N'zZHJRlZZS46u0NX/7fP0hA==', CAST(N'2021-03-14 00:25:21.387' AS DateTime), 0, 1)
GO
INSERT [dbo].[UsuarioInfo] ([UsuarioId], [TipoIdentificacionId], [Documento], [Nombres], [Apellidos], [CorreoAlternativo], [Telefono], [Direccion], [FechaNacimiento], [FechaCreacion], [UsuarioCrea], [FechaModificacion], [UsuarioModifica]) VALUES (N'6761776d-772b-4c86-9ea2-25a8a5c6958b', 1, N'', N'', N'', N'', N'', N'', NULL, CAST(N'2021-03-14 00:47:09.410' AS DateTime), N'8ac96764-be50-400b-9900-7d813e660c78', NULL, NULL)
GO
INSERT [dbo].[UsuarioInfo] ([UsuarioId], [TipoIdentificacionId], [Documento], [Nombres], [Apellidos], [CorreoAlternativo], [Telefono], [Direccion], [FechaNacimiento], [FechaCreacion], [UsuarioCrea], [FechaModificacion], [UsuarioModifica]) VALUES (N'8ac96764-be50-400b-9900-7d813e660c78', 1, N'1073675237', N'JUAN RICARDO', N'DIAZ SUANCHA', N'juanricardo200@gmail.com', NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[UsuarioInfo] ([UsuarioId], [TipoIdentificacionId], [Documento], [Nombres], [Apellidos], [CorreoAlternativo], [Telefono], [Direccion], [FechaNacimiento], [FechaCreacion], [UsuarioCrea], [FechaModificacion], [UsuarioModifica]) VALUES (N'722d4091-926a-49b7-a1ab-e2310dfa0f6a', 1, N'', N'', N'', N'', N'', N'', NULL, CAST(N'2021-03-14 00:25:21.387' AS DateTime), N'8ac96764-be50-400b-9900-7d813e660c78', NULL, NULL)
GO
INSERT [dbo].[UsuarioRoles] ([UsuarioRolId], [UsuarioId], [RolId], [TerceroId], [Estado], [FechaCreacion], [UsuarioCrea], [FechaModifica], [UsuarioModifica]) VALUES (N'dfe06f39-df34-4b63-9afc-2125caebdfe8', N'722d4091-926a-49b7-a1ab-e2310dfa0f6a', N'0e677492-1b9e-46f4-8c80-a3510014b517', N'00000000-0000-0000-0000-000000000000', 1, CAST(N'2021-03-14 00:00:00.000' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[UsuarioRoles] ([UsuarioRolId], [UsuarioId], [RolId], [TerceroId], [Estado], [FechaCreacion], [UsuarioCrea], [FechaModifica], [UsuarioModifica]) VALUES (N'd5449d3b-710d-4c55-a0e7-dc9edabf87f4', N'8ac96764-be50-400b-9900-7d813e660c78', N'9640a9fd-7224-44a2-9161-de596487167e', N'167c2ad2-80af-423b-8ccf-908cca2fa2e3', 1, CAST(N'2021-03-13 22:54:02.677' AS DateTime), NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[UsuariosEstado] ON 

GO
INSERT [dbo].[UsuariosEstado] ([UsuarioEstadoId], [DescripcionEstado]) VALUES (1, N'ACTIVO')
GO
INSERT [dbo].[UsuariosEstado] ([UsuarioEstadoId], [DescripcionEstado]) VALUES (2, N'INACTIVO')
GO
INSERT [dbo].[UsuariosEstado] ([UsuarioEstadoId], [DescripcionEstado]) VALUES (3, N'BLOQUEADO')
GO
SET IDENTITY_INSERT [dbo].[UsuariosEstado] OFF
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Terceros]    Script Date: 14/03/2021 1:43:05 ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Terceros]') AND name = N'IX_Terceros')
ALTER TABLE [dbo].[Terceros] ADD  CONSTRAINT [IX_Terceros] UNIQUE NONCLUSTERED 
(
	[TerceroId] ASC,
	[Documento] ASC,
	[TipoTerceroId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Usuario]    Script Date: 14/03/2021 1:43:05 ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Usuario]') AND name = N'IX_Usuario')
ALTER TABLE [dbo].[Usuario] ADD  CONSTRAINT [IX_Usuario] UNIQUE NONCLUSTERED 
(
	[UsuarioNombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Clientes_ClienteId]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Clientes] ADD  CONSTRAINT [DF_Clientes_ClienteId]  DEFAULT (newid()) FOR [ClienteId]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Clientes_FechaCreacion]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Clientes] ADD  CONSTRAINT [DF_Clientes_FechaCreacion]  DEFAULT (getdate()) FOR [FechaCreacion]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Clientes_FechaModifica]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Clientes] ADD  CONSTRAINT [DF_Clientes_FechaModifica]  DEFAULT (getdate()) FOR [FechaModifica]
END

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
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Menu_FechaCreacion]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Menu] ADD  CONSTRAINT [DF_Menu_FechaCreacion]  DEFAULT (getdate()) FOR [FechaCreacion]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Menu_FechaModificacion]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Menu] ADD  CONSTRAINT [DF_Menu_FechaModificacion]  DEFAULT (getdate()) FOR [FechaModificacion]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_MenuRoles_FechaCreacion]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[MenuRoles] ADD  CONSTRAINT [DF_MenuRoles_FechaCreacion]  DEFAULT (getdate()) FOR [FechaCreacion]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_MenuRoles_FechaModifica]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[MenuRoles] ADD  CONSTRAINT [DF_MenuRoles_FechaModifica]  DEFAULT (getdate()) FOR [FechaModifica]
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
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Roles_RolId]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Roles] ADD  CONSTRAINT [DF_Roles_RolId]  DEFAULT (newid()) FOR [RolId]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Roles_EsSuperAdmon]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Roles] ADD  CONSTRAINT [DF_Roles_EsSuperAdmon]  DEFAULT ((0)) FOR [EsSuperAdmon]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Roles_Estado]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Roles] ADD  CONSTRAINT [DF_Roles_Estado]  DEFAULT ((0)) FOR [Estado]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Roles_FechaCreacion]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Roles] ADD  CONSTRAINT [DF_Roles_FechaCreacion]  DEFAULT (getdate()) FOR [FechaCreacion]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Roles_FechaModifica]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Roles] ADD  CONSTRAINT [DF_Roles_FechaModifica]  DEFAULT (getdate()) FOR [FechaModifica]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Terceros_TerceroId]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Terceros] ADD  CONSTRAINT [DF_Terceros_TerceroId]  DEFAULT (newid()) FOR [TerceroId]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Terceros_TipoIdentificacionId]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Terceros] ADD  CONSTRAINT [DF_Terceros_TipoIdentificacionId]  DEFAULT ((5)) FOR [TipoIdentificacionId]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Terceros_TipoTerceroId]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Terceros] ADD  CONSTRAINT [DF_Terceros_TipoTerceroId]  DEFAULT ((2)) FOR [TipoTerceroId]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Terceros_FechaCreacion]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Terceros] ADD  CONSTRAINT [DF_Terceros_FechaCreacion]  DEFAULT (getdate()) FOR [FechaCreacion]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Terceros_FechaModifica]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Terceros] ADD  CONSTRAINT [DF_Terceros_FechaModifica]  DEFAULT (getdate()) FOR [FechaModifica]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Usuario_UsuarioId]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Usuario] ADD  CONSTRAINT [DF_Usuario_UsuarioId]  DEFAULT (newid()) FOR [UsuarioId]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Usuario_UsuarioEstadoId]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Usuario] ADD  CONSTRAINT [DF_Usuario_UsuarioEstadoId]  DEFAULT ((1)) FOR [UsuarioEstadoId]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Usuario_FechaCreacion]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Usuario] ADD  CONSTRAINT [DF_Usuario_FechaCreacion]  DEFAULT (getdate()) FOR [FechaCreacion]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Usuario_FechaModificacion]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Usuario] ADD  CONSTRAINT [DF_Usuario_FechaModificacion]  DEFAULT (getdate()) FOR [FechaModificacion]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Usuario_NumItentos]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Usuario] ADD  CONSTRAINT [DF_Usuario_NumItentos]  DEFAULT ((0)) FOR [NumItentos]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Usuario_FechaUltimoIngreso]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Usuario] ADD  CONSTRAINT [DF_Usuario_FechaUltimoIngreso]  DEFAULT (getdate()) FOR [FechaUltimoIngreso]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Usuario_RestauraClave]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Usuario] ADD  CONSTRAINT [DF_Usuario_RestauraClave]  DEFAULT ((0)) FOR [RestauraClave]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Usuario_LenguajeId]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Usuario] ADD  CONSTRAINT [DF_Usuario_LenguajeId]  DEFAULT ((1)) FOR [LenguajeId]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_UsuarioRoles_UsuarioRolId]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[UsuarioRoles] ADD  CONSTRAINT [DF_UsuarioRoles_UsuarioRolId]  DEFAULT (newid()) FOR [UsuarioRolId]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_UsuarioRoles_Estado]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[UsuarioRoles] ADD  CONSTRAINT [DF_UsuarioRoles_Estado]  DEFAULT ((1)) FOR [Estado]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_UsuarioRoles_FechaCreacion]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[UsuarioRoles] ADD  CONSTRAINT [DF_UsuarioRoles_FechaCreacion]  DEFAULT (getdate()) FOR [FechaCreacion]
END

GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Clientes_TercerosCliente]') AND parent_object_id = OBJECT_ID(N'[dbo].[Clientes]'))
ALTER TABLE [dbo].[Clientes]  WITH CHECK ADD  CONSTRAINT [FK_Clientes_TercerosCliente] FOREIGN KEY([TerceroId])
REFERENCES [dbo].[Terceros] ([TerceroId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Clientes_TercerosCliente]') AND parent_object_id = OBJECT_ID(N'[dbo].[Clientes]'))
ALTER TABLE [dbo].[Clientes] CHECK CONSTRAINT [FK_Clientes_TercerosCliente]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Clientes_TercerosPadre]') AND parent_object_id = OBJECT_ID(N'[dbo].[Clientes]'))
ALTER TABLE [dbo].[Clientes]  WITH CHECK ADD  CONSTRAINT [FK_Clientes_TercerosPadre] FOREIGN KEY([TerceroPadreId])
REFERENCES [dbo].[Terceros] ([TerceroId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Clientes_TercerosPadre]') AND parent_object_id = OBJECT_ID(N'[dbo].[Clientes]'))
ALTER TABLE [dbo].[Clientes] CHECK CONSTRAINT [FK_Clientes_TercerosPadre]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Menu_Menu_MenuPadre]') AND parent_object_id = OBJECT_ID(N'[dbo].[Menu]'))
ALTER TABLE [dbo].[Menu]  WITH CHECK ADD  CONSTRAINT [FK_Menu_Menu_MenuPadre] FOREIGN KEY([MenuPadreId])
REFERENCES [dbo].[Menu] ([MenuId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Menu_Menu_MenuPadre]') AND parent_object_id = OBJECT_ID(N'[dbo].[Menu]'))
ALTER TABLE [dbo].[Menu] CHECK CONSTRAINT [FK_Menu_Menu_MenuPadre]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_MenuRoles_Menu]') AND parent_object_id = OBJECT_ID(N'[dbo].[MenuRoles]'))
ALTER TABLE [dbo].[MenuRoles]  WITH CHECK ADD  CONSTRAINT [FK_MenuRoles_Menu] FOREIGN KEY([MenuId])
REFERENCES [dbo].[Menu] ([MenuId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_MenuRoles_Menu]') AND parent_object_id = OBJECT_ID(N'[dbo].[MenuRoles]'))
ALTER TABLE [dbo].[MenuRoles] CHECK CONSTRAINT [FK_MenuRoles_Menu]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_MenuRoles_Roles]') AND parent_object_id = OBJECT_ID(N'[dbo].[MenuRoles]'))
ALTER TABLE [dbo].[MenuRoles]  WITH CHECK ADD  CONSTRAINT [FK_MenuRoles_Roles] FOREIGN KEY([RolId])
REFERENCES [dbo].[Roles] ([RolId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_MenuRoles_Roles]') AND parent_object_id = OBJECT_ID(N'[dbo].[MenuRoles]'))
ALTER TABLE [dbo].[MenuRoles] CHECK CONSTRAINT [FK_MenuRoles_Roles]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Reservas_TipoIdentificacion]') AND parent_object_id = OBJECT_ID(N'[dbo].[Reservas]'))
ALTER TABLE [dbo].[Reservas]  WITH CHECK ADD  CONSTRAINT [FK_Reservas_TipoIdentificacion] FOREIGN KEY([TipoIdentificacionId])
REFERENCES [dbo].[TipoIdentificacion] ([TipoIdentificacionId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Reservas_TipoIdentificacion]') AND parent_object_id = OBJECT_ID(N'[dbo].[Reservas]'))
ALTER TABLE [dbo].[Reservas] CHECK CONSTRAINT [FK_Reservas_TipoIdentificacion]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Roles_Terceros]') AND parent_object_id = OBJECT_ID(N'[dbo].[Roles]'))
ALTER TABLE [dbo].[Roles]  WITH CHECK ADD  CONSTRAINT [FK_Roles_Terceros] FOREIGN KEY([TerceroId])
REFERENCES [dbo].[Terceros] ([TerceroId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Roles_Terceros]') AND parent_object_id = OBJECT_ID(N'[dbo].[Roles]'))
ALTER TABLE [dbo].[Roles] CHECK CONSTRAINT [FK_Roles_Terceros]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Terceros_TipoTercero]') AND parent_object_id = OBJECT_ID(N'[dbo].[Terceros]'))
ALTER TABLE [dbo].[Terceros]  WITH CHECK ADD  CONSTRAINT [FK_Terceros_TipoTercero] FOREIGN KEY([TipoTerceroId])
REFERENCES [dbo].[TipoTercero] ([TipoTerceroId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Terceros_TipoTercero]') AND parent_object_id = OBJECT_ID(N'[dbo].[Terceros]'))
ALTER TABLE [dbo].[Terceros] CHECK CONSTRAINT [FK_Terceros_TipoTercero]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TraduccionControles_Lenguaje]') AND parent_object_id = OBJECT_ID(N'[dbo].[TraduccionControles]'))
ALTER TABLE [dbo].[TraduccionControles]  WITH CHECK ADD  CONSTRAINT [FK_TraduccionControles_Lenguaje] FOREIGN KEY([LenguajeId])
REFERENCES [dbo].[Lenguaje] ([LenguajeId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TraduccionControles_Lenguaje]') AND parent_object_id = OBJECT_ID(N'[dbo].[TraduccionControles]'))
ALTER TABLE [dbo].[TraduccionControles] CHECK CONSTRAINT [FK_TraduccionControles_Lenguaje]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Usuario_Lenguaje]') AND parent_object_id = OBJECT_ID(N'[dbo].[Usuario]'))
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Lenguaje] FOREIGN KEY([LenguajeId])
REFERENCES [dbo].[Lenguaje] ([LenguajeId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Usuario_Lenguaje]') AND parent_object_id = OBJECT_ID(N'[dbo].[Usuario]'))
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_Lenguaje]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Usuario_UsuariosEstado]') AND parent_object_id = OBJECT_ID(N'[dbo].[Usuario]'))
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_UsuariosEstado] FOREIGN KEY([UsuarioEstadoId])
REFERENCES [dbo].[UsuariosEstado] ([UsuarioEstadoId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Usuario_UsuariosEstado]') AND parent_object_id = OBJECT_ID(N'[dbo].[Usuario]'))
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_UsuariosEstado]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_UsuarioInfo_TipoIdentificacion]') AND parent_object_id = OBJECT_ID(N'[dbo].[UsuarioInfo]'))
ALTER TABLE [dbo].[UsuarioInfo]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioInfo_TipoIdentificacion] FOREIGN KEY([TipoIdentificacionId])
REFERENCES [dbo].[TipoIdentificacion] ([TipoIdentificacionId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_UsuarioInfo_TipoIdentificacion]') AND parent_object_id = OBJECT_ID(N'[dbo].[UsuarioInfo]'))
ALTER TABLE [dbo].[UsuarioInfo] CHECK CONSTRAINT [FK_UsuarioInfo_TipoIdentificacion]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_UsuarioInfo_Usuario]') AND parent_object_id = OBJECT_ID(N'[dbo].[UsuarioInfo]'))
ALTER TABLE [dbo].[UsuarioInfo]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioInfo_Usuario] FOREIGN KEY([UsuarioId])
REFERENCES [dbo].[Usuario] ([UsuarioId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_UsuarioInfo_Usuario]') AND parent_object_id = OBJECT_ID(N'[dbo].[UsuarioInfo]'))
ALTER TABLE [dbo].[UsuarioInfo] CHECK CONSTRAINT [FK_UsuarioInfo_Usuario]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_UsuarioRoles_Roles]') AND parent_object_id = OBJECT_ID(N'[dbo].[UsuarioRoles]'))
ALTER TABLE [dbo].[UsuarioRoles]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioRoles_Roles] FOREIGN KEY([RolId])
REFERENCES [dbo].[Roles] ([RolId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_UsuarioRoles_Roles]') AND parent_object_id = OBJECT_ID(N'[dbo].[UsuarioRoles]'))
ALTER TABLE [dbo].[UsuarioRoles] CHECK CONSTRAINT [FK_UsuarioRoles_Roles]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_UsuarioRoles_Terceros]') AND parent_object_id = OBJECT_ID(N'[dbo].[UsuarioRoles]'))
ALTER TABLE [dbo].[UsuarioRoles]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioRoles_Terceros] FOREIGN KEY([TerceroId])
REFERENCES [dbo].[Terceros] ([TerceroId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_UsuarioRoles_Terceros]') AND parent_object_id = OBJECT_ID(N'[dbo].[UsuarioRoles]'))
ALTER TABLE [dbo].[UsuarioRoles] CHECK CONSTRAINT [FK_UsuarioRoles_Terceros]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_UsuarioRoles_Usuario]') AND parent_object_id = OBJECT_ID(N'[dbo].[UsuarioRoles]'))
ALTER TABLE [dbo].[UsuarioRoles]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioRoles_Usuario] FOREIGN KEY([UsuarioId])
REFERENCES [dbo].[Usuario] ([UsuarioId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_UsuarioRoles_Usuario]') AND parent_object_id = OBJECT_ID(N'[dbo].[UsuarioRoles]'))
ALTER TABLE [dbo].[UsuarioRoles] CHECK CONSTRAINT [FK_UsuarioRoles_Usuario]
GO
/****** Object:  StoredProcedure [dbo].[NetacticaDB_SP_ReservasConsultar]    Script Date: 14/03/2021 1:43:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NetacticaDB_SP_ReservasConsultar]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[NetacticaDB_SP_ReservasConsultar] AS' 
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
ALTER PROCEDURE [dbo].[NetacticaDB_SP_ReservasConsultar] @ReservaId        UNIQUEIDENTIFIER = NULL, 
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
/****** Object:  StoredProcedure [dbo].[NetacticaDB_SP_RolesConsultar]    Script Date: 14/03/2021 1:43:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NetacticaDB_SP_RolesConsultar]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[NetacticaDB_SP_RolesConsultar] AS' 
END
GO
-- ===========================================================================================
-- Author:		JUAN RICARDO DIAZ S
-- Create date: 2021-03-14
-- Description:	CONSULTA LOS ROLES
-- EJEMPLOS:
-- EXEC NetacticaDB_SP_RolesConsultar
-- ===========================================================================================
ALTER PROCEDURE [dbo].[NetacticaDB_SP_RolesConsultar] @RolId       UNIQUEIDENTIFIER = NULL, 
                                              @Descripcion NVARCHAR(50)     = NULL, 
                                              @TerceroId   UNIQUEIDENTIFIER = NULL
AS
    BEGIN
        -- ===========================================================================================
        -- ===========================================================================================
        SELECT r.RolId, 
               r.Descripcion, 
               r.TerceroId, 
               r.EsSuperAdmon, 
               r.Estado, 
               r.FechaCreacion, 
               r.UsuarioCrea, 
               r.FechaModifica, 
               r.UsuarioModifica
        FROM Roles r
        WHERE(r.RolId = @RolId
              OR @RolId IS NULL)
             AND (r.Descripcion LIKE '%' + @Descripcion + '%'
                  OR @Descripcion IS NULL)
             AND (r.TerceroId = @TerceroId
                  OR @TerceroId IS NULL);
        -- ===========================================================================================
    END;

GO
/****** Object:  StoredProcedure [dbo].[NetacticaDB_SP_TercerosConsultar]    Script Date: 14/03/2021 1:43:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NetacticaDB_SP_TercerosConsultar]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[NetacticaDB_SP_TercerosConsultar] AS' 
END
GO
-- =============================================
-- Author:		JUAN RICARDO DIAZ S
-- Create date: 2021-03-13
-- Description:	CONSULTA LOS TERCEROS SEGUN EL TIPO TERCERO Y OTROS FILTROS
-- EJEMPLOS:
-- EXEC NetacticaDB_SP_TercerosConsultar
-- =============================================
ALTER PROCEDURE [dbo].[NetacticaDB_SP_TercerosConsultar] @TerceroId            UNIQUEIDENTIFIER = NULL, 
                                                         @TipoIdentificacionId INT              = NULL, 
                                                         @TipoTerceroId        INT              = NULL, 
                                                         @Documento            NVARCHAR(50)     = NULL, 
                                                         @RazonSocial          NVARCHAR(100)    = NULL, 
                                                         @NombreComercial      NVARCHAR(100)    = NULL
AS
    BEGIN
        SELECT t.TerceroId, 
               t.TipoIdentificacionId, 
               t.TipoTerceroId, 
               t.Documento, 
               t.RazonSocial, 
               t.NombreComercial, 
               t.FechaCreacion, 
               t.UsuarioCrea, 
               t.FechaModifica, 
               t.UsuarioModifica, 
               split = NULL, 
               ti.TipoIdentificacionId, 
               ti.Descripcion, 
               ti.Alias, 
               split = NULL, 
               tt.TipoTerceroId, 
               tt.Descripcion
        FROM Terceros t
             JOIN TipoTercero tt ON t.TipoTerceroId = tt.TipoTerceroId
             LEFT JOIN TipoIdentificacion ti ON TI.TipoIdentificacionId = t.TipoIdentificacionId
        WHERE(T.TerceroId = @TerceroId
              OR @TerceroId IS NULL)
             AND (T.TipoIdentificacionId = @TipoIdentificacionId
                  OR @TipoIdentificacionId IS NULL)
             AND (T.TipoTerceroId = @TipoTerceroId
                  OR @TipoTerceroId IS NULL)
             AND (T.Documento LIKE '%' + @Documento + '%'
                  OR @Documento IS NULL)
             AND (T.RazonSocial LIKE '%' + @RazonSocial + '%'
                  OR @RazonSocial IS NULL)
             AND (T.NombreComercial LIKE '%' + @NombreComercial + '%'
                  OR @NombreComercial IS NULL);
    END;
GO
/****** Object:  StoredProcedure [dbo].[NetacticaDB_SP_TercerosRolesPorUsuario]    Script Date: 14/03/2021 1:43:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NetacticaDB_SP_TercerosRolesPorUsuario]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[NetacticaDB_SP_TercerosRolesPorUsuario] AS' 
END
GO
-- =============================================
-- Author:		JUAN RICARDO DIAZ S
-- Create date: 2021-03-13
-- Description:	CONSULTA LOS TERCEROS SEGUN LOS ROLES DE UN USUARIO
-- EJEMPLOS:
-- EXEC NetacticaDB_SP_TercerosRolesPorUsuario @UsuarioId='8AC96764-BE50-400B-9900-7D813E660C78'
-- =============================================
ALTER PROCEDURE [dbo].[NetacticaDB_SP_TercerosRolesPorUsuario] @UsuarioId UNIQUEIDENTIFIER, 
                                                               @Estado    BIT              = NULL
AS
    BEGIN
        SELECT t.TerceroId, 
               t.TipoIdentificacionId, 
               t.TipoTerceroId, 
               t.Documento, 
               t.RazonSocial, 
               t.NombreComercial, 
               t.FechaCreacion, 
               t.UsuarioCrea, 
               t.FechaModifica, 
               t.UsuarioModifica, 
               split = NULL, 
               tt.TipoTerceroId, 
               tt.Descripcion, 
               split = NULL, 
               ti.TipoIdentificacionId, 
               ti.Descripcion, 
               ti.Alias
        FROM UsuarioRoles ur
             JOIN Terceros t ON ur.TerceroId = t.TerceroId
             JOIN TipoTercero tt ON t.TipoTerceroId = tt.TipoTerceroId
             LEFT JOIN TipoIdentificacion ti ON t.TipoIdentificacionId = ti.TipoIdentificacionId
        WHERE ur.UsuarioId = @UsuarioId
              AND (ur.Estado = @Estado
                   OR @Estado IS NULL);
    END;
GO
/****** Object:  StoredProcedure [dbo].[NetacticaDB_SP_Usuario_Insertar]    Script Date: 14/03/2021 1:43:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NetacticaDB_SP_Usuario_Insertar]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[NetacticaDB_SP_Usuario_Insertar] AS' 
END
GO
-- ======================================================================================================================
-- Author:		JUAN RICARDO DIAZ
-- Create date: 2021-02-02 19:49
-- Description:	INSERTA UN NUEVO USUARIO EN LA BASE DE DATOS CON SU INFO COMPLEMENTARIA
-- ======================================================================================================================
ALTER PROCEDURE [dbo].[NetacticaDB_SP_Usuario_Insertar] @UsuarioId     UNIQUEIDENTIFIER = NULL OUTPUT, 
                                                @UsuarioNombre NVARCHAR(100)    = NULL, 
                                                @UsuarioCorreo NVARCHAR(200)    = NULL, 
                                                @UsuarioCrea   UNIQUEIDENTIFIER = NULL, 
                                                @Pw            NVARCHAR(500)    = NULL, 
                                                @LenguajeId    INT              = NULL
AS
    BEGIN
        -- ======================================================================================================================
        DECLARE @ACTIVO INT= 1, @CEDULA INT = 1;
        -- ======================================================================================================================
        IF @UsuarioId IS NULL
           OR @UsuarioId = '00000000-0000-0000-0000-000000000000'
            BEGIN
                SELECT @UsuarioId = NEWID();
            END;
        -- ======================================================================================================================
        INSERT INTO Usuario
        (UsuarioId, 
         UsuarioNombre, 
         UsuarioCorreo, 
         UsuarioEstadoId, 
         FechaCreacion, 
         UsuarioCrea, 
         NumItentos, 
         Pw, 
         RestauraClave, 
         LenguajeId
        )
        VALUES
        (@UsuarioId, -- UsuarioId - uniqueidentifier
         @UsuarioNombre, -- UsuarioNombre - nvarchar
         @UsuarioCorreo, -- UsuarioCorreo - nvarchar
         @ACTIVO, -- UsuarioEstadoId - int
         GETDATE(), -- FechaCreacion - datetime
         @UsuarioCrea, -- UsuarioCrea - uniqueidentifier
         0, -- NumItentos - int
         @Pw, -- Pw - nvarchar
         0, -- RestauraClave - bit
         @LenguajeId -- LenguajeId - int
        );
        -- INSERTA VACIO EN LA INFO COMPLEMENTARIA DEL USUARIO
        INSERT INTO UsuarioInfo
        (UsuarioId, 
         TipoIdentificacionId, 
         Documento, 
         Nombres, 
         Apellidos, 
         CorreoAlternativo, 
         Telefono, 
         Direccion, 
         FechaNacimiento, 
         FechaCreacion, 
         UsuarioCrea
        )
        VALUES
        (@UsuarioId, -- UsuarioId - uniqueidentifier
         @CEDULA, -- TipoIdentificacionId - int
         N'', -- Documento - nvarchar
         N'', -- Nombres - nvarchar
         N'', -- Apellidos - nvarchar
         N'', -- CorreoAlternativo - nvarchar
         N'', -- Telefono - nvarchar
         N'', -- Direccion - nvarchar
         NULL, -- FechaNacimiento - date
         GETDATE(), -- FechaCreacion - datetime
         @UsuarioCrea -- UsuarioCrea - uniqueidentifier

        );
        -- ======================================================================================================================
    END;

GO
/****** Object:  StoredProcedure [dbo].[NetacticaDB_SP_UsuarioConsultar]    Script Date: 14/03/2021 1:43:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NetacticaDB_SP_UsuarioConsultar]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[NetacticaDB_SP_UsuarioConsultar] AS' 
END
GO
--=======================================================================================================
-- Author:		JUAN RICARDO DIAZ SUANCHA
-- Create date: 2021-02-14
-- Description:	CONSULTA LOS USUARIOS
-- EJMPLOS:
-- EXEC NetacticaDB_SP_UsuarioConsultar --all
--=======================================================================================================
ALTER PROCEDURE [dbo].[NetacticaDB_SP_UsuarioConsultar] @UsuarioId     UNIQUEIDENTIFIER = NULL, 
                                                 @UsuarioNombre NVARCHAR(100)    = NULL
AS
    BEGIN
        --=======================================================================================================
        SELECT u.UsuarioId, 
               u.UsuarioNombre, 
               u.UsuarioCorreo, 
               u.UsuarioEstadoId, 
               u.FechaCreacion, 
               u.UsuarioCrea, 
               u.FechaModificacion, 
               u.UsuarioModifica, 
               u.NumItentos, 
               u.Pw, 
               u.FechaUltimoIngreso, 
               u.RestauraClave, 
               u.LenguajeId, 
               split = NULL, 
               ue.UsuarioEstadoId, 
               ue.DescripcionEstado, 
               split = NULL, 
               l.LenguajeId, 
               l.Descripcion, 
               l.Codigo, 
               l.CodigoHtml
        FROM Usuario u
             JOIN UsuariosEstado ue ON u.UsuarioEstadoId = ue.UsuarioEstadoId
             JOIN Lenguaje l ON u.LenguajeId = l.LenguajeId
        WHERE(u.UsuarioId = @UsuarioId
              OR @UsuarioId IS NULL)
             AND (u.UsuarioNombre = @UsuarioNombre
                  OR @UsuarioNombre IS NULL);
        --=======================================================================================================
    END;

GO
/****** Object:  StoredProcedure [dbo].[NetacticaDB_SP_UsuarioInfoPorId]    Script Date: 14/03/2021 1:43:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NetacticaDB_SP_UsuarioInfoPorId]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[NetacticaDB_SP_UsuarioInfoPorId] AS' 
END
GO
-- =============================================
-- Author:		JUAN RICARDO DIAZ S
-- Create date: 2021-03-13
-- Description:	CONSULTA LA INFORMACION COMPLEMTARIA POR ID DE USUAIRO
-- =============================================
ALTER PROCEDURE [dbo].[NetacticaDB_SP_UsuarioInfoPorId] @UsuarioId UNIQUEIDENTIFIER
AS
    BEGIN
        SELECT ui.UsuarioId, 
               ui.TipoIdentificacionId, 
               ui.Documento, 
               ui.Nombres, 
               ui.Apellidos, 
               ui.CorreoAlternativo, 
               ui.Telefono, 
               ui.Direccion, 
               ui.FechaNacimiento, 
               ui.FechaCreacion, 
               ui.UsuarioCrea, 
               ui.FechaModificacion, 
               ui.UsuarioModifica, 
               split = NULL, 
               ti.TipoIdentificacionId, 
               ti.Descripcion, 
               ti.Alias
        FROM UsuarioInfo ui
             JOIN TipoIdentificacion ti ON ui.TipoIdentificacionId = ti.TipoIdentificacionId
        WHERE UI.UsuarioId = @UsuarioId;
    END;

GO
/****** Object:  StoredProcedure [dbo].[NetacticaDB_SP_UsuariosConsultar_Admon]    Script Date: 14/03/2021 1:43:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NetacticaDB_SP_UsuariosConsultar_Admon]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[NetacticaDB_SP_UsuariosConsultar_Admon] AS' 
END
GO
-- ==================================================================================================================
-- Author:		JUAN RICARDO DIAZ 
-- Create date: 2021-03-13
-- Description:	CONSULTA LOS USUARIOS PARA UN USUARIO SUPER ADMINISTRADOR
-- EJEMPLOS:
-- EXEC NetacticaDB_SP_UsuariosConsultar_Admon
-- EXEC NetacticaDB_SP_UsuariosConsultar_Admon @TerceroId = NULL
-- EXEC NetacticaDB_SP_UsuariosConsultar_Admon @TerceroId = '00000000-0000-0000-0000-000000000000'
-- EXEC NetacticaDB_SP_UsuariosConsultar_Admon @TerceroId = '167c2ad2-80af-423b-8ccf-908cca2fa2e3'
-- ==================================================================================================================
ALTER PROCEDURE [dbo].[NetacticaDB_SP_UsuariosConsultar_Admon] @UsuarioNombre   NVARCHAR(100)    = NULL, 
                                                               @UsuarioEstadoId INT              = NULL, 
                                                               @Documento       NVARCHAR(50)     = NULL, 
                                                               @NombreCompleto  NVARCHAR(500)    = NULL, 
                                                               @TerceroId       UNIQUEIDENTIFIER = NULL, 
                                                               @UsuarioId       UNIQUEIDENTIFIER = NULL
AS
    BEGIN
        -- ==================================================================================================================
        DECLARE @ACTIVOS BIT= 1;
        -- ==================================================================================================================
        SELECT u.UsuarioId, 
               u.UsuarioNombre, 
               ui.Documento, 
               NombreCompleto = CONCAT(ui.Nombres, ' ', ui.Apellidos), 
               u.UsuarioCorreo, 
               u.NumItentos, 
               u.FechaUltimoIngreso, 
               Clientes = NULL, 
               Roles = NULL, 
               Estado = ue.DescripcionEstado
        FROM Usuario u
             JOIN UsuariosEstado ue ON u.UsuarioEstadoId = ue.UsuarioEstadoId
             LEFT JOIN UsuarioInfo ui ON u.UsuarioId = ui.UsuarioId
        WHERE(u.UsuarioNombre LIKE '%' + @UsuarioNombre + '%'
              OR @UsuarioNombre IS NULL)
             AND (u.UsuarioEstadoId = @UsuarioEstadoId
                  OR @UsuarioEstadoId IS NULL)
             AND (ui.Documento LIKE '%' + @Documento + '%'
                  OR @Documento IS NULL)
             AND ((REPLACE(CONCAT(ui.Nombres, ui.Apellidos), ' ', '')) LIKE '%' + REPLACE(@NombreCompleto, ' ', '') + '%'
                  OR @NombreCompleto IS NULL)
             AND (u.UsuarioId <> @UsuarioId
                  OR @UsuarioId IS NULL)
             AND NOT EXISTS
        (
            SELECT TOP 1 1
            FROM UsuarioRoles ur
            WHERE UR.UsuarioId = U.UsuarioId
        )
             AND @TerceroId IS NULL
        UNION
        SELECT u.UsuarioId, 
               u.UsuarioNombre, 
               ui.Documento, 
               NombreCompleto = CONCAT(ui.Nombres, ' ', ui.Apellidos), 
               u.UsuarioCorreo, 
               u.NumItentos, 
               u.FechaUltimoIngreso, 
               Clientes = STUFF(
        (
            SELECT ',' + t.NombreComercial
            FROM UsuarioRoles ur
                 JOIN Terceros t ON T.TerceroId = ur.TerceroId
            WHERE ur.UsuarioId = u.UsuarioId
                  AND ur.Estado = @ACTIVOS FOR XML PATH('')
        ), 1, 1, ''), 
               Roles = STUFF(
        (
            SELECT ',' + r.Descripcion
            FROM UsuarioRoles ur
                 JOIN Roles r ON ur.RolId = r.RolId
            WHERE ur.UsuarioId = u.UsuarioId
                  AND ur.Estado = @ACTIVOS FOR XML PATH('')
        ), 1, 1, ''), 
               Estado = ue.DescripcionEstado
        FROM Usuario u
             JOIN UsuariosEstado ue ON u.UsuarioEstadoId = ue.UsuarioEstadoId
             LEFT JOIN UsuarioInfo ui ON u.UsuarioId = ui.UsuarioId
        WHERE(u.UsuarioNombre LIKE '%' + @UsuarioNombre + '%'
              OR @UsuarioNombre IS NULL)
             AND (u.UsuarioEstadoId = @UsuarioEstadoId
                  OR @UsuarioEstadoId IS NULL)
             AND (ui.Documento LIKE '%' + @Documento + '%'
                  OR @Documento IS NULL)
             AND ((REPLACE(CONCAT(ui.Nombres, ui.Apellidos), ' ', '')) LIKE '%' + REPLACE(@NombreCompleto, ' ', '') + '%'
                  OR @NombreCompleto IS NULL)
             AND (u.UsuarioId <> @UsuarioId
                  OR @UsuarioId IS NULL)
             AND EXISTS
        (
            SELECT TOP 1 1
            FROM UsuarioRoles ur
            WHERE UR.UsuarioId = U.UsuarioId
                  AND (ur.TerceroId = @TerceroId
                       OR @TerceroId IS NULL)
        );
    END;
GO
/****** Object:  StoredProcedure [dbo].[NetacticaDB_SP_UsuariosConsultar_NoAdmon]    Script Date: 14/03/2021 1:43:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NetacticaDB_SP_UsuariosConsultar_NoAdmon]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[NetacticaDB_SP_UsuariosConsultar_NoAdmon] AS' 
END
GO
-- ==================================================================================================================
-- Author:		JUAN RICARDO DIAZ 
-- Create date: 2021-03-13
-- Description:	CONSULTA LOS USUARIOS PARA UN USUARIO  ADMINISTRADOR CLIENTE
-- EJEMPLOS:
-- EXEC NetacticaDB_SP_UsuariosConsultar_NoAdmon @TerceroId = '167c2ad2-80af-423b-8ccf-908cca2fa2e3'
-- ==================================================================================================================
ALTER PROCEDURE [dbo].[NetacticaDB_SP_UsuariosConsultar_NoAdmon] @UsuarioNombre   NVARCHAR(100)    = NULL, 
                                                                 @UsuarioEstadoId INT              = NULL, 
                                                                 @Documento       NVARCHAR(50)     = NULL, 
                                                                 @NombreCompleto  NVARCHAR(500)    = NULL, 
                                                                 @TerceroId       UNIQUEIDENTIFIER, 
                                                                 @UsuarioId       UNIQUEIDENTIFIER = NULL
AS
    BEGIN
        -- ==================================================================================================================
        DECLARE @ACTIVOS BIT= 1;
        -- ==================================================================================================================
        SELECT u.UsuarioId, 
               u.UsuarioNombre, 
               ui.Documento, 
               NombreCompleto = CONCAT(ui.Nombres, ' ', ui.Apellidos), 
               u.UsuarioCorreo, 
               u.NumItentos, 
               u.FechaUltimoIngreso, 
               Clientes = NULL, 
               Roles = NULL, 
               Estado = ue.DescripcionEstado
        FROM Usuario u
             JOIN UsuariosEstado ue ON u.UsuarioEstadoId = ue.UsuarioEstadoId
             LEFT JOIN UsuarioInfo ui ON u.UsuarioId = ui.UsuarioId
        WHERE(u.UsuarioNombre LIKE '%' + @UsuarioNombre + '%'
              OR @UsuarioNombre IS NULL)
             AND (u.UsuarioEstadoId = @UsuarioEstadoId
                  OR @UsuarioEstadoId IS NULL)
             AND (ui.Documento LIKE '%' + @Documento + '%'
                  OR @Documento IS NULL)
             AND ((REPLACE(CONCAT(ui.Nombres, ui.Apellidos), ' ', '')) LIKE '%' + REPLACE(@NombreCompleto, ' ', '') + '%'
                  OR @NombreCompleto IS NULL)
             AND (u.UsuarioId <> @UsuarioId
                  OR @UsuarioId IS NULL)
             AND u.UsuarioCrea = @UsuarioId
             AND @TerceroId IS NULL
             AND NOT EXISTS
        (
            SELECT TOP 1 1
            FROM UsuarioRoles ur
            WHERE UR.UsuarioId = U.UsuarioId
        )
        UNION
        SELECT u.UsuarioId, 
               u.UsuarioNombre, 
               ui.Documento, 
               NombreCompleto = CONCAT(ui.Nombres, ' ', ui.Apellidos), 
               u.UsuarioCorreo, 
               u.NumItentos, 
               u.FechaUltimoIngreso, 
               Clientes = STUFF(
        (
            SELECT ',' + t.NombreComercial
            FROM UsuarioRoles ur
                 JOIN Terceros t ON T.TerceroId = ur.TerceroId
            WHERE ur.UsuarioId = u.UsuarioId
                  AND ur.Estado = @ACTIVOS FOR XML PATH('')
        ), 1, 1, ''), 
               Roles = STUFF(
        (
            SELECT ',' + r.Descripcion
            FROM UsuarioRoles ur
                 JOIN Roles r ON ur.RolId = r.RolId
            WHERE ur.UsuarioId = u.UsuarioId
                  AND ur.Estado = @ACTIVOS FOR XML PATH('')
        ), 1, 1, ''), 
               Estado = ue.DescripcionEstado
        FROM Usuario u
             JOIN UsuariosEstado ue ON u.UsuarioEstadoId = ue.UsuarioEstadoId
             LEFT JOIN UsuarioInfo ui ON u.UsuarioId = ui.UsuarioId
        WHERE(u.UsuarioNombre LIKE '%' + @UsuarioNombre + '%'
              OR @UsuarioNombre IS NULL)
             AND (u.UsuarioEstadoId = @UsuarioEstadoId
                  OR @UsuarioEstadoId IS NULL)
             AND (ui.Documento LIKE '%' + @Documento + '%'
                  OR @Documento IS NULL)
             AND ((REPLACE(CONCAT(ui.Nombres, ui.Apellidos), ' ', '')) LIKE '%' + REPLACE(@NombreCompleto, ' ', '') + '%'
                  OR @NombreCompleto IS NULL)
             AND (u.UsuarioId <> @UsuarioId
                  OR @UsuarioId IS NULL)
             AND EXISTS
        (
            SELECT TOP 1 1
            FROM UsuarioRoles ur
            WHERE UR.UsuarioId = U.UsuarioId
                  AND (ur.TerceroId = @TerceroId)
        );
    END;
GO
/****** Object:  StoredProcedure [dbo].[NetaticaDB_SP_CreateClass]    Script Date: 14/03/2021 1:43:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NetaticaDB_SP_CreateClass]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[NetaticaDB_SP_CreateClass] AS' 
END
GO
-- ===================================================================================
-- Author:		JUAN RICARDO DIAZ
-- Create date: 2021-02-02 20:18
-- Description:	CREA LAS PROPIEDADES DE UNA CLASE A PARTIR DE UNA TABLA
-- EJEMPLOS:
-- EXEC NetaticaDB_SP_CreateClass 'Lenguaje'
-- ===================================================================================
ALTER PROCEDURE [dbo].[NetaticaDB_SP_CreateClass] @TableName NVARCHAR(50)
AS
    BEGIN
        -- ===================================================================================
        DECLARE @Result VARCHAR(MAX)= 'public class ' + @TableName + '
{';

        -- ===================================================================================
        SELECT @Result = @Result + '
    public ' + ColumnType + NullableSign + ' ' + ColumnName + ' { get; set; }
'
        FROM
        (
            SELECT replace(col.name, ' ', '_') ColumnName, 
                   column_id ColumnId,
                   CASE typ.name
                       WHEN 'bigint'
                       THEN 'long'
                       WHEN 'binary'
                       THEN 'byte[]'
                       WHEN 'bit'
                       THEN 'bool'
                       WHEN 'char'
                       THEN 'string'
                       WHEN 'date'
                       THEN 'DateTime'
                       WHEN 'datetime'
                       THEN 'DateTime'
                       WHEN 'datetime2'
                       THEN 'DateTime'
                       WHEN 'datetimeoffset'
                       THEN 'DateTimeOffset'
                       WHEN 'decimal'
                       THEN 'decimal'
                       WHEN 'float'
                       THEN 'double'
                       WHEN 'image'
                       THEN 'byte[]'
                       WHEN 'int'
                       THEN 'int'
                       WHEN 'money'
                       THEN 'decimal'
                       WHEN 'nchar'
                       THEN 'string'
                       WHEN 'ntext'
                       THEN 'string'
                       WHEN 'numeric'
                       THEN 'decimal'
                       WHEN 'nvarchar'
                       THEN 'string'
                       WHEN 'real'
                       THEN 'float'
                       WHEN 'smalldatetime'
                       THEN 'DateTime'
                       WHEN 'smallint'
                       THEN 'short'
                       WHEN 'smallmoney'
                       THEN 'decimal'
                       WHEN 'text'
                       THEN 'string'
                       WHEN 'time'
                       THEN 'TimeSpan'
                       WHEN 'timestamp'
                       THEN 'long'
                       WHEN 'tinyint'
                       THEN 'byte'
                       WHEN 'uniqueidentifier'
                       THEN 'Guid'
                       WHEN 'varbinary'
                       THEN 'byte[]'
                       WHEN 'varchar'
                       THEN 'string'
                       ELSE 'UNKNOWN_' + typ.name
                   END ColumnType,
                   CASE
                       WHEN col.is_nullable = 1
                            AND typ.name IN('bigint', 'bit', 'date', 'datetime', 'datetime2', 'datetimeoffset', 'decimal', 'float', 'int', 'money', 'numeric', 'real', 'smalldatetime', 'smallint', 'smallmoney', 'time', 'tinyint', 'uniqueidentifier')
                       THEN '?'
                       ELSE ''
                   END NullableSign
            FROM sys.columns col
                 JOIN sys.types typ ON col.system_type_id = typ.system_type_id
                                       AND col.user_type_id = typ.user_type_id
            WHERE object_id = OBJECT_ID(@TableName)
        ) t
        ORDER BY ColumnId;
        SET @Result = @Result + '
}';
        -- ===================================================================================
        PRINT @Result;
        -- ===================================================================================
    END;

GO
