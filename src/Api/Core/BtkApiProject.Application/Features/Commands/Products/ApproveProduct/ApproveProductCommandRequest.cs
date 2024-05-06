using BtkApiProject.Common.Tools;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace BtkApiProject.Application.Features.Commands.Products.ApproveProduct;

public sealed record ApproveProductCommandRequest : IRequest<ApproveProductCommandResponse>
{
    [Required(ErrorMessage = DataMessages.FieldRequired)]
    public required string ID { get; init; }
}
