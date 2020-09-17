using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.Business.Models
{
    public class Assignment
    {
        public int Id { get; set; }
        public string Station { get; set; }
        public string LocomotiveNumber { get; set; }
        public string SerialNumber { get; set; }
        public string WorkCode { get; set; }
        public string PaymentCode { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? InsertDate { get; set; }
        public int? AppliedCode { get; set; }
        public string Reason { get; set; }
        public string StartPark { get; set; }
        public string StartRoute { get; set; }
        public string EndRoute { get; set; }
        public string EndPark { get; set; }
    }
}
