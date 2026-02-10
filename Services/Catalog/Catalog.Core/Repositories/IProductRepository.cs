using Catalog.Core.Entities;
using Catalog.Core.Specs;

namespace Catalog.Core.Repositories;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllAsync();
    Task<Pagination<Product>> GetProducts(CatalogSpecParams catalogSpecParams);
    Task<IEnumerable<Product>> GetProductsByName(string name);
    Task<IEnumerable<Product>> GetProductsByBrand(string name);
    Task<Product> GetProduct(string id);
    Task<Product> CreateProduct(Product product);    
    Task<bool> UpdateProduct(Product product);
    Task<bool> DeleteProduct(string id);
}
