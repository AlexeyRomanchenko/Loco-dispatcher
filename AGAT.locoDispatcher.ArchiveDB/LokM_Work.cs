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
    
    public partial class LokM_Work
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LokM_Work()
        {
            this.LokM_oper = new HashSet<LokM_oper>();
        }
    
        public int lokM_work_id { get; set; }
        public string stanc { get; set; }
        public string counter { get; set; }
        public string num_lok { get; set; }
        public string ser_lok { get; set; }
        public string cod_work { get; set; }
        public Nullable<System.DateTime> dt_beg { get; set; }
        public Nullable<System.DateTime> dt_end { get; set; }
        public string fio_m { get; set; }
        public string fio_s { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LokM_oper> LokM_oper { get; set; }
    }
}
