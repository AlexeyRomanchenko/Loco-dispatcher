using AGAT.LocoDispatcher.Common.Interfaces.Rails;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AGAT.LocoDispatcher.Data.Models.Rails
{
    public class Park : IPark
    {
        [Key]
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public IEnumerable<Rail> Rails { get; set; }
        public int ParkId { get; set; }
    }
}
