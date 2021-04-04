using System;
using System.Collections.Generic;

namespace Netactica.Services.Request
{
    public class RolesMenuTVPRequest
    {
        public int Id { get; set; }

        public int Menu { get; set; }

        public Guid Rol { get; set; }

        public bool Estado { get; set; }
    }

    public class RolesMenuSaveRequest 
    {
        public List<RolesMenuTVPRequest> Roles { get; set; }

        public Guid RolId { get; set; }

        public Guid UserId { get; set; }

        public Guid RolUserId { get; set; }
    }
}