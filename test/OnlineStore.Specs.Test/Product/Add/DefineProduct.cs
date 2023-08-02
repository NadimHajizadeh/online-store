using OnlineStore.Entities;
using OnlineStore.TestTools.DataBaseConfig;
using OnlineStore.TestTools.DataBaseConfig.Integration;
using OnlineStore.TestTools.ProductGroups.Factories;
using OnlineStore.TestTools.Products.Factories;

namespace OnlineStore.Specs.Test.Product.Add;

[Scenario("تعریف کالا ")]
public class DefineProduct : BusinessIntegrationTest
{
    private ProductGroup _asbabBasiProductGroup;

    [Given("دو گروه با عنوان های  اسباب بازی و لبنیات در فهرست گروه ها وجود دارد")]
    [And("یک کالا با نام شیر در فهرست کالا های لبنیات وجود دارد ")]
    public void Given()
    {
         _asbabBasiProductGroup = ProductGroupFactory.Generate("اسباب بازی");
        DbContext.Save(_asbabBasiProductGroup);
        var labaniatProductGroup = ProductGroupFactory.Generate("لبنیات");
        var product = ProductFactory.Generate(labaniatProductGroup, "شیر",10);
        DbContext.Save(product);

    }

    [When("یک کالا با عنوان شیر در گروه اسباب بازی" +
          "  با حداقل موجودی ۱۰ را ثبت میکنم ")]
    public void When()
    {
        var product = ProductFactory.Generate(_asbabBasiProductGroup, "شیر",10);
      

    }

    [Then("یک کالا با عنوان شیر در گروه اسباب بازی و حداقل موجودی ۱۰ و" +
          " وضعیت ناموجود و موجودی ۰  باید در فهرست کالا موجود باشد")]
    public void Then()
    {

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