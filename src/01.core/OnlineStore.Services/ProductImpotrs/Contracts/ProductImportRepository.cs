using OnlineStore.Entities;
using OnlineStore.Specs.Test.ProductImports.Add;

namespace OnlineStore.Services.ProductImpotrs.Contracts;

public interface ProductImportRepository
{
    void Add(ProductImport productImport);
    List<GetallProductImportsDto> GetAll();
}