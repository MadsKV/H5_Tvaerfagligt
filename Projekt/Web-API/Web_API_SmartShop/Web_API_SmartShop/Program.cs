using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Web_API_SmartShop.Controllers;
using Web_API_SmartShop.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

ConfigurationManager configuration = builder.Configuration;

builder.Services.AddDbContext<SmartShopContext>(options =>
    options.UseSqlServer(
        configuration.GetConnectionString("SmartShop_ConnectionString")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles); // LTPE


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

app.MapCategoryEndpoints();

app.MapCustomerEndpoints();

app.MapOrderDetailsEndpoints();

app.MapOrdersEndpoints();

app.MapProductsEndpoints();

app.MapUserEndpoints();

//app.MapProduct_CategoryEndpoints();

app.Run();

