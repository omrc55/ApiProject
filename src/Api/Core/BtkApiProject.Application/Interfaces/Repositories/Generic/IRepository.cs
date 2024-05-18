using BtkApiProject.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace BtkApiProject.Application.Interfaces.Repositories.Generic;

public interface IRepository<T> where T : BaseEntity
{
    DbSet<T> Table { get; }
}