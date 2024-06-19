using BtkApiProject.Application.Helpers;

namespace BtkApiProject.Application.Interfaces.Services;

public interface IDataShaper<T> where T : class
{
    IEnumerable<ShapedEntity>? ShapeData(IEnumerable<T>? entities, string? filedsString);
    ShapedEntity? ShapeData(T? entity, string? filedsString);
}