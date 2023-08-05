using Microsoft.AspNetCore.Mvc;
using OnlineStore.Services.ProductImpotrs.Contracts;
using OnlineStore.Services.ProductImpotrs.Contracts.Dto;

namespace OnlineStore.RestApi.Controllers;

[Route("product-imports")]
[ApiController]
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

    [HttpGet]
    public List<GetallProductImportsDto> GetAll()
    {
        return
            _service.GetAll();
    }
}