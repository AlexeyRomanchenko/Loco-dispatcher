using System.ComponentModel.DataAnnotations;

namespace AGAT.LocoDispatcher.RailData.Models
{
    public class RoutePlate
    {
        [Key]
        public int Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public string Name { get; set; }
        public int RailId { get; set; }
        public Rail Rail { get; set; }
        public int Angle { get; set; }
    }
}
