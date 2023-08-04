using Microsoft.AspNetCore.Mvc;
using OnlineStore.Specs.Test.ProductSaless.Add;

namespace OnlineStore.RestApi.Controllers;

[Route("product-sales")]
public class ProductSalesController : Controller
{
    private readonly ProductSalesService _service;

    public ProductSalesController(ProductSalesService service)
    {
        _service = service;
    }


    [HttpPost]
    public void Add(AddProductSlaseDto dto)
    {
        _service.Define(dto);
    }
}