//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AGAT.LocoDispatcher.NSI_DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class tag5676
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tag5676()
        {
            this.pattern5676_tag5676 = new HashSet<pattern5676_tag5676>();
        }
    
        public string type { get; set; }
        public string tag { get; set; }
        public string name { get; set; }
        public int tag5676_id { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<pattern5676_tag5676> pattern5676_tag5676 { get; set; }
    }
}
