using SmartShop_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartShop_App.Services
{
    public interface ILoginRepository
    {
        Task<bool> Login(string userEmail, string password);

        Task<bool> NewUser(string userEmail, string password, string phoneNumber);

        Task<bool> UpdateUser(string userEmail, string password, string phoneNumber);
        Task<bool> DeleteUser(string userEmail);
    }
}
