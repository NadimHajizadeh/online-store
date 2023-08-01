using System;
using FluentAssertions;
using OnlineStore.Entities;
using OnlineStore.Services.ProductGroups.Exceptions;
using OnlineStore.TestTools.DataBaseConfig;
using OnlineStore.TestTools.DataBaseConfig.Integration;
using OnlineStore.TestTools.ProductGroups.Factories;

namespace OnlineStore.Specs.Test.ProductGroupServiceTest.Update;

[Scenario("رخ دادن خطا ویرایش نام گروه ")]
public class RenameProductGroupFailed : BusinessIntegrationTest
{
    private ProductGroup _behdashtiProuductGroup;
    private Action _expected;

    [Given("یک گروه با نام بهداشتی در فهرست گروه وجود دارد و" +
           "یک گروه با نام خوراکی در فهرست گروه وجود دارد")]
    public void Given()
    {
        _behdashtiProuductGroup = ProductGroupFactory.Generate("بهداشتی");
        var khorakiProuductGroup = ProductGroupFactory.Generate("خوراکی");
        DbContext.Save(_behdashtiProuductGroup);
        DbContext.Save(khorakiProuductGroup);
    }

    [When("نام گروه بهداشتی را به خوراکی  عوض کینم")]
    public void When()
    {
        var sut = ProductGroupServiceFactory.Generate(SetupContexts);
        var dto = RenameProuductGroupDtoFactory.Generate("خوراکی");
        _expected = () => sut.Rename(_behdashtiProuductGroup.Id, dto);
    }

    [Then("خطایی با عنوان نام گروه تکراری است رخ بدهد ")]
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