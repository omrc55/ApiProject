using BtkApiProject.Domain.Entities.Common;
using System.Linq.Expressions;

namespace BtkApiProject.Application.Interfaces.Repositories.Generic;

public interface IReadRepository<T> : IRepository<T> where T : BaseEntity
{
    Task<int> GetCountAsync();
    Task<int> GetCountAsync(Expression<Func<T, bool>> filter);
    IQueryable<T> GetAllItems(bool tracking = false);
    IQueryable<T> GetAllItems(Expression<Func<T, bool>> filter, bool tracking = false);
    Task<T?> GetSingleAsync(Expression<Func<T, bool>> filter, bool tracking = false);
}