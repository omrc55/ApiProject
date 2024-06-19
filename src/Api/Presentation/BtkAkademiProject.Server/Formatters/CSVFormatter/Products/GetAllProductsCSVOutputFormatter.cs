using BtkApiProject.Application.Features.Queries.Products.GetAllProducts;
using System.Text;

namespace BtkAkademiProject.Server.Formatters.CSVFormatter.Products;

public static class GetAllProductsCSVOutputFormatter
{
    public static void Formatter(StringBuilder buffer, GetAllProductsQueryResponse products)
    {
        //if (products.Products is not null)
        //{
        //    foreach (var product in products.Products)
        //    {
        //        buffer.AppendLine($"{product.ID}, {product.Name}, {product.Price}, {product.CreatedDate}, {product.UpdatedDate}, {product.IsApproved}, {product.IsDeleted}");
        //    }
        //}
    }
}