using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Netactica.Models
{
    [Table("Usuario")]
    public class Usuario
    {
        [Key]
        [Column("UsuarioId")]
        public Guid UsuarioId { get; set; }

        [Column("UsuarioNombre")]
        public string UsuarioNombre { get; set; }

        [Column("UsuarioCorreo")]
        public string UsuarioCorreo { get; set; }

        [Column("UsuarioEstadoId")]
        public int UsuarioEstadoId { get; set; }

        [Column("FechaCreacion")]
        public DateTime FechaCreacion { get; set; }

        [Column("UsuarioCrea")]
        public Guid? UsuarioCrea { get; set; }

        [Column("FechaModificacion")]
        public DateTime? FechaModificacion { get; set; }

        [Column("UsuarioModifica")]
        public Guid? UsuarioModifica { get; set; }

        [Column("NumItentos")]
        public int? NumItentos { get; set; }

        [Column("Pw")]
        public string Pw { get; set; }

        [Column("FechaUltimoIngreso")]
        public DateTime? FechaUltimoIngreso { get; set; }

        [Column("RestauraClave")]
        public bool? RestauraClave { get; set; }

        [Column("LenguajeId")]
        public int? LenguajeId { get; set; }

        [NotMapped]
        public UsuariosEstado UsuariosEstado { get; set; }

        [NotMapped]
        public Lenguaje Lenguaje { get; set; }

        /// <summary>
        /// Nombre completo del usuario sacado de la tabla UsuarioInfo
        /// </summary>
        [NotMapped]
        public string NombreCompleto { get; set; }
    }
}