using BtkApiProject.Common.DTOs.Products;

namespace BtkApiProject.Application.Features.Queries.Products.GetOneProduct;

public sealed record GetOneProductQueryResponse
{
    public ProductResponseDTO? Product { get; init; }
}