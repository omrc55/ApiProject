using BtkApiProject.Common.Tools;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace BtkApiProject.Application.Features.Commands.Products.DeleteProducts;

public sealed record DeleteProductsCommandRequest : IRequest<DeleteProductsCommandResponse>
{
    [Required(ErrorMessage = DataMessages.FieldRequired)]
    public required List<string> IDs { get; init; }
}
