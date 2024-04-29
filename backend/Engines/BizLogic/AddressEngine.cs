using System;
using Accessors.DBModels;
using Accessors.Accessors;

namespace Engines.BizLogic 
{
    public class AddressEngine
    {

        public static void isDeliveryRequestInRange(AddressDataModel address)
        {
            
        }

        // If long and lat are null in database, convert address, save to database, and return coordinates
        public void getLatitudeAndLongitude(AddressDataModel address)
        {
            Coordinate coordinate = OpenRouteAccessor(address);
            return coordinate;
        }
    }
}
