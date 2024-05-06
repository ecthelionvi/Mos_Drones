using Accessors.Accessors;
using Accessors.DBModels;
using Engines.BizLogic;
using Managers.Helpers;
using Managers.Models;

namespace Managers;

//Think of this class and its methods as having no actually functionality other than calling other methods
public class DroneManager
{
    public static List<Drone> GetDrones()
    {
        
        DroneEngine.UpdateDroneStatus();
        
        List<DroneDataModel> droneList = DroneAccessor.GetDroneList();
        List<Drone> drones = new List<Drone>();
        
        foreach (DroneDataModel droneDataModel in droneList)
        {
            drones.Add(DroneHelper.ConvertDroneDataModelToDroneModel(droneDataModel));
        }
        
        return new List<Drone>();
    }
}