using BtkApiProject.Application.Interfaces.Repositories.Read;
using BtkApiProject.Application.Interfaces.Repositories.Write;
using BtkApiProject.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BtkApiProject.Presentation.Controllers;

[Route("products")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductReadRepository _productReadRepository;
    private readonly IProductWriteRepository _productWriteRepository;

    public ProductsController(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
    {
        _productReadRepository = productReadRepository;
        _productWriteRepository = productWriteRepository;
    }

    [HttpGet]
    public IActionResult Get()
    {
        IEnumerable<Product>? response = _productReadRepository.GetAllItems().OrderBy(i => i.CreatedDate).ToList();

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get([FromRoute(Name = "id")] string id)
    {
        Product? product = await _productReadRepository.GetSingleAsync(i => i.ID == Guid.Parse(id));

        return Ok(product);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Product product)
    {
        bool response = await _productWriteRepository.AddAsync(product);

        if (response)
            await _productWriteRepository.SaveAsync();

        return Ok(response);
    }

    [HttpPut("approve/{id}")]
    public async Task<IActionResult> Approve([FromRoute(Name = "id")] string id)
    {
        bool response = await _productWriteRepository.ApproveAsync(id);

        if (response)
            await _productWriteRepository.SaveAsync();

        return Ok(response);
    }

    [HttpPut("delete/{id}")]
    public async Task<IActionResult> Delete([FromRoute(Name = "id")] string id)
    {
        bool response = await _productWriteRepository.DeleteAsync(id);

        if (response)
            await _productWriteRepository.SaveAsync();

        return Ok(response);
    }

    [HttpPut("deletes")]
    public async Task<IActionResult> Deletes([FromBody] List<string> ids)
    {
        bool response = await _productWriteRepository.DeleteAsync(ids);

        if (response)
            await _productWriteRepository.SaveAsync();

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Result([FromRoute(Name = "id")] string id)
    {
        bool response = await _productWriteRepository.HardDeleteAsync(id);

        if (response)
            await _productWriteRepository.SaveAsync();

        return Ok(response);
    }
}
