﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.Business.Models.RailModels
{
    public class Carriage : Coords
    {
        public int Id { get; set; }
        public int? Angle { get; set; }
    }
}
