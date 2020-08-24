using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.AsusDb.Models
{
    [Table("vagon")]
    public class CarriageInfo
    {
        [Column("in_vgn")]
        public string Id { get; set; }
        [Column("way_id")]
        public int RouteId { get; set; }
        [Column("ord_num")]
        public short Order { get; set; }
        [Column("cod_sbs")]
        public string OwnerCode { get; set; }
        [Column("ves_gruz")]
        public string LoadWeight { get; set; }
        [Column("st_destn")]
        public string DestinationCode { get; set; }
        [Column("prim")]
        public string Description { get; set; }
    }
}
