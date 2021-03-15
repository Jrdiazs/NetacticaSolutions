using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Netactica.Models
{
    [Table("TipoTercero")]
    public class TipoTercero
    {
        [Key]
        [Column("TipoTerceroId")]
        public int TipoTerceroId { get; set; }

        [Column("Descripcion")]
        public string Descripcion { get; set; }


    }
}
