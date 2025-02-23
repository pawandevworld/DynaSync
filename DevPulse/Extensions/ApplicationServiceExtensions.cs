using DevPulse.Data;
using Microsoft.EntityFrameworkCore;

namespace DevPulse.Extensions;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplicationservices(this IServiceCollection services,
     IConfiguration config)
    {
        services.AddControllers();
        //Add the DataContext service to the container
        //<DataContext> will create a new instance of DataContext
        //will receive the option from the DataContext class
        //Set option for the database to use SQLite
        services.AddDbContext<DataContext>(options =>
            options.UseSqlite(config.GetConnectionString("DefaultConnection")));

        //needed for setting cors
        services.AddCors();

        //We can either add a service like AddCors etc or 
        //1 add services.AddSingleton that is created first time they are requested and used same instance throughtout
        // cache data or maintain a state
        //2 add services.AddTransient that is created each time its requested from the service container. 
        // Good for lightweight stateless services
        //3 add services.AddScoped that is created once per client request (HttpRequest) like login in is a request
        //we can also use the following 
        // services.AddScoped<TokenService>();
        // but its recommended to use this as TokenService is binded with ITokenService
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IUserRepository, UserRepository>();
        //For mappers
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        return services;

    }
}