using FluentAssertions;
using OnlineStore.Entities;
using OnlineStore.Service.Unit.Test.Products;
using OnlineStore.Services.ProductImpotrs.Contracts;
using OnlineStore.Specs.Test.ProductImports.Add;
using OnlineStore.TestTools;
using OnlineStore.TestTools.DataBaseConfig;
using OnlineStore.TestTools.DataBaseConfig.Unit;
using OnlineStore.TestTools.ProductGroups.Factories;
using OnlineStore.TestTools.ProductImports;
using OnlineStore.TestTools.ProductImports.Factories;
using OnlineStore.TestTools.Products;
using OnlineStore.TestTools.Products.Factories;

namespace OnlineStore.Service.Unit.Test.ProductImports;

public class ProductImportServiceTest : BusinessUnitTest
{
    private readonly ProductImportService _sut;
    private readonly DateTime _date;

    public ProductImportServiceTest()
    {
        _date = DatetimeFactory.Generate();
        _sut = ProductImportServiceFactory.Generate(SetupContext, _date);
    }

    [Fact]
    public void Define_Certain_add_a_productImport()
    {
        var productGroup = ProductGroupFactory.Generate("dummy");
        var product = ProductFactory.Generate(productGroup, "dummy");
        DbContext.Save(product);
        var dto = new AddProductImportDtoBuilder()
            .WithProductId(product.Id)
            .Build();
        _sut.Define(dto);

        var expected = ReadContext.Set<Product>().Single();
        expected.Title.Should().Be(product.Title);
        expected.Count.Should().Be(20);
        expected.Status.Should().Be(ProductStatus.Available);
        var actual = ReadContext.Set<ProductImport>().Single();
        actual.Count.Should().Be(20);
        actual.ProductId.Should().Be(product.Id);
        actual.FactorNumber.Should().Be(dto.FactorNumber);
        actual.CompenyName.Should().Be(dto.CompenyName);
        actual.Date.Should().Be(_date);
    }

    [Fact]
    public void Define_Certain_add_a_productImport_to_get_ReadyToOrde_status()
    {
        var productGroup = ProductGroupFactory.Generate("dummy");
        var product = ProductFactory.Generate(productGroup, "dummy");
        DbContext.Save(product);
        var dto = new AddProductImportDtoBuilder()
            .WithProductId(product.Id)
            .WithCount(10)
            .Build();

        _sut.Define(dto);

        var expected = ReadContext.Set<Product>().Single();
        expected.Title.Should().Be(product.Title);
        expected.Count.Should().Be(10);
        expected.Status.Should().Be(ProductStatus.ReadyToOrder);
        var actual = ReadContext.Set<ProductImport>().Single();
        actual.Count.Should().Be(10);
        actual.ProductId.Should().Be(product.Id);
        actual.FactorNumber.Should().Be(dto.FactorNumber);
        actual.CompenyName.Should().Be(dto.CompenyName);
        actual.Date.Should().Be(_date);
    }


    [Fact]
    public void Define_Certain_product_not_found_exception()
    {
        var invalidId = 0;
        var dto = new AddProductImportDtoBuilder()
            .WithProductId(invalidId)
            .Build();

        var excepted = () => _sut.Define(dto);

        excepted.Should().ThrowExactly<ProuductNotFoundException>();
    }

    [Fact]
    public void GetAll_Certain_get_all()
    {
        var productGroup = ProductGroupFactory.Generate("dummy");
        var product = new ProductBuilder()
            .WithProductGroup(productGroup)
            .WithStatus(ProductStatus.Available)
            .WithCount(100)
            .Build();
        DbContext.Save(product);
        var productImport = new ProductImport()
        {
            Count = 20,
            FactorNumber = "dummy_factor_number",
            CompenyName = "dummyCo",
            Date = DateTime.Now,
            ProductId = product.Id,
        };
        DbContext.Save(productImport);

        var expected = _sut.GetAll().Single();

        expected.Count.Should().Be(productImport.Count);
        expected.CompenyName.Should().Be(productImport.CompenyName);
        expected.Date.Should().Be(productImport.Date);
        expected.FactorNumber.Should().Be(productImport.FactorNumber);
        expected.ProductName.Should().Be(product.Title);
    }
}