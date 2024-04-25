using BtkApiProject.Domain.Entities.Common;
using BtkApiProject.Domain.Entities.Joins;

namespace BtkApiProject.Domain.Entities;

public class Product : BaseEntity
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    public double Price { get; set; }
    public required Guid CategoryID { get; set; }

    public virtual Category? Category { get; set; }
    public virtual ProductDetail? ProductDetail { get; set; }
    public virtual ICollection<OrderProduct>? OrderProducts { get; set; }
}
