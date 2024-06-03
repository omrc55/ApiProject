using BtkApiProject.Domain.Entities;
using System.Linq.Dynamic.Core;

namespace BtkApiProject.Persistence.Repositories.Read.Extensions.Products;

public static class Sort
{
    public static IQueryable<Product>? OrderByProducts(this IQueryable<Product>? products, string? orderByQueryString)
    {
        if (products is not null)
        {
            if (!string.IsNullOrWhiteSpace(orderByQueryString))
            {
                var orderQuery = OrderQueryBuilder.CreateOrderQuery<Product>(orderByQueryString);
                return products.OrderBy(orderQuery);
            }

            return products;
        }
        else
            return products;
    }
}