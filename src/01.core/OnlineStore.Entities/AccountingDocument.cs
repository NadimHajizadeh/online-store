namespace OnlineStore.Entities;

public class AccountingDocument
{
    public DateTime date { get; set; }
    public double TotalPrice { get; set; }
    public Guid SalesFactorNumber { get; set; }
    public int DocumentNumber { get; set; }
    public ProductSales ProductSales { get; set; }
}