using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.AuthDB.Models
{
    public class Station
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string StationCode { get; set; }
    }
}
