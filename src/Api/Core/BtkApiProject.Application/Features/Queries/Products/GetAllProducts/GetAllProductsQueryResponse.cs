using BtkApiProject.Application.Helpers;
using BtkApiProject.Application.Helpers.Links;
using BtkApiProject.Common.DTOs.Products;

namespace BtkApiProject.Application.Features.Queries.Products.GetAllProducts;

public sealed record GetAllProductsQueryResponse
{
    public MetaData? MetaData { get; init; }
    public LinkResponse? LinkResponse { get; init; }
}