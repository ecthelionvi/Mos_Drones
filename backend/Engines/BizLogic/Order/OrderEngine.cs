using System;
using Accessors.Address.Models;
using Accessors.API.OpenRoute;
using Accessors.Depot;
using Accessors.Depot.Models;
using Accessors.Drone;
using Accessors.Drone.Models;
using Accessors.Order;
using Accessors.Order.Models;
using GeoCoordinatePortable;


namespace Engines.BizLogic.Order
{
    public class OrderEngine : IOrderEngine
    {
        private readonly IOrderAccessor _orderAccessor;
        private readonly IDepotAccessor _depotAccessor;
        private readonly IDroneAccessor _droneAccessor;

        public OrderEngine(IOrderAccessor orderAccessor, IDepotAccessor depotAccessor, IDroneAccessor droneAccessor)
        {
            _orderAccessor = orderAccessor;
            _depotAccessor = depotAccessor;
            _droneAccessor = droneAccessor;
        }
        public DateTime GetDeliveryDate(DateTime shippedDate, AddressDataModel origin, AddressDataModel destination)
        {
            DepotDataModel pickup = GetClosestDepot(origin);
            DepotDataModel deliveryDepot = GetClosestDepot(destination);

            List<DepotDataModel> depotList = _depotAccessor.GetDepotList();
            
            int pickupIdx = depotList.IndexOf(pickup);
            int deliveryIdx = depotList.IndexOf(deliveryDepot);

            //gets the total distance in miles between the depot and the address there and back
            double pickupDistance = 2 * 0.00062137 * DistanceBetween(origin.Coordinates.Longitude,
                origin.Coordinates.Latitude, pickup.DepotAddress.Coordinates.Longitude,
                pickup.DepotAddress.Coordinates.Latitude);
            double dropoffDistance = 2 * 0.00062137 * DistanceBetween(destination.Coordinates.Longitude,
                destination.Coordinates.Latitude, deliveryDepot.DepotAddress.Coordinates.Longitude,
                deliveryDepot.DepotAddress.Coordinates.Latitude);
            
            //20 minutues between each depot (10 miles * 30 miles/hour)
            //10 Minutes at each depot to switch packages
            //Number of minutes between 
            //Drones travel at 30 miles per hour, so dropoff and pickup distance is multiplied by 2 to calculate travel time
            int numRouteDepots = Math.Abs(deliveryIdx - pickupIdx);
            
            double deliveryTime = ((numRouteDepots - 1) * 20) + (numRouteDepots * 10);
            deliveryTime += (pickupDistance + dropoffDistance) * 2;
            
            return shippedDate.AddMinutes(deliveryTime);
        }

        public string GetOrderStatus(int orderId)
        {
            string status = "";
            OrderDataModel dm = _orderAccessor.GetOrderWithOrderId(orderId);

            if (dm.DeliveryDate.CompareTo(DateTime.Now) <= 0)
            {
                status = "Delivered";
            }
            else
            {
                TimeSpan timeInTrasit = DateTime.Now.Subtract(dm.ShipDate);
                
                DepotDataModel pickup = GetClosestDepot(dm.ShippedFrom);
                DepotDataModel deliveryDepot = GetClosestDepot(dm.ShippedTo);
                
                List<DepotDataModel> depotList = _depotAccessor.GetDepotList();
                
                int pickupIdx = depotList.IndexOf(pickup);
                int deliveryIdx = depotList.IndexOf(deliveryDepot);
                
                double pickupDistance = 2 * 0.00062137 * DistanceBetween(dm.ShippedFrom.Coordinates.Longitude,
                    dm.ShippedFrom.Coordinates.Latitude, pickup.DepotAddress.Coordinates.Longitude,
                    pickup.DepotAddress.Coordinates.Latitude);
                double dropoffDistance = 2 * 0.00062137 * DistanceBetween(dm.ShippedTo.Coordinates.Longitude,
                    dm.ShippedTo.Coordinates.Latitude, deliveryDepot.DepotAddress.Coordinates.Longitude,
                    deliveryDepot.DepotAddress.Coordinates.Latitude);
                
                int numRouteDepots = Math.Abs(deliveryIdx - pickupIdx);

                List<DateTime> routeTimes = new List<DateTime>();
                routeTimes.Add(dm.ShipDate.AddMinutes(pickupDistance));
                routeTimes.Add(routeTimes[routeTimes.Count - 1].AddMinutes(pickupDistance));
                
                foreach (DepotDataModel depot in depotList.GetRange(Math.Min(pickupIdx, deliveryIdx), numRouteDepots + 1))
                {
                    routeTimes.Add(routeTimes[routeTimes.Count - 1].AddMinutes(10));
                    if (depot.DepotId != deliveryDepot.DepotId){
                        routeTimes.Add(routeTimes[routeTimes.Count - 1].AddMinutes(20));
                    }
                }
                routeTimes.Add(routeTimes[routeTimes.Count - 1].AddMinutes(dropoffDistance));

                foreach (DateTime time in routeTimes)
                {
                    if (time.CompareTo(DateTime.Now) > 0)
                    {
                        int position = routeTimes.IndexOf(time);
                        if (position < 1)
                        {
                            status = "Drone-in-Route to Pickup";
                        }
                        else if (position == routeTimes.Count - 1)
                        {
                            status = "Drone-in-Route to Dropoff";
                        }
                        else if (position % 2 == 0)
                        {
                            position++;
                            string depotName = pickupIdx < deliveryIdx ? depotList[pickupIdx + (position / 2)].DepotId.ToString() : depotList[pickupIdx - (position / 2)].DepotId.ToString();
                            status = "Package-at-Depot " + depotName;
                        }
                        else
                        {
                            string depotName = pickupIdx < deliveryIdx ? depotList[pickupIdx + ((1 + position) / 2)].DepotId.ToString() : depotList[pickupIdx - ((1 + position) / 2)].DepotId.ToString();
                            status = "Package-in-Route to Depot " + depotName;
                        }

                        break;
                    }
                }

            }
            return status;
        }

        public async Task<Boolean> ValidateOrderRequest(AddressDataModel destination)
        {
            var openRouteAccessor = new OpenRouteAccessor();
            Coordinate coordinate = await openRouteAccessor.GetCoordinatesAsync(destination);
            destination.Coordinates = coordinate;
            Boolean result = IsDeliveryRequestInRange(destination);
            
            return result;
        }
        
        //Ensures it is within 5 miles of at least 1 depot
        //returns the depot closest
        public Boolean IsDeliveryRequestInRange(AddressDataModel address)
        {
            List<DepotDataModel> depots = _depotAccessor.GetDepotList();
            DepotDataModel? closest = null;
            double leastDistance = 5;

            foreach (var depot in depots)
            {
                double lon1 = address.Coordinates.Longitude;
                double lat1 = address.Coordinates.Latitude;
                double lon2 = depot.DepotAddress.Coordinates.Longitude;
                double lat2 = depot.DepotAddress.Coordinates.Latitude;
                
                double distance = DistanceBetween(lon1, lat1, lon2, lat2);
                double distanceInMiles = distance * 0.00062137; // Convert meters to miles

                if (distanceInMiles <= 5)
                {
                    return true;
                }
            }
            return false;
        }
        public static double DistanceBetween(double lon1, double lat1, double lon2, double lat2)
        {
            var coord1 = new GeoCoordinate(lat1, lon1);
            var coord2 = new GeoCoordinate(lat2, lon2);

            return coord1.GetDistanceTo(coord2);
        }
        
        public DepotDataModel GetClosestDepot(AddressDataModel address)
        {
            List<DepotDataModel> depots = _depotAccessor.GetDepotList();
            DepotDataModel closest = null;
            double leastDistance = 5;

            foreach (var depot in depots)
            {
                double lon1 = address.Coordinates.Longitude;
                double lat1 = address.Coordinates.Latitude;
                double lon2 = depot.DepotAddress.Coordinates.Longitude;
                double lat2 = depot.DepotAddress.Coordinates.Latitude;
                
                double distance = DistanceBetween(lon1, lat1, lon2, lat2);
                double distanceInMiles = distance * 0.00062137; // Convert meters to miles

                if (distanceInMiles < leastDistance)
                {
                    leastDistance = distanceInMiles;
                    closest = depot;
                }
            }
            return closest;
        }
        
        public void UpdateDroneStatus()
        {
            List<OrderDataModel> activeOrders = _orderAccessor.GetActiveOrders();
            List<DroneDataModel> nonUpdatedDrones = _droneAccessor.GetDroneList();
            List<DroneDataModel> updatedDrones = new List<DroneDataModel>();

            foreach (OrderDataModel order in activeOrders)
            {
                order.Status = GetOrderStatus(order.OrderId ?? 0);
                if (!order.Status.Contains("Package-at-Depot"))
                {
                    DroneDataModel drone;
                    if (order.Status == "Drone-in-Route to Dropoff")
                    {
                        DepotDataModel closest = GetClosestDepot(order.ShippedTo);
                        drone = nonUpdatedDrones.Find(d => d.CurrentDepot.Equals(closest));
                        drone.TransitStatus = "Drone-in-Route to " + order.ShippedTo.AddressLine;
                        drone.Order = order;
                    }
                    else if (order.Status == "Drone-in-Route to Pickup")
                    {
                        DepotDataModel closest = GetClosestDepot(order.ShippedFrom);
                        drone = nonUpdatedDrones.Find(d => d.CurrentDepot.Equals(closest));
                        drone.TransitStatus = "Drone-in-Route to " + order.ShippedFrom.AddressLine;
                        drone.Order = order;
                    }
                    else
                    {
                        DepotDataModel pickup = GetClosestDepot(order.ShippedFrom);
                        DepotDataModel delivery = GetClosestDepot(order.ShippedTo);

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
                _droneAccessor.UpdateDroneStatus(drone.DroneId, drone.TransitStatus);
            }

            foreach (DroneDataModel drone in updatedDrones)
            {
                _droneAccessor.UpdateDroneStatus(drone.DroneId, drone.TransitStatus);
            }
        }
    }
}
