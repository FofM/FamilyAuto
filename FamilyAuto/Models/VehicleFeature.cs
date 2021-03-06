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
    
    public partial class VehicleFeature
    {
        public int Id { get; set; }
        public string ExteriorColor { get; set; }
        public string InteriorColor { get; set; }
        public Nullable<bool> AirConditioning { get; set; }
        public string InteriorFeatures { get; set; }
        public string Security { get; set; }
        public Nullable<bool> Airbags { get; set; }
        public Nullable<bool> ParkingSensor { get; set; }
        public Nullable<bool> Sports { get; set; }
        public string InteriorMaterial { get; set; }
    
        public virtual Vehicle Vehicle { get; set; }
    }
}
