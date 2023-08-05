using System;
using System.Linq;
using FluentAssertions;
using OnlineStore.Entities;
using OnlineStore.TestTools;
using OnlineStore.TestTools.DataBaseConfig;
using OnlineStore.TestTools.DataBaseConfig.Integration;
using OnlineStore.TestTools.ProductGroups.Factories;
using OnlineStore.TestTools.ProductImports;
using OnlineStore.TestTools.ProductImports.Factories;
using OnlineStore.TestTools.Products;
using OnlineStore.TestTools.Products.Factories;

namespace OnlineStore.Specs.Test.ProductImports.Add;

[Scenario("ورود کالا برای دریافت وضغیت آماده سفارش")]
public class
    DefineProductImportToGetReadyToOrderStatus : BusinessIntegrationTest
{
    private Product _product;
    private DateTime _datetime;


    [Given("یک گروه با نام بهداشتی در فهرست گروه ها وجود دارد")]
    [And("یک کالا با عنوان شامپو با موجودی ۰ و" +
         " وضعیت ناموجود  و حداقل موجودی ۱۰ در گروه بهداشتی وجود دارد ")]
    public void Given()
    {
        var productGroup = ProductGroupFactory.Generate("بهداشتی");
        _product =  new ProductBuilder().WithProductGroup(productGroup)
            .WithTitle("شامپو")
            .Build();
        DbContext.Save(_product);
    }

    [When("تعداد ۲۰ تا به موجودی کالایی با" +
          " عنوان شامپو با شماره فاکتور ۱۲۳a و" +
          " نام شرکت فپکو  در گروه بهداشتی را وارد میکنم ")]
    public void When()
    {
        var dto = new AddProductImportDtoBuilder()
            .WithProductId(_product.Id)
            .WithCount(10)
            .WithCompenyName("فپکو")
            .WithFactorNumber("۱۲۳a")
            .Build();

        _datetime = DatetimeFactory.Generate();

        var sut =
            ProductImportServiceFactory.Generate(SetupContexts,
                _datetime);
        sut.Define(dto);
    }

    [Then("یک کالا با عنوان شامپو و موجودی ۲۰ و" +
          " وضعیت موجود در گروه بهداشتی و" +
          " حداقل موجودی ۱۰ باید در فهرست کالاها وجود داشته باشد")]
    [And("یک ورودی کالا برای کالای شامپو در تاریخ 1402/09/19 21:59  و" +
         " تعداد ۲۰ و شماره فاکتور ۱۲۳a و" +
         " نام شرکت فپکو باید در فهرست ورودی های کالا وجود داشته باشد")]
    public void Then()
    {
        var expected = ReadContext.Set<Product>().Single();
        expected.Title.Should().Be("شامپو");
        expected.Count.Should().Be(10);
        expected.Status.Should().Be(ProductStatus.ReadyToOrder);
        expected.LeastCount.Should().Be(10);

        var actual = ReadContext.Set<ProductImport>().Single();
        actual.Count.Should().Be(10);
        actual.ProductId.Should().Be(_product.Id);
        actual.FactorNumber.Should().Be("۱۲۳a");
        actual.CompenyName.Should().Be("فپکو");
        actual.Date.Should().Be(_datetime);
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