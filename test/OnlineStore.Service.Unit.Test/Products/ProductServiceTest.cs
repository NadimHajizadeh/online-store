using FluentAssertions;
using OnlineStore.Entities;
using OnlineStore.Services.ProductGroups.Exceptions;
using OnlineStore.Services.Products.Contracts;
using OnlineStore.Services.Products.Contracts.Dto;
using OnlineStore.Specs.Test.ProductServiceTest.Add;
using OnlineStore.TestTools.DataBaseConfig;
using OnlineStore.TestTools.DataBaseConfig.Unit;
using OnlineStore.TestTools.ProductGroups.Factories;
using OnlineStore.TestTools.Products.Factories;

namespace OnlineStore.Service.Unit.Test.Products;

public class ProductServiceTest : BusinessUnitTest
{
    private readonly ProductService _sut;

    public ProductServiceTest()
    {
        _sut = ProductServiceFactory.Generate(SetupContext);
    }


    [Fact]
    public void Define_Certain_add_a_product()
    {
        var productGroup = ProductGroupFactory.Generate("dummy");
        DbContext.Save(productGroup);
        var dto = AddProductDtoFactory.Generate("dummy", productGroup.Id,
            10);

        _sut.Define(dto);

        var expected = ReadContext.Set<Product>().Single();
        expected.Title.Should().Be(dto.Title);
        expected.LeastCount.Should().Be(dto.LeastCount);
        expected.ProductGroupId.Should().Be(productGroup.Id);
        expected.Status.Should().Be(ProductStatus.OutOfStock);
    }

    [Fact]
    public void Define_Certain_productGroup_not_found_exception()
    {
        var invalidId = 0;
        var dto = AddProductDtoFactory.Generate("dummy", invalidId,
            10);

        var expectet = () => _sut.Define(dto);

        expectet.Should().ThrowExactly<ProuductGroupNotFoundException>();
    }

    [Fact]
    public void Define_Certain_duplicated_Product_name_exception()
    {
        var productGroup = ProductGroupFactory.Generate("dummy");
        var product = ProductFactory.Generate(productGroup, "dummy");
        DbContext.Save(product);
        var dto =
            AddProductDtoFactory.Generate(product.Title, productGroup.Id, 10);

        var expected = () => _sut.Define(dto);

        expected.Should().ThrowExactly<DuplicatedProductNameException>();
    }
}