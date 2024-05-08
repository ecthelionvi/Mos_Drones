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
            List<DroneDataModel> nonUpdatedDrones = DroneAccessor.GetDroneList();
            List<DroneDataModel> updatedDrones = new List<DroneDataModel>();

            foreach (OrderDataModel order in activeOrders)
            {
                order.Status = OrderEngine.GetOrderStatus(order.OrderId ?? 0);
                if (!order.Status.Contains("Package-at-Depot"))
                {
                    DroneDataModel drone;
                    if (order.Status == "Drone-in-Route to Dropoff")
                    {
                        DepotDataModel closest = AddressEngine.GetClosestDepot(order.ShippedTo);
                        drone = nonUpdatedDrones.Find(d => d.CurrentDepot.Equals(closest));
                        drone.TransitStatus = "Drone-in-Route to " + order.ShippedTo.AddressLine;
                        drone.Order = order;
                    }
                    else if (order.Status == "Drone-in-Route to Pickup")
                    {
                        DepotDataModel closest = AddressEngine.GetClosestDepot(order.ShippedFrom);
                        drone = nonUpdatedDrones.Find(d => d.CurrentDepot.Equals(closest));
                        drone.TransitStatus = "Drone-in-Route to " + order.ShippedFrom.AddressLine;
                        drone.Order = order;
                    }
                    else
                    {
                        DepotDataModel pickup = AddressEngine.GetClosestDepot(order.ShippedFrom);
                        DepotDataModel delivery = AddressEngine.GetClosestDepot(order.ShippedTo);

                        string inxFromStatus = order.Status.Replace("Package-in-Route to Depot ", "");
                        int depotIdx = pickup.DepotId < delivery.DepotId
                            ? Int32.Parse(inxFromStatus) - 1
                            : Int32.Parse(inxFromStatus) + 1;
                        drone = nonUpdatedDrones.Find(d => d.CurrentDepot.DepotId.Equals(depotIdx));
                        drone.TransitStatus = order.Status.Replace("Package", "Drone");
                        drone.Order = order;
                    }

                    updatedDrones.Add(drone);
                    nonUpdatedDrones.RemoveAll(d => d.DroneId == drone.DroneId);
                }
            }

            foreach (DroneDataModel drone in nonUpdatedDrones)
            {
                drone.TransitStatus = "Free";
                drone.Order = null;
                DroneAccessor.UpdateDroneStatus(drone.DroneId, drone.TransitStatus);
            }

            foreach (DroneDataModel drone in updatedDrones)
            {
                DroneAccessor.UpdateDroneStatus(drone.DroneId, drone.TransitStatus);
            }
        }
    }
}