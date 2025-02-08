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



var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapControllers();

app.Run();
