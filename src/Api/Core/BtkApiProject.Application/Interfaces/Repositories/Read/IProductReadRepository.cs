using BtkApiProject.Application.Helpers;
using BtkApiProject.Application.Interfaces.Repositories.Generic;
using BtkApiProject.Application.Parameters;
using BtkApiProject.Domain.Entities;
using System.Linq.Expressions;

namespace BtkApiProject.Application.Interfaces.Repositories.Read;

public interface IProductReadRepository : IReadRepository<Product>
{
    Task<(IEnumerable<Product> products, MetaData metaData)> GetAllProductsAsync(ProductParameters parameters, bool tracking = false);
    Task<(IEnumerable<Product> products, MetaData metaData)> GetAllProductsAsync(ProductParameters parameters, Expression<Func<Product, bool>> filter, bool tracking = false);
    Task<Product?> GetProductAsync(ProductParameters parameters, Expression<Func<Product, bool>> filter, bool tracking = false);
}