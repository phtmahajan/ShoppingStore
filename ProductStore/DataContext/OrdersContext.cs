using System.Data.Entity;
using ProductStore.Models;

namespace ProductStore.DataContext
{
    //This provides the glue between the POCO models and the database.
    public class OrdersContext : DbContext
    {
        public OrdersContext()
            : base("name=DefaultConnection")
        {
        }
        //DbSet represents a set of entities that can be queried.
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }

       
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}
