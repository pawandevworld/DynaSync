using DevPulse.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplicationservices(builder.Configuration);
builder.Services.AddIdentityServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
//All middleware must be added befor MapControllers and must restart the API using cors
app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod()
    .WithOrigins("http://localhost:4200","https://localhost:4200"));

//Now add the Authintication middleware here
//and must be in the same order and just before MapControllers();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
