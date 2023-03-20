using Microsoft.EntityFrameworkCore;
using Web_API_SmartShop.DTO;
using Web_API_SmartShop.Models;
namespace Web_API_SmartShop.Controllers;

public static class OrdersEndpoints
{
    public static void MapOrdersEndpoints (this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/Orders", async (SmartShopContext db) =>
        {
            return await db.Orders.ToListAsync();
        })
        .WithName("GetAllOrderss");

        /***
         * Creates a new order with a product and an email
         */
        routes.MapPost("/api/Buy", async (BuyDTO buy, SmartShopContext db) =>
        {
            //Find User with buy.Email

        User user = db.User
            .Include(u => u.Customer)
            .Include(u => u.Customer.Orders)
            .First(u => u.email == buy.Email);
            
            //Create a new order
        Order order = new Order();
        order.Customer = user.Customer;
        order.shippingCost = 159;
        order.billingAddress = "Barndommens gade";
        order.orderStatus = "new";
                
            //Create a orderdetail instance with the product
            OrderDetail od = new();

            //Add the product to the order detail 
            od.ProductId = buy.Product;
            od.Products = db.Products.First(p => p.ProductId == buy.Product);

            //Add the order detail to the order
            order.orderdetails.Add(od);

            //Add the order to the customer order list
            user.Customer.Orders.Add(order);

            //Save the changes
            await db.SaveChangesAsync();
                
            return await Task.FromResult(true);
        })
        .WithName("Cart");

        routes.MapGet("/api/OrderHistory/{CustomerId}", async (int CustomerId, SmartShopContext db) =>
        {
            var list = new List<OrderDTO>();
            var orders = await db.Orders.ToListAsync();
            foreach (Order o in orders)
            {
                var dto = new OrderDTO();
                dto.OrderId = o.OrderId;
                dto.orderStatus = o.orderStatus;
                dto.orderDate = o.orderDate;
                list.Add(dto);
            }
            return list;
        })
        .WithName("OrderHistory");


        routes.MapGet("/api/GetAllOrders", async (int CustomerId, SmartShopContext db) =>
        {
            var list = new List<OrderDTO>();
            var orders = await db.Orders.Include(o => o.orderdetails).ToListAsync();
            foreach (Order o in orders)
            {
                var dto = new OrderDTO();
                dto.OrderId = o.OrderId;
                dto.orderStatus = o.orderStatus;
                dto.orderDate = o.orderDate;
                foreach (var d in o.orderdetails)
                {
                    var ddto = new OrderDetailDTO();
                    ddto.createdDate = (DateTime)d.createdDate;
                    ddto.shippingAddress = d.shippingAddress;
                    ddto.billingAddress = d.billingAddress;
                    ddto.orderAmount = d.orderAmount;
                    ddto.shippingType = d.shippingType;

                    dto.Details.Add(ddto);
                }
                list.Add(dto);
            }
            return list;
        })
        .WithName("GetAllOrders");

        //routes.MapGet("/api/Orders/{id}", async (int Id, SmartShopContext db) =>
        //{
        //    return await db.Orders.FindAsync(Id)
        //        is Order model
        //            ? Results.Ok(model)
        //            : Results.NotFound();
        //})
        //.WithName("GetOrdersById");

        //routes.MapPut("/api/Orders/{id}", async (int Id, Order orders, SmartShopContext db) =>
        //{
        //    var foundModel = await db.Orders.FindAsync(Id);

        //    if (foundModel is null)
        //    {
        //        return Results.NotFound();
        //    }

        //    db.Update(orders);

        //    await db.SaveChangesAsync();

        //    return Results.NoContent();
        //})
        //.WithName("UpdateOrders");

        //routes.MapPost("/api/Orders/", async (Order orders, SmartShopContext db) =>
        //{
        //    db.Orders.Add(orders);
        //    await db.SaveChangesAsync();
        //    return Results.Created($"/Orderss/{orders.OrderId}", orders);
        //})
        //.WithName("CreateOrders");

        //routes.MapDelete("/api/Orders/{id}", async (int Id, SmartShopContext db) =>
        //{
        //    if (await db.Orders.FindAsync(Id) is Order orders)
        //    {
        //        db.Orders.Remove(orders);
        //        await db.SaveChangesAsync();
        //        return Results.Ok(orders);
        //    }

        //    return Results.NotFound();
        //})
        //.WithName("DeleteOrders");
    }
}
