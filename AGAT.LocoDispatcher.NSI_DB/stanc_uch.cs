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
    
    public partial class stanc_uch
    {
        public string stanc { get; set; }
        public byte vid { get; set; }
        public int npp { get; set; }
        public string prinadl { get; set; }
        public string stanc_r { get; set; }
        public string stanc_l { get; set; }
        public string up_gr_stanc { get; set; }
        public string down_gr_stanc { get; set; }
        public int uch_id { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public int ugol { get; set; }
    
        public virtual uchastok uchastok { get; set; }
    }
}