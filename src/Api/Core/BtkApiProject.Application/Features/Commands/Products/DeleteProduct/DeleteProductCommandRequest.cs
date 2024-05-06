using BtkApiProject.Common.Tools;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace BtkApiProject.Application.Features.Commands.Products.DeleteProduct;

public sealed record DeleteProductCommandRequest : IRequest<DeleteProductCommandResponse>
{
    [Required(ErrorMessage = DataMessages.FieldRequired)]
    public required string ID { get; init; }
}
