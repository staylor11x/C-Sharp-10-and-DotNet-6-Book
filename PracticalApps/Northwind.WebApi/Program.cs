using Microsoft.AspNetCore.Mvc.Formatters;
using Packt.Shared; //AddNorthwindContext extention method
using Northwind.WebApi.Repositories;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI; //submit method
using Microsoft.AspNetCore.HttpLogging; //httpLoggingFields

using static System.Console;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseUrls("https://localhost:5002/");

// Add services to the container.
builder.Services.AddNorthwindContext();
builder.Services.AddControllers(options =>
{
    WriteLine("Default output formatters: ");
    foreach(IOutputFormatter formatter in options.OutputFormatters)
    {
        OutputFormatter? mediaFormatter = formatter as OutputFormatter;
        if(mediaFormatter == null)
        {
            WriteLine($" {formatter.GetType().Name}");
        }
        else     //OutputFormatter class has supported types
        {
            WriteLine("  {0}, Media types: {1}", mediaFormatter.GetType().Name, string.Join(", ", mediaFormatter.SupportedMediaTypes));
        }
    }
})
.AddXmlDataContractSerializerFormatters()
.AddXmlSerializerFormatters();

builder.Services.AddHttpLogging(options =>
{
    options.LoggingFields = HttpLoggingFields.All;
    //options.RequestBodyLogLimit = 4096; // default is 32k
    //options.RequestBodyLogLimit = 4096; //default is 32k
});

builder.Services.AddCors();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new()
    {
        Title = "Northwind Service API",
        Version = "v1"
    });
});


builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();  //register the repo for use at runtime as a scoped dependancy.

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Northwind Service API Version 1");
        c.SupportedSubmitMethods(new[]
        {
            SubmitMethod.Get, SubmitMethod.Post,
            SubmitMethod.Put, SubmitMethod.Delete
        });
    });


}

app.UseCors(configurePolicy: options =>
{
    options.WithMethods("GET", "POST", "PUT", "DELETE");
    options.WithOrigins("https://localhost:5001");  //allow requests from the MVC client
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseHttpLogging();       //the logging is not working for some unknown reason
app.MapControllers();

app.Run();
