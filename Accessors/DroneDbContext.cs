using System.Data;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Service;


//talks to database/implement ef here
public class DroneDbContext
{
    
    private readonly IConfiguration _configuration;

    public DroneDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public JsonResult GetDrones()
    {
        //use entity framework here if wanted
        string query = @"select Id, Status, Destination form dbo.Drones";

        DataTable table = new DataTable();
        string sqlDataSource = _configuration.GetConnectionString("DroneAppConn");
        SqlDataReader myReader;
        using (SqlConnection myCon = new SqlConnection(sqlDataSource))
        {
            myCon.Open();
            using (SqlCommand myCommand = new SqlCommand(query, myCon))
            {
                myReader = myCommand.ExecuteReader();
                table.Load(myReader);
                myReader.Close();
                myCon.Close();
            }
        }
        return new JsonResult(table);
    }
    
    public JsonResult SaveUser(string user)
    {
        //use entity framework here if wanted
        string query = @"insert into dbo.Drones values (@Name)";

        DataTable table = new DataTable();
        string sqlDataSource = _configuration.GetConnectionString("DroneAppConn");
        SqlDataReader myReader;
        using (SqlConnection myCon = new SqlConnection(sqlDataSource))
        {
            myCon.Open();
            using (SqlCommand myCommand = new SqlCommand(query, myCon))
            {
                myCommand.Parameters.AddWithValue("@Name", user);
                myReader = myCommand.ExecuteReader();
                table.Load(myReader);
                myReader.Close();
                myCon.Close();
            }
        }
        return new JsonResult(table);
    }
    
}