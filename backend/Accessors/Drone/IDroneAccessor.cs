using System.Data.SqlClient;
using System.Data.SqlTypes;
using Accessors.Drone.Models;
using Microsoft.AspNetCore.Components.Web;

namespace Accessors.Drone
{
    public interface IDroneAccessor
    {
        DroneDataModel GetDrone(int droneId);
        List<DroneDataModel> GetDroneList();
        void UpdateDroneStatus(int droneId, string newStatus, int? orderId);
    }
}