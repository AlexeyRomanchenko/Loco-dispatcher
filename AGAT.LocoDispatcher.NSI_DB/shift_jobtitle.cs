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
    
    public partial class shift_jobtitle
    {
        public int id_type { get; set; }
        public int id_code { get; set; }
        public string mn_code { get; set; }
        public string mn_code_lat { get; set; }
        public string code { get; set; }
        public Nullable<int> position_gir { get; set; }
    
        public virtual shift_type shift_type { get; set; }
    }
}
