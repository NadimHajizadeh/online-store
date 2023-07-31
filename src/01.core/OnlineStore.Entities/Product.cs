namespace OnlineStore.Entities;

public class Product
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int LeastCount { get; set; }
    public int Count { get; set; }
    public ProductStatus Status { get; set; }
    public int ProductGroupId { get; set; }
    public ProductGroup ProductGroup { get; set; }
}
public enum ProductStatus
{
    OutOfStock = 0,
    ReadyToOrder = 1,
    Available = 2
}