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
    
    public partial class otpravka
    {
        public string vid_otpk { get; set; }
        public string nom_kont { get; set; }
        public string tip_razm { get; set; }
        public string kc { get; set; }
        public string nom_otpk { get; set; }
        public Nullable<System.DateTime> data_otpk { get; set; }
        public string st_otpr { get; set; }
        public string cod_otpr { get; set; }
        public string name_otpr { get; set; }
        public string name_pol { get; set; }
        public string name_gr { get; set; }
        public string cod_gr { get; set; }
        public int gruz_id { get; set; }
        public int ves_gr { get; set; }
        public string cod_pol { get; set; }
        public Nullable<int> ves_kg { get; set; }
        public Nullable<int> massa_gr { get; set; }
        public Nullable<int> massa_tr { get; set; }
    
        public virtual gruz_v gruz_v { get; set; }
    }
}