namespace Service;

public class Program
{
    public static void Main(string[] args)
    {
        // var builder = WebApplication.CreateBuilder(args);
        //
        // // Add services to the container.
        //
        // builder.Services.AddControllers();
        //
        // var app = builder.Build();
        //
        // // Configure the HTTP request pipeline.
        //
        // app.UseAuthorization();
        //
        //
        // app.MapControllers();
        //
        // app.Run();
        
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
