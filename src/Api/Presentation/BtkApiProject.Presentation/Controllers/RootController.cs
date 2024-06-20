using BtkApiProject.Application.Helpers.Links;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace BtkApiProject.Presentation.Controllers;

[Route("/")]
[ApiController]
public class RootController(LinkGenerator linkGenerator) : ControllerBase
{
    private readonly LinkGenerator _linkGenerator = linkGenerator;

    [HttpGet(Name = "GetRoot")]
    public IActionResult GetRoot([FromHeader(Name = "Accept")] string mediaType)
    {
        if (mediaType.Contains("application/vnd.reysadijital.apiroot"))
        {
            var links = new List<Link>()
            {
                new()
                {
                    Href = _linkGenerator.GetUriByName(HttpContext, nameof(GetRoot), new{}),
                    Rel = "_self",
                    Method = "GET"
                },
                new()
                {
                    Href = _linkGenerator.GetUriByName(HttpContext, nameof(ProductsController.GetAllProducts), new{}),
                    Rel = "products",
                    Method = "GET"
                },
                new()
                {
                    Href = _linkGenerator.GetUriByName(HttpContext, nameof(ProductsController.AddProduct), new{}),
                    Rel = "products",
                    Method = "POST"
                }
            };

            return Ok(links);
        }

        return NoContent();
    }
}