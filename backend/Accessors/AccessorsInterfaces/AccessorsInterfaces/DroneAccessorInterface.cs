using System.Data.SqlClient;
using System.Data.SqlTypes;
using Accessors.DBModels;
using Microsoft.AspNetCore.Components.Web;

namespace Accessors.Accessors
{
    interface IDroneAccessor
    {
        public static DroneDataModel GetDrone(int droneId);
        public static List<DroneDataModel> GetDroneList();
    }
}