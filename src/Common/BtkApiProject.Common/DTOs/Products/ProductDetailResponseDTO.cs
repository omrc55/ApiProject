using BtkApiProject.Common.DTOs.Common;

namespace BtkApiProject.Common.DTOs.Products;

public record ProductDetailResponseDTO : BaseResponseDTO
{
    public int Quantity { get; init; }
}
