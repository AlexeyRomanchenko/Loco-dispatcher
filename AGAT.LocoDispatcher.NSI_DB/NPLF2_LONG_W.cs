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
    
    public partial class NPLF2_LONG_W
    {
        public string tip { get; set; }
        public Nullable<int> long_w { get; set; }
        public int id { get; set; }
    
        public virtual NPLF2 NPLF2 { get; set; }
    }
}