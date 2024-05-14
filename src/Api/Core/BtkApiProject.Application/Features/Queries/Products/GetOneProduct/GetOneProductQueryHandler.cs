using AutoMapper;
using BtkApiProject.Application.Exceptions.Products;
using BtkApiProject.Application.Interfaces.Repositories.Read;
using BtkApiProject.Application.Interfaces.Services;
using BtkApiProject.Common.DTOs.Products;
using BtkApiProject.Common.Tools;
using BtkApiProject.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BtkApiProject.Application.Features.Queries.Products.GetOneProduct;

public class GetOneProductQueryHandler : IRequestHandler<GetOneProductQueryRequest, GetOneProductQueryResponse>
{
    private readonly IProductReadRepository _productReadRepository;
    private readonly ILoggerService _logger;
    private readonly IMapper _mapper;

    public GetOneProductQueryHandler(IProductReadRepository productReadRepository, IMapper mapper, ILoggerService logger)
    {
        _productReadRepository = productReadRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<GetOneProductQueryResponse> Handle(GetOneProductQueryRequest request, CancellationToken cancellationToken)
    {
        ProductResponseDTO productDTO;
        IQueryable<Product> products = _productReadRepository.GetAllItems().Where(p => p.ID == Guid.Parse(request.ID));

        if (products.Any())
        {
            IQueryable<Product>? andProductDetail = request.AddProductDetail ? products.Include(p => p.ProductDetail) : products;
            IQueryable<Product>? andCategory = request.AddCategory ? andProductDetail.Include(i => i.Category) : andProductDetail;
            Product? andOrder = request.AddOrders ? await andCategory.Include(i => i.OrderProducts).ThenInclude(o => o.Order).FirstOrDefaultAsync(cancellationToken) : await andCategory.FirstOrDefaultAsync(cancellationToken);
            productDTO = _mapper.Map<ProductResponseDTO>(andOrder);
        }
        else
            throw new ProductNotFoundException(request.ID);

        _logger.LogInfo($"{LogMessages.ProductListed} {productDTO.Name}({productDTO.ID})");
        return new() { Product = productDTO };
    }
}
