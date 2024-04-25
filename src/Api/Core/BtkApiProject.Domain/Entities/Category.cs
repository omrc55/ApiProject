using BtkApiProject.Domain.Entities.Common;

namespace BtkApiProject.Domain.Entities;

public class Category : BaseEntity
{
    public required string Name { get; set; }
    public string? Description { get; set; }

    public virtual ICollection<Product>? Products { get; set; }
}