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
    
    public partial class mkao
    {
        public int ID { get; set; }
        public string FILE_NAME { get; set; }
        public string FILE_EXT { get; set; }
        public string DEPENDENCY { get; set; }
        public int YEAR { get; set; }
        public int MONTH { get; set; }
        public int FORM_VERSION { get; set; }
        public int DB_VERSION { get; set; }
        public Nullable<System.DateTime> DATE_CREATE { get; set; }
        public byte[] FILE { get; set; }
    }
}
