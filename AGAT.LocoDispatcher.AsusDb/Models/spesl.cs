//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AGAT.LocoDispatcher.AsusDb.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class spesl
    {
        public Nullable<int> way_id { get; set; }
        public string mplf { get; set; }
        public bool head { get; set; }
    
        public virtual way way { get; set; }
    }
}
