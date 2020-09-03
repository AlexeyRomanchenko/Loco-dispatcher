using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.Common.Models.RailModels
{
    public class Train
    {
        public string TrainIndex { get; set; }
        public string Length { get; set; }
        public string Weight { get; set; }
        public string HeadNumber { get; set; }
        public string TaleNumber { get; set; }
    }
}
