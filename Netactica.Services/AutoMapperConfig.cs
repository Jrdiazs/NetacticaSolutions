using AutoMapper;
using Netactica.Models;
using Netactica.Services.Request;
using Netactica.Services.Response;

namespace Netactica.Services
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize((config) =>
            {
                MappingUserResponse(config);
                MappingUserInfoResponse(config);
                MappingUsersStateResponse(config);
                MappingUsersSearchRequest(config);
                MappingUserListResponse(config);
                MappingRolesResponse(config);
                MappingRoleFilterRequest(config);
            });
        }

        public static void MappingUserResponse(IMapperConfigurationExpression config)
        {
            config.CreateMap<Usuario, UsuarioResponse>().
                ForMember(x => x.Correo, o => o.MapFrom(s => s.UsuarioCorreo)).
                ForMember(x => x.EstadoDescripcion, o => o.MapFrom(s => s.UsuariosEstado != null ? s.UsuariosEstado.DescripcionEstado : string.Empty)).
                ForMember(x => x.EstadoId, o => o.MapFrom(s => s.UsuarioEstadoId)).
                ForMember(x => x.FechaCreacion, o => o.MapFrom(s => s.FechaCreacion)).
                ForMember(x => x.LenguajeId, o => o.MapFrom(s => s.LenguajeId)).
                ForMember(x => x.FechaModificacion, o => o.MapFrom(s => s.FechaModificacion)).
                ForMember(x => x.Id, o => o.MapFrom(s => s.UsuarioId)).
                ForMember(x => x.LenguajeCodigo, o => o.MapFrom(s => s.Lenguaje != null ? s.Lenguaje.Codigo : string.Empty)).
                ForMember(x => x.Nombre, o => o.MapFrom(s => s.UsuarioNombre)).
                ForMember(x => x.NumItentos, o => o.MapFrom(s => s.NumItentos)).
                ForMember(x => x.RestauraClave, o => o.MapFrom(s => s.RestauraClave)).
                ForMember(x => x.UsuarioCrea, o => o.MapFrom(s => s.UsuarioCrea)).
                ForMember(x => x.Password, o => o.MapFrom(s => s.Pw)).
                ForMember(x => x.PasswordConfirm, o => o.Ignore()).
                ForMember(x => x.UsuarioModifica, o => o.MapFrom(s => s.UsuarioModifica));

            config.CreateMap<UsuarioResponse, Usuario>().
                ForMember(x => x.Lenguaje, o => o.Ignore()).
                ForMember(x => x.UsuariosEstado, o => o.Ignore()).
                ForMember(x => x.UsuarioCorreo, o => o.MapFrom(s => s.Correo)).
                ForMember(x => x.UsuarioEstadoId, o => o.MapFrom(s => s.EstadoId)).
                ForMember(x => x.FechaCreacion, o => o.MapFrom(s => s.FechaCreacion)).
                ForMember(x => x.LenguajeId, o => o.MapFrom(s => s.LenguajeId)).
                ForMember(x => x.FechaModificacion, o => o.MapFrom(s => s.FechaModificacion)).
                ForMember(x => x.UsuarioId, o => o.MapFrom(s => s.Id)).
                ForMember(x => x.UsuarioNombre, o => o.MapFrom(s => s.Nombre)).
                ForMember(x => x.NumItentos, o => o.MapFrom(s => s.NumItentos)).
                ForMember(x => x.RestauraClave, o => o.MapFrom(s => s.RestauraClave)).
                ForMember(x => x.UsuarioCrea, o => o.MapFrom(s => s.UsuarioCrea)).
                ForMember(x => x.Pw, o => o.MapFrom(s => s.Password)).
                ForMember(x => x.UsuarioModifica, o => o.MapFrom(s => s.UsuarioModifica));
        }

        public static void MappingUserInfoResponse(IMapperConfigurationExpression config)
        {
            config.CreateMap<UsuarioInfo, UsuarioInfoResponse>().
               ForMember(x => x.Apellidos, o => o.MapFrom(s => s.Apellidos)).
               ForMember(x => x.CorreoAlternativo, o => o.MapFrom(s => s.CorreoAlternativo)).
               ForMember(x => x.Direccion, o => o.MapFrom(s => s.Direccion)).
               ForMember(x => x.FechaCreacion, o => o.MapFrom(s => s.FechaCreacion)).
               ForMember(x => x.FechaModificacion, o => o.MapFrom(s => s.FechaModificacion)).
               ForMember(x => x.FechaNacimiento, o => o.MapFrom(s => s.FechaNacimiento)).
               ForMember(x => x.Id, o => o.MapFrom(s => s.UsuarioId)).
               ForMember(x => x.Nombres, o => o.MapFrom(s => s.Nombres)).
               ForMember(x => x.NumeroDocumento, o => o.MapFrom(s => s.Documento)).
               ForMember(x => x.Telefono, o => o.MapFrom(s => s.Telefono)).
               ForMember(x => x.TipoIdentificacion, o => o.MapFrom(s => s.TipoIdentificacion != null ? s.TipoIdentificacion.Alias : string.Empty)).
               ForMember(x => x.TipoIdentificacionId, o => o.MapFrom(s => s.TipoIdentificacionId)).
               ForMember(x => x.UsuarioCrea, o => o.MapFrom(s => s.UsuarioCrea)).
               ForMember(x => x.UsuarioModifica, o => o.MapFrom(s => s.UsuarioModifica));

            config.CreateMap<UsuarioInfoResponse, UsuarioInfo>().
               ForMember(x => x.Apellidos, o => o.MapFrom(s => s.Apellidos)).
               ForMember(x => x.CorreoAlternativo, o => o.MapFrom(s => s.CorreoAlternativo)).
               ForMember(x => x.Direccion, o => o.MapFrom(s => s.Direccion)).
               ForMember(x => x.FechaCreacion, o => o.MapFrom(s => s.FechaCreacion)).
               ForMember(x => x.FechaModificacion, o => o.MapFrom(s => s.FechaModificacion)).
               ForMember(x => x.FechaNacimiento, o => o.MapFrom(s => s.FechaNacimiento)).
               ForMember(x => x.UsuarioId, o => o.MapFrom(s => s.Id)).
               ForMember(x => x.Nombres, o => o.MapFrom(s => s.Nombres)).
               ForMember(x => x.Documento, o => o.MapFrom(s => s.NumeroDocumento)).
               ForMember(x => x.Telefono, o => o.MapFrom(s => s.Telefono)).
               ForMember(x => x.TipoIdentificacion, o => o.Ignore()).
               ForMember(x => x.Usuario, o => o.Ignore()).
               ForMember(x => x.TipoIdentificacionId, o => o.MapFrom(s => s.TipoIdentificacionId)).
               ForMember(x => x.UsuarioCrea, o => o.MapFrom(s => s.UsuarioCrea)).
               ForMember(x => x.UsuarioModifica, o => o.MapFrom(s => s.UsuarioModifica));
        }

        public static void MappingUsersStateResponse(IMapperConfigurationExpression config)
        {
            config.CreateMap<UsuariosEstado, DropDownItem>().
               ForMember(x => x.Descripcion, o => o.MapFrom(s => s.DescripcionEstado)).
               ForMember(x => x.Alias, o => o.MapFrom(s => s.Alias)).
               ForMember(x => x.Id, o => o.MapFrom(s => s.UsuarioEstadoId));

            config.CreateMap<DropDownItem, UsuariosEstado>().
               ForMember(x => x.UsuarioEstadoId, o => o.MapFrom(s => s.Id)).
               ForMember(x => x.Alias, o => o.MapFrom(s => s.Alias)).
               ForMember(x => x.DescripcionEstado, o => o.MapFrom(s => s.Descripcion));
        }

        public static void MappingUsersSearchRequest(IMapperConfigurationExpression config)
        {
            config.CreateMap<UsuariosFiltroRequest, UsuarioFiltro>().
               ForMember(x => x.Estado, o => o.MapFrom(s => s.EstadoId)).
               ForMember(x => x.Identificacion, o => o.MapFrom(s => s.Documento)).
               ForMember(x => x.NameUser, o => o.MapFrom(s => s.Nombre)).
               ForMember(x => x.NombresCompletos, o => o.MapFrom(s => s.NombresCompletos)).
               ForMember(x => x.Rol, o => o.MapFrom(s => s.RolId)).
               ForMember(x => x.Tercero, o => o.MapFrom(s => s.Tercero)).
               ForMember(x => x.Usuario, o => o.MapFrom(s => s.Usuario))
               ;

            config.CreateMap<UsuarioFiltro, UsuariosFiltroRequest>().
                ForMember(x => x.EstadoId, o => o.MapFrom(s => s.Estado)).
                ForMember(x => x.Documento, o => o.MapFrom(s => s.Identificacion)).
                ForMember(x => x.Nombre, o => o.MapFrom(s => s.NameUser)).
                ForMember(x => x.NombresCompletos, o => o.MapFrom(s => s.NombresCompletos)).
                ForMember(x => x.RolId, o => o.MapFrom(s => s.Rol)).
                ForMember(x => x.Tercero, o => o.MapFrom(s => s.Tercero)).
                ForMember(x => x.Usuario, o => o.MapFrom(s => s.Usuario));
        }

        public static void MappingUserListResponse(IMapperConfigurationExpression config)
        {
            config.CreateMap<UsuariosListadoResponse, UsuariosListado>().
               ForMember(x => x.Clientes, o => o.MapFrom(s => s.Clientes)).
               ForMember(x => x.Documento, o => o.MapFrom(s => s.Documento)).
               ForMember(x => x.Estado, o => o.MapFrom(s => s.Estado)).
               ForMember(x => x.FechaUltimoIngreso, o => o.MapFrom(s => s.FechaUltimoIngreso)).
               ForMember(x => x.NombreCompleto, o => o.MapFrom(s => s.NombreCompleto)).
               ForMember(x => x.NumItentos, o => o.MapFrom(s => s.NumItentos)).
               ForMember(x => x.Roles, o => o.MapFrom(s => s.Roles)).
               ForMember(x => x.UsuarioCorreo, o => o.MapFrom(s => s.UsuarioCorreo)).
               ForMember(x => x.UsuarioId, o => o.MapFrom(s => s.UsuarioId)).
               ForMember(x => x.UsuarioNombre, o => o.MapFrom(s => s.UsuarioNombre))
               ;

            config.CreateMap<UsuariosListado, UsuariosListadoResponse>().
               ForMember(x => x.Clientes, o => o.MapFrom(s => s.Clientes)).
               ForMember(x => x.Documento, o => o.MapFrom(s => s.Documento)).
               ForMember(x => x.Estado, o => o.MapFrom(s => s.Estado)).
               ForMember(x => x.FechaUltimoIngreso, o => o.MapFrom(s => s.FechaUltimoIngreso)).
               ForMember(x => x.NombreCompleto, o => o.MapFrom(s => s.NombreCompleto)).
               ForMember(x => x.NumItentos, o => o.MapFrom(s => s.NumItentos)).
               ForMember(x => x.Roles, o => o.MapFrom(s => s.Roles)).
               ForMember(x => x.UsuarioCorreo, o => o.MapFrom(s => s.UsuarioCorreo)).
               ForMember(x => x.UsuarioId, o => o.MapFrom(s => s.UsuarioId)).
               ForMember(x => x.UsuarioNombre, o => o.MapFrom(s => s.UsuarioNombre));
        }

        public static void MappingRolesResponse(IMapperConfigurationExpression config)
        {
            config.CreateMap<RolesResponse, Roles>().
               ForMember(x => x.Descripcion, o => o.MapFrom(s => s.Nombre)).
               ForMember(x => x.RolIdCreate, o => o.MapFrom(s => s.RolIdCreateRol)).
               ForMember(x => x.EsSuperAdmon, o => o.MapFrom(s => s.EsSuperAdmon)).
               ForMember(x => x.Estado, o => o.MapFrom(s => s.Estado)).
               ForMember(x => x.FechaCreacion, o => o.MapFrom(s => s.FechaCreacion)).
               ForMember(x => x.FechaModifica, o => o.MapFrom(s => s.FechaModifica)).
               ForMember(x => x.RolId, o => o.MapFrom(s => s.Id)).
               ForMember(x => x.Tercero, o => o.Ignore()).
               ForMember(x => x.TerceroId, o => o.MapFrom(s => s.Tercero)).
               ForMember(x => x.UsuarioCrea, o => o.MapFrom(s => s.UsuarioCrea)).
               ForMember(x => x.UsuarioModifica, o => o.MapFrom(s => s.UsuarioModifica))
               ;

            config.CreateMap<Roles, RolesResponse>().
                ForMember(x => x.Nombre, o => o.MapFrom(s => s.Descripcion)).
                ForMember(x => x.RolIdCreateRol, o => o.MapFrom(s => s.RolIdCreate)).
                ForMember(x => x.EsSuperAdmon, o => o.MapFrom(s => s.EsSuperAdmon)).
                ForMember(x => x.Estado, o => o.MapFrom(s => s.Estado)).
                ForMember(x => x.FechaCreacion, o => o.MapFrom(s => s.FechaCreacion)).
                ForMember(x => x.FechaModifica, o => o.MapFrom(s => s.FechaModifica)).
                ForMember(x => x.Id, o => o.MapFrom(s => s.RolId)).
                ForMember(x => x.Tercero, o => o.MapFrom(s => s.TerceroId)).
                ForMember(x => x.TerceroNombre, o => o.MapFrom(s => s.Tercero != null ? s.Tercero.NombreComercial : string.Empty)).
                ForMember(x => x.TerceroDocumento, o => o.MapFrom(s => s.Tercero != null ? s.Tercero.Documento : string.Empty)).
                ForMember(x => x.UsuarioCrea, o => o.MapFrom(s => s.UsuarioCrea)).
                ForMember(x => x.UsuarioModifica, o => o.MapFrom(s => s.UsuarioModifica));
        }

        public static void MappingRoleFilterRequest(IMapperConfigurationExpression config)
        {
            config.CreateMap<RolesFiltroRequest, RolesFiltro>().
               ForMember(x => x.Estados, o => o.MapFrom(s => s.EstadoRol)).
               ForMember(x => x.Id, o => o.Ignore()).
               ForMember(x => x.Nombre, o => o.MapFrom(s => s.NombreRol)).
               ForMember(x => x.Tercero, o => o.MapFrom(s => s.Tercero));

            config.CreateMap<RolesFiltro, RolesFiltroRequest>().
               ForMember(x => x.EstadoRol, o => o.MapFrom(s => s.Estados)).
               ForMember(x => x.NombreRol, o => o.MapFrom(s => s.Nombre)).
               ForMember(x => x.Tercero, o => o.MapFrom(s => s.Tercero));
        }
    }
}