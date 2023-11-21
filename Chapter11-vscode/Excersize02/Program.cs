using Packt.Shared;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

using static System.Console;

GetAllCities();

WriteLine("Enter the name of a city: ");

string? city = ReadLine();

GetCustomersInCity(city);

static void GetCustomersInCity(string city)
{
    //get all the customers located in the specified city!

    using(NorthWind db = new())
    {
        DbSet<Customer> allCustomers = db.Customers;

        if(allCustomers is null)
        {
            WriteLine("No customers found");
            return;
        }

        IQueryable<Customer> filteredCustomers = allCustomers.Where(customer => customer.City == city);     //cant seem to use a string comparison here :(

        var projectedCustomers = filteredCustomers
            .Select(customer => new
            {
                customer.CustomerID,
                customer.CompanyName,
                customer.City
            });

        WriteLine("There are {0} customers in {1}: ", projectedCustomers.Count(), city);
        foreach(var c in projectedCustomers)
        {
            WriteLine($" -- {c.CompanyName}");
        }
        WriteLine();
    }
}

static void GetAllCities()
{
    using(NorthWind db = new())
    {
        DbSet<Customer> allCustomers = db.Customers;

        if(allCustomers is null)
        {
            WriteLine("No Customers found :(");
            return;
        }

        

        var projectedCustomers = allCustomers
            .Select(customer => new
            {
                customer.City
            }).ToArray()
            .Distinct();

        WriteLine("List of Avaliable Cities: ");
        foreach(var c in projectedCustomers)
        {
            Write($"{c.City}, ");
        }
        WriteLine();
    }
}