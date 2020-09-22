using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.Common.Models.EventModels
{
    public class EmergencyModel
    {
        public int Timestamp { get; set; }
        public string TrainNumber { get; set; }
        public string Type { get; set; }
    }
}
