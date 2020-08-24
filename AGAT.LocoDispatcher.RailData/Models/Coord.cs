﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.RailData.Models
{
    public class Coord
    {
        [Key]
        public int Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public bool StartFlag { get; set; }
        public int RailId { get; set; }
       // public Rail Rail { get; set; }
       // public RoutePlate RoutePlate { get; set; }
    }
}
