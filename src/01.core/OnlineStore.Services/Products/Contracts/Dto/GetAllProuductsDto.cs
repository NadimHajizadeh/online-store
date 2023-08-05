using OnlineStore.Entities;

namespace OnlineStore.Services.Products.Contracts.Dto;

public class GetAllProuductsDto
{
    public int ProductCode { get; set; }
    public string ProductTitle { get; set; }
    public string GroupName { get; set; }
    public int Count { get; set; }
    public int LeastCount { get; set; }
    public ProductStatus Status { get; set; }
}