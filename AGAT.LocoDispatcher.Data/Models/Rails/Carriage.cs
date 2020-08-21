using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AGAT.LocoDispatcher.Data.Models.Rails
{
    public class Carriage : BaseCoord
    {
        [Key]
        [ForeignKey("Rail")]
        public new int Id { get; set; }
        public int? Angle { get; set; }
        public int RailId { get; set; }
        public Rail Rail { get; set; }
    }
}
