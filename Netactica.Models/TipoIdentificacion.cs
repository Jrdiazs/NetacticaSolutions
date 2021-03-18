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

    public enum EnumTipoIdentificacion
    {
        CC = 1,
        CE = 2,
        TI = 3,
        PA = 4,
        NIT = 5
    }
}