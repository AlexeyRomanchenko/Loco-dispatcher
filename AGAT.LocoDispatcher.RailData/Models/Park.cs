using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace AGAT.LocoDispatcher.RailData.Models
{
    public class Park
    {
        [Key]
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public IEnumerable<Rail> Rails { get; set; }
        public int ParkId { get; set; }
        public int StationId { get; set; }
    }
}
