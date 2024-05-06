using Bogus;
using BtkApiProject.Common.Tools;
using BtkApiProject.Domain.Entities.Joins;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BtkApiProject.Persistence.Configs;

public class OrderProductConfig : IEntityTypeConfiguration<OrderProduct>
{
    public void Configure(EntityTypeBuilder<OrderProduct> builder)
    {
        builder
            .HasKey(i => new { i.OrderID, i.ProductID });

        builder
            .HasOne(i => i.Product)
            .WithMany(i => i.OrderProducts)
            .HasForeignKey(i => i.ProductID)
            .OnDelete(DeleteBehavior.NoAction);

        builder
            .HasOne(i => i.Order)
            .WithMany(i => i.OrderProducts)
            .HasForeignKey(i => i.OrderID)
            .OnDelete(DeleteBehavior.NoAction);

        builder
            .HasData(FakeOrderProducts);
    }

    private static IEnumerable<OrderProduct> FakeOrderProducts
    {
        get
        {
            int orderInt = 0;
            int productInt = 0;

            var result = new Faker<OrderProduct>()
                .RuleFor(i => i.OrderID, i => Guid.Parse(GuidTool.Guids()[(productInt + 1) < (orderInt + 1) * 2 ? orderInt : orderInt++]))
                .RuleFor(i => i.ProductID, i => Guid.Parse(GuidTool.Guids()[productInt++]))
                .Generate(30);

            return result;
        }
    }
}
