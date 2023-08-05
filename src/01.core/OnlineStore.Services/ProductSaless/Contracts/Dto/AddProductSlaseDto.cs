using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Specs.Test.ProductSaless.Add;

public class AddProductSlaseDto
{
    [Required]
    public int ProductId { get; set; }
    [Required]
    [Range(1,Double.MaxValue)]
    public double PricePerProduct { get; set; }
    [Required]
    [Range(1,Int32.MaxValue)]
    public int Count { get; set; }
    [Required]
    [MaxLength(50)]
    public string CustomerName { get; set; }
}