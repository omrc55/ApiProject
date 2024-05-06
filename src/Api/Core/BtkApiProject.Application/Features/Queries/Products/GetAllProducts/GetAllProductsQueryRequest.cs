using MediatR;

namespace BtkApiProject.Application.Features.Queries.Products.GetAllProducts;

public sealed record GetAllProductsQueryRequest : IRequest<GetAllProductsQueryResponse>
{
    public GetAllProductsQueryRequest() { }

    public GetAllProductsQueryRequest(bool isApproved, bool isDeleted, bool productDetail, bool category, bool orders)
    {
        IsApproved = isApproved;
        IsDeleted = isDeleted;
        AddProductDetail = productDetail;
        AddCategory = category;
        AddOrders = orders;
    }

    public bool IsApproved { get; init; } = false;
    public bool IsDeleted { get; init; } = false;
    public bool AddProductDetail { get; init; } = false;
    public bool AddCategory { get; init; } = false;
    public bool AddOrders { get; init; } = false;
}