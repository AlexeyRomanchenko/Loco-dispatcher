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
    
    public partial class way
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public way()
        {
            this.vagon = new HashSet<vagon>();
        }
    
        public int way_id { get; set; }
        public string num_prk { get; set; }
        public string num_way { get; set; }
        public string name_way { get; set; }
        public Nullable<short> long_way { get; set; }
        public Nullable<int> weight_way { get; set; }
        public int lng_sum { get; set; }
        public int ves_sum { get; set; }
        public short blk_way { get; set; }
        public short kvo_vgn { get; set; }
        public string grup_way { get; set; }
        public string pr_way { get; set; }
        public string pr_otv { get; set; }
        public int prk_id { get; set; }
    
        public virtual park park { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<vagon> vagon { get; set; }
    }
}