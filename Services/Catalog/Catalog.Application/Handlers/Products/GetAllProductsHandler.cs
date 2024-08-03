using Catalog.Application.Mappers;
using Catalog.Application.Queries.Products;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers.Products;

public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, IList<ProductResponse>>
{
    private readonly IProductRepository _productRepository;

    public GetAllProductsHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<IList<ProductResponse>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var productList = await _productRepository.GetProducts();
        var productResponseList = ProductMapper.Mapper.Map<IList<ProductResponse>>(productList);

        return productResponseList;
    }
}
