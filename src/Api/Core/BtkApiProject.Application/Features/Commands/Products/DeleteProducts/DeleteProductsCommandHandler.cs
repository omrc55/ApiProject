using BtkApiProject.Application.Interfaces.Repositories.Write;
using BtkApiProject.Common.Tools;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BtkApiProject.Application.Features.Commands.Products.DeleteProducts;

public class DeleteProductsCommandHandler : IRequestHandler<DeleteProductsCommandRequest, DeleteProductsCommandResponse>
{
    private readonly IProductWriteRepository _productWriteRepository;
    private readonly ILogger<DeleteProductsCommandHandler> _logger;

    public DeleteProductsCommandHandler(IProductWriteRepository productWriteRepository, ILogger<DeleteProductsCommandHandler> logger)
    {
        _productWriteRepository = productWriteRepository;
        _logger = logger;
    }

    public async Task<DeleteProductsCommandResponse> Handle(DeleteProductsCommandRequest request, CancellationToken cancellationToken)
    {
        bool response = await _productWriteRepository.DeleteAsync(request.IDs);

        if (response)
            await _productWriteRepository.SaveAsync();
        else
            throw new Exception(ErrorMessages.ProductsNotDeleted);

        _logger.LogInformation(LogMessages.ProductsDeleted);
        return new();
    }
}
