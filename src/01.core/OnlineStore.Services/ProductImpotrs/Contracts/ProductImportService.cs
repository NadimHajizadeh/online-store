using OnlineStore.Services.ProductImpotrs.Contracts.Dto;

namespace OnlineStore.Services.ProductImpotrs.Contracts;

public interface ProductImportService
{
    void Define(AddProductImportDto dto);
    List<GetallProductImportsDto> GetAll();
}