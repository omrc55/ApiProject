using Bogus;
using BtkApiProject.Common.Tools;
using BtkApiProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BtkApiProject.Persistence.Configs;

public class ProductDetailConfig : IEntityTypeConfiguration<ProductDetail>
{
    public void Configure(EntityTypeBuilder<ProductDetail> builder)
    {
        builder
            .HasData(FakeProductDetails);
    }

    private static IEnumerable<ProductDetail> FakeProductDetails
    {
        get
        {
            int count = 0;

            var result = new Faker<ProductDetail>("en")
                .RuleFor(i => i.ID, i => Guid.Parse(GuidTool.Guids()[count]))
                .RuleFor(i => i.Quantity, i => i.Random.Number(50))
                .RuleFor(i => i.ProductID, i => Guid.Parse(GuidTool.Guids()[count++]))
                .RuleFor(i => i.CreatedDate, i => i.Date.Between(DateTime.Now.AddMonths(-12), DateTime.Now))
                .Generate(50);

            return result;
        }
    }
}