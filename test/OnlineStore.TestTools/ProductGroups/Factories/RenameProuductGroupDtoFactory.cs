using OnlineStore.Specs.Test.ProductGroupServiceTest.Update;

namespace OnlineStore.TestTools.ProductGroups.Factories;

public static class RenameProuductGroupDtoFactory
{
    public static RenameProuductGroupDto Generate(string name)
    {
        return
            new RenameProuductGroupDto()
            {
                Name = name
            };
    }
}