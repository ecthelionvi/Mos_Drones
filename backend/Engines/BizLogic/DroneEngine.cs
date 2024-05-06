using System;
using Accessors.Accessors;
using Accessors.DBModels;

namespace Engines.BizLogic 
{
    public class DroneEngine
    {
        public static void UpdateDroneStatus()
        {
            List<OrderDataModel> activeOrders = OrderAccessor.GetActiveOrders();
            List<DroneDataModel> drones = DroneAccessor.GetDroneList();
            
            foreach (OrderDataModel order in activeOrders)
            {
                if (!order.Status.Contains("Drone-at-Depot"))
                {
                    foreach (DroneDataModel drone in drones)
                    {
                        if (order.Status == "Drone-in-Route to Dropoff")
                        {
                            drone.TransitStatus = "Drone-in-Route to " + order.ShippedTo.AddressLine;
                        } else if (order.Status == "Drone-in-Route to Pickup")
                        {
                            drone.TransitStatus = "Drone-in-Route to " + order.ShippedFrom.AddressLine;
                        }
                        else
                        {
                            drone.TransitStatus = order.Status.Replace("Package", "Drone");
                        }
                        DroneAccessor.UpdateDroneStatus(drone.DroneId, drone.TransitStatus);
                    }
                }
            }
        }
    }
}
