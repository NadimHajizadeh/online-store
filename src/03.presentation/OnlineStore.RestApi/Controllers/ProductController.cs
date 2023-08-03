using Microsoft.AspNetCore.Mvc;
using OnlineStore.Services.Products.Contracts;
using OnlineStore.Services.Products.Contracts.Dto;

namespace OnlineStore.RestApi.Controllers;

[Route("propducts")]
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
}