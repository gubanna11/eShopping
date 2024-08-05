using Catalog.Application.Commands.Products;
using Catalog.Application.Mappers;
using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers.Products;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, bool>
{
    private readonly IProductRepository _productRepository;

    public UpdateProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var productEntity = ProductMapper.Mapper.Map<Product>(request);

        if (productEntity is null)
        {
            throw new ApplicationException("There is an issue with mapping while creating a new product");
        }

        var result = await _productRepository.UpdateProduct(productEntity);

        return result;
    }
}
