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
    
    public partial class oper_v
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public oper_v()
        {
            this.oper_kat_per = new HashSet<oper_kat_per>();
        }
    
        public string op_inv_vg { get; set; }
        public string kateg { get; set; }
        public string vid { get; set; }
        public System.DateTime data_op_v { get; set; }
        public string cod_op_v { get; set; }
        public string place { get; set; }
        public string disloc { get; set; }
        public string op_num_train { get; set; }
        public string op_ind_sost { get; set; }
        public string nom_por_v { get; set; }
        public string tip_park { get; set; }
        public string dokument { get; set; }
        public string vid_izm { get; set; }
        public Nullable<int> gruz_id { get; set; }
        public int op_id { get; set; }
        public int dviz_id { get; set; }
        public Nullable<int> tr_id { get; set; }
        public Nullable<int> prik_id { get; set; }
        public Nullable<int> lokM_oper_id { get; set; }
    
        public virtual dviz dviz { get; set; }
        public virtual gruz_v gruz_v { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<oper_kat_per> oper_kat_per { get; set; }
        public virtual prikaz prikaz { get; set; }
    }
}
