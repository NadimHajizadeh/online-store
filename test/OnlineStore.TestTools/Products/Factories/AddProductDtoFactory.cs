using OnlineStore.Services.Products.Contracts.Dto;

namespace OnlineStore.TestTools.Products.Factories;

public static class AddProductDtoFactory
{
    public static AddProductDto Generate(string title,
        int productGroupId,
        int leastCount)
    {
        return
            new AddProductDto()
            {
                Title = title,
                ProductGroupId = productGroupId,
                LeastCount = leastCount,
            };
    }
}