using Catalog.Application.Responses;
using MediatR;

namespace Catalog.Application.Queries.Types;

public class GetAllTypesQuery : IRequest<IList<TypeResponse>>
{
}
