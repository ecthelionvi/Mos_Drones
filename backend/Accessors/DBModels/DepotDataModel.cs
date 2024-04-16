namespace Accessors.DBModels;

public class DepotDataModel
{
    public int DepotId { get; set; }
    public AddressDataModel DepotAddress { get; set; }

    public DepotDataModel(int depotId, AddressDataModel depotAddress)
    {
        this.DepotId = depotId;
        this.DepotAddress = depotAddress;
    }

}