using MediatR;

namespace Catalog.Application.Commands.Products;

public record DeleteProductByIdCommand(string Id): IRequest<bool>;