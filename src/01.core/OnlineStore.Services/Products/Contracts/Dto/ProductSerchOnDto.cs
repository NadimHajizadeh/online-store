using OnlineStore.Entities;

namespace OnlineStore.Services.Products.Contracts.Dto;

public class SearchOnDto
{
    public string? Title { get; set; }
    public string? GroupName { get; set; }

    public ProductStatus? Status { get; set; }
}