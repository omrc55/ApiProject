using System.Reflection;
using System.Text;

namespace BtkApiProject.Persistence.Repositories.Read.Extensions;

public static class OrderQueryBuilder
{
    public static string CreateOrderQuery<T>(string orderByQueryString)
    {
        var orderParams = orderByQueryString.Trim().Split(',');
        var propInfos = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        var orderQueryBuilder = new StringBuilder();

        foreach (var param in orderParams)
        {
            if (string.IsNullOrWhiteSpace(param))
                continue;

            var propFromQueryName = param.Trim().Split(' ')[0];
            var objectProperty = propInfos.FirstOrDefault(pi => pi.Name.Equals(propFromQueryName, StringComparison.InvariantCultureIgnoreCase));

            if (objectProperty is null)
                continue;

            var direction = param.Trim().EndsWith(" desc") ? "descending" : "ascending";
            orderQueryBuilder.Append($"{objectProperty.Name.ToString()} {direction},");
        }

        var orderQuery = orderQueryBuilder.ToString().TrimEnd(',', ' ');

        return orderQuery;
    }
}