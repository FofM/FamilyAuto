//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FamilyAuto.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class VehicleHistory
    {
        public int Id { get; set; }
        public string Purpose { get; set; }
        public Nullable<int> NoOfOwners { get; set; }
        public Nullable<System.DateTime> HUValidUntil { get; set; }
        public bool Warranty { get; set; }
        public Nullable<int> Mileage { get; set; }
        public Nullable<System.DateTime> FirstRegistration { get; set; }
    
        public virtual Vehicle Vehicle { get; set; }
    }
}
