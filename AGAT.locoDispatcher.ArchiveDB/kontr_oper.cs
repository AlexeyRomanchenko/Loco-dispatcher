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
    
    public partial class kontr_oper
    {
        public string nom_kont { get; set; }
        public string kateg { get; set; }
        public string vid { get; set; }
        public System.DateTime data_op { get; set; }
        public string cod_op { get; set; }
        public string place { get; set; }
        public string disloc { get; set; }
        public string num_train { get; set; }
        public string ind_sost { get; set; }
        public string nom_por { get; set; }
        public string tip_park { get; set; }
        public string dokument { get; set; }
        public string vid_izm { get; set; }
        public Nullable<int> kontr_gruz_id { get; set; }
        public int kontr_op_id { get; set; }
        public Nullable<int> kontr_dviz_id { get; set; }
        public Nullable<int> dviz_id { get; set; }
        public Nullable<int> prik_id { get; set; }
        public Nullable<int> kr_id { get; set; }
    
        public virtual kontr_dviz kontr_dviz { get; set; }
        public virtual kontr_gruz kontr_gruz { get; set; }
    }
}
