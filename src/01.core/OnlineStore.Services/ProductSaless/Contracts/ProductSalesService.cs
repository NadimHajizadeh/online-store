namespace OnlineStore.Specs.Test.ProductSaless.Add;

public interface ProductSalesService
{
    void Define(AddProductSlaseDto dto);
    List<GetAllProductSalesDto> GetAll();
}