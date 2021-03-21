using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Netactica.Models
{
    [Table("Parametros")]
    public class Parametros
    {
        [Key]
        [Column("ParametroId")]
        public Guid ParametroId { get; set; }

        [Column("ParametroLlave")]
        public string ParametroLlave { get; set; }

        [Column("ParametroDescripcion")]
        public string ParametroDescripcion { get; set; }

        [Column("ValorGuid")]
        public Guid? ValorGuid { get; set; }

        [Column("ValorEntero")]
        public int? ValorEntero { get; set; }

        [Column("ValorDateTime")]
        public DateTime? ValorDateTime { get; set; }

        [Column("ValorSrtring")]
        public string ValorSrtring { get; set; }

        [Column("ValorBingInt")]
        public long? ValorBingInt { get; set; }

        [Column("ValorBoleano")]
        public bool? ValorBoleano { get; set; }

        [Column("FechaCreacion")]
        public DateTime? FechaCreacion { get; set; }

        [Column("UsuarioCrea")]
        public Guid? UsuarioCrea { get; set; }

        [Column("UsuarioModifica")]
        public Guid? UsuarioModifica { get; set; }

        [Column("FechaModificacion")]
        public DateTime? FechaModificacion { get; set; }
    }
}