using BtkApiProject.Application.Helpers;
using BtkApiProject.Common.DTOs.Products;

namespace BtkApiProject.Application.Features.Queries.Products.GetAllProducts;

public sealed record GetAllProductsQueryResponse
{
    public MetaData? MetaData { get; init; }
    public IEnumerable<ProductResponseDTO>? Products { get; init; }
}