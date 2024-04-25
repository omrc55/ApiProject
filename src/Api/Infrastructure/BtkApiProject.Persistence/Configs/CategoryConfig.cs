using Bogus;
using BtkApiProject.Common.Enums;
using BtkApiProject.Common.Tools;
using BtkApiProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BtkApiProject.Persistence.Configs;

public class CategoryConfig : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder
            .Property(p => p.Name)
            .HasMaxLength((int)DataLengthEnum.NameMax)
            .IsRequired();

        builder
            .HasIndex(p => p.Name)
            .IsUnique();

        builder
            .Property(p => p.Description)
            .HasMaxLength((int)DataLengthEnum.DescriptionMax);

        builder
            .HasData(FakeCategories());
    }

    private IEnumerable<Category> FakeCategories()
    {
        int count = 0;

        string[] categories = ["Kitap", "Elektronik", "Film", "Spor", "Giyim", "Aksesuar", "Mobilya", "Oyun", "Sanat", "Müzik"];

        var result = new Faker<Category>("tr")
            .RuleFor(i => i.ID, i => Guid.Parse(GuidTool.Guids()[count]))
            .RuleFor(i => i.Name, i => categories[count++])
            .RuleFor(i => i.Description, i => i.Lorem.Lines(1))
            .RuleFor(i => i.CreatedDate, i => i.Date.Between(DateTime.Now.AddMonths(-12), DateTime.Now))
            .Generate(10);

        return result;
    }
}