using Microsoft.AspNetCore.Mvc;
using OnlineStore.Specs.Test.ProductSaless.Add;

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
    public List<GetAllAccountingDocumentsDto> GetAll()
    {
        return
            _service.GetAll();
    }
}