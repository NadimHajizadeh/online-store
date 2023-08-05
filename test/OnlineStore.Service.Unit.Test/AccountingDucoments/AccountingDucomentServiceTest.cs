using FluentAssertions;
using OnlineStore.Entities;
using OnlineStore.Services.AcountingDocuments;
using OnlineStore.Specs.Test.ProductSaless.Add;
using OnlineStore.TestTools.DataBaseConfig;
using OnlineStore.TestTools.DataBaseConfig.Unit;
using OnlineStore.TestTools.ProductGroups.Factories;
using OnlineStore.TestTools.Products;

namespace OnlineStore.Service.Unit.Test.Accountingducoments;

public class AccountingDucomentServiceTest : BusinessUnitTest
{
    private readonly AccountingDocumentService _sut;

    public AccountingDucomentServiceTest()
    {
        var repository = new EFAccountingDocumentRepository(SetupContext);
        _sut = new AccountingDocumentAppService(repository);
    }

    [Fact]
    public void GetAll_Certain_getAll()
    {
        var productGroup = ProductGroupFactory.Generate("dummy");
        var product = new ProductBuilder()
            .WithCount(100)
            .WithStatus(ProductStatus.Available)
            .WithProductGroup(productGroup)
            .Build();
        DbContext.Save(product);
        var productSales = ProductSalesFactory.Generate(product.Id,
            DateTime.Now);
        var accountingDocument = new AccountingDocument()
        {
            date = productSales.Date,
            ProductSales = productSales,
            TotalPrice = productSales.Count * productSales.PricePerProduct,
            DocumentNumber = 12,
        };
        DbContext.Save(accountingDocument);

        var expected = _sut.GetAll().Single();

        expected.DocumentNumber.Should().Be(accountingDocument.DocumentNumber);
        expected.TotalPrice.Should().Be(accountingDocument.TotalPrice);
        expected.date.Should().Be(accountingDocument.date);
        expected.SalesFactorNumber.Should().Be(productSales.FactorNumber);
        expected.CustomerName.Should().Be(productSales.CustomerName);
    }
}