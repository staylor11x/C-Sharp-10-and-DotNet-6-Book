using Microsoft.EntityFrameworkCore;

namespace Packt.Shared;

//this manages the connection to the db
public class NorthWind : DbContext
{
    //these properties map to the table in the database
    public DbSet<Category>? Categories {get; set; }
    public DbSet<Product>? Products {get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string path = Path.Combine(Environment.CurrentDirectory, "Northwind.db");

        optionsBuilder.UseSqlite($"Filename={path}");

        /*
        string connection = "Data Source=.;" + "Initial Catalog=Northwind;" + "integrated Security=true;" + "MultipleActiveResultSets=true;";

        optionsBuilder.UseSqlServer(connection);
        */
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>()
            .Property(product => product.UnitPrice)
            .HasConversion<double>();
    }
}
