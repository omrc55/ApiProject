using BtkApiProject.Application.Parameters;
using BtkApiProject.Domain.Entities.Common;
using System.Linq.Expressions;

namespace BtkApiProject.Application.Interfaces.Repositories.Generic;

public interface IReadRepository<T> : IRepository<T> where T : BaseEntity
{
    Task<int> GetCountAsync();
    Task<int> GetCountAsync(Expression<Func<T, bool>> filter);
    (IQueryable<T> items, int count) GetAllItems(RequestParameters parameters, bool tracking = false);
    IQueryable<T> GetAllItems(Expression<Func<T, bool>> filter, bool tracking = false);
    (IQueryable<T> items, int count) GetAllItems(RequestParameters parameters, Expression<Func<T, bool>> filter, bool tracking = false);
}