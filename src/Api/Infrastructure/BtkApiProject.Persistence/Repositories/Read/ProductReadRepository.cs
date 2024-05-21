using BtkApiProject.Application.Helpers;
using BtkApiProject.Application.Interfaces.Repositories.Read;
using BtkApiProject.Application.Parameters;
using BtkApiProject.Domain.Entities;
using BtkApiProject.Persistence.Contexts;
using BtkApiProject.Persistence.Repositories.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BtkApiProject.Persistence.Repositories.Read;

public class ProductReadRepository(CustomDbContext context) : ReadRepository<Product>(context), IProductReadRepository
{
    public async Task<(IEnumerable<Product> products, MetaData metaData)> GetAllProductsAsync(ProductParameters parameters, bool tracking = false)
    {
        RequestParameters requestParameters = new()
        {
            IsApproved = parameters.IsApproved,
            IsDeleted = parameters.IsDeleted,
            Pagination = parameters.Pagination
        };

        (IQueryable<Product> productsQuery, int productsQueryCount) = GetAllItems(requestParameters);

        if (parameters.AddProductDetail)
            productsQuery = productsQuery.Include(pd => pd.ProductDetail);

        if (parameters.AddCategory)
            productsQuery = productsQuery.Include(c => c.Category);

        if (parameters.AddOrders)
            productsQuery = productsQuery.Include(o => o.OrderProducts!).ThenInclude(o => o.Order);

        var productsList = await productsQuery.ToListAsync();

        MetaData metaData = new()
        {
            CurrentPage = parameters.Pagination.PageNumber,
            PageSize = parameters.Pagination.PageSize,
            TotalCount = productsQueryCount
        };

        return (productsList, metaData);
    }

    public async Task<(IEnumerable<Product> products, MetaData metaData)> GetAllProductsAsync(ProductParameters parameters, Expression<Func<Product, bool>> filter, bool tracking = false)
    {
        RequestParameters requestParameters = new()
        {
            IsApproved = parameters.IsApproved,
            IsDeleted = parameters.IsDeleted,
            Pagination = parameters.Pagination
        };

        (IQueryable<Product> productsQuery, int productsQueryCount) = GetAllItems(requestParameters, filter);

        if (parameters.AddProductDetail)
            productsQuery = productsQuery.Include(pd => pd.ProductDetail);

        if (parameters.AddCategory)
            productsQuery = productsQuery.Include(c => c.Category);

        if (parameters.AddOrders)
            productsQuery = productsQuery.Include(o => o.OrderProducts!).ThenInclude(o => o.Order);

        var productList = await productsQuery.ToListAsync();

        MetaData metaData = new()
        {
            CurrentPage = parameters.Pagination.PageNumber,
            PageSize = parameters.Pagination.PageSize,
            TotalCount = productsQueryCount
        };

        return (productList, metaData);
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