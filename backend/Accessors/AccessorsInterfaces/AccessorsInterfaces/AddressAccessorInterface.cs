using System.Data.SqlClient;
using System.Collections.Generic;
using Accessors.ConnectionAccessor;
using Accessors.DBModels;

namespace Accessors.Accessors
{
    interface IAddressAccessor
    {
        public static List<AddressDataModel> GetAddressList();
        public static AddressDataModel GetAddress(int addressId);
        public static int InsertAddress(string city, string state, string zip, string addressLine);
    }
}