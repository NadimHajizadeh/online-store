using OnlineStore.Services.Products.Contracts.Dto;

namespace OnlineStore.Services.Products.Contracts;

public interface ProductService
{
    void Define(AddProductDto dto);
    void Remove(int productId);
    List<GetAllProuductsDto> GetAll(ProductOrderBy? orderBy = null,
        SearchOnDto? dto = null);
}