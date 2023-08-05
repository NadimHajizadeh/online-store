using OnlineStore.Entities;
using OnlineStore.Services.ProductSaless.Contracts.Dto;

namespace OnlineStore.Services.ProductSaless.Contracts;

public interface ProductSalesRepository
{
    void Add(ProductSales productSales);
    List<GetAllProductSalesDto> GetAll();
}