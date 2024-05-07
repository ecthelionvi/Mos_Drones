using System;
using Accessors.Accessors;
using Accessors.DBModels;

namespace Engines.BizLogic 
{
    public class OrderEngine
    {
        public static DateTime getDeliveryDate(DateTime shippedDate, AddressDataModel origin, AddressDataModel destination)
        {
            DepotDataModel pickup = AddressEngine.GetClosestDepot(origin);
            DepotDataModel deliveryDepot = AddressEngine.GetClosestDepot(destination);

            List<DepotDataModel> depotList = DepotAccessor.GetDepotList();
            depotList.Sort((depot1, depot2) => depot2.DepotAddress.Coordinates.Latitude.CompareTo(depot1.DepotAddress.Coordinates.Latitude));

            int pickupIdx = depotList.IndexOf(pickup);
            int deliveryIdx = depotList.IndexOf(deliveryDepot);

            //gets the total distance in miles between the depot and the address there and back
            double pickupDistance = 2 * 0.00062137 * AddressEngine.DistanceBetween(origin.Coordinates.Longitude,
                origin.Coordinates.Latitude, pickup.DepotAddress.Coordinates.Longitude,
                pickup.DepotAddress.Coordinates.Latitude);
            double dropoffDistance = 2 * 0.00062137 * AddressEngine.DistanceBetween(destination.Coordinates.Longitude,
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

        public static string GetOrderStatus(int orderId)
        {
            string status = "";
            OrderDataModel dm = OrderAccessor.GetOrderWithOrderId(orderId);

            if (dm.DeliveryDate.CompareTo(DateTime.Now) <= 0)
            {
                status = "Delivered";
            }
            else
            {
                TimeSpan timeInTrasit = DateTime.Now.Subtract(dm.ShipDate);
                
                DepotDataModel pickup = AddressEngine.GetClosestDepot(dm.ShippedFrom);
                DepotDataModel deliveryDepot = AddressEngine.GetClosestDepot(dm.ShippedTo);
                
                List<DepotDataModel> depotList = DepotAccessor.GetDepotList();
                depotList.Sort((depot1, depot2) => depot2.DepotAddress.Coordinates.Latitude.CompareTo(depot1.DepotAddress.Coordinates.Latitude));

                int pickupIdx = depotList.IndexOf(pickup);
                int deliveryIdx = depotList.IndexOf(deliveryDepot);
                
                double pickupDistance = 2 * 0.00062137 * AddressEngine.DistanceBetween(dm.ShippedFrom.Coordinates.Longitude,
                    dm.ShippedFrom.Coordinates.Latitude, pickup.DepotAddress.Coordinates.Longitude,
                    pickup.DepotAddress.Coordinates.Latitude);
                double dropoffDistance = 2 * 0.00062137 * AddressEngine.DistanceBetween(dm.ShippedTo.Coordinates.Longitude,
                    dm.ShippedTo.Coordinates.Latitude, deliveryDepot.DepotAddress.Coordinates.Longitude,
                    deliveryDepot.DepotAddress.Coordinates.Latitude);
                
                int numRouteDepots = Math.Abs(deliveryIdx - pickupIdx);

                List<DateTime> routeTimes = new List<DateTime>();
                routeTimes.Add(dm.ShipDate);
                routeTimes.Add(dm.ShipDate.AddMinutes( pickupDistance * 2));
                foreach(DepotDataModel depot in depotList.GetRange(Math.Min(pickupIdx, deliveryIdx), numRouteDepots))
                {
                    routeTimes.Add(routeTimes[routeTimes.Count - 1].AddMinutes(20));
                    routeTimes.Add(routeTimes[routeTimes.Count - 1].AddMinutes(10));
                }
                routeTimes.Add(routeTimes[routeTimes.Count - 1].AddMinutes(dropoffDistance * 2));

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
                            string depotName = depotList[pickupIdx + 1 + position / 2 ].DepotId.ToString();
                            status = "Package-in-Route to Depot " + depotName;
                        }
                        else
                        {
                            position++;
                            string depotName = depotList[pickupIdx + (position / 2)].DepotId.ToString();
                            status = "Package-at-Depot " + depotName;
                        }

                        break;
                    }
                }

            }
            return status;
        }

        public async Task<Boolean> validateOrderRequest(AddressDataModel destination)
        {
            var openRouteAccessor = new OpenRouteAccessor();
            Coordinate coordinate = await openRouteAccessor.GetCoordinatesAsync(destination);
            destination.Coordinates = coordinate;
            Boolean result = AddressEngine.IsDeliveryRequestInRange(destination);
            
            return result;
        }
    }
}
