﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.AuthDB.Models
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }
        [MaxLength(20)]
        public string Name { get; set; }
        public ICollection<User> Users { get; set; }
    }
}