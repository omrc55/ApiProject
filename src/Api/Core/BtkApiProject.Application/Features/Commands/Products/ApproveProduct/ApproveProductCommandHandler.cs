using BtkApiProject.Application.Interfaces.Repositories.Write;
using BtkApiProject.Common.Tools;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BtkApiProject.Application.Features.Commands.Products.ApproveProduct;

public class ApproveProductCommandHandler : IRequestHandler<ApproveProductCommandRequest, ApproveProductCommandResponse>
{
    private readonly IProductWriteRepository _productWriteRepository;
    private readonly ILogger<ApproveProductCommandHandler> _logger;

    public ApproveProductCommandHandler(IProductWriteRepository productWriteRepository, ILogger<ApproveProductCommandHandler> logger)
    {
        _productWriteRepository = productWriteRepository;
        _logger = logger;
    }

    public async Task<ApproveProductCommandResponse> Handle(ApproveProductCommandRequest request, CancellationToken cancellationToken)
    {
        bool response = await _productWriteRepository.ApproveAsync(request.ID);
        if (response)
            await _productWriteRepository.SaveAsync();
        else
            throw new Exception($"{ErrorMessages.ProductNotApproved} {request.ID}");

        _logger.LogInformation($"{LogMessages.ProductApproved} {request.ID}");
        return new();
    }
}