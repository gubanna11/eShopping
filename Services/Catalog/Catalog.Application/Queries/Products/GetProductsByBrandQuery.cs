using Catalog.Application.Responses;
using MediatR;

namespace Catalog.Application.Queries.Products;

public class GetProductsByBrandQuery : IRequest<IList<ProductResponse>>
{
    public string BrandName { get; set; }

    public GetProductsByBrandQuery(string brandName)
    {
        BrandName = brandName;
    }
}
