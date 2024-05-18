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

public class GetOneProductQueryHandler(IProductReadRepository productReadRepository, IMapper mapper, ILoggerService logger) : IRequestHandler<GetOneProductQueryRequest, GetOneProductQueryResponse>
{
    private readonly IProductReadRepository _productReadRepository = productReadRepository;
    private readonly ILoggerService _logger = logger;
    private readonly IMapper _mapper = mapper;

    public async Task<GetOneProductQueryResponse> Handle(GetOneProductQueryRequest request, CancellationToken cancellationToken)
    {
        IQueryable<Product> products = _productReadRepository.GetAllItems();
        products = products.Where(p => p.ID == Guid.Parse(request.ID));

        if (products.Any())
        {
            if (request.AddProductDetail)
                products = products.Include(i => i.ProductDetail);

            if (request.AddCategory)
                products = products.Include(i => i.Category);

            if (request.AddOrders)
                products = products.Include(i => i.OrderProducts).ThenInclude(o => o.Order);

            Product? product = await products.FirstOrDefaultAsync(cancellationToken);
            ProductResponseDTO productDTO = _mapper.Map<ProductResponseDTO>(product);

            _logger.LogInfo($"{LogMessages.ProductListed} {productDTO.Name}({productDTO.ID})");
            return new() { Product = productDTO };
        }
        else
            throw new ProductNotFoundException(request.ID);

    }
}