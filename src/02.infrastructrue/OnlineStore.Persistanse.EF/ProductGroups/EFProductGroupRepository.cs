using Microsoft.EntityFrameworkCore;
using OnlineStore.Entities;
using OnlineStore.Persistanse.EF;

namespace OnlineStore.Specs.Test.ProductGroupServiceTest.Add;

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
}