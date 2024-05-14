using BtkApiProject.Application.Exceptions.Common;

namespace BtkApiProject.Application.Exceptions.Products;

public sealed class ProductNotFoundException(string id) : NotFoundException("The product", $": {id}") { }