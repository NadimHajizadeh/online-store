using OnlineStore.Services.AcountingDocuments.Contracts.Dto;

namespace OnlineStore.Services.AcountingDocuments.Contracts;

public interface AccountingDocumentService
{
    List<GetAllAccountingDocumentsDto> GetAll
                    (AccountingDucomentsSerchByDto? dto =null);
}