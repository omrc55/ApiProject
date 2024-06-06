using BtkApiProject.Application.Parameters;
using MediatR;

namespace BtkApiProject.Application.Features.Queries.Products.GetAllProducts;

public sealed record GetAllProductsQueryRequest : ProductParameters, IRequest<GetAllProductsQueryResponse>
{
    public int PageNumber { get; init; }
    public int PageSize { get; init; }
}