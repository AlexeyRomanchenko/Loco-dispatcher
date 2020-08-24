using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AGAT.LocoDispatcher.RailData.Models
{
    public class Carriage
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int? Angle { get; set; }
        public int RailId { get; set; }
        public Rail Rail { get; set; }
    }
}
