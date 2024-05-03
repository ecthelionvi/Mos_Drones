using System;
using Accessors.DBModels;
using Accessors.Accessors;
using System.Collections.Generic;
using System.Threading.Tasks;
using GeoCoordinatePortable;

namespace Engines.BizLogic 
{
    public class AddressEngine
    {
        //Ensures it is within 5 miles of at least 1 depot
        //returns the depot closest
        public static Boolean IsDeliveryRequestInRange(AddressDataModel address)
        {
            float range = float.MaxValue;
            List<DepotDataModel> depots = DepotAccessor.GetDepotList();
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
        
        public static DepotDataModel GetClosestDepot(AddressDataModel address)
        {
            float range = float.MaxValue;
            List<DepotDataModel> depots = DepotAccessor.GetDepotList();
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
        
    }

}
