using Bogus;
using BtkApiProject.Common.Enums;
using BtkApiProject.Common.Tools;
using BtkApiProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BtkApiProject.Persistence.Configs;

public class ProductConfig : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder
            .HasOne(c => c.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(c => c.CategoryID)
            .OnDelete(DeleteBehavior.NoAction);

        builder
            .HasOne(c => c.ProductDetail)
            .WithOne(c => c.Product)
            .HasForeignKey<ProductDetail>(c => c.ProductID)
            .OnDelete(DeleteBehavior.NoAction);

        builder
            .Property(p => p.Name)
            .HasMaxLength((int)DataLengthEnum.NameMax)
            .IsRequired();

        builder
            .Property(p => p.Description)
            .HasMaxLength((int)DataLengthEnum.DescriptionMax);

        builder
            .HasData(FakeProducts);
    }

    private static IEnumerable<Product> FakeProducts
    {
        get
        {
            Random random = new();
            int count = 0;

            var result = new Faker<Product>("en")
                .RuleFor(i => i.ID, i => Guid.Parse(GuidTool.Guids()[count++]))
                .RuleFor(i => i.Name, i => i.Commerce.ProductName())
                .RuleFor(i => i.Description, i => i.Lorem.Lines(1))
                .RuleFor(i => i.Price, i => i.Random.Number(1, 500))
                .RuleFor(i => i.CategoryID, Guid.Parse(GuidTool.Guids()[random.Next(0, 9)]))
                .RuleFor(i => i.CreatedDate, i => i.Date.Between(DateTime.Now.AddMonths(-12), DateTime.Now))
                .Generate(50);

            return result;
        }
    }
}
