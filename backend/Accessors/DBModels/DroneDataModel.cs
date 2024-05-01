namespace Accessors.DBModels;

public class DroneDataModel
{
    public int DroneId { get; set; }
    public string TransitStatus { get; set; }
    public OrderDataModel? Order { get; set; }
    public DepotDataModel? CurrentDepot { get; set; }

    public DroneDataModel(int droneId, string transitStatus, OrderDataModel? order, DepotDataModel? currentDepot)
    {
        this.DroneId = droneId;
        this.TransitStatus = transitStatus;
        this.Order = order;
        this.CurrentDepot = currentDepot;
    }
    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;

        DroneDataModel other = (DroneDataModel)obj;

        bool currentDepotEqual = (CurrentDepot == null && other.CurrentDepot == null) ||
                         (CurrentDepot != null && CurrentDepot.Equals(other.CurrentDepot));

        return (DroneId == other.DroneId && TransitStatus == other.TransitStatus && Order.Equals(other.Order)
                && currentDepotEqual);
    }

    public override string ToString()
    {
        return $"droneId: {DroneId}\nTransit Status: {TransitStatus}\n{Order}{CurrentDepot}";
    }
}
