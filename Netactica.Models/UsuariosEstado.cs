using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Netactica.Models
{
    [Table("UsuariosEstado")]
    public class UsuariosEstado
    {
        [Key]
        [Column("UsuarioEstadoId")]
        public int UsuarioEstadoId { get; set; }

        [Column("DescripcionEstado")]
        public string DescripcionEstado { get; set; }

        [Column("Alias")]
        public string Alias { get; set; }
    }

    public enum EnumUsuariosEstado
    {
        ACTIVO = 1,
        INACTIVO = 2,
        BLOQUEADO = 3
    }
}