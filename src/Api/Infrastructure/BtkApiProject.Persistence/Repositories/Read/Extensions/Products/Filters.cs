using BtkApiProject.Application.Exceptions.Products;
using BtkApiProject.Application.Parameters;
using BtkApiProject.Domain.Entities;

namespace BtkApiProject.Persistence.Repositories.Read.Extensions.Products;

public static class Filters
{
    public static IQueryable<Product>? ProductFilters(this IQueryable<Product>? products, ProductParameters parameters)
    {
        if (products is not null)
        {
            if (!parameters.ValidPriceRange)
                throw new PriceOutOfRangeBadRequestException();

            if (!parameters.ValidQuantity)
                throw new QuantityOutOfRangeBadRequestException();

            if (!parameters.ValidCategoryIDs)
                throw new IDsNotGuidBadRequestException(true);

            if (parameters.CategoryIDs is not null && parameters.CategoryIDs.Count != 0)
                products = products.Where(c => parameters.CategoryIDs.Contains(c.CategoryID.ToString()));

            if (parameters.MinPrice is not null)
                products = products.Where(p => p.Price >= parameters.MinPrice);

            if (parameters.MaxPrice is not null)
                products = products.Where(p => p.Price <= parameters.MaxPrice);

            if (parameters.MinQuantity is not null)
                products = products.Where(p => p.ProductDetail!.Quantity >= parameters.MinQuantity);

            if (parameters.MaxQuantity is not null)
                products = products.Where(p => p.ProductDetail!.Quantity <= parameters.MaxQuantity);

            return products;
        }
        else
            return null;
    }
}