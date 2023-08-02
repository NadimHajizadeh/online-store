using OnlineStore.Entities;

namespace OnlineStore.TestTools.Products.Factories;

public static class ProductFactory
{
    public static Product Generate(ProductGroup productGroup, string title ,
     int leastCount)
    {
        return
            new Product()
            {
                ProductGroup = productGroup,
                Title = title,
                LeastCount = leastCount,
                Status = ProductStatus.OutOfStock,
            };
    }
}