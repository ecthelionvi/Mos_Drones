using System.Data.SqlClient;
using System.Collections.Generic;
using Accessors.ConnectionAccessor;
using Accessors.DBModels;

namespace Accessors.Accessors
{
    interface IAddressAccessor
    {
        List<AddressDataModel> GetAddressList();
        AddressDataModel GetAddress(int addressId);
        int InsertAddress(AddressDataModel a);
    }
}