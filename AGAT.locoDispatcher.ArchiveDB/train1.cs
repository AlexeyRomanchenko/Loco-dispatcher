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
    
    public partial class train1
    {
        public string tip_oper { get; set; }
        public string num_train { get; set; }
        public string ind_s { get; set; }
        public string naprav { get; set; }
        public string priz_spis { get; set; }
        public string usl_dl_tr { get; set; }
        public string brutto_tr { get; set; }
        public string cod_prk { get; set; }
        public string negab_s { get; set; }
        public string zivn_s { get; set; }
        public string mar_s { get; set; }
        public string tara_s { get; set; }
        public string netto_s { get; set; }
        public string kol_vgn { get; set; }
        public string vid_tr { get; set; }
        public string cod_per { get; set; }
        public Nullable<System.DateTime> datt_nl { get; set; }
        public string fam { get; set; }
        public System.DateTime dat_tr { get; set; }
        public string old_index { get; set; }
        public Nullable<int> bl_id { get; set; }
        public string stanc { get; set; }
        public int tr_id { get; set; }
        public string ohr { get; set; }
        public Nullable<byte> razr_tr { get; set; }
        public byte prizn_mash { get; set; }
        public string dop_num_tr { get; set; }
    
        public virtual har_s har_s { get; set; }
        public virtual razl_kat razl_kat { get; set; }
        public virtual razl_nod razl_nod { get; set; }
        public virtual razl_osn razl_osn { get; set; }
        public virtual razl_pogr razl_pogr { get; set; }
        public virtual razl_rps razl_rps { get; set; }
    }
}