using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Entities;
using OnlineStore.Services.ProductGroups.Exceptions;
using OnlineStore.Services.Products.Contracts;
using OnlineStore.Services.Products.Contracts.Dto;
using OnlineStore.Specs.Test.ProductServiceTest.Add;
using OnlineStore.TestTools.DataBaseConfig;
using OnlineStore.TestTools.DataBaseConfig.Unit;
using OnlineStore.TestTools.ProductGroups.Factories;
using OnlineStore.TestTools.Products;
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

    [Fact]
    public void Remove_Certain_delete_a_product()
    {
        var productGroup = ProductGroupFactory.Generate("dummy");
        var product = ProductFactory.Generate(productGroup, "dummy");
        DbContext.Save(product);

        _sut.Remove(product.Id);

        var expected = ReadContext.Set<ProductGroup>()
            .Include(_ => _.Products)
            .Single();
        expected.Products.Should().HaveCount(0);
    }

    [Fact]
    public void Remove_Certain_product_not_found_exception()
    {
        var invalidId = 0;

        var expected = () => _sut.Remove(invalidId);

        expected.Should().ThrowExactly<ProuductNotFoundException>();
    }

    [Fact]
    public void GetAll_Certain_getall_products()
    {
        var productGroup = ProductGroupFactory.Generate("dummy");
        var product = new ProductBuilder()
            .WithCount(10)
            .WithStatus(ProductStatus.Available)
            .WithProductGroup(productGroup)
            .Build();
        DbContext.Save(product);
        var dto = new SearchOnDto();

        var expected = _sut.GetAll(null, dto).Single();

        expected.ProductTitle.Should().Be(product.Title);
        expected.LeastCount.Should().Be(product.LeastCount);
        expected.Status.Should().Be(product.Status.ToString());
        expected.Count.Should().Be(product.Count);
        expected.GroupName.Should().Be(product.ProductGroup.Name);
        expected.ProductCode.Should().Be(product.Id);
    }

    [Fact]
    public void GetAll_Serach_on_title_Certain()
    {
        var productGroup = ProductGroupFactory.Generate("dummy");
        var product = new ProductBuilder()
            .WithCount(10)
            .WithStatus(ProductStatus.Available)
            .WithProductGroup(productGroup)
            .Build();
        var secondProduct = new ProductBuilder()
            .WithTitle("second_dummy")
            .WithCount(10)
            .WithStatus(ProductStatus.Available)
            .WithProductGroup(productGroup)
            .Build();
        DbContext.Save(product);
        DbContext.Save(secondProduct);
        var dto = new SearchOnDto
        {
            Title = "dummy"
        };

        var expected = _sut.GetAll(null, dto).Single();

        expected.ProductTitle.Should().Be(product.Title);
        expected.LeastCount.Should().Be(product.LeastCount);
        expected.Status.Should().Be(product.Status.ToString());
        expected.Count.Should().Be(product.Count);
        expected.GroupName.Should().Be(product.ProductGroup.Name);
        expected.ProductCode.Should().Be(product.Id);
    }

    [Fact]
    public void GetAll_Serach_on_groupName_Certain()
    {
        var productGroup = ProductGroupFactory.Generate("dummy");
        var secondProductGroup = ProductGroupFactory.Generate("dummy2");
        var product = new ProductBuilder()
            .WithCount(10)
            .WithStatus(ProductStatus.Available)
            .WithProductGroup(productGroup)
            .Build();
        var secondProduct = new ProductBuilder()
            .WithCount(10)
            .WithStatus(ProductStatus.Available)
            .WithProductGroup(secondProductGroup)
            .Build();
        DbContext.Save(product);
        DbContext.Save(secondProduct);
        var dto = new SearchOnDto
        {
            GroupName = "dummy"
        };

        var expected = _sut.GetAll(null, dto).Single();

        expected.ProductTitle.Should().Be(product.Title);
        expected.LeastCount.Should().Be(product.LeastCount);
        expected.Status.Should().Be(product.Status.ToString());
        expected.Count.Should().Be(product.Count);
        expected.GroupName.Should().Be(product.ProductGroup.Name);
        expected.ProductCode.Should().Be(product.Id);
    }

    [Fact]
    public void GetAll_Order_on_title_Certain()
    {
        var productGroup = ProductGroupFactory.Generate("dummy");
        var product = new ProductBuilder()
            .WithProductGroup(productGroup)
            .Build();
        var secondProduct = new ProductBuilder()
            .WithTitle("dummy_second")
            .WithProductGroup(productGroup)
            .Build();
        DbContext.Save(product);
        DbContext.Save(secondProduct);
        var dto = new SearchOnDto();
        var orderBy = ProductOrderBy.Title;

        var expected = _sut.GetAll(null, dto);

        var actual = expected.First();
        actual.ProductTitle.Should().Be(product.Title);
        actual.LeastCount.Should().Be(product.LeastCount);
        actual.Status.Should().Be(product.Status.ToString());
        actual.Count.Should().Be(product.Count);
        actual.GroupName.Should().Be(product.ProductGroup.Name);
        actual.ProductCode.Should().Be(product.Id);
    }

    [Fact]
    public void GetAll_Order_on_groupName_Certain()
    {
        var productGroup = ProductGroupFactory.Generate("dummy");
        var secondProductGroup = ProductGroupFactory.Generate("dummy_second");
        var product = new ProductBuilder()
            .WithCount(10)
            .WithStatus(ProductStatus.Available)
            .WithProductGroup(productGroup)
            .Build();
        var secondProduct = new ProductBuilder()
            .WithProductGroup(secondProductGroup)
            .Build();
        DbContext.Save(product);
        DbContext.Save(secondProduct);
        var dto = new SearchOnDto();
        var orderBy = ProductOrderBy.GroupName;

        var expected = _sut.GetAll(orderBy, dto);
        var actual = expected.First();
        actual.ProductTitle.Should().Be(product.Title);
        actual.LeastCount.Should().Be(product.LeastCount);
        actual.Status.Should().Be(product.Status.ToString());
        actual.Count.Should().Be(product.Count);
        actual.GroupName.Should().Be(product.ProductGroup.Name);
        actual.ProductCode.Should().Be(product.Id);
    }
}