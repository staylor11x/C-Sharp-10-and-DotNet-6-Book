using System.Text.Json;
using System.Text.Json.Serialization;
using static System.Console;
using static System.Environment;
using static System.IO.Path;

Book csharp10 = new(title: "C# 10 and .NET 6 - Modern Cross Platform Development")
{
    Author = "Mark J. Price",
    PublishDate = new(year:2021, month:11, day:9),
    pages = 823,
    Created = DateTimeOffset.UtcNow
};

JsonSerializerOptions options = new()
{
    IncludeFields = true,   //include all the fields
    PropertyNameCaseInsensitive = true,
    WriteIndented = true,
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
};

string filePath = Combine("book.json");

using(Stream fileStream = File.Create(filePath))
{
    JsonSerializer.Serialize<Book>(utf8Json: fileStream, value:csharp10, options);
}

WriteLine("Written {0:N0} bytes of JSON to {1}", new FileInfo(filePath).Length, filePath);
WriteLine();

//Display the serialized object graph
WriteLine(File.ReadAllText(filePath));

public class Book
{
    //constructor to set the nullable property
    public Book(string title)
    {
        Title = title;
    }

    //Properties
    public string Title {get;set;}
    public string Author {get;set;}

    //fields
    [JsonInclude]   //include this field
    public DateTime PublishDate;
    [JsonInclude]
    public DateTimeOffset Created;
    public ushort pages;
}