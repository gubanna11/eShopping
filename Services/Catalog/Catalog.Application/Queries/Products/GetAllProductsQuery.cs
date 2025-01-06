using Catalog.Application.Responses;
using Catalog.Core.Specs;
using MediatR;

namespace Catalog.Application.Queries.Products;

public class GetAllProductsQuery : IRequest<Pagination<ProductResponse>>
{
    public CatalogSpecParams CatalogSpecParams { get; }

    public GetAllProductsQuery(CatalogSpecParams catalogSpecParams)
    {
        CatalogSpecParams = catalogSpecParams;
    }
}
