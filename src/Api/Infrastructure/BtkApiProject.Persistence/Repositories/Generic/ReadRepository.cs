using BtkApiProject.Application.Interfaces.Repositories.Generic;
using BtkApiProject.Domain.Entities.Common;
using BtkApiProject.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BtkApiProject.Persistence.Repositories.Generic;

public abstract class ReadRepository<T>(CustomDbContext context) : IReadRepository<T> where T : BaseEntity
{
    private readonly CustomDbContext _context = context;

    public DbSet<T> Table => _context.Set<T>();

    public IQueryable<T> GetAllItems(bool tracking = false)
    {
        IQueryable<T> query = Table.AsQueryable().OrderBy(o => o.CreatedDate);

        if (!tracking)
            query.AsNoTracking();

        return query;
    }

    public IQueryable<T> GetAllItems(Expression<Func<T, bool>> filter, bool tracking = false)
    {
        IQueryable<T> query = Table.Where(filter).OrderBy(o => o.CreatedDate);

        if (!tracking)
            query.AsNoTracking();

        return query;
    }

    public async Task<int> GetCountAsync() => await Table.AsNoTracking().CountAsync();

    public async Task<int> GetCountAsync(Expression<Func<T, bool>> filter) => await Table.AsNoTracking().CountAsync(filter);
}