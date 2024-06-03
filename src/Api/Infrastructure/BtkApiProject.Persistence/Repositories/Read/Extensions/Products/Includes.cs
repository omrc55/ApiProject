using BtkApiProject.Application.Parameters;
using BtkApiProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BtkApiProject.Persistence.Repositories.Read.Extensions.Products;

public static class Includes
{
    public static IQueryable<Product>? ProductIncludes(this IQueryable<Product>? products, ProductParameters parameters)
    {
        if (products is not null)
        {
            if (parameters.AddProductDetail)
                products = products.Include(d => d.ProductDetail);

            if (parameters.AddCategory)
                products = products.Include(c => c.Category);

            if (parameters.AddOrders)
                products = products.Include(o => o.OrderProducts!).ThenInclude(o => o.Order);

            return products;
        }
        else
            return null;
    }
}