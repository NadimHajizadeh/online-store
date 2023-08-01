using Microsoft.EntityFrameworkCore;
using OnlineStore.Entities;
using OnlineStore.Services.ProductGroups.Contracts;

namespace OnlineStore.Persistanse.EF.ProductGroups;

public class EFProductGroupRepository : ProductGroupRepository
{
    private readonly DbSet<ProductGroup> _productGroups;

    public EFProductGroupRepository(EFDataContext context)
    {
        _productGroups = context.Set<ProductGroup>();
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
}