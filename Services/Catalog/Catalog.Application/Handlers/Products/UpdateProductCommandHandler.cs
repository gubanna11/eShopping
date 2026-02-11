using Catalog.Application.Commands.Products;
using Catalog.Application.Mappers;
using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers.Products;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, bool>
{
    private readonly IProductRepository _productRepository;
    private readonly IBrandRepository _brandRepository;
    private readonly ITypeRepository _typeRepository;

    public UpdateProductCommandHandler(
        IProductRepository productRepository,
        IBrandRepository brandRepository,
        ITypeRepository typeRepository)
    {
        _productRepository = productRepository;
        _brandRepository = brandRepository;
        _typeRepository = typeRepository;
    }

    public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var existing = await _productRepository.GetProduct(request.Id);
        if (existing == null)
        {
            throw new KeyNotFoundException($"Product with Id {request.Id} not found");
        }
        //Step 1: Fetch Brand and Type
        var brand = await _brandRepository.GetBrandByIdAsync(request.BrandId);
        var type = await _typeRepository.GetTypeByIdAsync(request.TypeId);
        if (brand == null || type == null)
        {
            throw new ApplicationException("Invalid Brand or Type Specified");
        }
        //Step 2: Mapper Role
        var updatedProduct = request.ToUpdateEntity(existing, brand, type);

        //Step 3: Save the record
        return await _productRepository.UpdateProduct(updatedProduct);
    }
}
