using OnlineStore.Entities;

namespace OnlineStore.Services.Products.Contracts.Dto;

public class SearchOnDto
{
    public string? Title { get; set; } = null;
    public string? GroupName { get; set; } = null;
   // public string? Status { get; set; } = null;
}