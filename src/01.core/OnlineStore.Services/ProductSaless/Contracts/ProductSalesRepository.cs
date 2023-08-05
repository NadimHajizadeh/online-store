using OnlineStore.Entities;

namespace OnlineStore.Specs.Test.ProductSaless.Add;

public interface ProductSalesRepository
{
    void Add(ProductSales productSales);
    List<GetAllProductSalesDto> GetAll();
}