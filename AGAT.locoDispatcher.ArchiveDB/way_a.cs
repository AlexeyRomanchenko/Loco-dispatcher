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
    
    public partial class way_a
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public way_a()
        {
            this.way_vag = new HashSet<way_vag>();
        }
    
        public string name_w { get; set; }
        public string grpl_a { get; set; }
        public string smnz { get; set; }
        public string stanc { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<way_vag> way_vag { get; set; }
    }
}
