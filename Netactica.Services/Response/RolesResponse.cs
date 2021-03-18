using System;

namespace Netactica.Services.Response
{
    public class RolesResponse
    {
        public Guid Id { get; set; }

        public string Nombre { get; set; }

        public Guid? Tercero { get; set; }

        public bool EsSuperAdmon { get; set; }

        public bool Estado { get; set; }

        public DateTime? FechaCreacion { get; set; }

        public Guid? UsuarioCrea { get; set; }

        public DateTime? FechaModifica { get; set; }

        public Guid? UsuarioModifica { get; set; }

        public string TerceroNombre { get; set; }
    }
}