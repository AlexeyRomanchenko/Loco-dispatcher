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
    
    public partial class vu14_vag
    {
        public string in_vgn { get; set; }
        public string num_train { get; set; }
        public Nullable<short> ord_num { get; set; }
        public string code_godn_gr { get; set; }
        public string name_pred { get; set; }
        public int vu14_id { get; set; }
        public int vu14_vag_id { get; set; }
        public string godn { get; set; }
        public string note { get; set; }
    
        public virtual vu14 vu14 { get; set; }
    }
}
