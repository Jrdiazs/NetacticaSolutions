using System;

namespace Netactica.Services.Request
{
    public class RolesFiltroRequest
    {
        public string NombreRol { get; set; }

        public bool? EstadoRol { get; set; }

        public Guid? Tercero { get; set; }
    }
}