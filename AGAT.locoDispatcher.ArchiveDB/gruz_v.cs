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
    
    public partial class gruz_v
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public gruz_v()
        {
            this.oper_v = new HashSet<oper_v>();
            this.otpravka = new HashSet<otpravka>();
        }
    
        public string vid { get; set; }
        public string ves_gr { get; set; }
        public string st_destn { get; set; }
        public string cod_gruz { get; set; }
        public string cod_grpl { get; set; }
        public string mach { get; set; }
        public string cod_prk_gr { get; set; }
        public string negab_vg { get; set; }
        public string plomb { get; set; }
        public string knt_srt { get; set; }
        public string knt_krt { get; set; }
        public string srok_dostav { get; set; }
        public string nplf { get; set; }
        public string nod { get; set; }
        public string pogr_st { get; set; }
        public string prim { get; set; }
        public int gruz_id { get; set; }
        public int dviz_id { get; set; }
        public string npmr { get; set; }
        public string sobst_komp { get; set; }
        public string PV_Gruz { get; set; }
        public string PV_PrizV { get; set; }
    
        public virtual dviz dviz { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<oper_v> oper_v { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<otpravka> otpravka { get; set; }
    }
}
