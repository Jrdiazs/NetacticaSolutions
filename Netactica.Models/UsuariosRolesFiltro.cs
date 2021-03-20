using System;

namespace Netactica.Models
{
    public class UsuariosRolesFiltro
    {
        public Guid? Id { get; set; }

        public Guid? Rol { get; set; }

        public Guid? Usuario { get; set; }

        public bool? Estado { get; set; }

        public Guid? Tercero { get; set; }
    }
}