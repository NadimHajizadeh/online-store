using OnlineStore.Persistanse.EF;
using OnlineStore.Persistanse.EF.ProductImports;
using OnlineStore.Persistanse.EF.Products;
using OnlineStore.Services.ProductImpotrs;
using OnlineStore.Services.ProductImpotrs.Contracts;
using OnlineStore.Services.Products.Contracts;

namespace OnlineStore.TestTools.ProductImports.Factories;

public static class ProductImportServiceFactory
{
    public static ProductImportService Generate(EFDataContext context,
        DateTime? time)
    {
        var unitOfWork = new EFUnitOfWork(context);
        var repasitory = new EFProductImportRepository(context);
        var productRepasitory = new EFProductRepository(context);
        var dateTime = time ?? DateTime.Now;
        
        return
            new ProductImportAppService(unitOfWork, repasitory,
                productRepasitory,dateTime);
    }
}