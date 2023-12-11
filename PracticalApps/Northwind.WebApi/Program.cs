using Microsoft.AspNetCore.Mvc.Formatters;
using Packt.Shared; //AddNorthwindContext extention method
using Northwind.WebApi.Repositories;

using static System.Console;

var builder = WebApplication.CreateBuilder(args);

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
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();  //register the repo for use at runtime as a scoped dependancy.

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
