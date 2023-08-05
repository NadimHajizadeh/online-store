using OnlineStore.Specs.Test.ProductImports.Add;

namespace OnlineStore.Services.ProductImpotrs.Contracts;

public interface ProductImportService
{
    void Define(AddProductImportDto dto);
    List<GetallProductImportsDto> GetAll();
}