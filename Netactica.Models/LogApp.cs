using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Netactica.Models
{
    [Table("LogApp")]
    public class LogApp
    {
        [Key]
        [Column("IdLog")]
        public Guid IdLog { get; set; }

        [Column("DateCreate")]
        public DateTime? DateCreate { get; set; }

        [Column("ThreadLog")]
        public string ThreadLog { get; set; }

        [Column("LeveLog")]
        public string LeveLog { get; set; }

        [Column("Logger")]
        public string Logger { get; set; }

        [Column("MessagLog")]
        public string MessagLog { get; set; }

        [Column("ExceptionLog")]
        public string ExceptionLog { get; set; }
    }
}