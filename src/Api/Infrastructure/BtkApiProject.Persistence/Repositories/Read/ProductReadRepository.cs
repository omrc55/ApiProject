using AutoMapper;
using BtkApiProject.Application.Helpers;
using BtkApiProject.Application.Interfaces.Repositories.Read;
using BtkApiProject.Application.Parameters;
using BtkApiProject.Domain.Entities;
using BtkApiProject.Persistence.Contexts;
using BtkApiProject.Persistence.Repositories.Generic;
using BtkApiProject.Persistence.Repositories.Read.Extensions;
using BtkApiProject.Persistence.Repositories.Read.Extensions.Products;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BtkApiProject.Persistence.Repositories.Read;

public class ProductReadRepository(CustomDbContext context, IMapper mapper) : ReadRepository<Product>(context), IProductReadRepository
{
    private readonly IMapper _mapper = mapper;

    public async Task<(IEnumerable<Product>? products, MetaData metaData)> GetAllProductsAsync(ProductParameters parameters, bool tracking = false)
    {
        var requestParameters = _mapper.Map<RequestParameters>(parameters);

        IQueryable<Product> productsQuery = GetAllItems();

        (IEnumerable<Product>? products, int count) = await BaseFilters<Product>.ItemFilters(productsQuery, requestParameters).ProductFilters(parameters).ProductIncludes(parameters).ProductSearch(parameters.SearchTerm).OrderByProducts(parameters.OrderBy).ProductPaginationAsync(parameters.Pagination);

        MetaData metaData = new()
        {
            CurrentPage = parameters.Pagination.PageNumber,
            PageSize = parameters.Pagination.PageSize,
            TotalCount = count
        };

        return (products, metaData);
    }

    public async Task<(IEnumerable<Product>? products, MetaData metaData)> GetAllProductsAsync(ProductParameters parameters, Expression<Func<Product, bool>> filter, bool tracking = false)
    {
        var requestParameters = _mapper.Map<RequestParameters>(parameters);

        IQueryable<Product> productsQuery = GetAllItems(filter);

        (IEnumerable<Product>? products, int count) = await BaseFilters<Product>.ItemFilters(productsQuery, requestParameters).ProductFilters(parameters).ProductIncludes(parameters).ProductSearch(parameters.SearchTerm).OrderByProducts(parameters.OrderBy).ProductPaginationAsync(parameters.Pagination);

        MetaData metaData = new()
        {
            CurrentPage = parameters.Pagination.PageNumber,
            PageSize = parameters.Pagination.PageSize,
            TotalCount = count
        };

        return (products, metaData);
    }

    public async Task<Product?> GetProductAsync(ProductParameters parameters, Expression<Func<Product, bool>> filter, bool tracking = false)
    {
        IQueryable<Product> products = GetAllItems(filter);

        if (parameters.AddProductDetail)
            products = products.Include(pd => pd.ProductDetail);

        if (parameters.AddCategory)
            products = products.Include(c => c.Category);

        if (parameters.AddOrders)
            products = products.Include(o => o.OrderProducts!).ThenInclude(o => o.Order);

        return await products.FirstOrDefaultAsync();
    }
}