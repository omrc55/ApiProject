using System.Dynamic;

namespace BtkApiProject.Application.Interfaces.Services;

public interface IDataShaper<T> where T : class
{
    IEnumerable<ExpandoObject>? ShapeData(IEnumerable<T>? entities, string? filedsString);
    ExpandoObject? ShapeData(T? entity, string? filedsString);
}