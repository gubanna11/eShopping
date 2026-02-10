using Catalog.Application.Responses;
using MediatR;

namespace Catalog.Application.Queries.Types;

public record GetAllTypesQuery : IRequest<IList<TypeResponse>>
{
}