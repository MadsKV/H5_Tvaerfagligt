using Microsoft.EntityFrameworkCore;
using Web_API_SmartShop.DTO;
using Web_API_SmartShop.Models;
namespace Web_API_SmartShop.Controllers;

public static class CategoryEndpoints
{
    public static void MapCategoryEndpoints (this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/Category", async (SmartShopContext db) =>
        {
            return await db.Category.ToListAsync();
        })
        .WithName("GetAllCategorys");

        routes.MapGet("/api/CategoryHistory/{id}", async (int CategoryId, SmartShopContext db) =>
        {
            var list = new List<CategoryDTO>();
            var categories = await db.Category.ToListAsync();
            foreach (Category c in categories)
            {
                var dto = new CategoryDTO();
                dto.CategoryId = c.CategoryId;
                dto.CategoryName = c.CategoryName;
                list.Add(dto);
            }
            return list;
        })
        .WithName("CategoryHistory");

        //routes.MapGet("/api/Category/{id}", async (int CategoryId, SmartShopContext db) =>
        //{
        //    return await db.Category.FindAsync(CategoryId)
        //        is Category model
        //            ? Results.Ok(model)
        //            : Results.NotFound();
        //})
        //.WithName("GetCategoryById");

        //routes.MapPut("/api/Category/{id}", async (int CategoryId, Category category, SmartShopContext db) =>
        //{
        //    var foundModel = await db.Category.FindAsync(CategoryId);

        //    if (foundModel is null)
        //    {
        //        return Results.NotFound();
        //    }
            
        //    db.Update(category);

        //    await db.SaveChangesAsync();

        //    return Results.NoContent();
        //})
        //.WithName("UpdateCategory");

        //routes.MapPost("/api/Category/", async (Category category, SmartShopContext db) =>
        //{
        //    db.Category.Add(category);
        //    await db.SaveChangesAsync();
        //    return Results.Created($"/Categorys/{category.CategoryId}", category);
        //})
        //.WithName("CreateCategory");

        //routes.MapDelete("/api/Category/{id}", async (int CategoryId, SmartShopContext db) =>
        //{
        //    if (await db.Category.FindAsync(CategoryId) is Category category)
        //    {
        //        db.Category.Remove(category);
        //        await db.SaveChangesAsync();
        //        return Results.Ok(category);
        //    }

        //    return Results.NotFound();
        //})
        //.WithName("DeleteCategory");
    }
}
