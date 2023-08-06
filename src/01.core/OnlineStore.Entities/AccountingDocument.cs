namespace OnlineStore.Entities;

public class AccountingDocument
{
    public int Id { get; set; }
    public DateTime date { get; set; }
    public double TotalPrice { get; set; }
    public int DocumentNumber { get; set; }
    public Guid SalesFactorNumber { get; set; }
    public ProductSales ProductSales { get; set; }
}