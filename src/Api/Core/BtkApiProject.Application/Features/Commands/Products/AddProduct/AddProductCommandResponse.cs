using BtkApiProject.Common.DTOs.Products;

namespace BtkApiProject.Application.Features.Commands.Products.AddProduct;

public sealed record AddProductCommandResponse
{
    public ProductRequestDTO? Product { get; init; }
}
