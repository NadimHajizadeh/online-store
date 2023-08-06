using FluentAssertions;
using OnlineStore.Entities;
using OnlineStore.Persistanse.EF.AccountingDocuments;
using OnlineStore.Services.AcountingDocuments;
using OnlineStore.Services.AcountingDocuments.Contracts;
using OnlineStore.Services.AcountingDocuments.Contracts.Dto;
using OnlineStore.TestTools.AccountingDocuments;
using OnlineStore.TestTools.DataBaseConfig;
using OnlineStore.TestTools.DataBaseConfig.Unit;
using OnlineStore.TestTools.ProductGroups.Factories;
using OnlineStore.TestTools.Products;
using OnlineStore.TestTools.ProductSaless.Factories;

namespace OnlineStore.Service.Unit.Test.AccountingDucoments;

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
        var accountingDocument =
            AccountingDocumentFactory.Generate(productSales, 1);
        DbContext.Save(accountingDocument);

        var expected = _sut.GetAll().Single();

        expected.DocumentNumber.Should().Be(accountingDocument.DocumentNumber);
        expected.TotalPrice.Should().Be(accountingDocument.TotalPrice);
        expected.date.Should().Be(accountingDocument.date);
        expected.SalesFactorNumber.Should().Be(productSales.FactorNumber);
        expected.CustomerName.Should().Be(productSales.CustomerName);
    }

    [Fact]
    public void GetAll_Certain_search_on_FactorNumber_getAll()
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
        var productSales2 = ProductSalesFactory.Generate(product.Id,
            DateTime.Now);
        var accountingDocument =
            AccountingDocumentFactory.Generate(productSales, 1);
        var accountingDocument2 =
            AccountingDocumentFactory.Generate(productSales2, 2);
        DbContext.Save(accountingDocument);
        DbContext.Save(accountingDocument2);
        var dto = new AccountingDucomentsSerchByDto()
        {
            FactorNumber = accountingDocument.SalesFactorNumber
        };

        var expected = _sut.GetAll(dto).Single();
        
        expected.DocumentNumber.Should().Be(accountingDocument.DocumentNumber);
        expected.TotalPrice.Should().Be(accountingDocument.TotalPrice);
        expected.date.Should().Be(accountingDocument.date);
        expected.SalesFactorNumber.Should().Be(productSales.FactorNumber);
        expected.CustomerName.Should().Be(productSales.CustomerName);
    }

    [Fact]
    public void GetAll_Certain_search_on_DucomentNumber_getAll()
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
        var productSales2 = ProductSalesFactory.Generate(product.Id,
            DateTime.Now);
        var accountingDocument =
            AccountingDocumentFactory.Generate(productSales, 1);
        var accountingDocument2 =
            AccountingDocumentFactory.Generate(productSales2, 2);
        DbContext.Save(accountingDocument);
        DbContext.Save(accountingDocument2);
        var dto = new AccountingDucomentsSerchByDto()
        {
            DocumentNumber = accountingDocument.DocumentNumber
        };

        var expected = _sut.GetAll(dto).Single();

        expected.DocumentNumber.Should().Be(accountingDocument.DocumentNumber);
        expected.TotalPrice.Should().Be(accountingDocument.TotalPrice);
        expected.date.Should().Be(accountingDocument.date);
        expected.SalesFactorNumber.Should().Be(productSales.FactorNumber);
        expected.CustomerName.Should().Be(productSales.CustomerName);
    }


    [Fact]
    public void GetAll_Certain_search_on_fromDate_getAll()
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
        var productSales2 = ProductSalesFactory.Generate(product.Id,
            DateTime.Now);
        var accountingDocument =
            AccountingDocumentFactory.Generate(productSales, 1);
        var accountingDocument2 =
            AccountingDocumentFactory.Generate(productSales2, 2);
        DbContext.Save(accountingDocument);
        DbContext.Save(accountingDocument2);
        var dto = new AccountingDucomentsSerchByDto()
        {
            FromDate = accountingDocument2.date
        };

        var expected = _sut.GetAll(dto).Single();

        expected.DocumentNumber.Should()
            .Be(accountingDocument2.DocumentNumber);
        expected.TotalPrice.Should().Be(accountingDocument2.TotalPrice);
        expected.date.Should().Be(accountingDocument2.date);
        expected.SalesFactorNumber.Should().Be(productSales2.FactorNumber);
        expected.CustomerName.Should().Be(productSales2.CustomerName);
    }

    [Fact]
    public void GetAll_Certain_search_on_tillDate_getAll()
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
        var productSales2 = ProductSalesFactory.Generate(product.Id,
            DateTime.Now);
        var accountingDocument =
            AccountingDocumentFactory.Generate(productSales, 1);
        var accountingDocument2 =
            AccountingDocumentFactory.Generate(productSales2, 2);
        DbContext.Save(accountingDocument);
        DbContext.Save(accountingDocument2);
        var dto = new AccountingDucomentsSerchByDto()
        {
            TillDate = accountingDocument.date
        };

        var expected = _sut.GetAll(dto).Single();

        expected.DocumentNumber.Should().Be(accountingDocument.DocumentNumber);
        expected.TotalPrice.Should().Be(accountingDocument.TotalPrice);
        expected.date.Should().Be(accountingDocument.date);
        expected.SalesFactorNumber.Should().Be(productSales.FactorNumber);
        expected.CustomerName.Should().Be(productSales.CustomerName);
    }
}