using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.Data.Models.Rails
{
    public class Coord : BaseCoord
    {
        [Key]
        public new int Id { get; set; }
        public bool StartFlag { get; set; }
        public int RailId { get; set; }
        public Rail Rail { get; set; }
        public RoutePlate RoutePlate { get; set; }
    }
}
