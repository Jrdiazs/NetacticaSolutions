using System;

namespace Netactica.Services.Response
{
    public class UsuarioRolesResponse
    {
        public Guid Id { get; set; }

        public Guid Usuario { get; set; }

        public Guid Rol { get; set; }

        public Guid Tercero { get; set; }

        public bool Estado { get; set; }

        public DateTime? FechaCreacion { get; set; }

        public Guid? UsuarioCrea { get; set; }

        public DateTime? FechaModifica { get; set; }

        public Guid? UsuarioModifica { get; set; }

        public string UsuarioNombreCompleto { get; set; }

        public string RolNombre { get; set; }

        public string TerceroNombre { get; set; }

        public string TerceroDocumento { get; set; }
    }
}