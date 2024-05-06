using BtkApiProject.Application.Interfaces.Repositories.Write;
using BtkApiProject.Common.Tools;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BtkApiProject.Application.Features.Commands.Products.DeleteProduct;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest, DeleteProductCommandResponse>
{
    private readonly IProductWriteRepository _productWriteRepository;
    private readonly ILogger<DeleteProductCommandHandler> _logger;

    public DeleteProductCommandHandler(IProductWriteRepository productWriteRepository, ILogger<DeleteProductCommandHandler> logger)
    {
        _productWriteRepository = productWriteRepository;
        _logger = logger;
    }

    public async Task<DeleteProductCommandResponse> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
    {
        bool response = await _productWriteRepository.DeleteAsync(request.ID);
        if (response)
            await _productWriteRepository.SaveAsync();
        else
            throw new Exception($"{ErrorMessages.ProductNotDeleted} {request.ID}");

        _logger.LogInformation($"{LogMessages.ProductDeleted} {request.ID}");
        return new();
    }
}
