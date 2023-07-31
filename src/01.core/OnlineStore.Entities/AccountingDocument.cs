namespace OnlineStore.Entities;

public class AccountingDocument
{

    public DateTime date { get; set; }
    public double TotalPrice { get; set; }
    public string SalesFactorNumber { get; set; }
    public double DocumentNumber { get; set; }
    public ProductSales ProductSales { get; set; }
}