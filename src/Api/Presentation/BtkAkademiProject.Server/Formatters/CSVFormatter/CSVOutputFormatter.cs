using BtkAkademiProject.Server.Formatters.CSVFormatter.Products;
using BtkApiProject.Application.Features.Queries.Products.GetAllProducts;
using BtkApiProject.Application.Features.Queries.Products.GetOneProduct;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using System.Net.Mime;
using System.Text;

namespace BtkAkademiProject.Server.Formatters.CSVFormatter;

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
        if (typeof(GetAllProductsQueryResponse).IsAssignableFrom(type) || typeof(GetOneProductQueryResponse).IsAssignableFrom(type))
        {
            return base.CanWriteType(type);
        }
        return false;
    }

    public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
    {
        var response = context.HttpContext.Response;
        var buffer = new StringBuilder();
        var obj = context.Object;

        if (obj is GetAllProductsQueryResponse products)
        {
            GetAllProductsCSVOutputFormatter.Formatter(buffer, products);
        }

        if (obj is GetOneProductQueryResponse product)
        {
            GetOneProductCSVOutputFormatter.Formatter(buffer, product);
        }

        await response.WriteAsync(buffer.ToString());
    }
}