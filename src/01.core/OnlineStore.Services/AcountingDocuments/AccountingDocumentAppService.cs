using OnlineStore.Specs.Test.ProductSaless.Add;

namespace OnlineStore.Services.AcountingDocuments;

public class AccountingDocumentAppService : AccountingDocumentService
{
    private readonly AccountingDocumentRepository _repository;

    public AccountingDocumentAppService(AccountingDocumentRepository repository)
    {
        _repository = repository;
    }
    public List<GetAllAccountingDocumentsDto> GetAll()
    {
        return 
        _repository.GetAll();
    }
}