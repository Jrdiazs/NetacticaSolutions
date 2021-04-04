using System;
using System.Collections.Generic;

namespace Netactica.Services.Request
{
    public class RolesMenuTVPRequest
    {
        public int Menu { get; set; }
    }

    public class RolesMenuSaveRequest 
    {
        public List<RolesMenuTVPRequest> Menus { get; set; }

        public Guid RolId { get; set; }

        public Guid UserId { get; set; }

        public Guid RolUserId { get; set; }
    }
}