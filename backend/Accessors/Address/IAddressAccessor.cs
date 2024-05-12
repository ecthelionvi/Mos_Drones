using System.Data.SqlClient;
using System.Collections.Generic;
using Accessors.Address.Models;

namespace Accessors.Address
{
    public interface IAddressAccessor
    {
        List<AddressDataModel> GetAddressList();
        AddressDataModel GetAddress(int addressId);
        Task<int> InsertAddress(AddressDataModel a);
    }
}