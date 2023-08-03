using System;
using FluentAssertions;
using OnlineStore.Entities;
using OnlineStore.Services.ProductGroups.Exceptions;
using OnlineStore.Services.Products.Contracts.Dto;
using OnlineStore.TestTools.DataBaseConfig;
using OnlineStore.TestTools.DataBaseConfig.Integration;
using OnlineStore.TestTools.ProductGroups.Factories;
using OnlineStore.TestTools.Products.Factories;

namespace OnlineStore.Specs.Test.ProductServiceTest.Add;

[Scenario("تعریف کالا با عنوان تکراری در یک گروه")]
public class DefineProductFailed : BusinessIntegrationTest
{
    private ProductGroup _propductGroup;
    private Action _expectet;

    [Given("یک گروه با عنوان بهداشتی در فهرست گروه ها وجود دارد")]
    [And("یک کالا با نام شامپو در گروه بهداشتی وجود دارد")]
    public void Given()
    {
        _propductGroup = ProductGroupFactory.Generate("بهداشتی");
        var product = ProductFactory.Generate(_propductGroup, "شامپو");
        DbContext.Save(product);
    }

    [When(
        "یک کالا با عنوان شامپو و گروه بهداشتی و حداقل موجودی ۱۰ را ثبت میکنم ")]
    public void When()
    {
        var dto =
            AddProductDtoFactory.Generate("شامپو", _propductGroup.Id, 10);
        var sut = ProductServiceFactory.Generate(SetupContexts);
        _expectet = () => sut.Define(dto);
    }

    [Then("خطایی با عنوان 'عنوان کالا تکراری است' باید رخ دهد ")]
    public void Then()
    {
        _expectet.Should().ThrowExactly<DuplicatedProductNameException>();
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