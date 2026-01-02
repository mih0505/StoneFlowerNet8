using Domain.Common;
using Domain.OrderModels;
using Domain.ProductModels;
using Microsoft.EntityFrameworkCore;

namespace ApplicationLayer.Interfaces
{
    public interface IStoneFlowersDbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<OrderType> OrderTypes { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryProperty> CategoryProperties { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductParameter> ProductParameters { get; set; }
        public DbSet<ProductProperty> Properties { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
