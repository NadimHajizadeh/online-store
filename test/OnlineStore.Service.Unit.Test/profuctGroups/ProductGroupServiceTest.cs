using FluentAssertions;
using OnlineStore.Entities;
using OnlineStore.Persistanse.EF;
using OnlineStore.Services.ProductGroups.Contracts;
using OnlineStore.Services.ProductGroups.Exceptions;
using OnlineStore.TestTools.DataBaseConfig;
using OnlineStore.TestTools.DataBaseConfig.Unit;
using OnlineStore.TestTools.ProductGroups.Factories;

namespace OnlineStore.Service.Unit.Test.profuctGroups;

public class ProductGroupServiceTest : BusinessUnitTest

{
    private readonly ProductGroupService _sut;

    public ProductGroupServiceTest()
    {
        _sut = ProductGroupServiceFactory.Generate(SetupContext);
    }


    [Fact]
    public void Define_Certain_add_a_productGroup()
    {
        var dto = AddProductGroupDtoFactory.Generate("dummy");

        _sut.Define(dto);

        var expected = ReadContext.Set<ProductGroup>().Single();
        expected.Name.Should().Be(dto.Name);
    }

    [Fact]
    public void Define_Certain_duplicated_name_exception_throw()
    {
        var productGroup = ProductGroupFactory.Generate("dummy");
        DbContext.Save(productGroup);
        var dto = AddProductGroupDtoFactory.Generate("dummy");

        var expected = () => _sut.Define(dto);

        expected.Should().ThrowExactly<DuplicatedProductGroupNameException>();
    }
}