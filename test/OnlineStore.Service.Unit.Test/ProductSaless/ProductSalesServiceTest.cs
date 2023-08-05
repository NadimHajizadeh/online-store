using FluentAssertions;
using OnlineStore.Entities;
using OnlineStore.Service.Unit.Test.Products;
using OnlineStore.Specs.Test.ProductSaless.Add;
using OnlineStore.TestTools.DataBaseConfig;
using OnlineStore.TestTools.DataBaseConfig.Unit;
using OnlineStore.TestTools.ProductGroups.Factories;
using OnlineStore.TestTools.Products;
using OnlineStore.TestTools.ProductSales;

namespace OnlineStore.Service.Unit.Test.ProductSaless;

public class ProductSalesServiceTest : BusinessUnitTest
{
    private readonly ProductSalesService _sut;

    public ProductSalesServiceTest()
    {
        _sut = ProductSalesServiceFactory.Generate(SetupContext);
    }

    [Fact]
    public void Define_Certain_add_a_productSales_and_its_accounting()
    {
        var productGroup = ProductGroupFactory.Generate("dummy");
        var product = new ProductBuilder()
            .WithCount(20)
            .WithStatus(ProductStatus.Available)
            .WithProductGroup(productGroup)
            .Build();
        DbContext.Save(product);
        var dto = new AddProductSalesDtoBuilder()
            .WithProductId(product.Id)
            .Build();
        var expectedTotalPrice = 5000;

        _sut.Define(dto);

        var expectedProduct = ReadContext.Set<Product>().Single();
        expectedProduct.Title.Should().Be(product.Title);
        expectedProduct.LeastCount.Should().Be(product.LeastCount);
        expectedProduct.Count.Should().Be(product.Count - dto.Count);
        expectedProduct.ProductGroupId.Should().Be(productGroup.Id);
        expectedProduct.Status.Should().Be(ProductStatus.Available);

        var expectedProductSales = ReadContext.Set<ProductSales>().Single();
        expectedProductSales.ProductId.Should().Be(dto.ProductId);
        expectedProductSales.Count.Should().Be(dto.Count);
        expectedProductSales.PricePerProduct.Should().Be(dto.PricePerProduct);
        expectedProductSales.CustomerName.Should().Be(dto.CustomerName);

        var expectedAccounting =
            ReadContext.Set<AccountingDocument>().Single();

        expectedAccounting.SalesFactorNumber.Should().Be
            (expectedProductSales.FactorNumber);
        expectedAccounting.date.Should().Be(expectedProductSales.Date);
        expectedAccounting.TotalPrice.Should().Be(expectedTotalPrice);
    }

    [Fact]
    public void Define_Certain_productNotFound_exception()
    {
        var invalidId = 0;
        var dto = new AddProductSalesDtoBuilder()
            .WithProductId(invalidId)
            .Build();

        var expected = () => _sut.Define(dto);

        expected.Should().ThrowExactly<ProuductNotFoundException>();
    }

    [Fact]
    public void Define_Certain_outOfStock_exception()
    {
        var productGroup = ProductGroupFactory.Generate("dummy");
        var product = new ProductBuilder()
            .WithCount(0)
            .WithProductGroup(productGroup)
            .Build();
        DbContext.Save(product);
        var dto = new AddProductSalesDtoBuilder()
            .WithProductId(product.Id)
            .Build();

       var expected =()=> _sut.Define(dto);

       expected.Should().ThrowExactly<OutofStockException>();
    }
    
    [Fact]
    public void Define_Certain_outOfStock_exception2()
    {
        var productGroup = ProductGroupFactory.Generate("dummy");
        var product = new ProductBuilder()
            .WithCount(10)
            .WithProductGroup(productGroup)
            .Build();
        DbContext.Save(product);
        var dto = new AddProductSalesDtoBuilder()
            .WithCount(11)
            .WithProductId(product.Id)
            .Build();

        var expected =()=> _sut.Define(dto);

        expected.Should().ThrowExactly<OutofStockException>();
    }
}