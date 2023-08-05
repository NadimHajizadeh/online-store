namespace OnlineStore.Specs.Test.ProductSaless.Add;

public class GetAllProductSalesDto
{
    public string CustomerName { get; set; }
    public string ProductName { get; set; }
    public int Count { get; set; }
    public double PricePerProduct { get; set; }
    public DateTime Date { get; set; }
    public Guid FactorNumber { get; set; }
}