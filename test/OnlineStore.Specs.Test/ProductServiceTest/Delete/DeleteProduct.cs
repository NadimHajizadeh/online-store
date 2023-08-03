using System;
using System.Linq;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Entities;
using OnlineStore.TestTools.DataBaseConfig;
using OnlineStore.TestTools.DataBaseConfig.Integration;
using OnlineStore.TestTools.ProductGroups.Factories;
using OnlineStore.TestTools.Products.Factories;

namespace OnlineStore.Specs.Test.ProductServiceTest.Delete;

[Scenario("حذف کالا")]
public class DeleteProduct : BusinessIntegrationTest
{
    private ProductGroup _productGroup;
    private Product _product;


    [Given("یک گروه با نام بهداشتی در فهرست گروه ها وجود دارد")]
    [And("یک کالا با عنوان شامپو در گروه بهداشتی وجود دارد ")]
    public void Given()
    {
        _productGroup = ProductGroupFactory.Generate("بهداشتی");
        _product = ProductFactory.Generate(_productGroup, "شامپو");
        DbContext.Save(_product);
    }

    [When("کالای شامپو را حذف میکنم ")]
    public void When()
    {
        var sut = ProductServiceFactory.Generate(SetupContexts);
        sut.Remove(_product.Id);
    }

    [Then("بنابر این لیست کالا های گروه بهداشتی باید خالی باشد ")]
    public void Then()
    {
        var expected = ReadContext.Set<ProductGroup>()
            .Include(_ => _.Products)
            .Single();
        expected.Products.Should().HaveCount(0);
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