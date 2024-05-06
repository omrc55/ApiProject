using MediatR;
using AutoMapper;
using BtkApiProject.Common.DTOs.Products;
using BtkApiProject.Application.Interfaces.Repositories.Read;
using BtkApiProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using BtkApiProject.Common.Tools;
using System.Linq.Expressions;

namespace BtkApiProject.Application.Features.Queries.Products.GetAllProducts;

public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQueryRequest, GetAllProductsQueryResponse>
{
    private readonly IProductReadRepository _productReadRepository;
    private readonly ILogger<GetAllProductsQueryHandler> _logger;
    private readonly IMapper _mapper;

    public GetAllProductsQueryHandler(IProductReadRepository productReadRepository, IMapper mapper, ILogger<GetAllProductsQueryHandler> logger)
    {
        _productReadRepository = productReadRepository;
        _logger = logger;
        _mapper = mapper;
    }

    public Task<GetAllProductsQueryResponse> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
    {
        Expression<Func<Product, bool>>? filter;

        if (request.IsDeleted)
            filter = f => f.IsDeleted;
        else if (request.IsApproved)
            filter = f => f.IsApproved;
        else
            filter = null;

        IQueryable<Product>? products = filter is null ? _productReadRepository.GetAllItems() : _productReadRepository.GetAllItems(filter);
        IQueryable<Product>? andProductDetail = request.AddProductDetail ? products.Include(i => i.ProductDetail) : products;
        IQueryable<Product>? andCategory = request.AddCategory ? andProductDetail.Include(i => i.Category) : andProductDetail;
        IQueryable<Product>? andOrder = request.AddOrders ? andCategory.Include(i => i.OrderProducts).ThenInclude(o => o.Order) : andCategory;

        var productsDTO = _mapper.Map<IEnumerable<ProductResponseDTO>>(andOrder);

        _logger.LogInformation(LogMessages.ProductsListed);
        return Task.FromResult<GetAllProductsQueryResponse>(new() { Products = productsDTO });
    }
}
