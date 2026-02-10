using System.ComponentModel.DataAnnotations;

namespace Catalog.Application.DTOs.Product
{ 
    public record ProductDto(
        string Id,
        string Name,
        string Summary,
        string Description,
        string ImageFile,
        BrandDto Brand,
        TypeDto Type,
        decimal Price,
        DateTimeOffset CreatedDate
        );
}