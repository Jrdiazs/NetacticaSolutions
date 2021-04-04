using Netactica.Models;
using System;
using System.Collections.Generic;

namespace Netactica.Services.Response
{
    public class MenuItem
    {
        public MenuItemResponse Menu { get; set; }

        public List<MenuItem> Childrens { get; set; } = new List<MenuItem>();
    }

    public class MenuItemResponse
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public int? PadreId { get; set; }

        public string Url { get; set; }

        public string Class { get; set; }

        public int? Ordenamiento { get; set; }

        public bool Estado { get; set; }

        public bool Checked { get; set; }

        public DateTime? FechaCreacion { get; set; }

        public Guid? UsuarioCrea { get; set; }

        public Guid? UsuarioModifica { get; set; }

        public DateTime? FechaModificacion { get; set; }
    }
}