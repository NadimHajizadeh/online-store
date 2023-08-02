using FluentAssertions;
using OnlineStore.Entities;
using OnlineStore.TestTools.DataBaseConfig;
using OnlineStore.TestTools.DataBaseConfig.Integration;
using OnlineStore.TestTools.ProductGroups.Factories;

namespace OnlineStore.Specs.Test.ProductGroupServiceTest.Delete;

[Scenario("حذف گروه ")]
public class DeleteProuductGroup : BusinessIntegrationTest
{
    private ProductGroup _productGroup;

    [Given("در فهرست گروه ها یک گروه به نام بهداشتی وجود دارد")]
    public void Given()
    {
        _productGroup = ProductGroupFactory.Generate("بهداشتی");
        DbContext.Save(_productGroup);
    }

    [When("گروه بهداشتی را حذف میکنم")]
    public void When()
    {
        var sut = ProductGroupServiceFactory.Generate(SetupContexts);
        sut.Remove(_productGroup.Id);
    }

    [Then("در فهرست گروه ها نباید گروهی وجود داشته باشد")]
    public void Then()
    {
        ReadContext.Set<ProductGroup>().Should().HaveCount(0);
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