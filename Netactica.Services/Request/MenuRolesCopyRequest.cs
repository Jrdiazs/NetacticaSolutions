using System;

namespace Netactica.Services.Request
{
    public class MenuRolesCopyRequest
    {
        public Guid RoldIdSource { get; set; }

        public Guid RolIdTarget { get; set; }

        public Guid UserId { get; set; }
    }
}