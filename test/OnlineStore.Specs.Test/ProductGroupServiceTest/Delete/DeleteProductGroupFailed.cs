using System;
using FluentAssertions;
using OnlineStore.Entities;
using OnlineStore.Service.Unit.Test.profuctGroups;
using OnlineStore.Services.ProductGroups.Contracts;
using OnlineStore.TestTools.DataBaseConfig;
using OnlineStore.TestTools.DataBaseConfig.Integration;
using OnlineStore.TestTools.ProductGroups.Factories;
using OnlineStore.TestTools.Products.Factories;

namespace OnlineStore.Specs.Test.ProductGroupServiceTest.Delete;

[Scenario("حذف گروه وقتی که برای گروه کالا وجود دارد")]
public class DeleteProductGroupFailed : BusinessIntegrationTest
{
    private ProductGroup _productGroup;
    private Action _expectet;


    [Given("در فهرست گروه ها یک گروه به نام بهداشتی وجود دارد و")]
    [And(" یک کالا با عنوان شامپو در گروه بهداشتی ثبت شده است ")]
    public void Given()
    {
        _productGroup = ProductGroupFactory.Generate("بهداشتی");
        var product = ProductFactory.Generate(_productGroup, "شامپو");
        DbContext.Save(product);
    }

    [When("گروه بهداشتی را حذف میکنم ")]
    public void When()
    {
        var sut = ProductGroupServiceFactory.Generate(SetupContexts);
        _expectet = () => sut.Remove(_productGroup.Id);
    }

    [Then("خطایی با عنوان 'گروه دارای کالا است' باید رخ دهد")]
    public void Then()
    {
        _expectet.Should().ThrowExactly<ProuductGroupHasProuductException>();
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