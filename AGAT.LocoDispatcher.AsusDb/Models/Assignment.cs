using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.AsusDb.Models
{
    [Table("LokM_operWork")]
    public class Assignment
    {
        [Column("lokM_operW_id")]
        public int Id { get; set; }
        [Column("stanc")]
        public string Station { get; set; }
        [Column("num_lok")]
        public string LocomotiveNumber { get; set; } // HERE
        [Column("ser_lok")]
        public string SerialNumber { get; set; }
        [Column("cod_work")]
        public string WorkCode { get; set; }
        [Column("cod_opL")]
        public string PaymentCode { get; set; }

        [Column("dt_beg")]
        public DateTime? StartDate { get; set; }
        [Column("dt_end")]
        public DateTime? EndDate { get; set; }
        [Column("dt_ins")]
        public DateTime? InsertDate { get; set; }
        [Column("utv")]
        public int? AppliedCode { get; set; }
    }
}
