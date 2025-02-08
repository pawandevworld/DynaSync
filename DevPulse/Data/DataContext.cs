using DevPulse.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevPulse.Data;

// DataContext is a class that inherits from DbContext
//Any new service is to be registered in the Program.ca method in the Startup class
public class DataContext(DbContextOptions options) : DbContext(options)
{
    // DbSet is a collection of entities that can be queried
    //AppUser is the entity that will be stored in the table
    //Users is the name of the table in the database
        public DbSet<AppUser> Users { get; set; }

}
