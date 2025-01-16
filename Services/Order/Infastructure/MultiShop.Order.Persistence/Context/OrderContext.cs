using Microsoft.EntityFrameworkCore;
using MultiShop.Order.Core.Domain.Entities;
using System.Reflection;

namespace MultiShop.Order.Core.Infastructure.Persistence.Context
{
    public class OrderContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1434;initial Catalog=MultiShop.Order;User=sa;Password=123456789Aa*;TrustServerCertificate=true;");
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Ordering> Orderings { get; set; }



    }
}