using OnlineStore.Services.AcountingDocuments.Contracts;
using OnlineStore.Services.AcountingDocuments.Contracts.Dto;

namespace OnlineStore.Services.AcountingDocuments;

public class AccountingDocumentAppService : AccountingDocumentService
{
    private readonly AccountingDocumentRepository _repository;

    public AccountingDocumentAppService(AccountingDocumentRepository repository)
    {
        _repository = repository;
    }
    public List<GetAllAccountingDocumentsDto> GetAll(
        AccountingDucomentsSerchByDto? dto )
    {
        return 
        _repository.GetAll(dto);
    }
}