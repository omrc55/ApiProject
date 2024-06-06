using BtkApiProject.Application.Interfaces.Services;
using System.Dynamic;
using System.Reflection;

namespace BtkApiProject.Persistence.Services;

public class DataShaper<T> : IDataShaper<T> where T : class
{
    public DataShaper()
    {
        Properties = typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public);
    }

    public PropertyInfo[] Properties { get; init; }

    public IEnumerable<ExpandoObject>? ShapeData(IEnumerable<T>? entities, string? filedsString)
    {
        var requiredFields = GetRequiredProperties(filedsString);
        return FetchData(entities, requiredFields);
    }

    public ExpandoObject? ShapeData(T? entity, string? filedsString)
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

    private ExpandoObject? FetchDataForEntity(T? entity, IEnumerable<PropertyInfo>? requiredProperties)
    {
        var shapedObject = new ExpandoObject();

        if (requiredProperties is not null)
        {
            foreach (var property in requiredProperties)
            {
                var objectPropertyValue = property.GetValue(entity);
                shapedObject.TryAdd(property.Name, objectPropertyValue);
            }
        }

        return shapedObject;
    }

    private IEnumerable<ExpandoObject>? FetchData(IEnumerable<T>? entities, IEnumerable<PropertyInfo>? requiredProperties)
    {
        var shapedData = new List<ExpandoObject>();

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