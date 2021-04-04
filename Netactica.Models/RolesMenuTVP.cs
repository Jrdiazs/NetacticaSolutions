﻿using Netactica.Tools.Map;
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
        public int MenuId { get; set; }

        public static DataTable ListRolesToTable(List<RolesMenuTVP> list)
        {
            try
            {
                var data = list.ListToDataTable("MenuId");
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}