using OnlineStore.Entities;

namespace OnlineStore.TestTools.ProductSaless.Factories;

public static class ProductSalesFactory
{
    public static ProductSales Generate(int productId, DateTime dateTime)
    {
        return
            new ProductSales()
            {
                Count = 10,
                Date = dateTime,
                CustomerName = "dummy_customer :D ",
                ProductId = productId,
                PricePerProduct = 100
            };
    }
}