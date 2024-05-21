using BtkApiProject.Application.Interfaces.Repositories.Generic;
using BtkApiProject.Application.Parameters;
using BtkApiProject.Domain.Entities.Common;
using BtkApiProject.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BtkApiProject.Persistence.Repositories.Generic;

public abstract class ReadRepository<T>(CustomDbContext context) : IReadRepository<T> where T : BaseEntity
{
    private readonly CustomDbContext _context = context;

    public DbSet<T> Table => _context.Set<T>();

    public (IQueryable<T> items, int count) GetAllItems(RequestParameters parameters, bool tracking = false)
    {
        IQueryable<T> query = Table.AsQueryable().OrderBy(o => o.CreatedDate);

        if (parameters.IsApproved is not null)
            query = query.Where(a => a.IsApproved == parameters.IsApproved);

        if (parameters.IsDeleted is not null)
            query = query.Where(d => d.IsDeleted == parameters.IsDeleted);

        if (!tracking)
            query.AsNoTracking();

        int queryCount = query.Count();
        query = query.Skip((parameters.Pagination.PageNumber - 1) * parameters.Pagination.PageSize).Take(parameters.Pagination.PageSize);

        return (query, queryCount);
    }

    public (IQueryable<T> items, int count) GetAllItems(RequestParameters parameters, Expression<Func<T, bool>> filter, bool tracking = false)
    {
        IQueryable<T> query = Table.Where(filter).OrderBy(o => o.CreatedDate);

        if (parameters.IsApproved is not null)
            query = query.Where(a => a.IsApproved == parameters.IsApproved);

        if (parameters.IsDeleted is not null)
            query = query.Where(d => d.IsDeleted == parameters.IsDeleted);

        if (!tracking)
            query.AsNoTracking();

        int queryCount = query.Count();
        query = query.Skip((parameters.Pagination.PageNumber - 1) * parameters.Pagination.PageSize).Take(parameters.Pagination.PageSize);

        return (query, queryCount);
    }

    public IQueryable<T> GetAllItems(Expression<Func<T, bool>> filter, bool tracking = false)
    {
        IQueryable<T> query = Table.Where(filter);

        if (!tracking)
            query.AsNoTracking();

        return query;
    }

    public async Task<int> GetCountAsync() => await Table.AsNoTracking().CountAsync();

    public async Task<int> GetCountAsync(Expression<Func<T, bool>> filter) => await Table.AsNoTracking().CountAsync(filter);
}