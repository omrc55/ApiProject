using MediatR;

namespace BtkApiProject.Application.Features.Queries.Products.GetAllProducts;

public sealed record GetAllProductsQueryRequest : IRequest<GetAllProductsQueryResponse>
{
    public bool? IsApproved { get; init; } = null;
    public bool? IsDeleted { get; init; } = null;
    public bool AddProductDetail { get; init; } = false;
    public bool AddCategory { get; init; } = false;
    public bool AddOrders { get; init; } = false;
    public int PageNumber { get; init; }
    public int PageSize { get; init; }
}