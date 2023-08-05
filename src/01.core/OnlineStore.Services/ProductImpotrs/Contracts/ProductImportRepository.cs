using OnlineStore.Entities;
using OnlineStore.Services.ProductImpotrs.Contracts.Dto;

namespace OnlineStore.Services.ProductImpotrs.Contracts;

public interface ProductImportRepository
{
    void Add(ProductImport productImport);
    List<GetallProductImportsDto> GetAll();
}