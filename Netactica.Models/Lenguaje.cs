using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Netactica.Models
{
    [Table("Lenguaje")]
    public class Lenguaje
    {
        [Key]
        [Column("LenguajeId")]
        public int LenguajeId { get; set; }

        [Column("Descripcion")]
        public string Descripcion { get; set; }

        [Column("Codigo")]
        public string Codigo { get; set; }

        [Column("CodigoHtml")]
        public string CodigoHtml { get; set; }
    }
}