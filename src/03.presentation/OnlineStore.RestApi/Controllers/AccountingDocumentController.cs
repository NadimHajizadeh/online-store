using Microsoft.AspNetCore.Mvc;
using OnlineStore.Services.AcountingDocuments.Contracts;
using OnlineStore.Services.AcountingDocuments.Contracts.Dto;

namespace OnlineStore.RestApi.Controllers;

[Route("accounting-ducoments")]
public class AccountingDocumentController : Controller
{
    private readonly AccountingDocumentService _service;

    public AccountingDocumentController(AccountingDocumentService service)
    {
        _service = service;
    }

    [HttpGet]
    public List<GetAllAccountingDocumentsDto> GetAll
        ([FromQuery] AccountingDucomentsSerchByDto dto)
    {
        return
            _service.GetAll(dto);
    }
}