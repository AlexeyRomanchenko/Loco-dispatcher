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
    
    public partial class vu14
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public vu14()
        {
            this.vu14_vag = new HashSet<vu14_vag>();
        }
    
        public string num { get; set; }
        public string num_way { get; set; }
        public string num_prk { get; set; }
        public System.DateTime date_begin { get; set; }
        public Nullable<System.DateTime> date_end { get; set; }
        public byte is_utv { get; set; }
        public string fio1 { get; set; }
        public string fio2 { get; set; }
        public string fio_osm1 { get; set; }
        public string fio_osm2 { get; set; }
        public string stanc { get; set; }
        public int vu14_id { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<vu14_vag> vu14_vag { get; set; }
    }
}