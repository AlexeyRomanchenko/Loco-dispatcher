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
    
    public partial class data_sort
    {
        public string in_vgn { get; set; }
        public string nplf { get; set; }
        public string nprz { get; set; }
        public string npmr { get; set; }
        public string nplf1 { get; set; }
        public string pto { get; set; }
        public Nullable<int> way_id { get; set; }
        public short usl_dl_v { get; set; }
        public short ves_tr_v { get; set; }
        public short ves_grz { get; set; }
        public short brut { get; set; }
        public string opv { get; set; }
        public string pko { get; set; }
        public short grpd_v { get; set; }
        public string kateg { get; set; }
        public Nullable<short> sader { get; set; }
        public string stanc { get; set; }
        public Nullable<int> prikaz_id { get; set; }
        public string nom_act { get; set; }
        public Nullable<int> osngr_id { get; set; }
        public Nullable<short> num { get; set; }
        public Nullable<short> kol_in_gr { get; set; }
        public string pr_gr { get; set; }
    
        public virtual vagon vagon { get; set; }
    }
}
