namespace OnlineStore.Entities;

public class ProductImport
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public string CompenyName { get; set; }
    public int Count { get; set; }
    public DateTime Date { get; set; }
    public string FactorNumber { get; set; }
}