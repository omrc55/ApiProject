using BtkApiProject.Application.Interfaces.Repositories.Read;
using BtkApiProject.Application.Interfaces.Repositories.Write;
using BtkApiProject.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BtkAkademiProject.Server.Controllers
{
    [Route("values")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ILogger<ValuesController> _logger;
        private readonly IProductReadRepository _productReadRepository;
        private readonly IProductWriteRepository _productWriteRepository;

        public ValuesController(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository, ILogger<ValuesController> logger)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Product>? response = _productReadRepository.GetAllItems().OrderBy(i => i.CreatedDate).ToList();
            _logger.LogInformation("Tüm ürünler getirildi.");

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Product product)
        {
            bool response = await _productWriteRepository.AddAsync(product);

            if (response)
                await _productWriteRepository.SaveAsync();

            return Ok(response);
        }

        [HttpPut("approve")]
        public async Task<IActionResult> Approve(string id)
        {
            bool response = await _productWriteRepository.ApproveAsync(id);

            if (response)
                await _productWriteRepository.SaveAsync();

            return Ok(response);
        }

        [HttpPut("delete")]
        public async Task<IActionResult> Delete(string id)
        {
            bool response = await _productWriteRepository.DeleteAsync(id);

            if (response)
                await _productWriteRepository.SaveAsync();

            return Ok(response);
        }

        [HttpPut("deletes")]
        public async Task<IActionResult> Deletes(List<string> ids)
        {
            bool response = await _productWriteRepository.DeleteAsync(ids);

            if (response)
                await _productWriteRepository.SaveAsync();

            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Result(string id)
        {
            bool response = await _productWriteRepository.HardDeleteAsync(id);

            if (response)
                await _productWriteRepository.SaveAsync();

            return Ok(response);
        }
    }
}
