using BtkApiProject.Common.DTOs.Categories;
using BtkApiProject.Common.DTOs.Common;
using BtkApiProject.Common.DTOs.Joins;

namespace BtkApiProject.Common.DTOs.Products;

public record ProductResponseDTO : BaseResponseDTO
{
    public string? Name { get; init; }
    public string? Description { get; init; }
    public double? Price { get; init; }
    public Guid? CategoryID { get; init; }

    public virtual CategoryResponseForProductDTO? Category { get; init; }
    public virtual ProductDetailResponseDTO? ProductDetail { get; init; }
    public virtual ICollection<OrdersForProductDTO>? OrderProducts { get; init; }
}
