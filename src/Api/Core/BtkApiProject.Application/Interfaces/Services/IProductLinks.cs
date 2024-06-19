using BtkApiProject.Application.Helpers.Links;
using BtkApiProject.Common.DTOs.Products;
using Microsoft.AspNetCore.Http;

namespace BtkApiProject.Application.Interfaces.Services;

public interface IProductLinks
{
    LinkResponse TryGenerateLinks(IEnumerable<ProductResponseDTO>? products, string? fields);
}