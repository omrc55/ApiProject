using BtkApiProject.Application.Helpers;
using BtkApiProject.Application.Interfaces.Services;
using System.Reflection;

namespace BtkApiProject.Persistence.Services;

public class DataShaper<T> : IDataShaper<T> where T : class
{
    public DataShaper()
    {
        Properties = typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public);
    }

    public PropertyInfo[] Properties { get; init; }

    public IEnumerable<ShapedEntity>? ShapeData(IEnumerable<T>? entities, string? filedsString)
    {
        var requiredFields = GetRequiredProperties(filedsString);
        return FetchData(entities, requiredFields);
    }

    public ShapedEntity? ShapeData(T? entity, string? filedsString)
    {
        var requiredProperties = GetRequiredProperties(filedsString);
        return FetchDataForEntity(entity, requiredProperties);
    }

    private IEnumerable<PropertyInfo>? GetRequiredProperties(string? fieldsString)
    {
        var requiredFields = new List<PropertyInfo>();

        if (!string.IsNullOrWhiteSpace(fieldsString))
        {
            var fields = fieldsString.Trim().Split(',', StringSplitOptions.RemoveEmptyEntries);

            foreach (var field in fields)
            {
                var property = Properties.FirstOrDefault(p => p.Name.Equals(field.Trim(), StringComparison.InvariantCultureIgnoreCase));

                if (property is not null)
                    requiredFields.Add(property);
            }
        }
        else
            requiredFields = [.. Properties];

        return requiredFields;
    }

    private ShapedEntity? FetchDataForEntity(T? entity, IEnumerable<PropertyInfo>? requiredProperties)
    {
        ShapedEntity shapedObject = new();

        if (requiredProperties is not null)
        {
            foreach (var property in requiredProperties)
            {
                var objectPropertyValue = property.GetValue(entity);

                if (objectPropertyValue is not null)
                {
                    shapedObject.Entity ??= new();
                    shapedObject.Entity.TryAdd(property.Name, objectPropertyValue);
                }
            }

            if (entity is not null)
            {
                var objectValue = entity.GetType().GetProperty("ID");

                if (objectValue is not null)
                {
                    var val = objectValue.GetValue(entity);

                    if (val is not null)
                        shapedObject.ID = (Guid)val;
                }
            }
        }

        return shapedObject;
    }

    private IEnumerable<ShapedEntity>? FetchData(IEnumerable<T>? entities, IEnumerable<PropertyInfo>? requiredProperties)
    {
        var shapedData = new List<ShapedEntity>();

        if (entities is not null)
        {
            foreach (var entity in entities)
            {
                var shapedObject = FetchDataForEntity(entity, requiredProperties);

                if (shapedObject is not null)
                    shapedData.Add(shapedObject);
            }
        }

        return shapedData;
    }
}