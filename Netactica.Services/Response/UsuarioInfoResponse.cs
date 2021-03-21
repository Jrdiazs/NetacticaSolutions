using System;

namespace Netactica.Services.Response
{
    public class UsuarioInfoResponse
    {
        public Guid Id { get; set; }

        public int? TipoIdentificacionId { get; set; }

        public string NumeroDocumento { get; set; }

        public string Nombres { get; set; }

        public string Apellidos { get; set; }

        public string CorreoAlternativo { get; set; }

        public string Telefono { get; set; }

        public string Direccion { get; set; }

        public DateTime? FechaNacimiento { get; set; }

        public DateTime? FechaCreacion { get; set; }

        public Guid? UsuarioCrea { get; set; }

        public DateTime? FechaModificacion { get; set; }

        public Guid? UsuarioModifica { get; set; }

        public string TipoIdentificacion { get; set; }

        public string NombreCompleto { get; set; }
    }
}