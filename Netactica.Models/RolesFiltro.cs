using System;

namespace Netactica.Models
{
    public class RolesFiltro
    {
        public Guid? RolId { get; set; }

        public string Descripcion { get; set; }

        public Guid? TerceroId { get; set; }

        public bool? Estado { get; set; }
    }
}