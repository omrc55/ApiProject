using AutoMapper;
using BtkApiProject.Application.Exceptions.Products;
using BtkApiProject.Application.Interfaces.Repositories.Read;
using BtkApiProject.Application.Interfaces.Services;
using BtkApiProject.Application.Parameters;
using BtkApiProject.Common.DTOs.Products;
using BtkApiProject.Common.Tools;
using BtkApiProject.Domain.Entities;
using MediatR;
using System.Linq.Expressions;

namespace BtkApiProject.Application.Features.Queries.Products.GetOneProduct;

public class GetOneProductQueryHandler(IProductReadRepository productReadRepository, IMapper mapper, ILoggerService logger) : IRequestHandler<GetOneProductQueryRequest, GetOneProductQueryResponse>
{
    private readonly IProductReadRepository _productReadRepository = productReadRepository;
    private readonly ILoggerService _logger = logger;
    private readonly IMapper _mapper = mapper;

    public async Task<GetOneProductQueryResponse> Handle(GetOneProductQueryRequest request, CancellationToken cancellationToken)
    {
        var parameters = _mapper.Map<ProductParameters>(request);
        Expression<Func<Product, bool>> filter = p => p.ID == Guid.Parse(request.ID);

        var product = await _productReadRepository.GetProductAsync(parameters, filter);

        if (product is not null)
        {
            ProductResponseDTO productDTO = _mapper.Map<ProductResponseDTO>(product);

            _logger.LogInfo($"{LogMessages.ProductListed} {productDTO.Name}({productDTO.ID})");
            return new() { Product = productDTO };
        }
        else
            throw new ProductNotFoundException(request.ID);
    }
}