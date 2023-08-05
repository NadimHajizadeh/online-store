using Microsoft.EntityFrameworkCore;
using OnlineStore.Entities;
using OnlineStore.Services.AcountingDocuments.Contracts;
using OnlineStore.Services.AcountingDocuments.Contracts.Dto;

namespace OnlineStore.Persistanse.EF.AccountingDocuments;

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

    public List<GetAllAccountingDocumentsDto> GetAll(
        AccountingDucomentsSerchByDto? dto)
    {
        var result =
            _accountingDucoments.Select(_ => new GetAllAccountingDocumentsDto()
            {
                DocumentNumber = _.DocumentNumber,
                date = _.date,
                CustomerName = _.ProductSales.CustomerName,
                TotalPrice = _.TotalPrice,
                SalesFactorNumber = _.SalesFactorNumber,
            });

        result = SearchOnDocumentNumber(result, dto);

        result = SearchOnFactorNumber(result, dto);

        result = SearchOnFromDate(result, dto);

        result = SearchOnTillDate(dto, result);


        return result.ToList();
    }

    private IQueryable<GetAllAccountingDocumentsDto> SearchOnTillDate(
        AccountingDucomentsSerchByDto? dto,
        IQueryable<GetAllAccountingDocumentsDto> result)
    {
        if (dto.TillDate != null)
        {
            result =
                result.Where(_ => _.date <= dto.TillDate);
        }

        return result;
    }

    private IQueryable<GetAllAccountingDocumentsDto> SearchOnFromDate(
        IQueryable<GetAllAccountingDocumentsDto> result,
        AccountingDucomentsSerchByDto? dto)
    {
        if (dto.FromDate != null)
        {
            result =
                result.Where(_ => _.date >= dto.FromDate);
        }

        return result;
    }

    private IQueryable<GetAllAccountingDocumentsDto> SearchOnFactorNumber(
        IQueryable<GetAllAccountingDocumentsDto> result,
        AccountingDucomentsSerchByDto? dto)
    {
        if (dto.FactorNumber != null)
        {
            result =
                result.Where(_ => _.SalesFactorNumber == dto.FactorNumber);
        }

        return result;
    }

    private IQueryable<GetAllAccountingDocumentsDto> SearchOnDocumentNumber(
        IQueryable<GetAllAccountingDocumentsDto> result,
        AccountingDucomentsSerchByDto? dto)
    {
        if (dto.DocumentNumber != null)
        {
            result = result.Where(_ => _.DocumentNumber == dto
                .DocumentNumber);
        }

        return result;
    }
}