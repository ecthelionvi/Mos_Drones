using System.Data;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Text.Json.Nodes;
using Managers.Models;
using Managers;

namespace Service.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DroneController : Controller
{
    [HttpGet("GetDrones")]
    public JsonResult GetDrones()
    {
        List<Drone> droneList = DroneManager.GetDrones();
        return new JsonResult(droneList);
    }

    [HttpPost("ChangeDepot")]
    public void UpdateDepot([FromBody] Drone drone)
    {
        // updates drone depotId in the drone object
    } 
    
}