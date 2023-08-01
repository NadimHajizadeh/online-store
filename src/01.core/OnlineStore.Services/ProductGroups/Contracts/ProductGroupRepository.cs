using OnlineStore.Entities;

namespace OnlineStore.Services.ProductGroups.Contracts;

public interface ProductGroupRepository
{
    void Add(ProductGroup productGroup);
    bool IsDuplicatedName(string name);
}