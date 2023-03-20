using Microsoft.EntityFrameworkCore;
using Web_API_SmartShop.DTO;
using Web_API_SmartShop.Models;
namespace Web_API_SmartShop.Controllers;

public static class ProductsEndpoints
{
    public static void MapProductsEndpoints (this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/Products", async (SmartShopContext db) =>
        {
            return await db.Products.ToListAsync();
        })
        .WithName("GetAllProductss");

        routes.MapGet("/api/ProductsHistory/", async (SmartShopContext db) =>
        {
            var list = new List<ProductDTO>();
            var products = await db.Products.ToListAsync();
            foreach (Product p in products)
            {
                var dto = new ProductDTO();
                dto.ProductId = p.ProductId;
                dto.productName = p.productName;
                dto.productPrice = p.productPrice;
                list.Add(dto);
            }
            return list;
        })
        .WithName("ProductHistory");

        //routes.MapGet("/api/Products/{id}", async (int Id, SmartShopContext db) =>
        //{
        //    return await db.Products.FindAsync(Id)
        //        is Product model
        //            ? Results.Ok(model)
        //            : Results.NotFound();
        //})
        //.WithName("GetProductsById");

        //routes.MapPut("/api/Products/{id}", async (int Id, Product products, SmartShopContext db) =>
        //{
        //    var foundModel = await db.Products.FindAsync(Id);

        //    if (foundModel is null)
        //    {
        //        return Results.NotFound();
        //    }
            
        //    db.Update(products);

        //    await db.SaveChangesAsync();

        //    return Results.NoContent();
        //})
        //.WithName("UpdateProducts");

        //routes.MapPost("/api/Products/", async (Product products, SmartShopContext db) =>
        //{
        //    db.Products.Add(products);
        //    await db.SaveChangesAsync();
        //    return Results.Created($"/Productss/{products.ProductId}", products);
        //})
        //.WithName("CreateProducts");

        //routes.MapDelete("/api/Products/{id}", async (int Id, SmartShopContext db) =>
        //{
        //    if (await db.Products.FindAsync(Id) is Product products)
        //    {
        //        db.Products.Remove(products);
        //        await db.SaveChangesAsync();
        //        return Results.Ok(products);
        //    }

        //    return Results.NotFound();
        //})
        //.WithName("DeleteProducts");
    }
}
