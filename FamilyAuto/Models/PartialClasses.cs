using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FamilyAuto.Models
{
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
    }
}