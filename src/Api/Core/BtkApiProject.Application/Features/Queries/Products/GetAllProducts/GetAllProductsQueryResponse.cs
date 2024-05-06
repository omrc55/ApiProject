using BtkApiProject.Common.DTOs.Products;

namespace BtkApiProject.Application.Features.Queries.Products.GetAllProducts;

public sealed record GetAllProductsQueryResponse
{
    public IEnumerable<ProductResponseDTO>? Products { get; init; }
}
