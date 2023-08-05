using OnlineStore.Services.ProductSaless.Contracts.Dto;

namespace OnlineStore.Services.ProductSaless.Contracts;

public interface ProductSalesService
{
    void Define(AddProductSlaseDto dto);
    List<GetAllProductSalesDto> GetAll();
}