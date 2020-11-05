using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.Common.Models.EventModels
{
    public class BasicEventModel
    {
        public string Type { get; set; }
        public int Timestamp { get; set; }
        public string Message { get; set; }
        public string CheckPointNumber { get; set; }
        public string TrackNumber { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
