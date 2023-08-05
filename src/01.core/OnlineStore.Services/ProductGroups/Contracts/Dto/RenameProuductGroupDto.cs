using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Services.ProductGroups.Contracts.Dto;

public class RenameProuductGroupDto
{
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
}