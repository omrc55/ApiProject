using BtkApiProject.Application.Helpers;
using BtkApiProject.Common.DTOs.Products;
using System.Dynamic;

namespace BtkApiProject.Application.Features.Queries.Products.GetAllProducts;

public sealed record GetAllProductsQueryResponse
{
    public MetaData? MetaData { get; init; }
    public IEnumerable<ProductResponseDTO>? Products { get; init; }
    public IEnumerable<ExpandoObject>? ExProducts { get; init; }
}