using OnlineStore.Persistanse.EF;
using OnlineStore.Persistanse.EF.ProductGroups;
using OnlineStore.Services.ProductGroups;
using OnlineStore.Services.ProductGroups.Contracts;

namespace OnlineStore.TestTools.ProductGroups.Factories;

public static class ProductGroupServiceFactory
{
    public static ProductGroupService Generate(EFDataContext context)
    {
        var productGroupRepository = new EFProductGroupRepository(context);
        var unitOfWork = new EFUnitOfWork(context);

        return
            new ProductGroupAppService(productGroupRepository, unitOfWork);
    }
}