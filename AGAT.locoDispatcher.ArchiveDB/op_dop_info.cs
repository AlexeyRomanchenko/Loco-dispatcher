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
    
    public partial class op_dop_info
    {
        public int oper_tr_id { get; set; }
        public string kol_vag { get; set; }
        public string kol_otc { get; set; }
        public string num_loc { get; set; }
        public string brutto { get; set; }
        public string prich { get; set; }
        public string pole1 { get; set; }
        public string prim { get; set; }
    
        public virtual oper_tr oper_tr { get; set; }
    }
}
