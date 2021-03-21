using System;

namespace Netactica.Services.Request
{
    public class UsuariosRolesFiltroRequest
    {
        public Guid? Rol { get; set; }

        public Guid? Usuario { get; set; }

        public bool? Estado { get; set; }

        public Guid? Tercero { get; set; }
    }
}