using OnlineStore.Services.ProductGroups.Contracts.Dto;

namespace OnlineStore.Services.ProductGroups.Contracts;

public interface ProductGroupService
{
    void Define(AddProductGroupDto dto);
}