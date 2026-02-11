using Catalog.Application.Responses;
using MediatR;

namespace Catalog.Application.Queries.Brands;

public record GetAllBrandsQuery : IRequest<IList<BrandResponse>>
{
}