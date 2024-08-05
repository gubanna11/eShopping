using Catalog.Application.Commands.Products;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers.Products;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, bool>
{
    private readonly IProductRepository _productRepository;

    public DeleteProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        return await _productRepository.DeleteProduct(request.Id);
    }
}
