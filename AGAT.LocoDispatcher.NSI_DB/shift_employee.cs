//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AGAT.LocoDispatcher.NSI_DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class shift_employee
    {
        public int id_type { get; set; }
        public int id_employee { get; set; }
        public string surname { get; set; }
        public short state { get; set; }
        public int id_code { get; set; }
        public Nullable<int> num_shift { get; set; }
    
        public virtual shift_type shift_type { get; set; }
    }
}