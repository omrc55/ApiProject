using AutoMapper;
using BtkApiProject.Application.Interfaces.Repositories.Read;
using BtkApiProject.Application.Interfaces.Services;
using BtkApiProject.Common.DTOs.Products;
using BtkApiProject.Common.Tools;
using BtkApiProject.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BtkApiProject.Application.Features.Queries.Products.GetAllProducts;

public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQueryRequest, GetAllProductsQueryResponse>
{
    private readonly IProductReadRepository _productReadRepository;
    private readonly ILoggerService _logger;
    private readonly IMapper _mapper;

    public GetAllProductsQueryHandler(IProductReadRepository productReadRepository, IMapper mapper, ILoggerService logger)
    {
        _productReadRepository = productReadRepository;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<GetAllProductsQueryResponse> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
    {
        Expression<Func<Product, bool>>? filter = null;

        if (request.IsApproved is not null) filter = f => f.IsApproved == request.IsApproved;
        if (request.IsDeleted is not null) filter = f => f.IsDeleted == request.IsDeleted;
        if (request.IsApproved is not null & request.IsDeleted is not null) filter = f => f.IsApproved == request.IsApproved & f.IsDeleted == request.IsDeleted;

        int totalCount = await _productReadRepository.GetCountAsync();
        IQueryable<Product>? products = filter is null ? _productReadRepository.GetAllItems() : _productReadRepository.GetAllItems(filter);
        IQueryable<Product>? andProductDetail = request.AddProductDetail ? products.Include(i => i.ProductDetail) : products;
        IQueryable<Product>? andCategory = request.AddCategory ? andProductDetail.Include(i => i.Category) : andProductDetail;
        IQueryable<Product>? andOrder = request.AddOrders ? andCategory.Include(i => i.OrderProducts).ThenInclude(o => o.Order) : andCategory;

        var productsDTO = _mapper.Map<IEnumerable<ProductResponseDTO>>(andOrder);

        _logger.LogInfo(LogMessages.ProductsListed);
        return new() { TotalProductsCount = totalCount, QueryProductsCount = productsDTO.Count(), Products = productsDTO };
    }
}