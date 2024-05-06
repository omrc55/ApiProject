using BtkApiProject.Common.DTOs.Products;
using MediatR;

namespace BtkApiProject.Application.Features.Commands.Products.AddProduct;

public sealed record AddProductCommandRequest : IRequest<AddProductCommandResponse>
{
    public ProductRequestDTO? Product { get; init; }
}