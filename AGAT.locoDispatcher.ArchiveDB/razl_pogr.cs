//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AGAT.locoDispatcher.ArchiveDB
{
    using System;
    using System.Collections.Generic;
    
    public partial class razl_pogr
    {
        public string cod_pogr { get; set; }
        public Nullable<int> gr_pogr { get; set; }
        public Nullable<int> por_pogr { get; set; }
        public Nullable<int> gr_rp { get; set; }
        public int tr_id { get; set; }
    
        public virtual train1 train1 { get; set; }
    }
}
