using Microsoft.AspNetCore.Mvc;
using OnlineStore.Services.ProductGroups.Contracts;
using OnlineStore.Services.ProductGroups.Contracts.Dto;

namespace OnlineStore.RestApi.Controllers;

[Route("product-groups")]
[ApiController]
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

    [HttpPut("{id}")]
    public void Rename([FromRoute] int id,
        [FromBody] RenameProuductGroupDto dto)
    {
        _service.Rename(id, dto);
    }

    [HttpDelete("{id}")]
    public void Delete([FromRoute] int id)
    {
        _service.Remove(id);
    }
}