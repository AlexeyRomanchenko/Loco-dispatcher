using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.AsusDb.Models
{
    [Table("way")]
    public class Route
    {
        [Column("way_id")]
        public int Id { get; set; }
        [Column("kvo_vgn")]
        public short CarCount { get; set; }
        [Column("ves_sum")]
        public int CarWeight { get; set; }
        [Column("lng_sum")]
        public int CarLength { get; set; }
        [Column("num_way")]
        public string RouteNumber { get; set; }
        [Column("num_prk")]
        public string ParkCode { get; set; }
        [Column("prk_id")]
        public int ParkId { get; set; }
    }
}
