using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AGAT.LocoDispatcher.Data.Models.Rails
{
    public class Carriage
    {
        [Key]
        public int Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int? Angle { get; set; }
        public int RailId { get; set; }
        [ForeignKey("RailId")]
        public Rail Rail { get; set; }
    }
}
