using OnlineStore.Persistanse.EF;
using OnlineStore.Persistanse.EF.AccountingDocuments;
using OnlineStore.Persistanse.EF.Products;
using OnlineStore.Persistanse.EF.ProductSaless;
using OnlineStore.Services.ProductSaless;
using OnlineStore.Services.ProductSaless.Contracts;

namespace OnlineStore.TestTools.ProductSaless.Factories;

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