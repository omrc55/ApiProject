using BtkApiProject.Application.Exceptions.Products;
using BtkApiProject.Application.Parameters;
using BtkApiProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BtkApiProject.Persistence.Repositories.Read.Helpers;

public static class ProductFiltersHelper
{
    public static async Task<(IEnumerable<Product>? products, int count)> ProductFiltersAsync(this IQueryable<Product>? thisProducts, ProductParameters parameters)
    {
        if (thisProducts is not null)
        {
            if (!parameters.ValidPriceRange)
                throw new PriceOutOfRangeBadRequestException();

            if (!parameters.ValidQuantity)
                throw new QuantityOutOfRangeBadRequestException();

            if (!parameters.ValidCategoryIDs)
                throw new IDsNotGuidBadRequestException(true);

            if (parameters.CategoryIDs is not null && parameters.CategoryIDs.Count != 0)
                thisProducts = thisProducts.Where(c => parameters.CategoryIDs.Contains(c.CategoryID.ToString()));

            if (parameters.MinPrice is not null)
                thisProducts = thisProducts.Where(p => p.Price >= parameters.MinPrice);

            if (parameters.MaxPrice is not null)
                thisProducts = thisProducts.Where(p => p.Price <= parameters.MaxPrice);

            if (parameters.MinQuantity is not null)
                thisProducts = thisProducts.Where(p => p.ProductDetail!.Quantity >= parameters.MinQuantity);

            if (parameters.MaxQuantity is not null)
                thisProducts = thisProducts.Where(p => p.ProductDetail!.Quantity <= parameters.MaxQuantity);

            if (parameters.AddProductDetail)
                thisProducts = thisProducts.Include(d => d.ProductDetail);

            if (parameters.AddCategory)
                thisProducts = thisProducts.Include(c => c.Category);

            if (parameters.AddOrders)
                thisProducts = thisProducts.Include(o => o.OrderProducts!).ThenInclude(o => o.Order);

            var productCount = await thisProducts.CountAsync();
            var products = await thisProducts.Skip((parameters.Pagination.PageNumber - 1) * parameters.Pagination.PageSize).Take(parameters.Pagination.PageSize).ToListAsync();

            return (products, productCount);
        }
        else
            return (null, 0);
    }
}