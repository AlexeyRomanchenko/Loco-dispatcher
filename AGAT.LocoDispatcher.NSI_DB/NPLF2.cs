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
    
    public partial class NPLF2
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NPLF2()
        {
            this.NPLF2_KLIENT = new HashSet<NPLF2_KLIENT>();
        }
    
        public int id { get; set; }
        public string station { get; set; }
        public string np { get; set; }
        public string mnk { get; set; }
        public string mnk2 { get; set; }
        public string naim { get; set; }
        public string naim2 { get; set; }
        public string dop { get; set; }
        public short pr1 { get; set; }
        public string pr2 { get; set; }
        public string sobstv { get; set; }
        public short long_way_d { get; set; }
        public string rast_pod { get; set; }
        public string z_otv { get; set; }
        public string way_pod { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NPLF2_KLIENT> NPLF2_KLIENT { get; set; }
        public virtual NPLF2_LONG_W NPLF2_LONG_W { get; set; }
    }
}
