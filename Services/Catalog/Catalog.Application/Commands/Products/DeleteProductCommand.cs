using MediatR;

namespace Catalog.Application.Commands.Products;

public class DeleteProductCommand : IRequest<bool>
{
    public string Id { get; }

    public DeleteProductCommand(string id)
    {
        Id = id;
    }
}
