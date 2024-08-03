using Amazon.Runtime.Internal;
using Catalog.Application.Responses;
using MediatR;

namespace Catalog.Application.Queries.Products;

public class GetProductByIdQuery : IRequest<ProductResponse>
{
    public string Id { get; set; }

    public GetProductByIdQuery(string id)
    {
        Id = id;
    }
}
