using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Specs.Test.ProductGroupServiceTest.Add;

public class AddProductGroupDto
{
    [Required] [MaxLength(50)] public string Name { get; set; }
}