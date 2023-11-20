using Packt.Shared;
using static System.Console;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using Newtonsoft.Json;
using System.Xml.Serialization;
using Newtonsoft.Json.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


QueryingCategoriesAndProducts();

static void QueryingCategoriesAndProducts()
{
    using (NorthWind db = new())
    {
        IQueryable<Category>? categories = db.Categories; //?.Include(c => c.Products);

        if (categories is null)
        {
            WriteLine("No categories found.");
            return;
        }

        
        WriteLine($"ToQueryString: {categories.ToQueryString()}");
        
        List<Category> categoryList = categories.ToList();

        foreach(Category c in categoryList)
        {
            WriteLine($"{c.CategoryName}");

            foreach(Product p in c.Products)
            {
                WriteLine($" - {p.ProductName}");
            }
        }

        JsonSerializer(categoryList);
        XmlSerializer(categories);
        BinarySerializer(categories);
    }
}


static void JsonSerializer(List<Category> categories)
{
    JsonSerializerSettings settings = new JsonSerializerSettings
    {
        ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
        TypeNameHandling = TypeNameHandling.Auto
    };

    string filePath = Path.Combine(Environment.CurrentDirectory, "Data.json");

    string json = JsonConvert.SerializeObject(categories, Formatting.None, settings);

    File.WriteAllText(filePath, json);
    WriteLine();
    WriteLine("Written {0:N0} bytes of json to: {1}", new FileInfo(filePath).Length, filePath);

}

static void XmlSerializer(IQueryable<Category> categories)
{
    //create data transfer objects to avoid circualr references
    List<CategoryDto> categoryDtoList = categories.Select(c => new CategoryDto
    {
        CategoryName = c.CategoryName,
        Description = c.Description,
        CategoryID = c.CategoryId,
        Products = c.Products.Select(p => new ProductDto
        {
            ProductId = p.ProductId,
            ProductName = p.ProductName,
            Cost = p.Cost,
            Stock = p.Stock,
            Discontinued = p.Discontinued,
            CategoryId = p.CategoryId
        }).ToList(),
    }).ToList();


    XmlSerializer xs = new(categoryDtoList.GetType());

    string path = Path.Combine(Environment.CurrentDirectory, "Data.xml");

    using(FileStream stream = File.Create(path))
    {
        xs.Serialize(stream, categoryDtoList);
    }

    WriteLine("Written {0:N0} bytes of XML to {1}", new FileInfo(path).Length, path);
    WriteLine();
}

static void BinarySerializer(IQueryable<Category> categories)
{
    //create data transfer objects to avoid circualr references, same as for XML
    List<CategoryDto> categoryDtoList = categories.Select(c => new CategoryDto
    {
        CategoryName = c.CategoryName,
        Description = c.Description,
        CategoryID = c.CategoryId,
        Products = c.Products.Select(p => new ProductDto
        {
            ProductId = p.ProductId,
            ProductName = p.ProductName,
            Cost = p.Cost,
            Stock = p.Stock,
            Discontinued = p.Discontinued,
            CategoryId = p.CategoryId
        }).ToList(),
    }).ToList();

    BinaryFormatter formatter = new BinaryFormatter();

    string path = Path.Combine(Environment.CurrentDirectory, "Data.bin");

    using(FileStream stream = File.Create(path))
    {
        formatter.Serialize(stream,categoryDtoList);
    }

    WriteLine("Witten {0:N0} bytes of binary data to {1}", new FileInfo(path).Length, path);
    WriteLine();
}