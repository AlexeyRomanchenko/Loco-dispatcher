using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.Business.Models.RouteModels
{
    public class CarriageInfo
    {
        public string Id { get; set; }
        public int RouteId { get; set; }
        public short Order { get; set; }
        public string OwnerCode { get; set; }
        public string LoadWeight { get; set; }
        public string DestinationCode { get; set; }
        public string Description { get; set; }
    }
}
