using System.Linq;
using FluentAssertions;
using OnlineStore.Entities;
using OnlineStore.TestTools.DataBaseConfig;
using OnlineStore.TestTools.DataBaseConfig.Integration;
using OnlineStore.TestTools.ProductGroups.Factories;
using OnlineStore.TestTools.Products;
using OnlineStore.TestTools.ProductSaless;
using OnlineStore.TestTools.ProductSaless.Factories;


namespace OnlineStore.Specs.Test.ProductSaless.Add;

[Scenario("فروش کالا ")]
public class DefineProductSales : BusinessIntegrationTest
{
    private Product _product;
    private ProductGroup _productGroup;

    [Given("گروهی با نام لوازم یدکی در فهرست گروه ها وجود دارد")]
    [And("کالایی با عنوان لنت ترمز با موجودی ۲۰  و وضعیت موجود و" +
         " حداقل موجودی ۵ در گروه لوازم یدکی وجود دارد ")]
    public void Given()
    {
        _productGroup = ProductGroupFactory.Generate("لوازم یدکی");
        _product = new ProductBuilder()
            .WithTitle("لنت ترمز")
            .WithCount(20)
            .WithStatus(ProductStatus.Available)
            .WithLeastCount(5)
            .WithProductGroup(_productGroup)
            .Build();
        DbContext.Save(_product);
    }

    [When("کالای با عنوان لنت ترمز و" +
          " قیمت واحد ۱۰۰۰ تومان" +
          " برای مشتری به نام مجید رضوی به تعداد ۵ عدد را ثبت میکنم")]
    public void When()
    {
        var dto = new AddProductSalesDtoBuilder()
            .WithCount(5)
            .WithProductId(_product.Id)
            .WithCustomerName("مجید رضوی")
            .WithPericePerCount(1000)
            .Build();
        var sut = ProductSalesServiceFactory.Generate(SetupContexts);
        sut.Define(dto);
    }

    [Then("کالا با عنوان لنت ترمز با موجودی ۱۵ و" +
          " وضعیت موجود و حداقل موجودی ۵ در گروه لوازم یدکی وجود داشته باشد")]
    [And("یک فاکتور فروش با کالای لنت ترمز و تعداد ۵ و" +
         " قیمت ۱۰۰۰ و شماره فاکتور ۱۲۳a و مشتری با نام مجید رضوی و" +
         " تاریخ 1402 در فاکتورهای فروش باید وجود داشته باشد")]
    [And("و یک سند حسابداری با شماره فاکتور ۱۲۳a و" +
         " شماره سند 1233455657 و تاریخ 1402 و" +
         " مبلغ ۵۰۰۰ باید در فهرست سندهای حسابداری ثبت شده باشد  ")]
    public void Then()
    {
        var expectedProduct = ReadContext.Set<Product>().Single();
        expectedProduct.Title.Should().Be("لنت ترمز");
        expectedProduct.LeastCount.Should().Be(5);
        expectedProduct.Count.Should().Be(15);
        expectedProduct.ProductGroupId.Should().Be(_productGroup.Id);
        expectedProduct.Status.Should().Be(ProductStatus.Available);

        var expectedProductSales = ReadContext.Set<ProductSales>().Single();
        expectedProductSales.ProductId.Should().Be(_product.Id);
        expectedProductSales.Count.Should().Be(5);
        expectedProductSales.PricePerProduct.Should().Be(1000);
        expectedProductSales.CustomerName.Should().Be("مجید رضوی");

        var expectedAccounting =
            ReadContext.Set<AccountingDocument>().Single();

        expectedAccounting.SalesFactorNumber.Should().Be
            (expectedProductSales.FactorNumber);
        expectedAccounting.date.Should().Be(expectedProductSales.Date);
        expectedAccounting.TotalPrice.Should().Be(5000);
    }

    [Fact]
    public void Run()
    {
        Runner.RunScenario(
            _ => Given(),
            _ => When(),
            _ => Then()
        );
    }
}