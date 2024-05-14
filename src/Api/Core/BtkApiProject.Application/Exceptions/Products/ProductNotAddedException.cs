using BtkApiProject.Application.Exceptions.Common;

namespace BtkApiProject.Application.Exceptions.Products;

public sealed class ProductNotAddedException : NotAddedException
{
    public ProductNotAddedException() : base("Products", ".") { }
    public ProductNotAddedException(string id) : base("The product", $": {id}") { }
}