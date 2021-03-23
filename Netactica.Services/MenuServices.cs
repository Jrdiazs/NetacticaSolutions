using Netactica.Data;
using System;

namespace Netactica.Services
{
    public class MenuServices : BaseServices, IMenuServices, IDisposable
    {
        private readonly IMenuData _data;

        private readonly IMenuRolesData _dataRoles;

        public MenuServices(IMenuData data, IMenuRolesData dataRoles)
        {
            _data = data ?? throw new ArgumentNullException(nameof(data));
            _dataRoles = dataRoles ?? throw new ArgumentNullException(nameof(dataRoles));
        }

        #region [Dispose]

        private bool disposedValue;

        

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: eliminar el estado administrado (objetos administrados)

                    if (_data != null)
                        _data.Dispose();

                    if (_dataRoles != null)
                        _dataRoles.Dispose();
                }

                // TODO: liberar los recursos no administrados (objetos no administrados) y reemplazar el finalizador
                // TODO: establecer los campos grandes como NULL
                disposedValue = true;
            }
        }

        // // TODO: reemplazar el finalizador solo si "Dispose(bool disposing)" tiene código para liberar los recursos no administrados
        // ~MenuServices()
        // {
        //     // No cambie este código. Coloque el código de limpieza en el método "Dispose(bool disposing)".
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // No cambie este código. Coloque el código de limpieza en el método "Dispose(bool disposing)".
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        #endregion [Dispose]
    }

    public interface IMenuServices : IBaseServices, IDisposable
    {

    }
}