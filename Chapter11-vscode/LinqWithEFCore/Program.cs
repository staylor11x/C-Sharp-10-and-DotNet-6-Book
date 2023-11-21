using Packt.Shared;
using Microsoft.EntityFrameworkCore;

using static System.Console;
using System.Runtime.CompilerServices;

//FilterAndSort();
JoinCategoriesAndProducts();

static void FilterAndSort()
{
    using(NorthWind db = new())
    {
        DbSet<Product> allProducts = db.Products;

        IQueryable<Product> filteredProducts = allProducts.Where(product => product.UnitPrice < 10M);

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
            innerKeySelector: product => product.ProductId,
            resultSelector: (c,p) =>
                new {c.CategoryName, p.ProductName, p.ProductId}
        ).OrderBy(cp => cp.CategoryName);

        foreach(var item in queryJoin)
        {
            WriteLine("{0}: {1} is in {2}.", item.ProductId, item.ProductName, item.CategoryName);
        }
    }
}
