using Microsoft.EntityFrameworkCore;

namespace Packt.Shared;

//this manages the connection to the db
public class NorthWind : DbContext
{
    //these properties map to the table in the database
    public DbSet<Customer>? Customers {get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string path = Path.Combine(Environment.CurrentDirectory, "Northwind.db");

        optionsBuilder.UseSqlite($"Filename={path}");
    }
}
