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
    
    public partial class arenda
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public arenda()
        {
            this.ar_vag = new HashSet<ar_vag>();
        }
    
        public string vid_dok { get; set; }
        public string num_pr { get; set; }
        public string arend { get; set; }
        public Nullable<System.DateTime> data_ar { get; set; }
        public Nullable<System.DateTime> data_ok { get; set; }
        public int ar_id { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ar_vag> ar_vag { get; set; }
    }
}
