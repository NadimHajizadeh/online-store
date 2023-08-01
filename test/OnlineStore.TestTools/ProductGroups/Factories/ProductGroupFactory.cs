using OnlineStore.Entities;

namespace OnlineStore.TestTools.ProductGroups.Factories;

public static class ProductGroupFactory
{
    public static ProductGroup Generate(string name)
    {
        return
            new ProductGroup()
            {
                Name = name
            };
    }
}