using Microsoft.AspNetCore.Mvc;
using OnlineStore.Services.ProductGroups.Contracts;
using OnlineStore.Services.ProductGroups.Contracts.Dto;

namespace OnlineStore.RestApi.Controllers;
[Route("product-groups")]
public class ProductGroupController : Controller
{
    private readonly ProductGroupService _service;

    public ProductGroupController(ProductGroupService service)
    {
        _service = service;
    }

    [HttpPost]
    public void Add([FromBody] AddProductGroupDto dto)
    {
        _service.Define(dto);
    }
}