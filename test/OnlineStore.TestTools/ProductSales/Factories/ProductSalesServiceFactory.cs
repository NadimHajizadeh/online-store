using OnlineStore.Persistanse.EF;
using OnlineStore.Services.Products.Contracts;

namespace OnlineStore.Specs.Test.ProductSaless.Add;

public static class ProductSalesServiceFactory
{
    public static ProductSalesService Generate(EFDataContext context)
    {
        var unitOfWork = new EFUnitOfWork(context);
        var repository = new EFProductSalesRepository(context);
        var acountingDucomentRepository =
            new EFAccountingDocumentRepository(context);
        var productRepasitory = new EFProductRepository(context);
        return
            new ProductSalesAppService(unitOfWork, repository,
                acountingDucomentRepository, productRepasitory);
    }
}