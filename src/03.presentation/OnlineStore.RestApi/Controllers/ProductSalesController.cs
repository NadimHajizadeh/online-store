using Microsoft.AspNetCore.Mvc;
using OnlineStore.Services.ProductSaless.Contracts;
using OnlineStore.Services.ProductSaless.Contracts.Dto;

namespace OnlineStore.RestApi.Controllers;

[Route("product-sales")]
[ApiController]
public class ProductSalesController : Controller
{
    private readonly ProductSalesService _service;

    public ProductSalesController(ProductSalesService service)
    {
        _service = service;
    }


    [HttpPost]
    public void Add([FromBody] AddProductSlaseDto dto)
    {
        _service.Define(dto);
    }

    [HttpGet]
    public List<GetAllProductSalesDto> GetAll()
    {
        return
            _service.GetAll();
    }
}