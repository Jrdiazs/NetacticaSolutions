using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Netactica.Models
{
    [Table("TipoIdentificacion")]
    public class TipoIdentificacion
    {
        [Key]
        [Column("TipoIdentificacionId")]
        public int TipoIdentificacionId { get; set; }

        [Column("Descripcion")]
        public string Descripcion { get; set; }

        [Column("Alias")]
        public string Alias { get; set; }
    }
}