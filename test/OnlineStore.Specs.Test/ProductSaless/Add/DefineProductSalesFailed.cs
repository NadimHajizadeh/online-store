using System;
using FluentAssertions;
using OnlineStore.Entities;
using OnlineStore.Services.ProductSaless.Exceptions;
using OnlineStore.TestTools.DataBaseConfig;
using OnlineStore.TestTools.DataBaseConfig.Integration;
using OnlineStore.TestTools.ProductGroups.Factories;
using OnlineStore.TestTools.Products;
using OnlineStore.TestTools.ProductSaless;
using OnlineStore.TestTools.ProductSaless.Factories;

namespace OnlineStore.Specs.Test.ProductSaless.Add;

[Scenario("فروش کالا با موجودی 0 ")]
public class DefineProductSalesFailed : BusinessIntegrationTest
{
    private ProductGroup _productGroup;
    private Product _product;
    private Action _expected;


    [Given("گروهی با نام لوازم یدکی در فهرست گروه ها وجود دارد")]
    [And("کالایی با عنوان لنت ترمز با موجودی0   و وضعیت ناموجود و" +
         " حداقل موجودی ۵ در گروه لوازم یدکی وجود دارد ")]
    public void Given()
    {
        _productGroup = ProductGroupFactory.Generate("لوازم یدکی");
        _product = new ProductBuilder()
            .WithTitle("لنت ترمز")
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
        _expected = () => sut.Define(dto);
    }

    [Then("خطایی با عنوان موجودی کافی نیست یاید رخ بدهد")]
    public void Then()
    {
        _expected.Should().ThrowExactly<OutofStockException>();
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