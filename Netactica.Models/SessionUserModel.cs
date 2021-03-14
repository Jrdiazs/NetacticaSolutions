using System;

namespace Netactica.Models
{
    /// <summary>
    /// Sesion del usuario
    /// </summary>
    public class SessionUserModel
    {
        /// <summary>
        /// Id del usuario
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Id del Rol
        /// </summary>
        public Guid RolId { get; set; }

        /// <summary>
        /// Tercero Id
        /// </summary>
        public Guid TerceroId { get; set; }
    }
}