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
    
    public partial class ZAJ_OTRAB
    {
        public System.DateTime date_otr { get; set; }
        public int zv_id { get; set; }
        public int kolvo { get; set; }
        public Nullable<int> prik_id { get; set; }
        public int z_otr { get; set; }
    
        public virtual ZAJ_VAGON ZAJ_VAGON { get; set; }
    }
}