using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Specs.Test.ProductImports.Add;

public class AddProductImportDto
{
    [Required] [Range(1, Int32.MaxValue)] public int Count { get; set; }
    [Required] public int ProductId { get; set; }
    [Required] [MaxLength(50)] public string CompenyName { get; set; }
    [Required] public string FactorNumber { get; set; }
}