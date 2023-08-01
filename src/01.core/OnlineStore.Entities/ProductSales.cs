namespace OnlineStore.Entities;

public class ProductSales
{
    public Guid FactorNumber { get; set; }
    public string CustomerName { get; set; }
    public DateTime Date { get; set; }
    public int ProductId { get; set; }
    public int Count { get; set; }
    public double PricePerProduct { get; set; }
}