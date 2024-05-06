using BtkApiProject.Common.Tools;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace BtkApiProject.Application.Features.Queries.Products.GetOneProduct;

public sealed record GetOneProductQueryRequest : IRequest<GetOneProductQueryResponse>
{
    public GetOneProductQueryRequest() { }

    public GetOneProductQueryRequest(string id, bool productDetail, bool category, bool orders)
    {
        ID = id;
        AddProductDetail = productDetail;
        AddCategory = category;
        AddOrders = orders;
    }

    [Required(ErrorMessage = DataMessages.FieldRequired)]
    public required string ID { get; init; }
    public bool AddProductDetail { get; init; } = false;
    public bool AddCategory { get; init; } = false;
    public bool AddOrders { get; init; } = false;
}
