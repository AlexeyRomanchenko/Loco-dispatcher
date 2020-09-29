using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.RailData.Models
{
    public class Point
    {
        //public Point()
        //{
        //    Rails = new List<Rail>();
        //}
        [Key]
        public int Id { get; set; }
        public string Code { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Angle { get; set; }
        public int ParkId { get; set; }
        public Park Park { get; set; }
       // public List<Rail>  Rails { get; set; }
    }
}
