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
    
    public partial class uslugi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public uslugi()
        {
            this.uslug_form = new HashSet<uslug_form>();
        }
    
        public string cod_usl { get; set; }
        public string mnk { get; set; }
        public string mnk2 { get; set; }
        public int usl_id { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<uslug_form> uslug_form { get; set; }
    }
}