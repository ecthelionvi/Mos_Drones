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

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;

        DepotDataModel other = (DepotDataModel)obj;
        return (DepotId == other.DepotId && DepotAddress.Equals(other.DepotAddress));
    }

    public override string ToString()
    {
        return $"depotId: {DepotId}\n{DepotAddress}";
    }
}
