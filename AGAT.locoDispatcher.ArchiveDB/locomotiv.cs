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
    
    public partial class locomotiv
    {
        public string ser_loc { get; set; }
        public string num_loc { get; set; }
        public string time_brig { get; set; }
        public string depo_brig { get; set; }
        public string tab_m { get; set; }
        public string fam_m { get; set; }
        public string priz_loc { get; set; }
        public string time_d { get; set; }
        public string prost_l { get; set; }
        public int tr_id { get; set; }
        public string vid_sled { get; set; }
        public int lok_id { get; set; }
        public string dor_prip { get; set; }
    
        public virtual train2 train2 { get; set; }
    }
}
