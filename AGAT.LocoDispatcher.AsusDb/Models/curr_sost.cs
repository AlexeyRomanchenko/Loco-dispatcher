//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AGAT.LocoDispatcher.AsusDb.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class curr_sost
    {
        public int sostav_id { get; set; }
        public string cod_sost { get; set; }
        public string st_prib { get; set; }
        public string st_otpr { get; set; }
        public Nullable<System.DateTime> data_sost { get; set; }
        public string stanc { get; set; }
        public string vid_tr { get; set; }
        public byte razr_tr { get; set; }
        public string stPos { get; set; }
        public string PV_cod { get; set; }
        public string PV_fio_perev { get; set; }
        public string PV_codPerev { get; set; }
    
        public virtual sostav sostav { get; set; }
    }
}
