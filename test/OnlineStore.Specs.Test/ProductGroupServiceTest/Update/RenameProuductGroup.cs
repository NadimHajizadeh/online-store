using System.Linq;
using FluentAssertions;
using OnlineStore.Entities;
using OnlineStore.TestTools.DataBaseConfig;
using OnlineStore.TestTools.DataBaseConfig.Integration;
using OnlineStore.TestTools.ProductGroups.Factories;

namespace OnlineStore.Specs.Test.ProductGroupServiceTest.Update;

[Scenario("ویرایش نام گروه ")]
public class RenameProuductGroup : BusinessIntegrationTest
{
    private ProductGroup _productGroup;


    [Given("یک گروه با نام بهداشتی در فهرست گروه وجود دارد")]
    public void Given()
    {
        _productGroup = ProductGroupFactory.Generate("بهداشتی");
        DbContext.Save(_productGroup);
    }

    [When("نام گروه بهداشتی را به ارایشی-بهداشتی عوض کینم")]
    public void When()
    {
        var sut = ProductGroupServiceFactory.Generate(SetupContexts);
        var dto = RenameProuductGroupDtoFactory.Generate("ارایشی-بهداشتی");

        sut.Rename(_productGroup.Id, dto);
    }

    [Then("در فهرست گروه ها باید یک گروه با نام ارایشی-بهداشتی باشد")]
    public void Then()
    {
        var expected = ReadContext.Set<ProductGroup>().Single();
        expected.Name.Should().Be("ارایشی-بهداشتی");
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