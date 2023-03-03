using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VehicleDashboard.Models
{
    public class VehicleDashboardModel
    {
        public UsedVehicleDashboard UsedVehicleDashboard { get; set; }
        public NewVehicleDashboard NewVehicleDashboard { get; set; }
    }

    public class VehicleOptionModel
    {
        public string Location { get; set; }
        public string Condition { get; set; }
        public UsedVehicleDashboard UsedVehicleDashboard { get; set; }
        public NewVehicleDashboard NewVehicleDashboard { get; set; }
        public List<VehicleData> VehicleData { get; set; }
        public List<VehicleImages> VehicleImages { get; set; }
    }
}