using BtkApiProject.Common.Tools;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace BtkApiProject.Application.Features.Queries.Products.GetOneProduct;

public sealed record GetOneProductQueryRequest : IRequest<GetOneProductQueryResponse>
{
    [Required(ErrorMessage = DataMessages.FieldRequired)]
    public required string ID { get; init; }
    public bool AddProductDetail { get; init; } = false;
    public bool AddCategory { get; init; } = false;
    public bool AddOrders { get; init; } = false;
    public bool ValidID => IsGuid(ID);

    private static bool IsGuid(string input)
    {
        return Guid.TryParse(input, out _);
    }
}