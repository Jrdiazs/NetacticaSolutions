using Netactica.Data;
using Ninject.Modules;

namespace Netactica.Services
{
    /// <summary>
    /// Contenedor de clases de Netactica
    /// </summary>
    public class NetacticaContainer : NinjectModule
    {
        public override void Load()
        {
            //Repositorios
            Bind<IDataCommon>().To<DataCommon>();
            Bind<IReservasData>().To<ReservasData>();
            Bind<IRolesData>().To<RolesData>();
            Bind<IUsuariosEstadoData>().To<UsuariosEstadoData>();
            Bind<IUsuarioInfoData>().To<UsuarioInfoData>();
            Bind<IUsuariosData>().To<UsuariosData>();
            Bind<IUsuarioRolesData>().To<UsuarioRolesData>();

            //Servicios
            Bind<IReservasServices>().To<ReservasServices>();
            Bind<IUsuarioServices>().To<UsuarioServices>();
            Bind<IRolesServices>().To<RolesServices>();
        }
    }
}