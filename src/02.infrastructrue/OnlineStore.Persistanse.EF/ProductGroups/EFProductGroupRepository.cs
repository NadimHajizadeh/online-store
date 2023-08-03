using Microsoft.EntityFrameworkCore;
using OnlineStore.Entities;
using OnlineStore.Services.ProductGroups.Contracts;

namespace OnlineStore.Persistanse.EF.ProductGroups;

public class EFProductGroupRepository : ProductGroupRepository
{
    private readonly DbSet<ProductGroup> _productGroups;
    private readonly DbSet<Product> _products;

    public EFProductGroupRepository(EFDataContext context)
    {
        _productGroups = context.Set<ProductGroup>();
        _products = context.Set<Product>();
    }

    public void Add(ProductGroup productGroup)
    {
        _productGroups.Add(productGroup);
    }

    public bool IsDuplicatedName(string name)
    {
        return
            _productGroups.Any(_ => _.Name == name);
    }

    public ProductGroup? FindeById(int productGroupId)
    {
        return
            _productGroups.Find(productGroupId);
    }

    public void Update(ProductGroup productGroup)
    {
        _productGroups.Update(productGroup);
    }

    public void Remove(ProductGroup productGroup)
    {
        _productGroups.Remove(productGroup);
    }

    public bool HasProduct(int productGroupId)
    {
        return
            _products.Any(_ => _.ProductGroupId == productGroupId);
    }

    public bool IsExistById(int productGroupId)
    {
        return
            _productGroups.Any(_ => _.Id == productGroupId);
    }
}