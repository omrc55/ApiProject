using BtkApiProject.Domain.Entities;

namespace BtkApiProject.Persistence.Repositories.Read.Extensions.Products;

public static class Searches
{
    public static IQueryable<Product>? ProductSearch(this IQueryable<Product>? products, string? searchTerms)
    {
        if (products is not null)
        {
            if (!string.IsNullOrWhiteSpace(searchTerms))
            {
                var lowerCaseTerm = searchTerms.Trim().ToLower();
                products = products.Where(s => s.Name.ToLower().Contains(lowerCaseTerm) || s.Description!.ToLower().Contains(lowerCaseTerm));
            }

            return products;
        }
        else
            return null;
    }
}