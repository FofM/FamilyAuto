﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class FamilyAutoEntities : DbContext
    {
        public FamilyAutoEntities()
            : base("name=FamilyAutoEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Vehicle> Vehicles { get; set; }
        public virtual DbSet<VehicleEngine> VehicleEngines { get; set; }
        public virtual DbSet<VehicleFeature> VehicleFeatures { get; set; }
        public virtual DbSet<VehicleHistory> VehicleHistories { get; set; }
        public virtual DbSet<VehiclePicture> VehiclePictures { get; set; }
        public virtual DbSet<Articles> Articles { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<SoldVehicles> SoldVehicles { get; set; }
        public virtual DbSet<Supplier> Supplier { get; set; }
        public virtual DbSet<ServiceOrder> ServiceOrder { get; set; }
    }
}
