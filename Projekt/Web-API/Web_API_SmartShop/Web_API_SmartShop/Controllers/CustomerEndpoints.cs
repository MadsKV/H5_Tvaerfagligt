using Microsoft.EntityFrameworkCore;
using Web_API_SmartShop.DTO;
using Web_API_SmartShop.Models;
namespace Web_API_SmartShop.Controllers;

public static class CustomerEndpoints
{
    public static void MapCustomerEndpoints(this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/Customer", async (SmartShopContext db) =>
        {
            return await db.Customer.ToListAsync();
        })
        .WithName("GetAllCustomers");

        routes.MapGet("/api/CustomerHistory/{id}", async (int id, SmartShopContext db) =>
        {
            var list = new List<CustomerDTO>();
            var costomers = await db.Customer.ToListAsync();
            foreach (Customer c in costomers)
            {
                var dto = new CustomerDTO();
                dto.CustomerId = c.CustomerId;
                dto.Name = c.Name;
                dto.billingAddress = c.billingAddress;
                dto.shippingAddress = c.shippingAddress;
                list.Add(dto);
            }
            return list;
        })
        .WithName("CustomerHistory");

        //routes.MapGet("/api/Customer/{id}", async (int Id, SmartShopContext db) =>
        //{
        //    return await db.Customer.FindAsync(Id)
        //        is Customer model
        //            ? Results.Ok(model)
        //            : Results.NotFound();
        //})
        //.WithName("GetCustomerById");

        //routes.MapPut("/api/Customer/{id}", async (int Id, Customer customer, SmartShopContext db) =>
        //{
        //    var foundModel = await db.Customer.FindAsync(Id);

        //    if (foundModel is null)
        //    {
        //        return Results.NotFound();
        //    }

        //    db.Update(customer);

        //    await db.SaveChangesAsync();

        //    return Results.NoContent();
        //})
        //.WithName("UpdateCustomer");

        //routes.MapPost("/api/Customer/", async (Customer customer, SmartShopContext db) =>
        //{
        //    db.Customer.Add(customer);
        //    await db.SaveChangesAsync();
        //    return Results.Created($"/Customers/{customer.CustomerId}", customer);
        //})
        //.WithName("CreateCustomer");

        //routes.MapDelete("/api/Customer/{id}", async (int Id, SmartShopContext db) =>
        //{
        //    if (await db.Customer.FindAsync(Id) is Customer customer)
        //    {
        //        db.Customer.Remove(customer);
        //        await db.SaveChangesAsync();
        //        return Results.Ok(customer);
        //    }

        //    return Results.NotFound();
        //})
        //.WithName("DeleteCustomer");
    }
}
