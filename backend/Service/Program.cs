using System.Configuration;
using System.Data.SqlClient;
using Accessors.Account;
using Accessors.Address;
using Accessors.API.OpenRoute;
using Accessors.Depot;
using Accessors.Drone;
using Accessors.Order;
using Engines.BizLogic.Order;
using Managers.Account;
using Managers.Order;
using Microsoft.Extensions.Configuration;

namespace Service;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddCors(options =>
        {
            options.AddPolicy(
                name: "_MyAllowSubdomainPolicy",
                policy =>
                {
                    policy.WithOrigins("http://localhost:3001")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                }
            );
        });

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        
        var connectionString = builder.Configuration.GetConnectionString("DroneDatabase");
        
        builder.Services.AddScoped<IAddressAccessor, AddressAccessor>(serviceProvider => new AddressAccessor(new SqlConnection(connectionString)));
        builder.Services.AddScoped<IAccountAccessor, AccountAccessor>((serviceProvider) => 
        {
            var connection = new SqlConnection(connectionString);
            var addressAccessor = serviceProvider.GetRequiredService<IAddressAccessor>();
            return new AccountAccessor(connection, addressAccessor);
        });
        builder.Services.AddScoped<IDepotAccessor, DepotAccessor>((serviceProvider) => 
        {
            var connection = new SqlConnection(connectionString);
            var addressAccessor = serviceProvider.GetRequiredService<IAddressAccessor>();
            return new DepotAccessor(connection, addressAccessor);
        });
        builder.Services.AddScoped<IDroneAccessor, DroneAccessor>((serviceProvider) => 
        {
            var connection = new SqlConnection(connectionString);
            var orderAccessor = serviceProvider.GetRequiredService<IOrderAccessor>();
            var depotAccessor = serviceProvider.GetRequiredService<IDepotAccessor>();
            return new DroneAccessor(connection, orderAccessor, depotAccessor);
        });
        builder.Services.AddScoped<IOrderAccessor, OrderAccessor>((serviceProvider) => 
        {
            var connection = new SqlConnection(connectionString);
            var accountAccessor = serviceProvider.GetRequiredService<IAccountAccessor>();
            var addressAccessor = serviceProvider.GetRequiredService<IAddressAccessor>();
            return new OrderAccessor(connection, accountAccessor, addressAccessor);
        });
        builder.Services.AddScoped<IOpenRouteAccessor, OpenRouteAccessor>();
        builder.Services.AddScoped<IAccountManager, AccountManager>();
        builder.Services.AddScoped<IOrderManager, OrderManager>();
        builder.Services.AddScoped<IOrderEngine, OrderEngine>();

        var app = builder.Build();

        app.UseHttpsRedirection();
        app.UseCors("_MyAllowSubdomainPolicy");
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}
