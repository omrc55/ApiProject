using AutoMapper;
using BtkApiProject.Application.Interfaces.Repositories.Read;
using BtkApiProject.Application.Interfaces.Services;
using BtkApiProject.Common.DTOs.Products;
using BtkApiProject.Common.Tools;
using BtkApiProject.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BtkApiProject.Application.Features.Queries.Products.GetAllProducts;

public class GetAllProductsQueryHandler(IProductReadRepository productReadRepository, IMapper mapper, ILoggerService logger) : IRequestHandler<GetAllProductsQueryRequest, GetAllProductsQueryResponse>
{
    private readonly IProductReadRepository _productReadRepository = productReadRepository;
    private readonly ILoggerService _logger = logger;
    private readonly IMapper _mapper = mapper;

    public async Task<GetAllProductsQueryResponse> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
    {
        IQueryable<Product> product = _productReadRepository.GetAllItems();

        if (request.IsApproved is not null)
            product = product.Where(f => f.IsApproved == request.IsApproved);

        if (request.IsDeleted is not null)
            product = product.Where(f => f.IsDeleted == request.IsDeleted);

        if (request.AddProductDetail)
            product = product.Include(i => i.ProductDetail);

        if (request.AddCategory)
            product = product.Include(i => i.Category);

        if (request.AddOrders)
            product = product.Include(i => i.OrderProducts).ThenInclude(o => o.Order);

        int totalCount = await _productReadRepository.GetCountAsync();
        var productsDTO = _mapper.Map<IEnumerable<ProductResponseDTO>>(product);

        _logger.LogInfo(LogMessages.ProductsListed);
        return new() { TotalProductsCount = totalCount, QueryProductsCount = productsDTO.Count(), Products = productsDTO };
    }
}