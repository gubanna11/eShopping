using Amazon.Runtime.Internal;
using Catalog.Application.Responses;
using MediatR;

namespace Catalog.Application.Queries.Products;

public record GetProductByIdQuery(string Id) : IRequest<ProductResponse> 
{
}