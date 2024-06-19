using BtkApiProject.Application.Features.Commands.Products.AddProduct;
using BtkApiProject.Application.Features.Commands.Products.ApproveProduct;
using BtkApiProject.Application.Features.Commands.Products.DeleteProduct;
using BtkApiProject.Application.Features.Commands.Products.DeleteProducts;
using BtkApiProject.Application.Features.Queries.Products.GetAllProducts;
using BtkApiProject.Application.Features.Queries.Products.GetOneProduct;
using BtkApiProject.Presentation.ActionFilters;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace BtkApiProject.Presentation.Controllers;

[Route("products")]
[ApiController]
[ServiceFilter(typeof(LogFilterAttribute))]
public class ProductsController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpGet]
    [ServiceFilter(typeof(ValidateMediaTypeAttribute))]
    public async Task<IActionResult> GetAllProducts([FromQuery] GetAllProductsQueryRequest request)
    {
        var response = await _mediator.Send(request);
        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(response.MetaData));

        if (response.LinkResponse is not null)
            return response.LinkResponse.HasLinks ? Ok(response.LinkResponse.LinkedEntities) : Ok(response.LinkResponse.ShapedEntities);

        return Ok(response);
    }

    [HttpGet("product")]
    public async Task<IActionResult> GetOneProduct([FromQuery] GetOneProductQueryRequest request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpPost]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> AddProduct([FromBody] AddProductCommandRequest request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpPut("approve")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> Approve([FromQuery] ApproveProductCommandRequest request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpPut("delete")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> Delete([FromQuery] DeleteProductCommandRequest request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpPut("delete/products")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> Deletes([FromBody] DeleteProductsCommandRequest request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }
}