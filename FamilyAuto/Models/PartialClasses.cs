using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FamilyAuto.Models
{
    [MetadataType(typeof(VehicleMetadata))]
    public partial class Vehicle
    {
    }

    [MetadataType(typeof(VehicleHistoryMetadata))]
    public partial class VehicleHistory
    {
    }

    [MetadataType(typeof(VehicleFeatureMetadata))]
    public partial class VehicleFeature
    {
    }

    [MetadataType(typeof(SoldVehiclesMetadata))]
    public partial class SoldVehicles
    {
        public string VehicleIdName
        {
            get
            {
                return VehicleId + " - " + Vehicle.Make;
            }
        }

        public string CustomerIdName
        {
            get
            {
                return CustomerId + " - " + Customers.FirstName + " " + Customers.LastName;
            }
        }
    }

    [MetadataType(typeof(VehicleEngineMetadata))]
    public partial class VehicleEngine
    {
    }

    [MetadataType(typeof(ArticlesMetadata))]
    public partial class Articles
    {
    }

    [MetadataType(typeof(CustomersMetadata))]
    public partial class Customers
    {
    }

    [MetadataType(typeof(SupplierMetadata))]
    public partial class Supplier
    {
    }
}