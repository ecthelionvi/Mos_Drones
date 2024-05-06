using Accessors.DBModels;
using Managers.Models;

namespace Managers.Helpers;

public class DroneHelper
{
    public static DroneDataModel ConvertDroneModelToDroneDataModel(Drone drone)
    {
        OrderDataModel orderDataModel = drone.Order == null ? null : OrderHelper.OrderToOrderDataModel(drone.Order);
        DepotDataModel depotDataModel = drone.CurrentDepot == null ? null : DepotHelper.ConvertDepotModelToDepotDataModel(drone.CurrentDepot);
        return new DroneDataModel(drone.DroneId, drone.TransitStatus, orderDataModel, depotDataModel);
    }

    public static Drone ConvertDroneDataModelToDroneModel(DroneDataModel droneDataModel)
    {
        Order order = droneDataModel.Order == null ? null : OrderHelper.OrderDataModelToOrderModel(droneDataModel.Order);
        Depot depot = droneDataModel.CurrentDepot == null ? null : DepotHelper.ConvertDepotDataModelToDepotModel(droneDataModel.CurrentDepot);
        return new Drone(droneDataModel.DroneId, droneDataModel.TransitStatus, order, depot);
    }
}