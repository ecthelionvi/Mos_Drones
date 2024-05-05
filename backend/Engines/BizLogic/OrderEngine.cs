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

            double pickupDistance = 2 * AddressEngine.DistanceBetween(origin.Coordinates.Longitude,
                origin.Coordinates.Latitude, pickup.DepotAddress.Coordinates.Longitude,
                pickup.DepotAddress.Coordinates.Latitude);
            double dropoffDistance = 2 * AddressEngine.DistanceBetween(destination.Coordinates.Longitude,
                destination.Coordinates.Latitude, deliveryDepot.DepotAddress.Coordinates.Longitude,
                deliveryDepot.DepotAddress.Coordinates.Latitude);
            
            //20 minutues between each depot (10 miles * 30 miles/hour)
            //10 Minutes at each depot to switch packages
            //Number of minutes between 
            int numRouteDepots = Math.Abs(deliveryIdx - pickupIdx);
            
            double deliveryTime = ((numRouteDepots - 1) * 20) + (numRouteDepots * 10);
            deliveryTime += ((30 / pickupDistance) + (30 / dropoffDistance)) * 60;
            
            return shippedDate.AddMinutes(deliveryTime);
        }

        public static string getOrderStatus(DateTime deliveryDate)
        {
            int compare = deliveryDate.CompareTo(DateTime.Now);
            return compare < 0 ? "Package-In-Transit" : "delivered";
        }

        public static string getAdminOrderStatus(DateTime deliveryDate)
        {
            int compare = deliveryDate.CompareTo(DateTime.Now);
            return compare < 0 ? "Package-In-Transit" : "delivered";
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
