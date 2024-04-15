using System.Data;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Text.Json.Nodes;
using Managers.Models;

namespace Service.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DroneController : Controller
{
    [HttpGet]
    public JsonResult GetDrones()
    {
        //returns all data we have on all our drones
        return new JsonResult();
    }
    
}