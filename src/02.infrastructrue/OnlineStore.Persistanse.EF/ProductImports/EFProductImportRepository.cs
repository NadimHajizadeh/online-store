using Microsoft.EntityFrameworkCore;
using OnlineStore.Entities;
using OnlineStore.Persistanse.EF;
using OnlineStore.Specs.Test.ProductImports.Add;

namespace OnlineStore.Services.ProductImpotrs.Contracts;

public class EFProductImportRepository : ProductImportRepository
{
    private readonly DbSet<ProductImport> _productImports;

    public EFProductImportRepository(EFDataContext context)
    {
        _productImports = context.Set<ProductImport>();
    }
   

    public void Add(ProductImport productImport)
    {
        _productImports.Add(productImport);
    }
}