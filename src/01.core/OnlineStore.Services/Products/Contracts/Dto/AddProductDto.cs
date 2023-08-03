namespace OnlineStore.Services.Products.Contracts.Dto;

public class AddProductDto
{
    public string Title { get; set; }
    public int ProductGroupId { get; set; }
    public int LeastCount { get; set; }
}