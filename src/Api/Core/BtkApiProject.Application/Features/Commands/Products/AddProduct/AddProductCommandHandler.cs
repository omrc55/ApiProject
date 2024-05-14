using AutoMapper;
using BtkApiProject.Application.Exceptions.Products;
using BtkApiProject.Application.Interfaces.Repositories.Write;
using BtkApiProject.Application.Interfaces.Services;
using BtkApiProject.Common.Tools;
using BtkApiProject.Domain.Entities;
using MediatR;

namespace BtkApiProject.Application.Features.Commands.Products.AddProduct;

public class AddProductCommandHandler : IRequestHandler<AddProductCommandRequest, AddProductCommandResponse>
{
    private readonly IProductWriteRepository _productWriteRepository;
    private readonly IMapper _mapper;
    private readonly ILoggerService _logger;

    public AddProductCommandHandler(IProductWriteRepository productWriteRepository, IMapper mapper, ILoggerService logger)
    {
        _productWriteRepository = productWriteRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<AddProductCommandResponse> Handle(AddProductCommandRequest request, CancellationToken cancellationToken)
    {
        Guid productID = Guid.NewGuid();
        if (request.Product is not null && request.Product.ProductDetail is not null)
        {
            request.Product.ID = productID;
            request.Product.ProductDetail.ID = Guid.NewGuid();
            request.Product.ProductDetail.ProductID = productID;
        }

        Product product = _mapper.Map<Product>(request.Product);
        bool response = await _productWriteRepository.AddAsync(product);

        if (response)
            await _productWriteRepository.SaveAsync();
        else
            throw new ProductNotAddedException(productID.ToString());

        _logger.LogInfo($"{LogMessages.ProductAdded} {request.Product?.Name}({productID})");
        return new() { Product = request.Product };
    }
}
