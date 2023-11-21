using Packt.Shared;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

using static System.Console;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.Arm;

//FilterAndSort();
//JoinCategoriesAndProducts();
//GroupJoinCategoriesAndProducts();
//AggregateProducts();
//CustomExtensionMethods();
//OutputProductAsXml();
ProcessSettings();

static void FilterAndSort()
{
    using(NorthWind db = new())
    {
        DbSet<Product> allProducts = db.Products;

        if(allProducts is null)
        {
            WriteLine("No products found");
            return;
        }

        IQueryable<Product> processedProducts = allProducts.ProcessSequence();

        IQueryable<Product> filteredProducts = processedProducts.Where(product => product.UnitPrice < 10M);

        IOrderedQueryable<Product> sortedAndFilteredProducts = filteredProducts.OrderByDescending(product => product.UnitPrice);
        //This not a good example as the querey gets all the columns from the product table instead of just the three that we need!

        var projectedProducts = sortedAndFilteredProducts   //this is more efficient as we only select the properties that we need
            .Select(product => new  //anonymous type
            {
                product.ProductId,
                product.ProductName,
                product.UnitPrice
            });

        WriteLine("Products that cost less than $10");
        foreach(var p in projectedProducts)
        {
            WriteLine("{0}: {1} costs {2:$#,##0.00}", p.ProductId, p.ProductName, p.UnitPrice);
        }
        WriteLine();
    }
}

static void JoinCategoriesAndProducts()
{
    using(NorthWind db = new())
    {
        //join every product to its category to return 77 matches
        var queryJoin = db.Categories.Join(
            inner:db.Products,
            outerKeySelector: category => category.CategoryId,
            innerKeySelector: product => product.CategoryId,        //THIS IS WHERE THE MISTAKE WAS!!! we had product.ProductId, how silly...
            resultSelector: (c, p) =>
                new {c.CategoryName, p.ProductName, p.ProductId}
                ).OrderBy(cp => cp.CategoryName);

        foreach(var item in queryJoin)
        {
            WriteLine("{0}: {1} is in {2}.", item.ProductId, item.ProductName, item.CategoryName);
        }
    }
}

static void GroupJoinCategoriesAndProducts()
{
    using(NorthWind db = new())
    {
        //group all the products by their categories to return 8 matches
        var queryGroup = db.Categories.AsEnumerable().GroupJoin(        //AsEnumerable prevents a run time error
            inner: db.Products,
            outerKeySelector: category => category.CategoryId,
            innerKeySelector: product => product.CategoryId,
            resultSelector: (c, matchingProducts) => new{
                c.CategoryName,
                Products = matchingProducts.OrderBy(p => p.ProductName)
            });

        foreach(var category in queryGroup)
        {
            WriteLine("{0} has  {1} products", category.CategoryName, category.Products.Count());

            foreach(var product in category.Products)
            {
                WriteLine($"    {product.ProductName}");
            }
        }
    }
}

static void AggregateProducts()
{
    using(NorthWind db = new())
    {
        WriteLine("{0,-25} {1,-10}", "Product Count", db.Products.Count());

        WriteLine("{0,-25} {1,10:$#,##0.00}", "Highest Product Price: ", db.Products.Max(p => p.UnitPrice));

        WriteLine("{0,-25} {1,10:N0}", "Sum of units in stock: ", db.Products.Sum(p => p.UnitsInStock));

        WriteLine("{0,-25} {1,10:N0}", "Sum of units on order", db.Products.Sum(p => p.UnitsOnOrder));

        WriteLine("{0,-25} {1,10:$#.##0.00}", "Average unit price", db.Products.Average(p => p.UnitPrice));

        WriteLine("{0,-25} {1,10:$#,##0.00}", "Value of units in stock", db.Products.Sum(p => p.UnitsInStock * p.UnitPrice));
    }
}

static void CustomExtensionMethods()
{
    using(NorthWind db = new())
    {
        WriteLine("Mean units in stock: {0:N0}", db.Products.Average(p => p.UnitsInStock));
        WriteLine("Mean unit price: {0:$#,##0.00}", db.Products.Average(p => p.UnitPrice));
        WriteLine("Median units in stock: {0:N0}", db.Products.Median(p => p.UnitsInStock));
        WriteLine("Median unit price: {0:$#,##0.00}", db.Products.Median(p => p.UnitPrice));
        WriteLine("Mode units in stock: {0:N0}", db.Products.Mode(p => p.UnitsInStock));
        WriteLine("Mode unit price: {0:$#,##0.00}", db.Products.Mode(p => p.UnitPrice));
    }
}

static void OutputProductAsXml()
{
    using(NorthWind db = new())
    {
        Product[] productsArray = db.Products.ToArray();

        XElement xml = new("products", from p in productsArray 
            select new XElement("product", 
            new XAttribute("id", p.ProductId),
            new XAttribute("price", p.UnitPrice),
            new XElement("name", p.ProductName)));

        WriteLine(xml.ToString());
    }
}

static void ProcessSettings()
{
    XDocument doc = XDocument.Load("settings.xml");

    var appSettings = doc.Descendants("appSettings")
        .Descendants("add")
        .Select(node => new
        {
            key = node.Attribute("key")?.Value,
            Value = node.Attribute("value")?.Value
        }).ToArray();
    
    foreach(var item in appSettings)
    {
        WriteLine($"{item.key}: {item.Value}");
    }
}