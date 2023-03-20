using Microsoft.EntityFrameworkCore;
using Web_API_SmartShop.Models;
namespace Web_API_SmartShop.Controllers;

public static class Product_CategoryEndpoints
{
    public static void MapProduct_CategoryEndpoints (this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/Product_Category", async (SmartShopContext db) =>
        {
            return await db.Product_Category.ToListAsync();
        })
        .WithName("GetAllProduct_Categorys");

        routes.MapGet("/api/Product_Category/{id}", async (int Id, SmartShopContext db) =>
        {
            return await db.Product_Category.FindAsync(Id)
                is Product_Category model
                    ? Results.Ok(model)
                    : Results.NotFound();
        })
        .WithName("GetProduct_CategoryById");

        routes.MapPut("/api/Product_Category/{id}", async (int Id, Product_Category product_Category, SmartShopContext db) =>
        {
            var foundModel = await db.Product_Category.FindAsync(Id);

            if (foundModel is null)
            {
                return Results.NotFound();
            }
            
            db.Update(product_Category);

            await db.SaveChangesAsync();

            return Results.NoContent();
        })
        .WithName("UpdateProduct_Category");

        routes.MapPost("/api/Product_Category/", async (Product_Category product_Category, SmartShopContext db) =>
        {
            db.Product_Category.Add(product_Category);
            await db.SaveChangesAsync();
            return Results.Created($"/Product_Categorys/{product_Category.PCId}", product_Category);
        })
        .WithName("CreateProduct_Category");

        routes.MapDelete("/api/Product_Category/{id}", async (int Id, SmartShopContext db) =>
        {
            if (await db.Product_Category.FindAsync(Id) is Product_Category product_Category)
            {
                db.Product_Category.Remove(product_Category);
                await db.SaveChangesAsync();
                return Results.Ok(product_Category);
            }

            return Results.NotFound();
        })
        .WithName("DeleteProduct_Category");
    }
}
