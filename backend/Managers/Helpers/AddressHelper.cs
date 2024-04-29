using Accessors.DBModels;
using Managers.Models;

namespace Managers.Helpers;

public class AddressHelper
{
    public static Address AddressDataModelToAddress(AddressDataModel addressDataModel)
    {
        return new Address
        (
            addressDataModel.AddressId,
            addressDataModel.City,
            addressDataModel.State,
            addressDataModel.ZipCode,
            addressDataModel.AddressLine
        );
}

    public static AddressDataModel AddressToAddressDataModel(Address address)
    {
        return new AddressDataModel
        (
            address.AddressId,
            address.City,
            address.State,
            address.ZipCode,
            address.AddressLine,
            null
        );
    }
}