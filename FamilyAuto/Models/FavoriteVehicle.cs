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
    
    public partial class FavoriteVehicle
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int VehicleId { get; set; }
    
        public virtual AspNetUsers AspNetUsers { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }
}