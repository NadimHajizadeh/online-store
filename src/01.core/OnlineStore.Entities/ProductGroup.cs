namespace OnlineStore.Entities;

public class ProductGroup
{
    public ProductGroup()
    {
        Products = new();
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public HashSet<Product> Products { get; set; }
}