using System.Linq;
using FluentAssertions;
using OnlineStore.Entities;
using OnlineStore.TestTools.DataBaseConfig;
using OnlineStore.TestTools.DataBaseConfig.Integration;
using OnlineStore.TestTools.ProductGroups.Factories;
using OnlineStore.TestTools.Products;
using OnlineStore.TestTools.Products.Factories;

namespace OnlineStore.Specs.Test.Products.Add;

[Scenario("تعریف کالا ")]
public class DefineProduct : BusinessIntegrationTest
{
    private ProductGroup _asbabBasiProductGroup;

    [Given(
        "دو گروه با عنوان های  اسباب بازی و لبنیات در فهرست گروه ها وجود دارد")]
    [And("یک کالا با نام شیر در فهرست کالا های لبنیات وجود دارد ")]
    public void Given()
    {
        _asbabBasiProductGroup = ProductGroupFactory.Generate("اسباب بازی");
        DbContext.Save(_asbabBasiProductGroup);
        var labaniatProductGroup = ProductGroupFactory.Generate("لبنیات");
        var product =  new ProductBuilder().WithProductGroup(labaniatProductGroup)
            .WithTitle("شیر")
            .Build();
        DbContext.Save(product);
    }

    [When("یک کالا با عنوان شیر در گروه اسباب بازی" +
          "  با حداقل موجودی ۱۰ را ثبت میکنم ")]
    public void When()
    {
        var dto = AddProductDtoFactory.Generate("شیر",
            _asbabBasiProductGroup.Id,
            10);
        var sut = ProductServiceFactory.Generate(SetupContexts);
        sut.Define(dto);
    }

    [Then("یک کالا با عنوان شیر در گروه اسباب بازی و حداقل موجودی ۱۰ و" +
          " وضعیت ناموجود و موجودی ۰  باید در فهرست کالا موجود باشد")]
    public void Then()
    {
        var expected = ReadContext.Set<Product>()
            .First(_ => _.Title == "شیر" && _
                .ProductGroupId == _asbabBasiProductGroup.Id);

        expected.Title.Should().Be("شیر");
        expected.ProductGroupId.Should().Be(_asbabBasiProductGroup.Id);
        expected.LeastCount.Should().Be(10);
        expected.Status.Should().Be(ProductStatus.OutOfStock);
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