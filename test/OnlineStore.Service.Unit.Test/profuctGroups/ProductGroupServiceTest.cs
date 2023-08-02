using FluentAssertions;
using OnlineStore.Entities;
using OnlineStore.Persistanse.EF;
using OnlineStore.Services.ProductGroups.Contracts;
using OnlineStore.Services.ProductGroups.Exceptions;
using OnlineStore.Specs.Test.ProductGroupServiceTest.Delete;
using OnlineStore.Specs.Test.ProductGroupServiceTest.Update;
using OnlineStore.TestTools.DataBaseConfig;
using OnlineStore.TestTools.DataBaseConfig.Unit;
using OnlineStore.TestTools.ProductGroups.Factories;
using OnlineStore.TestTools.Products.Factories;

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

    [Fact]
    public void Rename_Certain_rename_a_prouductGroup()
    {
        var productGroup = ProductGroupFactory.Generate("dummy");
        DbContext.Save(productGroup);
        var dto = RenameProuductGroupDtoFactory.Generate("dummy_rename");

        _sut.Rename(productGroup.Id, dto);

        var expected = ReadContext.Set<ProductGroup>().Single();
        expected.Id.Should().Be(productGroup.Id);
        expected.Name.Should().Be(dto.Name);
    }

    [Fact]
    public void Rename_Certain_prouductGroup_not_found_exception()
    {
        var invalidId = 0;
        var dto = RenameProuductGroupDtoFactory.Generate("dummy_rename");

        var expected = () => _sut.Rename(invalidId, dto);

        expected.Should().ThrowExactly<ProuductGroupNotFoundException>();
    }

    [Fact]
    public void Rename_Certain_duplicated_name_exception_throw()
    {
        var productGroup = ProductGroupFactory.Generate("dummy");
        var secondProuductGroup = ProductGroupFactory.Generate("dummy_second");
        DbContext.Save(productGroup);
        DbContext.Save(secondProuductGroup);
        var dto =
            RenameProuductGroupDtoFactory.Generate(secondProuductGroup.Name);

        var expected = () => _sut.Rename(productGroup.Id, dto);

        expected.Should().ThrowExactly<DuplicatedProductGroupNameException>();
    }

    [Fact]
    public void Remove_Certain_remove_a_productGroup()
    {
        var productGroup = ProductGroupFactory.Generate("dummy");
        DbContext.Save(productGroup);

        _sut.Remove(productGroup.Id);

        ReadContext.Set<ProductGroup>().Should().HaveCount(0);
    }

    [Fact]
    public void Remove_Certain_prouductGroup_not_found_exception()
    {
        var invalidId = 0;

        var expected = () => _sut.Remove(invalidId);

        expected.Should().ThrowExactly<ProuductGroupNotFoundException>();
    }

    [Fact]
    public void Remove_Certain_productGroup_has_product_exception()
    {
        var productGroup = ProductGroupFactory.Generate("dummy");
        var product = ProductFactory.Generate(productGroup, "dummy",10);
        DbContext.Save(product);

        var expected = () => _sut.Remove(productGroup.Id);

        expected.Should().ThrowExactly<ProuductGroupHasProuductException>();
    }
}