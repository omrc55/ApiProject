using BtkApiProject.Common.DTOs.Products;

namespace BtkApiProject.Application.Features.Queries.Products.GetAllProducts;

public sealed record GetAllProductsQueryResponse
{
    public int TotalProductsCount { get; init; }
    public int QueryProductsCount { get; init; }
    public IEnumerable<ProductResponseDTO>? Products { get; init; }
}