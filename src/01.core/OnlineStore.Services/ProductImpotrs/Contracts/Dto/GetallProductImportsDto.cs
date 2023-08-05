namespace OnlineStore.Services.ProductImpotrs.Contracts.Dto;

public class GetallProductImportsDto
{
    public string ProductName { get; set; }
    public string CompenyName { get; set; }
    public int Count { get; set; }
    public DateTime Date { get; set; }
    public string FactorNumber { get; set; }
}