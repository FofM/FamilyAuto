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
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public Nullable<System.DateTime> HUValidUntil;

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public Nullable<System.DateTime> FirstRegistration;

        public bool Warranty { get; set; }

    }

    public class VehicleFeatureMetadata
    {
        public bool AirConditioning { get; set; }
        public bool Airbags { get; set; }
        public bool ParkingSensor { get; set; }
        public bool Sports { get; set; }
    }

    public class SoldVehiclesMetadata
    {
        [DataType(DataType.Date)]
        public System.DateTime DateSold { get; set; }
    }
}