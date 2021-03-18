using System;

namespace Netactica.Services.Request
{
    public class UsuariosFiltroRequest
    {
        public string Nombre { get; set; }

        public int? EstadoId { get; set; }

        public string Documento { get; set; }

        public string NombresCompletos { get; set; }

        public Guid? Tercero { get; set; }

        public Guid Usuario { get; set; }

        public Guid RolId { get; set; }
    }
}