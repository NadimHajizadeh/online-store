using Microsoft.EntityFrameworkCore;
using OnlineStore.Entities;
using OnlineStore.Persistanse.EF;

namespace OnlineStore.Specs.Test.ProductSaless.Add;

public class EFAccountingDocumentRepository : AccountingDocumentRepository
{
    private readonly DbSet<AccountingDocument> _accountingDucoments;

    public EFAccountingDocumentRepository(EFDataContext context)
    {
        _accountingDucoments = context.Set<AccountingDocument>();
    }

    public void Add(AccountingDocument accountingDocument)
    {
        _accountingDucoments.Add(accountingDocument);
    }

    public List<GetAllAccountingDocumentsDto> GetAll()
    {
        return
            _accountingDucoments.Select(_ => new GetAllAccountingDocumentsDto()
            {
                DocumentNumber = _.DocumentNumber,
                date = _.date,
                CustomerName = _.ProductSales.CustomerName,
                TotalPrice = _.TotalPrice,
                SalesFactorNumber = _.SalesFactorNumber,
            }).ToList();
    }
}