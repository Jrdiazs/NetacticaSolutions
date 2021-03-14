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
    }
}