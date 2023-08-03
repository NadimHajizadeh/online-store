using OnlineStore.Services.Products.Contracts.Dto;

namespace OnlineStore.Services.Products.Contracts;

public interface ProductService
{
    void Define(AddProductDto dto);
    void Remove(int productId);
}