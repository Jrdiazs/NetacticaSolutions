using Netactica.Data;
using Ninject.Modules;

namespace Netactica.Services
{
    public class NetacticaContainer : NinjectModule
    {
        public override void Load()
        {
            //Repositorios
            Bind<IReservasData>().To<ReservasData>();

            //Servicios
            Bind<IReservasServices>().To<ReservasServices>();
        }
    }
}