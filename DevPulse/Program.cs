using DevPulse.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
//Add the DataContext service to the container
//<DataContext> will create a new instance of DataContext
//will receive the option from the DataContext class
//Set option for the database to use SQLite
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

//needed for setting cors
builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
//All middleware must be added befor MapControllers and must restart the API using cors
app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod()
    .WithOrigins("http://localhost:4200","https://localhost:4200"));


app.MapControllers();

app.Run();
