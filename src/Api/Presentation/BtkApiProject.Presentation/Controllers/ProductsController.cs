using BtkApiProject.Application.Features.Commands.Products.AddProduct;
using BtkApiProject.Application.Features.Commands.Products.ApproveProduct;
using BtkApiProject.Application.Features.Commands.Products.DeleteProduct;
using BtkApiProject.Application.Features.Commands.Products.DeleteProducts;
using BtkApiProject.Application.Features.Queries.Products.GetAllProducts;
using BtkApiProject.Application.Features.Queries.Products.GetOneProduct;
using BtkApiProject.Application.Interfaces.Repositories.Write;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BtkApiProject.Presentation.Controllers;

[Route("products")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] GetAllProductsQueryRequest request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpGet("product")]
    public async Task<IActionResult> Get([FromQuery] GetOneProductQueryRequest request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] AddProductCommandRequest request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpPut("approve")]
    public async Task<IActionResult> Approve([FromQuery] ApproveProductCommandRequest request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpPut("delete")]
    public async Task<IActionResult> Delete([FromQuery] DeleteProductCommandRequest request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpPut("delete/products")]
    public async Task<IActionResult> Deletes([FromBody] DeleteProductsCommandRequest request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }
}
