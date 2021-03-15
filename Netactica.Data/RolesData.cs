using Netactica.Models;
using System;

namespace Netactica.Data
{
    /// <summary>
    /// Acceso a datos Roles
    /// </summary>
    public class RolesData : Repository<Roles>, IRolesData, IDisposable
    {
        /// <summary>
        /// Acceso a datos Roles
        /// </summary>
        public RolesData() : base()
        {
        }
    }

    /// <summary>
    /// Acceso a datos Roles
    /// </summary>
    public interface IRolesData : IRepository<Roles>, IDisposable { }
}