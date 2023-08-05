using Microsoft.AspNetCore.Mvc;
using OnlineStore.Services.Products.Contracts;
using OnlineStore.Services.Products.Contracts.Dto;

namespace OnlineStore.RestApi.Controllers;

[Route("propducts")]
[ApiController]
public class ProductController : Controller
{
    private readonly ProductService _service;

    public ProductController(ProductService service)
    {
        _service = service;
    }

    [HttpPost]
    public void Add([FromBody] AddProductDto dto)
    {
        _service.Define(dto);
    }

    [HttpGet]
    public List<GetAllProuductsDto> GetAll([FromQuery]SearchOnDto? dto,
        [FromQuery] ProductOrderBy orderBy)
    {
        return
            _service.GetAll(orderBy,dto);
    }

    [HttpDelete("{id}")]
    public void Delete([FromRoute] int id)
    {
        _service.Remove(id);
    }
}