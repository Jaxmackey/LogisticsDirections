//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DerectionSender
{
    using System;
    using System.Collections.Generic;
    
    public partial class IndexNumbers
    {
        public System.Guid Id { get; set; }
        public string Number { get; set; }
        public Nullable<System.Guid> FK_CountryIndex { get; set; }
    
        public virtual Countries Countries { get; set; }
    }
}