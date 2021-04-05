
using System.Collections.Generic;


namespace Netactica.Services.Response
{
    public class MenuRolesChecked
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool Checked { get; set; }
        public int? Ordenamiento { get; set; }
    }

    public class MenuRolesChechedResponse 
    {
        public MenuRolesChecked Menu { get; set; }

        public List<MenuRolesChechedResponse> Childrens { get; set; } = new List<MenuRolesChechedResponse>();
    }
}
