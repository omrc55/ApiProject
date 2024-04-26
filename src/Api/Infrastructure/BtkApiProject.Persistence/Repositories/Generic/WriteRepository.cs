using BtkApiProject.Application.Interfaces.Repositories.Generic;
using BtkApiProject.Domain.Entities.Common;
using BtkApiProject.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BtkApiProject.Persistence.Repositories.Generic;

public abstract class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
{
    private readonly CustomDbContext _context;

    public WriteRepository(CustomDbContext context)
    {
        _context = context;
    }

    public DbSet<T> Table => _context.Set<T>();

    public async Task<bool> AddAsync(T model)
    {
        EntityEntry<T> entry = await Table.AddAsync(model);
        return entry.State == EntityState.Added;
    }

    public async Task<bool> AddAsync(List<T> datas)
    {
        try
        {
            await Table.AddRangeAsync(datas);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<bool> ApproveAsync(string id)
    {
        T? model = await Table.FirstOrDefaultAsync(d => d.ID == Guid.Parse(id));

        if (model is not null)
        {
            model.IsApproved = true;
            return true;
        }
        else
        {
            return false;
        }
    }

    public Task<bool> ApproveAsync(T model)
    {
        model.IsApproved = true;
        EntityEntry<T> entry = Table.Update(model);
        return Task.FromResult(entry.State == EntityState.Modified);
    }

    public async Task<bool> ApproveAsync(List<string> ids)
    {
        try
        {
            foreach (string id in ids)
            {
                T? model = await Table.FirstOrDefaultAsync(d => d.ID == Guid.Parse(id));

                if (model is not null)
                {
                    model.IsApproved = true;
                }
            }

            return true;
        }
        catch
        {
            return false;
        }
    }

    public Task<bool> ApproveAsync(List<T> datas)
    {
        foreach (T data in datas)
        {
            data.IsApproved = true;
        }

        try
        {
            Table.UpdateRange(datas);
            return Task.FromResult(true);
        }
        catch
        {
            return Task.FromResult(false);
        }
    }

    public async Task<bool> DeleteAsync(string id)
    {
        T? model = await Table.FirstOrDefaultAsync(d => d.ID == Guid.Parse(id));

        if (model is not null)
        {
            model.IsDeleted = true;
            return true;
        }
        else
        {
            return false;
        }
    }

    public Task<bool> DeleteAsync(T model)
    {
        model.IsDeleted = true;
        EntityEntry<T> entry = Table.Update(model);
        return Task.FromResult(entry.State == EntityState.Modified);
    }

    public async Task<bool> DeleteAsync(List<string> ids)
    {
        try
        {
            foreach (string id in ids)
            {
                T? model = await Table.FirstOrDefaultAsync(d => d.ID == Guid.Parse(id));

                if (model is not null)
                {
                    model.IsDeleted = true;
                }
            }

            return true;
        }
        catch
        {
            return false;
        }
    }

    public Task<bool> DeleteAsync(List<T> datas)
    {
        foreach (T data in datas)
        {
            data.IsDeleted = true;
        }

        try
        {
            Table.UpdateRange(datas);
            return Task.FromResult(true);
        }
        catch
        {
            return Task.FromResult(false);
        }
    }

    public Task<bool> HardDeleteAsync(T model)
    {
        if (model is not null)
        {
            EntityEntry<T> entityEntry = Table.Remove(model);
            return Task.FromResult(entityEntry.State == EntityState.Deleted);
        }
        else
        {
            return Task.FromResult(false);
        }
    }

    public async Task<bool> HardDeleteAsync(string id)
    {
        T? model = await Table.AsNoTracking().FirstOrDefaultAsync(d => d.ID == Guid.Parse(id));

        if (model is not null)
            return await HardDeleteAsync(model);
        else
            return false;
    }

    public Task<bool> HardDeleteAsync(List<T> datas)
    {
        try
        {
            Table.RemoveRange(datas);
            return Task.FromResult(true);
        }
        catch
        {
            return Task.FromResult(false);
        }
    }

    public async Task<bool> HardDeleteAsync(List<string> ids)
    {
        List<T> datas = [];

        foreach (string id in ids)
        {
            T? model = await Table.AsNoTracking().FirstOrDefaultAsync(d => d.ID == Guid.Parse(id));

            if (model is not null)
                datas.Add(model);
        }

        return await HardDeleteAsync(datas);
    }

    public async Task<int> SaveAsync() => await _context.SaveChangesAsync();

    public Task<bool> UpdateAsync(T model)
    {
        EntityEntry<T> entry = Table.Update(model);
        return Task.FromResult(entry.State == EntityState.Modified);
    }

    public Task<bool> UpdateAsync(List<T> datas)
    {
        try
        {
            Table.UpdateRange(datas);
            return Task.FromResult(true);
        }
        catch
        {
            return Task.FromResult(false);
        }
    }
}