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
    
    public partial class SoldVehicles
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public int CustomerId { get; set; }
        public System.DateTime DateSold { get; set; }
        public System.DateTime DateCreated { get; set; }
        public int FinalPrice { get; set; }
    
        public virtual Customers Customers { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }
}