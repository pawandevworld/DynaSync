using DevPulse;
using DevPulse.Data;
using DevPulse.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplicationservices(builder.Configuration);
builder.Services.AddIdentityServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
//All middleware must be added before MapControllers and must restart the API using cors
app.UseMiddleware<ExceptionMiddleware>();
app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod()
    .WithOrigins("http://localhost:4200","https://localhost:4200"));

//Now add the Authintication middleware here
//and must be in the same order and just before MapControllers();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();


//Location is very importanc must be between MapControllers and Run
//Apply seed and migration to the database
//since we are not injecting a service we need to create a scope
//to get the service provider and it can be then disposed
using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
try{
    var context = services.GetRequiredService<DataContext>();
    await context.Database.MigrateAsync();
    await Seed.SeedUsers(context);
}
catch(Exception ex){
    //Program is for the Program class
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An error occured during migration");
}   

app.Run();
