using AccessLayer.Configurations.Common;
using AccessLayer.Configurations.OrderModels;
using AccessLayer.Configurations.ProductModels;
using ApplicationLayer.Interfaces;
using Domain.Common;
using Domain.OrderModels;
using Domain.ProductModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AccessLayer;

public class StoneFlowersDbContext : IdentityDbContext<User, Role, Guid>, IStoneFlowersDbContext
{
    public StoneFlowersDbContext(DbContextOptions<StoneFlowersDbContext> options)
    : base(options)
    { }

    public DbSet<Department> Departments { get; set; }
    public DbSet<Organization> Organizations { get; set; } 
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


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        new DepartmentConfiguration().Configure(modelBuilder.Entity<Department>());
        new OrganizationConfiguration().Configure(modelBuilder.Entity<Organization>());
               
        new CustomerConfiguration().Configure(modelBuilder.Entity<Customer>());
        new DeceasedConfiguration().Configure(modelBuilder.Entity<Deceased>());
        new OrderConfiguration().Configure(modelBuilder.Entity<Order>());
        new OrderProductConfiguration().Configure(modelBuilder.Entity<OrderProduct>());
        new OrderTypeConfiguration().Configure(modelBuilder.Entity<OrderType>());
        new PaymentConfiguration().Configure(modelBuilder.Entity<Payment>());
        
        new CategoryConfiguration().Configure(modelBuilder.Entity<Category>());
        new CategoryPropertyConfiguration().Configure(modelBuilder.Entity<CategoryProperty>());
        new ProductConfiguration().Configure(modelBuilder.Entity<Product>());
        new ProductParameterConfiguration().Configure(modelBuilder.Entity<ProductParameter>());
        new PropertyConfiguration().Configure(modelBuilder.Entity<ProductProperty>());

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(StoneFlowersDbContext).Assembly);
    }
}
