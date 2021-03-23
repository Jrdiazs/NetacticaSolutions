using Netactica.Services;
using System;
using System.Web.Http;

namespace Netactica.UI.Controllers
{
    [RoutePrefix("api/Menu")]
    public class MenuController : ApiController
    {
        private readonly IMenuServices _services;

        public MenuController(IMenuServices services)
        {
            _services = services ?? throw new ArgumentNullException(nameof(services));
        }
    }
}