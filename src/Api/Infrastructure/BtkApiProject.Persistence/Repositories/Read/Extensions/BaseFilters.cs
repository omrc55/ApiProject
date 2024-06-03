using BtkApiProject.Application.Parameters;
using BtkApiProject.Domain.Entities.Common;

namespace BtkApiProject.Persistence.Repositories.Read.Extensions;

public static class BaseFilters<T> where T : BaseEntity
{
    public static IQueryable<T>? ItemFilters(IQueryable<T>? values, RequestParameters parameters)
    {
        if (values is not null)
        {
            if (parameters.IsApproved is not null)
                values = values.Where(a => a.IsApproved == parameters.IsApproved);

            if (parameters.IsDeleted is not null)
                values = values.Where(a => a.IsDeleted == parameters.IsDeleted);

            return values;
        }
        else
            return null;
    }
}