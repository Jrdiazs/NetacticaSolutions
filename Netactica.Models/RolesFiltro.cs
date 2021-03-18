using System;

namespace Netactica.Models
{
    public class RolesFiltro
    {
        public Guid? Id { get; set; }

        public string Nombre { get; set; }

        public Guid? Tercero { get; set; }

        public bool? Estados { get; set; }
    }
}