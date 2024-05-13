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
                    policy.WithOrigins("http://localhost:3000")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                }
            );
        });
        
        
        var connection = builder.Configuration.GetConnectionString("DroneDatabase");
        
        builder.Services.AddScoped<IAddressAccessor, AddressAccessor>(serviceProvider => new AddressAccessor(connection));
        builder.Services.AddScoped<IAccountAccessor, AccountAccessor>((serviceProvider) => 
        {
            var addressAccessor = serviceProvider.GetRequiredService<IAddressAccessor>();
            return new AccountAccessor(connection, addressAccessor);
        });
        builder.Services.AddScoped<IDepotAccessor, DepotAccessor>((serviceProvider) => 
        {
            var addressAccessor = serviceProvider.GetRequiredService<IAddressAccessor>();
            return new DepotAccessor(connection, addressAccessor);
        });
        builder.Services.AddScoped<IOrderAccessor, OrderAccessor>((serviceProvider) => 
        {
            var accountAccessor = serviceProvider.GetRequiredService<IAccountAccessor>();
            var addressAccessor = serviceProvider.GetRequiredService<IAddressAccessor>();
            return new OrderAccessor(connection, accountAccessor, addressAccessor);
        });

        builder.Services.AddScoped<IDroneAccessor, DroneAccessor>((serviceProvider) => 
        {
            var orderAccessor = serviceProvider.GetRequiredService<IOrderAccessor>();
            var depotAccessor = serviceProvider.GetRequiredService<IDepotAccessor>();
            return new DroneAccessor(connection, orderAccessor, depotAccessor);
        });
        builder.Services.AddScoped<IOpenRouteAccessor, OpenRouteAccessor>();
        builder.Services.AddScoped<IAccountManager, AccountManager>(serviceProvider =>
        {
            var accountAccessor = serviceProvider.GetRequiredService<IAccountAccessor>();
            return new AccountManager(accountAccessor);
        });
        builder.Services.AddScoped<IOrderEngine, OrderEngine>(serviceProvider =>
        {
            var orderAccessor = serviceProvider.GetRequiredService<IOrderAccessor>();
            var depotAccessor = serviceProvider.GetRequiredService<IDepotAccessor>();
            var droneAccessor = serviceProvider.GetRequiredService<IDroneAccessor>();
            return new OrderEngine(orderAccessor, depotAccessor, droneAccessor);
        });
        builder.Services.AddScoped<IOrderManager, OrderManager>(serviceProvider =>
        {
            var orderAccessor = serviceProvider.GetRequiredService<IOrderAccessor>();
            var accountAccessor = serviceProvider.GetRequiredService<IAccountAccessor>();
            var addressAccessor = serviceProvider.GetRequiredService<IAddressAccessor>();
            var droneAccessor = serviceProvider.GetRequiredService<IDroneAccessor>();
            var depotAccessor = serviceProvider.GetRequiredService<IDepotAccessor>();
            var orderEngine = serviceProvider.GetRequiredService<IOrderEngine>();

            return new OrderManager(orderAccessor, accountAccessor, addressAccessor, droneAccessor, depotAccessor, orderEngine);
        });

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        
        var app = builder.Build();

        app.UseHttpsRedirection();
        app.UseCors("_MyAllowSubdomainPolicy");
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}
