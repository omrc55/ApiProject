using BtkApiProject.Application.Helpers;
using BtkApiProject.Application.Helpers.Links;
using BtkApiProject.Application.Interfaces.Services;
using BtkApiProject.Common.DTOs.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Net.Http.Headers;

namespace BtkApiProject.Persistence.Services;

public class ProductLinks(IDataShaper<ProductResponseDTO> shaper, IHttpContextAccessor context) : IProductLinks
{
    private readonly IDataShaper<ProductResponseDTO> _shaper = shaper;
    private readonly IHttpContextAccessor _context = context;

    public LinkResponse TryGenerateLinks(IEnumerable<ProductResponseDTO>? products, string? fields)
    {
        var shapedProducts = ShapeData(products, fields);

        if (ShouldGenerateLinks(_context.HttpContext))
            return ReturnLinkedProducts(products, fields, _context.HttpContext, shapedProducts);

        return ReturnShapedProducts(shapedProducts);
    }

    private static LinkResponse ReturnLinkedProducts(IEnumerable<ProductResponseDTO>? products, string? fields, HttpContext? httpContext, List<Entity?>? shapedProducts)
    {
        var productList = products?.ToList();

        for (int index = 0; index < productList?.Count; index++)
        {
            var productLinks = CreateForProduct(httpContext, productList[index], fields);
            shapedProducts?[index]?.Add("Links", productLinks);
        }

        LinkCollectionWrapper<Entity?>? productCollection = new(shapedProducts);
        CreateForProducts(httpContext, productCollection);

        return new LinkResponse() { HasLinks = true, LinkedEntities = productCollection };
    }

    private static LinkCollectionWrapper<Entity?>? CreateForProducts(HttpContext? httpContext, LinkCollectionWrapper<Entity?>? productCollectionWrapper)
    {
        productCollectionWrapper?.Links?.Add(new() { Href = $"/{httpContext.GetRouteData().Values["controller"].ToString()?.ToLower()}", Rel = "self", Method = "GET" });

        return productCollectionWrapper;
    }

    private static List<Link> CreateForProduct(HttpContext? httpContext, ProductResponseDTO? productResponseDTO, string? fields)
    {
        var links = new List<Link>()
        {
            new()
            {
                Href = $"/{httpContext.GetRouteData().Values["controller"].ToString()?.ToLower()}/product?id={productResponseDTO?.ID}",
                Rel = "self",
                Method = "GET"
            },
            new()
            {
                Href = $"/{httpContext.GetRouteData().Values["controller"].ToString()?.ToLower()}",
                Rel = "create",
                Method = "POST"
            }
        };

        return links;
    }

    private static LinkResponse ReturnShapedProducts(List<Entity?>? shapedProducts) => new() { ShapedEntities = shapedProducts };

    private static bool ShouldGenerateLinks(HttpContext? httpContext)
    {
        MediaTypeHeaderValue? mediaType = (MediaTypeHeaderValue?)httpContext?.Items["AcceptHeaderMediaType"];

        if (mediaType is not null)
            return mediaType.SubTypeWithoutSuffix.EndsWith("hateoas", StringComparison.InvariantCultureIgnoreCase);
        else return false;
    }

    private List<Entity?>? ShapeData(IEnumerable<ProductResponseDTO>? products, string? fields) => _shaper.ShapeData(products, fields)?.Select(s => s.Entity).ToList();
}