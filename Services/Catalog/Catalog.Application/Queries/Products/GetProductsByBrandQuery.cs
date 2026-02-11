using Catalog.Application.Responses;
using MediatR;

namespace Catalog.Application.Queries.Products;

public record GetProductsByBrandQuery(string BrandName) : IRequest<IList<ProductResponse>>;