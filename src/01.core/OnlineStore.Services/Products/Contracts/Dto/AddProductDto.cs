using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Services.Products.Contracts.Dto;

public class AddProductDto
{
    [Required] [MaxLength(50)] public string Title { get; set; }
    [Required] public int ProductGroupId { get; set; }
    [Required] [Range(1, Int32.MaxValue)] public int LeastCount { get; set; }
}