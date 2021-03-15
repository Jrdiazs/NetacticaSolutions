using AutoMapper;
using Netactica.Models;
using Netactica.Services.Response;

namespace Netactica.Services
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize((config) =>
            {
                ConfigUserResponse(config);
                ConfigUserInfoResponse(config);
                ConfigUsuariosEstadosResponse(config);
            });
        }

        public static void ConfigUserResponse(IMapperConfigurationExpression config)
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

        public static void ConfigUserInfoResponse(IMapperConfigurationExpression config)
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

        public static void ConfigUsuariosEstadosResponse(IMapperConfigurationExpression config)
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
    }
}