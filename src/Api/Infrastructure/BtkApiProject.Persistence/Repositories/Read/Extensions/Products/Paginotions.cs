using BtkApiProject.Application.Helpers;
using BtkApiProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BtkApiProject.Persistence.Repositories.Read.Extensions.Products;

public static class Paginotions
{
    public static async Task<(IEnumerable<Product>? products, int count)> ProductPaginationAsync(this IQueryable<Product>? thisProducts, Pagination pagination)
    {
        if (thisProducts is not null)
        {
            var productCount = await thisProducts.CountAsync();
            var products = await thisProducts.Skip((pagination.PageNumber - 1) * pagination.PageSize).Take(pagination.PageSize).ToListAsync();

            return (products, productCount);
        }
        else
            return (null, 0);
    }
}