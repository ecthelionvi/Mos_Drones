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
    //should handle the actions of actions on the app, calls managers
    //should have a controller for each page

    // [HttpGet]
    // public JsonResult GetDrones()
    // {
    //     
    //     return new JsonResult();
    // }
    //
    // [HttpPost]
    // public JsonResult SaveUser(UserServiceModel userService)
    // {
    //
    //     return new JsonResult();
    // }
}