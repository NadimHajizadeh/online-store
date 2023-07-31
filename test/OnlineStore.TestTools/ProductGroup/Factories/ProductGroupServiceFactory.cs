using OnlineStore.Persistanse.EF;
using OnlineStore.Specs.Test.ProductGroupServiceTest.Add;

namespace OnlineStore.TestTools.ProductGroup;

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