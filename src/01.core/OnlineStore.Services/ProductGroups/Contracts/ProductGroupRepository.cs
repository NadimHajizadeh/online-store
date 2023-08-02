using OnlineStore.Entities;

namespace OnlineStore.Services.ProductGroups.Contracts;

public interface ProductGroupRepository
{
    void Add(ProductGroup productGroup);
    bool IsDuplicatedName(string name);
    ProductGroup? FindeById(int productGroupId);
    void Update(ProductGroup productGroup);
    void Remove(ProductGroup productGroup);
    bool HasProduct(int productGroupId);
}