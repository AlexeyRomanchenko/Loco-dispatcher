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
    
    public partial class train2
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public train2()
        {
            this.locomotiv = new HashSet<locomotiv>();
        }
    
        public string ind_s { get; set; }
        public string num_park { get; set; }
        public string num_way { get; set; }
        public Nullable<System.DateTime> time_so_st { get; set; }
        public Nullable<System.DateTime> time_na_st { get; set; }
        public string prim { get; set; }
        public string tip_oper { get; set; }
        public System.DateTime date_op { get; set; }
        public int tr2_id { get; set; }
        public Nullable<int> bl_id { get; set; }
        public string stanc { get; set; }
        public string num_dsp { get; set; }
        public Nullable<int> pr_to { get; set; }
        public Nullable<System.DateTime> date_op2 { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<locomotiv> locomotiv { get; set; }
    }
}
