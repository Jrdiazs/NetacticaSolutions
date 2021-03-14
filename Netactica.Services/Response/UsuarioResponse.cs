using System;

namespace Netactica.Services.Response
{
    public class UsuarioResponse
    {
        public Guid Id { get; set; }

        public string Nombre { get; set; }

        public string Correo { get; set; }

        public int EstadoId { get; set; }

        public DateTime FechaCreacion { get; set; }

        public Guid? UsuarioCrea { get; set; }

        public DateTime? FechaModificacion { get; set; }

        public Guid? UsuarioModifica { get; set; }

        public int? NumItentos { get; set; }

        public DateTime? FechaUltimoIngreso { get; set; }

        public bool? RestauraClave { get; set; }

        public int? LenguajeId { get; set; }

        public string EstadoDescripcion { get; set; }

        public string LenguajeCodigo { get; set; }

        public string Password { get; set; }

        public string PasswordConfirm { get; set; }
    }
}