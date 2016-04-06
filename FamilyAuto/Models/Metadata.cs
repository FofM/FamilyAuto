using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FamilyAuto.Models
{
    public class Metadata
    {
    }

    public class VehicleMetadata
    {
        [Display(Name = "Date Uploaded")]
        [DataType(DataType.Date)]
        public System.DateTime DateUploaded { get; set; }
    }

    public class VehicleHistoryMetadata
    {
        [Display(Name = "Owners")]
        public Nullable<int> NoOfOwners { get; set; }

        [Display(Name = "HU Valid Until")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public Nullable<System.DateTime> HUValidUntil;

        [Display(Name = "First Registration")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public Nullable<System.DateTime> FirstRegistration;
    }

    public class VehicleEngineMetadata
    {
        [Display(Name = "Fuel Type")]
        public string FuelType { get; set; }

        [Display(Name = "Cubic Capacity")]
        public Nullable<int> CubicCapacity { get; set; }

        [Display(Name = "Power (KW)")]
        public Nullable<int> Power { get; set; }

        [Display(Name = "Fuel Consumption")]
        public string FuelConsumption { get; set; }

        [Display(Name = "Emission Class")]
        public string EmissionClass { get; set; }

        [Display(Name = "Emission Sticker")]
        public string EmissionSticker { get; set; }
    }

    public class VehicleFeatureMetadata
    {
        [Display(Name = "Exterior Color")]
        public string ExteriorColor { get; set; }

        [Display(Name = "Interior Color")]
        public string InteriorColor { get; set; }

        [Display(Name = "Air Conditioning")]
        public bool AirConditioning { get; set; }

        [Display(Name = "Interior Features")]
        public string InteriorFeatures { get; set; }

        [Display(Name = "Parking Sensor")]
        public bool ParkingSensor { get; set; }

        [Display(Name = "Interior Material")]
        public string InteriorMaterial { get; set; }
    }

    public class SoldVehiclesMetadata
    {
        [Display(Name = "Vehicle ID")]
        public int VehicleId { get; set; }

        [Display(Name = "Customer ID")]
        public int CustomerId { get; set; }

        [Display(Name = "Date Created")]
        [DataType(DataType.Date)]
        public System.DateTime DateCreated { get; set; }

        [Display(Name = "Final Price")]
        public int FinalPrice { get; set; }

        [Display(Name = "Date Sold")]
        [DataType(DataType.Date)]
        public System.DateTime DateSold { get; set; }

        [Display(Name = "Vehicle ID and Make")]
        public string VehicleIdName;

        [Display(Name = "Customer ID and Name")]
        public string CustomerIdName;
    }

    public class ArticlesMetadata
    {
        [Display(Name = "Article Title")]
        public string ArticleTitle { get; set; }

        [Display(Name = "Article Description")]
        public string ArticleDescription { get; set; }

        [Display(Name = "Article Type")]
        public ArticleEnum ArticleType { get; set; }

        [Display(Name = "Date Published")]
        [DataType(DataType.Date)]
        public System.DateTime DateUploaded { get; set; }
    }

    public class CustomersMetadata
    {
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }
    }

    public class SupplierMetadata
    {
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        [Display(Name = "Contact Name")]
        public string ContactName { get; set; }

        [Display(Name = "E-Mail")]
        public string Email { get; set; }

        [Display(Name = "Web Address")]
        public string WebAddress { get; set; }
    }
}