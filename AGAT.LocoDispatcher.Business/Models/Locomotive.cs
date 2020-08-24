using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.Business.Models
{
    public class Locomotive
    {
        public int Id { get; set; }
        public string TrainNumber { get; set; }
        public string ESR { get; set; }
        public bool IsValid { get; set; }
        public DateTime StartShift { get; set; }
        public DateTime? EndShift { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
