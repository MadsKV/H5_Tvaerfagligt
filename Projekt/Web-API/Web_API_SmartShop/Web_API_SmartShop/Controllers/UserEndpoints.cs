using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using Web_API_SmartShop.DTO;
using Web_API_SmartShop.Models;
namespace Web_API_SmartShop.Controllers;

public static class UserEndpoints
{
    public static void MapUserEndpoints (this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/UserHistory/", async (SmartShopContext db) =>
        {
            var list = new List<UserDTO>();
            var users = await db.User.ToListAsync();
            foreach (User u in users)
            {
                var dto = new UserDTO();
                dto.UserId = u.UserId;
                dto.email = u.email;
                dto.password = u.password;
                dto.phoneNumber = u.phoneNumber;
                list.Add(dto);
            }
            return list;
        })
        .WithName("UserHistory");



        routes.MapPost("/api/Login/", async (LoginDTO login, SmartShopContext db) =>
        {
            var users = await db.User.ToListAsync();
            foreach (User u in users)
            {
                if (u.email == login.email && u.password == login.password)
                {
                    return Results.Ok(true);
                }

            }
            return Results.Ok(false);
        })
        .WithName("UserLogin");



        routes.MapPost("/api/NewUser/", async (LoginDTO login, SmartShopContext db) =>
        {
            var users = await db.User.ToListAsync();
            foreach (User u in users)
            {
                if (u.email == login.email)
                {
                    return Results.BadRequest(false);
                }
            }
            Customer customer = new Customer();

            db.Customer.Add(customer);
            db.SaveChanges();
            User user = new User();
            user.email = login.email;
            user.password = login.password;
            user.phoneNumber = login.phoneNumber;
            user.CustomerId = customer.CustomerId;
            //users.Add(user);
            db.Add(user);
            db.SaveChanges();
            return Results.Ok(true);
        })
        .WithName("CreateNewUser");



        routes.MapDelete("/api/DeleteCurrentUser/{email}", async (string email, SmartShopContext db) =>
        {
            var user = db.User.Where(u => u.email == email).First();
            db.User.Remove(user);
            db.SaveChanges();
            return Results.Ok();
        })
        .WithName("DeleteUser");



        routes.MapPut("/api/UpdateCurrentUser/{email}", async (string email, LoginDTO login, SmartShopContext db) =>
        {
            var user = db.User.Where(u => u.email == email).First();
            user.email = login.email;
            user.password = login.password;
            user.phoneNumber = login.phoneNumber;

            db.SaveChanges();
            
        })
        .WithName("UpdateCurrentUser");
    }
}
