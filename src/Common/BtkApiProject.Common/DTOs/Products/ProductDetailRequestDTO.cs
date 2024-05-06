using BtkApiProject.Common.DTOs.Common;

namespace BtkApiProject.Common.DTOs.Products;

public record ProductDetailRequestDTO : BaseRequestDTO
{
    public int Quantity { get; init; }
    public Guid? ProductID { get; set; }
}
