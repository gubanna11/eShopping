using Catalog.Application.Commands.Products;
using Catalog.Application.Mappers;
using Catalog.Application.Responses;
using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers.Products;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductResponse>
{
    private readonly IProductRepository _productRepository;
    private readonly IBrandRepository _brandRepository;
    private readonly ITypeRepository _typeRepository;

    public CreateProductCommandHandler(
        IProductRepository productRepository,
        IBrandRepository brandRepository,
        ITypeRepository typeRepository)
    {
        _productRepository = productRepository;
        _brandRepository = brandRepository;
        _typeRepository = typeRepository;
    }
    public async Task<ProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        //Fetch Brand and Type from Repository
        var brand = await _brandRepository.GetBrandByIdAsync(request.BrandId);
        var type = await _typeRepository.GetTypeByIdAsync(request.TypeId);

        if(brand == null || type == null)
        {
            throw new ApplicationException("Invalid Brand or Type Specified");
        }
        //Match to Entity
        var productEntity = request.ToEntity(brand, type);
        var newProduct = await _productRepository.CreateProduct(productEntity);
        return newProduct.ToResponse();
    }
}