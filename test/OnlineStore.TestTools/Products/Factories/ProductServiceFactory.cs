using OnlineStore.Persistanse.EF;
using OnlineStore.Persistanse.EF.ProductGroups;
using OnlineStore.Services.Products;
using OnlineStore.Services.Products.Contracts;


namespace OnlineStore.TestTools.Products.Factories;

public static class ProductServiceFactory
{
    public static ProductService Generate(EFDataContext context)
    {
        var productRepository = new EFProductRepository(context);
        var productGroupRepository = new EFProductGroupRepository(context);
        var unitOfWork = new EFUnitOfWork(context);

        return
            new ProductAppService(unitOfWork, productRepository,productGroupRepository);
    }
}