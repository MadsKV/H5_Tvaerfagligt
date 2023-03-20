using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace Web_API_SmartShop.Models
{
    public class SmartShopContext : DbContext
    {
        //public DbSet<Category> Categories { get; set; }
        ////public List<Category> Categories { get; set; } = new();
        //public List<Customer> Customers { get; set; } = new();
        //public List<OrderDetails> OrderDetails { get; set; } = new();
        //public List<Orders> Orders { get; set; } = new();
        //public List<Product_Category> Product_Categories { get; set; } = new();
        //public List<Products> Products { get; set; } = new();
        //public List<User> Users { get; set; } = new();

        private readonly IConfiguration _configuration;

        public SmartShopContext() { }
        public SmartShopContext(DbContextOptions<SmartShopContext> options) : base(options)
        {

        }
        public SmartShopContext(DbContextOptions<SmartShopContext> options,
                               IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            Console.WriteLine($"Connecting to database through: {_configuration.GetConnectionString("SmartShop_ConnectionString")}");
            options.UseSqlServer("Data Source=MADS778I\\SQLEXPRESS;Initial Catalog=Web_API_Project;TrustServerCertificate=True;MultipleActiveResultSets=true;Integrated Security=true;");
        }

        public DbSet<Category> Category { get; set; }

        public DbSet<Customer> Customer { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<User> User { get; set; }

        //public DbSet<Product_Category> Product_Category { get; set; }

    }
}
