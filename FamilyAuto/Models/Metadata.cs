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

        public bool Warranty { get; set; }

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
        [DataType(DataType.Date)]
        public System.DateTime DateSold { get; set; }
    }
}