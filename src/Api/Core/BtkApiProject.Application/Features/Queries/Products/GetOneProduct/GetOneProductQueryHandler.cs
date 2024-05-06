using AutoMapper;
using BtkApiProject.Common.DTOs.Products;
using BtkApiProject.Application.Interfaces.Repositories.Read;
using BtkApiProject.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using BtkApiProject.Common.Tools;

namespace BtkApiProject.Application.Features.Queries.Products.GetOneProduct;

public class GetOneProductQueryHandler : IRequestHandler<GetOneProductQueryRequest, GetOneProductQueryResponse>
{
    private readonly IProductReadRepository _productReadRepository;
    private readonly ILogger<GetOneProductQueryHandler> _logger;
    private readonly IMapper _mapper;

    public GetOneProductQueryHandler(IProductReadRepository productReadRepository, IMapper mapper, ILogger<GetOneProductQueryHandler> logger)
    {
        _productReadRepository = productReadRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<GetOneProductQueryResponse> Handle(GetOneProductQueryRequest request, CancellationToken cancellationToken)
    {
        IQueryable<Product>? product = _productReadRepository.GetAllItems().Where(p => p.ID == Guid.Parse(request.ID));
        IQueryable<Product>? andProductDetail = request.AddProductDetail ? product.Include(p => p.ProductDetail) : product;
        IQueryable<Product>? andCategory = request.AddCategory ? andProductDetail.Include(i => i.Category) : andProductDetail;
        Product? andOrder = request.AddOrders ? await andCategory.Include(i => i.OrderProducts).ThenInclude(o => o.Order).FirstOrDefaultAsync() : await andCategory.FirstOrDefaultAsync();

        var productDTO = _mapper.Map<ProductResponseDTO>(andOrder);

        _logger.LogInformation($"{LogMessages.ProductListed} {productDTO.Name}({productDTO.ID})");
        return new() { Product = productDTO };
    }
}
