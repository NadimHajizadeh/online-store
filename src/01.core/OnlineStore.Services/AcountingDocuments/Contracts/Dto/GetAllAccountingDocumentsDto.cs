namespace OnlineStore.Specs.Test.ProductSaless.Add;

public class GetAllAccountingDocumentsDto
{
    public string CustomerName { get; set; }
    public int DocumentNumber { get; set; }
    public double TotalPrice { get; set; }
    public DateTime date { get; set; }
    public Guid SalesFactorNumber { get; set; }
}