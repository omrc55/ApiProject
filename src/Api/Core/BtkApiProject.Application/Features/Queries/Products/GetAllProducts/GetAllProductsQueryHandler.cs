using AutoMapper;
using BtkApiProject.Application.Interfaces.Repositories.Read;
using BtkApiProject.Application.Interfaces.Services;
using BtkApiProject.Application.Parameters;
using BtkApiProject.Common.DTOs.Products;
using BtkApiProject.Common.Tools;
using MediatR;

namespace BtkApiProject.Application.Features.Queries.Products.GetAllProducts;

public class GetAllProductsQueryHandler(IProductReadRepository productReadRepository, IMapper mapper, ILoggerService logger, IProductLinks productLinks) : IRequestHandler<GetAllProductsQueryRequest, GetAllProductsQueryResponse>
{
    private readonly IProductReadRepository _productReadRepository = productReadRepository;
    private readonly IProductLinks _productLinks = productLinks;
    private readonly ILoggerService _logger = logger;
    private readonly IMapper _mapper = mapper;

    public async Task<GetAllProductsQueryResponse> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
    {
        var productParameters = _mapper.Map<ProductParameters>(request);

        var (products, metaData) = await _productReadRepository.GetAllProductsAsync(productParameters);

        var productsDTO = _mapper.Map<IEnumerable<ProductResponseDTO>>(products);
        var links = _productLinks.TryGenerateLinks(productsDTO, request.Fields);

        _logger.LogInfo(LogMessages.ProductsListed);

        return new() { MetaData = metaData, LinkResponse = links };
    }
}