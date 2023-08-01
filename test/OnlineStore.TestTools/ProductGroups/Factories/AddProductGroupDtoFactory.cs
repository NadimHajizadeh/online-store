using OnlineStore.Services.ProductGroups.Contracts.Dto;

namespace OnlineStore.TestTools.ProductGroups.Factories
{
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
}