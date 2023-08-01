using System.Linq;
using FluentAssertions;
using OnlineStore.Entities;
using OnlineStore.Persistanse.EF;
using OnlineStore.Services.ProductGroups.Contracts;
using OnlineStore.TestTools.DataBaseConfig.Integration;
using OnlineStore.TestTools.ProductGroups.Factories;

namespace OnlineStore.Specs.Test.ProductGroupServiceTest.Add;

[Scenario("ثبت گروه ")]
public class DefineProductGroup : BusinessIntegrationTest
{
    private readonly ProductGroupService _sut;

    public DefineProductGroup()
    {
        _sut = ProductGroupServiceFactory.Generate(SetupContexts);
    }

    [Given("فهرست گروه خالی است")]
    public void Given()
    {
    }

    [When("یک گروه با نام بهداشتی را ثبت میکنم ")]
    public void When()
    {
        var dto = AddProductGroupDtoFactory.Generate("بهداشتی");
        _sut.Define(dto);
    }

    [Then("در فهرست گروه ها یک گروه با نام بهداشتی باید وجود داشته باشد")]
    public void Then()
    {
        var expected = ReadContext.Set<ProductGroup>().Single();
        expected.Name.Should().Be("بهداشتی");
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