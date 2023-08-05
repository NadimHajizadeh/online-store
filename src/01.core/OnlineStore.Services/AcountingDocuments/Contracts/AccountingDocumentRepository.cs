using OnlineStore.Entities;
using OnlineStore.Services.AcountingDocuments.Contracts.Dto;

namespace OnlineStore.Services.AcountingDocuments.Contracts;

public interface AccountingDocumentRepository
{
    void Add(AccountingDocument accountingDocument);

    List<GetAllAccountingDocumentsDto> GetAll(AccountingDucomentsSerchByDto?
        dto = null);
}