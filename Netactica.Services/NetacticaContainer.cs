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
            Bind<IReservasData>().To<ReservasData>();
            Bind<IUsuarioInfoData>().To<UsuarioInfoData>();
            Bind<IUsuariosData>().To<UsuariosData>();

            //Servicios
            Bind<IReservasServices>().To<ReservasServices>();
            Bind<IUsuarioServices>().To<UsuarioServices>();
        }
    }
}