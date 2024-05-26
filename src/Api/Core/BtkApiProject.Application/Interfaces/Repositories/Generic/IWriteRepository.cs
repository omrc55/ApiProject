using BtkApiProject.Domain.Entities.Common;

namespace BtkApiProject.Application.Interfaces.Repositories.Generic;

public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
{
    Task<bool> AddAsync(T model);
    Task<bool> AddAsync(List<T> datas);
    Task<bool> UpdateAsync(T model);
    Task<bool> UpdateAsync(List<T> datas);
    Task<bool> ApproveAsync(string id);
    Task<bool> ApproveAsync(T model);
    Task<bool> ApproveAsync(List<string> ids);
    Task<bool> ApproveAsync(List<T> datas);
    Task<bool> DeleteAsync(string id);
    Task<bool> DeleteAsync(T model);
    Task<bool> DeleteAsync(List<string> ids);
    Task<bool> DeleteAsync(List<T> datas);
    Task<bool> HardDeleteAsync(T model);
    Task<bool> HardDeleteAsync(string id);
    Task<bool> HardDeleteAsync(List<T> datas);
    Task<bool> HardDeleteAsync(List<string> ids);
    Task<int> SaveAsync();
}