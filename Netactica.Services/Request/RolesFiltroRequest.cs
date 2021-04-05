using System;

namespace Netactica.Services.Request
{
    public class RolesFiltroRequest
    {
        public string NameRol { get; set; }

        public bool? StatusRole { get; set; }

        public Guid? ThirdId { get; set; }
    }
}