using OnlineStore.Persistanse.EF;
using OnlineStore.Persistanse.EF.ProductImports;
using OnlineStore.Persistanse.EF.Products;
using OnlineStore.Services.ProductImpotrs;
using OnlineStore.Services.ProductImpotrs.Contracts;
using OnlineStore.Services.Products.Contracts;
using OnlineStore.Services.Shared;

namespace OnlineStore.TestTools.ProductImports.Factories;

public static class ProductImportServiceFactory
{
    public static ProductImportService Generate(
        EFDataContext context,
        DateTimeService? timeService)
    {
        var unitOfWork = new EFUnitOfWork(context);
        var repasitory = new EFProductImportRepository(context);
        var productRepasitory = new EFProductRepository(context);
        var dateTimeService = new DateTimeAppService();
        
        if (timeService is not null)
        {
            return
                new ProductImportAppService(
                    unitOfWork,
                    repasitory,
                    productRepasitory,
                    timeService);
        }

        return
            new ProductImportAppService(
                unitOfWork,
                repasitory,
                productRepasitory,
                dateTimeService);
    }
}