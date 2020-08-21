using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AGAT.LocoDispatcher.Data.Models.Rails
{
    public class RoutePlate
    {
        [Key]
        public  int Id { get; set; }
        public string Name { get; set; }
        public int RailId { get; set; }
        [Required]
        public Rail Rail { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Angle { get; set; }
    }
}
