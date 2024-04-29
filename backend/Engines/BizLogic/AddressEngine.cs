using System;
using Accessors.DBModels;
using Accessors.Accessors;
using System.Threading.Tasks;
using System.Device.Location;

namespace Engines.BizLogic 
{
    public class AddressEngine
    {
        // Ensures it is within 5 miles of at least 1 depot
        public static void isDeliveryRequestInRange(AddressDataModel address)
        {
            float range = float.MaxValue;
            int i = 0;
            List<DepotDataModel> depots = DepotAccessor.GetDepotList();

            for (i = 0; i < depots.Count; i++)
            {
                float lon1 = address.Coordinates.Longitude;
                float lat1 = address.Coordinates.Latitude;
                var sCoord = new GeoCoordinate(lon1, lat1);
                float lon2 = depots[i].DepotAddress.Coordinates.Longitude;
                float lat2 = depots[i].DepotAddress.Coordinates.Latitude;
                var eCoord = new GeoCoordinate(lon2, lat2);

                range = sCoord.GetDistanceTo(eCoord);
                range = range * 0.00062137;
                if (range < 5)
                {
                    return;
                }
            }
            throw new ArgumentException("Delivery is not in range");
        }

        // If long and lat are null in database, convert address, save to database, and return coordinates
        public async void getLatitudeAndLongitude(AddressDataModel address)
        {
            var openRouteAccessor = new OpenRouteAccessor();
            Coordinate coordinate = await openRouteAccessor.GetCoordinatesAsync(address);
            return coordinate;
        }
    }
}
