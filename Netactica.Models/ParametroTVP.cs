using Netactica.Tools.Map;
using System;
using System.Collections.Generic;
using System.Data;

namespace Netactica.Models
{
    /// <summary>
    /// Clase que representa el parametor tipo tabla dbo.TVP_Lista
    /// </summary>
    public class ParametroTVP
    {
        public int? Entero { get; set; }

        public long? EnteroGrande { get; set; }

        public Guid? GuidValue { get; set; }

        public string StringValue { get; set; }

        /// <summary>
        /// Convierte un listado de parametros a un datatable
        /// </summary>
        /// <param name="list">listado de parametros</param>
        /// <returns>DataTable</returns>
        public static DataTable ListParametersToData(List<ParametroTVP> list)
        {
            try
            {
                var data = list.ListToDataTable("Entero", "EnteroGrande", "GuidValue", "StringValue");
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}