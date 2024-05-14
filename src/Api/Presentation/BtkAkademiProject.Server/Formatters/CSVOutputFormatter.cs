using BtkApiProject.Application.Features.Queries.Products.GetAllProducts;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using System.Net.Mime;
using System.Text;

namespace BtkAkademiProject.Server.Formatters;

public class CSVOutputFormatter : TextOutputFormatter
{
    public CSVOutputFormatter()
    {
        SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse(MediaTypeNames.Text.Csv));
        SupportedEncodings.Add(Encoding.UTF8);
        SupportedEncodings.Add(Encoding.Unicode);
    }

    protected override bool CanWriteType(Type? type)
    {
        if (typeof(GetAllProductsQueryResponse).IsAssignableFrom(type) || typeof(IEnumerable<GetAllProductsQueryResponse>).IsAssignableFrom(type))
        {
            return base.CanWriteType(type);
        }
        return false;
    }

    private static void FormatCSV(StringBuilder buffer, GetAllProductsQueryResponse product)
    {
        buffer.AppendLine($"{product.QueryProductsCount}, {product.TotalProductsCount}");
    }

    public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
    {
        var response = context.HttpContext.Response;
        var buffer = new StringBuilder();
        var obj = context.Object;

        if (obj is IEnumerable<GetAllProductsQueryResponse> products)
        {
            foreach (var product in products)
            {
                FormatCSV(buffer, product);
            }
        }
        else
        {
            if (obj is not null)
                FormatCSV(buffer, (GetAllProductsQueryResponse)obj);
        }

        await response.WriteAsync(buffer.ToString());
    }
}