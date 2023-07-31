using FluentAssertions;
using OnlineStore.Entities;
using OnlineStore.Persistanse.EF;
using OnlineStore.Specs.Test.ProductGroupServiceTest.Add;
using OnlineStore.TestTools.DataBaseConfig.Unit;
using OnlineStore.TestTools.ProductGroup;

namespace OnlineStore.Service.Unit.Test.profuctGroups;

public class ProductGroupServiceTest : BusinessUnitTest
{
    private readonly ProductGroupService _sut;

    public ProductGroupServiceTest()
    {
        _sut = ProductGroupServiceFactory.Generate(SetupContext);
    }


    [Fact]
    public void Define_Certain_add_a_ProductGroup()
    {
        var dto = AddProductGroupDtoFactory.Generate("dummy");

        _sut.Define(dto);

        var expected = ReadContext.Set<ProductGroup>().Single();
        expected.Name.Should().Be(dto.Name);
    }
}