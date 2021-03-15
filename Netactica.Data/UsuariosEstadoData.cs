using Netactica.Models;
using System;

namespace Netactica.Data
{
    /// <summary>
    /// Acceso a datos a la tabla UsuariosEstado
    /// </summary>
    public class UsuariosEstadoData : Repository<UsuariosEstado>, IUsuariosEstadoData, IDisposable
    {
        /// <summary>
        /// Acceso a datos a la tabla UsuariosEstado
        /// </summary>
        public UsuariosEstadoData() : base()
        {
        }
    }

    /// <summary>
    /// Acceso a datos a la tabla UsuariosEstado
    /// </summary>
    public interface IUsuariosEstadoData : IRepository<UsuariosEstado>, IDisposable { }
}