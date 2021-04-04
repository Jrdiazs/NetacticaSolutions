using Netactica.Tools.Map;
using System;
using System.Collections.Generic;
using System.Data;

namespace Netactica.Models
{
    /// <summary>
    /// Clase que representa parametro tipo tabla dbo.TVP_MenuRoles
    /// </summary>
    public class RolesMenuTVP
    {
        public int MenuRolId { get; set; }

        public int MenuId { get; set; }

        public Guid RolId { get; set; }

        public bool Estado { get; set; }

        public static DataTable ListRolesToTable(List<RolesMenuTVP> list)
        {
            try
            {
                var data = list.ListToDataTable("MenuRolId", "MenuId", "RolId", "Estado");
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}