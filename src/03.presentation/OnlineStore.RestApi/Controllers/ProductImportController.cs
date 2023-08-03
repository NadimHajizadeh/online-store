using Microsoft.AspNetCore.Mvc;
using OnlineStore.Services.ProductImpotrs.Contracts;
using OnlineStore.Specs.Test.ProductImports.Add;

namespace OnlineStore.RestApi.Controllers;

[Route("product-imports")]
public class ProductImportController : Controller
{
    private readonly ProductImportService _service;

    public ProductImportController(ProductImportService service)
    {
        _service = service;
    }

    [HttpPost]
    public void Add([FromBody] AddProductImportDto dto)
    {
        _service.Define(dto);
    }
}