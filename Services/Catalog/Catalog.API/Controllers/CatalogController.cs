using Catalog.Application.Commands.Products;
using Catalog.Application.Queries.Brands;
using Catalog.Application.Queries.Products;
using Catalog.Application.Queries.Types;
using Catalog.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Catalog.Core.Specs;

namespace Catalog.API.Controllers;

public class CatalogController : ApiController
{
    private readonly IMediator _mediator;

    public CatalogController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("[action]/{id}", Name = "GetProductById")]
    [ProducesResponseType(typeof(ProductResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<ActionResult<ProductResponse>> GetProductById(string id)
    {
        var query = new GetProductByIdQuery(id);
        var result = await _mediator.Send(query);

        if (result is null)
        {
            return NotFound();
        }

        return Ok(result);
    }


    [HttpGet]
    [Route("[action]/{productName}", Name = "GetProductByProductName")]
    [ProducesResponseType(typeof(IList<ProductResponse>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IList<ProductResponse>>> GetProductByProductName(string productName)
    {
        var query = new GetProductByNameQuery(productName);
        var result = await _mediator.Send(query);

        if (result is null)
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpGet]
    [Route("[action]/{brandName}", Name = "GetProductsByBrandName")]
    [ProducesResponseType(typeof(IList<ProductResponse>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IList<ProductResponse>>> GetProductsByBrandName(string brandName)
    {
        var query = new GetProductsByBrandQuery(brandName);
        var result = await _mediator.Send(query);

        return Ok(result);
    }

    [HttpGet]
    [Route("GetAllProducts")]
    [ProducesResponseType(typeof(Pagination<ProductResponse>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<Pagination<ProductResponse>>> GetAllProducts([FromQuery]CatalogSpecParams catalogSpecParams)
    {
        var query = new GetAllProductsQuery(catalogSpecParams);
        var result = await _mediator.Send(query);

        return Ok(result);
    }

    [HttpGet]
    [Route("GetAllBrands")]
    [ProducesResponseType(typeof(IList<BrandResponse>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IList<BrandResponse>>> GetAllBrands()
    {
        var query = new GetAllBrandsQuery();
        var result = await _mediator.Send(query);

        return Ok(result);
    }

    [HttpGet]
    [Route("GetAllTypes")]
    [ProducesResponseType(typeof(IList<TypeResponse>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IList<TypeResponse>>> GetAllTypes()
    {
        var query = new GetAllTypesQuery();
        var result = await _mediator.Send(query);

        return Ok(result);
    }

    [HttpPost]
    [Route("CreateProduct")]
    [ProducesResponseType(typeof(TypeResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<ProductResponse>> CreateProduct([FromBody] CreateProductCommand productCommand)
    {
        var result = await _mediator.Send(productCommand);

        return Ok(result);
    }

    [HttpPut]
    [Route("UpdateProduct")]
    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<bool>> UpdateProducts([FromBody] UpdateProductCommand productCommand)
    {
        var result = await _mediator.Send(productCommand);

        return Ok(result);
    }

    [HttpDelete]
    [Route("{id}", Name = "DeleteProduct")]
    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<bool>> DeleteProduct(string id)
    {
        var query = new DeleteProductCommand(id);
        var result = await _mediator.Send(query);

        return Ok(result);
    }
}
