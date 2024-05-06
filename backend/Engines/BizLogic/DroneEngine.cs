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
                if (!order.Status.Contains("Package-at-Depot"))
                {
                    foreach (DroneDataModel drone in drones)
                    {
                        if (order.Status == "Drone-in-Route to Dropoff")
                        {
                            DepotDataModel closest = AddressEngine.GetClosestDepot(order.ShippedFrom);
                            if (drone.CurrentDepot.Equals(closest))
                            {
                                drone.TransitStatus = "Drone-in-Route to " + order.ShippedTo.AddressLine;
                            }
                        } else if (order.Status == "Drone-in-Route to Pickup")
                        {
                            DepotDataModel closest = AddressEngine.GetClosestDepot(order.ShippedTo);
                            if (drone.CurrentDepot.Equals(closest))
                            {
                                drone.TransitStatus = "Drone-in-Route to " + order.ShippedFrom.AddressLine;
                            }
                        }
                        else
                        {
                            string inxFromStatus = order.Status.Replace("Package-in-Route to Depot ", "");
                            int depotIdx = int.Parse(inxFromStatus) - 1;
                            if (drone.CurrentDepot.DepotId == depotIdx)
                            {
                                drone.TransitStatus = order.Status.Replace("Package", "Drone");
                            }
                        }
                        DroneAccessor.UpdateDroneStatus(drone.DroneId, drone.TransitStatus);
                    }
                }
            }
        }
    }
}
