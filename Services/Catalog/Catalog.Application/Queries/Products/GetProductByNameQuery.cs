using Catalog.Application.Responses;
using MediatR;

namespace Catalog.Application.Queries.Products;

public record GetProductByNameQuery(string Name) : IRequest<IList<ProductResponse>>;