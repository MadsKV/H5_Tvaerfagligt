using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop.Infrastructure;
using Web_API_SmartShop.DTO;
using Web_API_SmartShop.Models;
namespace Web_API_SmartShop.Controllers;

public static class OrderDetailsEndpoints
{
    public static void MapOrderDetailsEndpoints (this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/OrderDetails", async (SmartShopContext db) =>
        {
            return await db.OrderDetails.ToListAsync();
        })
        .WithName("GetAllOrderDetailss");

        routes.MapGet("/api/OrderDetailsHistory/{OrderId}", async (int Id, SmartShopContext db) =>
        {
            var list = new List<OrderDetailDTO>();
            var ordersDetails = await db.OrderDetails.ToListAsync();
            foreach (OrderDetail od in ordersDetails)
            {
                if (od.OrderId != Id) continue;
                var dto = new OrderDetailDTO();
                dto.OrderDetailId = od.orderDetailId;
                dto.orderAmount = od.orderAmount;
                dto.createdDate = (DateTime)od.createdDate;
                list.Add(dto);
            }
            return list;
        })
        .WithName("OrderDetailsHistory");

        //routes.MapGet("/api/OrderDetails/{id}", async (int Id, SmartShopContext db) =>
        //{
        //    return await db.OrderDetails.FindAsync(Id)
        //        is OrderDetail model
        //            ? Results.Ok(model)
        //            : Results.NotFound();
        //})
        //.WithName("GetOrderDetailsById");

        //routes.MapPut("/api/OrderDetails/{id}", async (int Id, OrderDetail orderDetails, SmartShopContext db) =>
        //{
        //    var foundModel = await db.OrderDetails.FindAsync(Id);

        //    if (foundModel is null)
        //    {
        //        return Results.NotFound();
        //    }
            
        //    db.Update(orderDetails);

        //    await db.SaveChangesAsync();

        //    return Results.NoContent();
        //})
        //.WithName("UpdateOrderDetails");

        //routes.MapPost("/api/OrderDetails/", async (OrderDetail orderDetails, SmartShopContext db) =>
        //{
        //    db.OrderDetails.Add(orderDetails);
        //    await db.SaveChangesAsync();
        //    return Results.Created($"/OrderDetailss/{orderDetails.orderDetailId}", orderDetails);
        //})
        //.WithName("CreateOrderDetails");

        //routes.MapDelete("/api/OrderDetails/{id}", async (int Id, SmartShopContext db) =>
        //{
        //    if (await db.OrderDetails.FindAsync(Id) is OrderDetail orderDetails)
        //    {
        //        db.OrderDetails.Remove(orderDetails);
        //        await db.SaveChangesAsync();
        //        return Results.Ok(orderDetails);
        //    }

        //    return Results.NotFound();
        //})
        //.WithName("DeleteOrderDetails");
    }
}
