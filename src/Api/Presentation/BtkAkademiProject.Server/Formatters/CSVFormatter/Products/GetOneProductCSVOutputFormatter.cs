using BtkApiProject.Application.Features.Queries.Products.GetOneProduct;
using System.Text;

namespace BtkAkademiProject.Server.Formatters.CSVFormatter.Products;

public static class GetOneProductCSVOutputFormatter
{
    public static void Formatter(StringBuilder buffer, GetOneProductQueryResponse product)
    {
        if (product.Product is not null)
        {
            buffer.AppendLine($"ID: {product.Product.ID}, Name: {product.Product.Name}, Price: {product.Product.Price}");

            if (product.Product.ProductDetail is not null)
            {
                buffer.AppendLine($"Quantity: {product.Product.ProductDetail.Quantity}");
            }

            if (product.Product.Category is not null)
            {
                buffer.AppendLine($"Category ID: {product.Product.CategoryID} Category: {product.Product.Category.Name}");
            }
        }
    }
}