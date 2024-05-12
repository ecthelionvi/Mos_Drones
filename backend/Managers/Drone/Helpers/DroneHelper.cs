using Accessors.Depot.Models;
using Accessors.Drone.Models;
using Accessors.Order.Models;
using Managers.Depot;
using Managers.Order.Helpers;

namespace Managers.Drone.Helpers;

public class DroneHelper
{
    public static DroneDataModel ConvertDroneModelToDroneDataModel(Models.Drone drone)
    {
        OrderDataModel orderDataModel = drone.Order == null ? null : OrderHelper.OrderToOrderDataModel(drone.Order);
        DepotDataModel depotDataModel = drone.CurrentDepot == null ? null : DepotHelper.ConvertDepotModelToDepotDataModel(drone.CurrentDepot);
        return new DroneDataModel(drone.DroneId, drone.TransitStatus, orderDataModel, depotDataModel);
    }

    public static Models.Drone ConvertDroneDataModelToDroneModel(DroneDataModel droneDataModel)
    {
        Order.Models.Order order = droneDataModel.Order == null ? null : OrderHelper.OrderDataModelToOrderModel(droneDataModel.Order);
        Depot.Depot depot = droneDataModel.CurrentDepot == null ? null : DepotHelper.ConvertDepotDataModelToDepotModel(droneDataModel.CurrentDepot);
        return new Models.Drone(droneDataModel.DroneId, droneDataModel.TransitStatus, order, depot);
    }
}