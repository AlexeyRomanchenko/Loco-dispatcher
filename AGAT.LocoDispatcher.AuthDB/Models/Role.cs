using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AGAT.LocoDispatcher.AuthDB.Models
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }
        [MaxLength(20)]
        public string Name { get; set; }
    }
}
