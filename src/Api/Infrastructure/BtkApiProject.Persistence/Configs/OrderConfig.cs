using Bogus;
using BtkApiProject.Common.Tools;
using BtkApiProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BtkApiProject.Persistence.Configs;

public class OrderConfig : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder
            .HasData(FakeOrders);
    }

    private static IEnumerable<Order> FakeOrders
    {
        get
        {
            int count = 0;

            var result = new Faker<Order>("en")
                .RuleFor(i => i.ID, i => Guid.Parse(GuidTool.Guids()[count++]))
                .RuleFor(i => i.CreatedDate, i => i.Date.Between(DateTime.Now.AddMonths(-12), DateTime.Now))
                .Generate(15);

            return result;
        }
    }
}