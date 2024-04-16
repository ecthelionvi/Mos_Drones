namespace Accessors.DBModels;

public class DroneDataModel
{
    public int DroneId { get; set; }
    public string TransitStatus { get; set; }
    public OrderDataModel Order { get; set; }
    public DepotDataModel? CurrentDepot { get; set; }

    public DroneDataModel(int droneId, string transitStatus, OrderDataModel order, DepotDataModel? currentDepot)
    {
        this.DroneId = droneId;
        this.TransitStatus = transitStatus;
        this.Order = order;
        this.CurrentDepot = currentDepot;
    }
    
}
