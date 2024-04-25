using BtkApiProject.Domain.Entities.Common;

namespace BtkApiProject.Domain.Entities;

public class ProductDetail : BaseEntity
{
    public int Quantity { get; set; }
    public required Guid ProductID { get; set; }
    public virtual Product? Product { get; set; }
}
