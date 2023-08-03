
using OnlineStore.Services.ProductGroups.Contracts.Dto;

namespace OnlineStore.Services.ProductGroups.Contracts;

public interface ProductGroupService
{
    void Define(AddProductGroupDto dto);
    void Rename(int productGroupID, RenameProuductGroupDto dto);
    void Remove(int productGroupId);
}