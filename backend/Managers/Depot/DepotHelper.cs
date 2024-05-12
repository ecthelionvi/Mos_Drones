using Accessors.Depot.Models;
using Managers.Address;

namespace Managers.Depot;

public class DepotHelper
{
    public static DepotDataModel ConvertDepotModelToDepotDataModel(Depot depot)
    {
        return new DepotDataModel(depot.DepotId, AddressHelper.AddressToAddressDataModel(depot.DepotAddress));
    }
    
    public static Depot ConvertDepotDataModelToDepotModel(DepotDataModel depotDataModel)
    {
        return new Depot(depotDataModel.DepotId, AddressHelper.AddressDataModelToAddress(depotDataModel.DepotAddress));
    }
}