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
    
    public partial class perev_lok
    {
        public Nullable<int> id_per { get; set; }
        public string ser_lok { get; set; }
        public string num_lok { get; set; }
        public string cod_sbs { get; set; }
        public Nullable<int> id_ar { get; set; }
    
        public virtual perev_ar perev_ar { get; set; }
        public virtual perevoz perevoz { get; set; }
    }
}