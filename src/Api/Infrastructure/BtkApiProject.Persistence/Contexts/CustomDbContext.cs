using BtkApiProject.Domain.Entities;
using BtkApiProject.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Reflection;

namespace BtkApiProject.Persistence.Contexts;

public class CustomDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductDetail> ProductDetails { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        OnBeforeSave();
        return base.SaveChangesAsync(cancellationToken);
    }

    private void OnBeforeSave()
    {
        IEnumerable<EntityEntry<BaseEntity>> datas = ChangeTracker.Entries<BaseEntity>();

        foreach (EntityEntry<BaseEntity> data in datas)
        {
            if (data.State == EntityState.Added)
                data.Entity.CreatedDate = DateTime.Now;
            else if (data.State == EntityState.Modified)
                data.Entity.UpdatedDate = DateTime.Now;
        }
    }
}
