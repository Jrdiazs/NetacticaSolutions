using System;

namespace Netactica.Models
{
    public class UsuariosListado
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

    public class UsuarioFiltro
    {
        public string UsuarioNombre { get; set; }

        public int? EstadoId { get; set; }

        public string Identificacion { get; set; }

        public string NombresCompletos { get; set; }

        public Guid? Tercero { get; set; }

        public Guid Usuario { get; set; }

        public Guid Rol { get; set; }
    }
}