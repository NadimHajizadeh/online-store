using Microsoft.EntityFrameworkCore;
using OnlineStore.Entities;
using OnlineStore.Persistanse.EF;
using OnlineStore.Specs.Test.ProductImports.Add;

namespace OnlineStore.Services.ProductImpotrs.Contracts;

public class EFProductImportRepository : ProductImportRepository
{
    private readonly DbSet<ProductImport> _productImports;
    private readonly DbSet<Product> _products;

    public EFProductImportRepository(EFDataContext context)
    {
        _productImports = context.Set<ProductImport>();
        _products = context.Set<Product>();
    }


    public void Add(ProductImport productImport)
    {
        _productImports.Add(productImport);
    }

    public List<GetallProductImportsDto> GetAll()
    {
        return
            (from productImport in _productImports
                join product in _products on productImport.ProductId equals product.Id
                select new GetallProductImportsDto()
                {
                    ProductName = product.Title,
                    CompenyName = productImport.CompenyName,
                    Date = productImport.Date,
                    Count = productImport.Count,
                    FactorNumber = productImport.FactorNumber,
                }
            ).ToList();
    }
}