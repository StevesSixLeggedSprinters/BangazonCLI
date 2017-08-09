using Microsoft.EntityFrameworkCore;
using Bangazon.Models;

namespace Bangazon.Data
{
    public class BangazonCLIContext : DbContext
    {
         public BangazonCLIContext(DbContextOptions<BangazonCLIContext> options)
            : base(options)
        { }

        public DbSet<Customer> Customer {get; set;}
        public DbSet<Order> Order {get; set;}
        public DbSet<PaymentType> PaymentType {get; set;}
        public DbSet<Product> Product {get; set;}
        public DbSet<ProductType> ProductType {get; set;}
        public DbSet<ProductOrder> ProductOrder {get; set;}
    }
}