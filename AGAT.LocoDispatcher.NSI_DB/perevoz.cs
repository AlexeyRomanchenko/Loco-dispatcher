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
    
    public partial class perevoz
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public perevoz()
        {
            this.perev_lok = new HashSet<perev_lok>();
        }
    
        public int id_per { get; set; }
        public string cod_per { get; set; }
        public string mnk_per { get; set; }
        public string mnk_per_l { get; set; }
        public string naim { get; set; }
        public string naim_l { get; set; }
        public byte priznak { get; set; }
        public string PV_prKPS { get; set; }
        public string PV_Ntr { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<perev_lok> perev_lok { get; set; }
    }
}
