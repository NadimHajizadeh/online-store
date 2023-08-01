using System;
using FluentAssertions;
using OnlineStore.Entities;
using OnlineStore.Services.ProductGroups.Contracts;
using OnlineStore.Services.ProductGroups.Exceptions;
using OnlineStore.TestTools.DataBaseConfig;
using OnlineStore.TestTools.DataBaseConfig.Integration;
using OnlineStore.TestTools.ProductGroups.Factories;

namespace OnlineStore.Specs.Test.ProductGroupServiceTest.Add;

[Scenario("ثبت گروه با نام تکراری")]
public class DefineProductGroupFailed : BusinessIntegrationTest
{
    private readonly ProductGroupService _sut;
    private Action _expected;

    public DefineProductGroupFailed()
    {
         _sut = ProductGroupServiceFactory.Generate(SetupContexts);
    }
    [Given("یک گروه با نام بهداشتی در فهرست گروه وجود دارد")]
    public void Given()
    {
        var productGroup = ProductGroupFactory.Generate("بهداشتی");
        DbContext.Save(productGroup);
    }

    [When("یک گروه با نام بهداشتی را ثبت میکنم ")]
    public void When()
    {
        var dto = AddProductGroupDtoFactory.Generate("بهداشتی");
        _expected = ()=> _sut.Define(dto);
       
    }

    [Then("خطایی با عنوان 'اسم گروه تکراری' باید رخ دهد")]
    public void Then()
    {
        _expected.Should().ThrowExactly<DuplicatedProductGroupNameException>();
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