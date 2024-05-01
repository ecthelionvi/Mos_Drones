using System.Data.SqlClient;
using System.Data.SqlTypes;
using Accessors.DBModels;
using Microsoft.AspNetCore.Components.Web;

namespace Accessors.Accessors
{
    interface IDroneAccessor
    {
        DroneDataModel GetDrone(int droneId);
        List<DroneDataModel> GetDroneList();
    }
}