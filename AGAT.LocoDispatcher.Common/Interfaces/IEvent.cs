﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.Common.Interfaces
{
    public interface IEvent
    {
        string Type { get; set; }
        int Timestamp { get; set; }
    }
}
