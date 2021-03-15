using System;

namespace Netactica.Services.Response
{
    public class UsuarioFiltroResponse
    {
        public Guid UsuarioId { get; set; }

        public string UsuarioNombre { get; set; }

        public string Documento { get; set; }

        public string NombreCompleto { get; set; }

        public string UsuarioCorreo { get; set; }

        public int? NumItentos { get; set; }

        public DateTime? FechaUltimoIngreso { get; set; }

        public string Clientes { get; set; }

        public string Roles { get; set; }

        public string Estado { get; set; }
    }
}