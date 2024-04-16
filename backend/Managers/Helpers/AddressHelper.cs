using Accessors.DBModels;
using Managers.Models;

namespace Managers.Helpers;

public class AddressHelper
{
    public static Address AddressDataModelToAddress(AddressDataModel addressDataModel)
    {
        return new Address
        {
            AddressId = addressDataModel.AddressId,
            City = addressDataModel.City,
            State = addressDataModel.State,
            ZipCode = addressDataModel.ZipCode,
            AddressLine = addressDataModel.AddressLine
        };
}

    public static AddressDataModel AddressToAddressDataModel(Address address)
    {
        return new AddressDataModel
        {
            AddressId = address.AddressId,
            City = address.City,
            State = address.State,
            ZipCode = address.ZipCode,
            AddressLine = address.AddressLine
        };
    }
}