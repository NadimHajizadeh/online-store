using OnlineStore.Specs.Test.ProductGroupServiceTest.Add;

namespace OnlineStore.TestTools.ProductGroup;

public static class AddProductGroupDtoFactory
{
    public static AddProductGroupDto Generate(string name)
    {
        return
            new AddProductGroupDto()
            {
                Name = name
            };
    }
}