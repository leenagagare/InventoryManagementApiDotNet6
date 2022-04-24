namespace InventoryManagementApi.Models.Products;

using System.ComponentModel.DataAnnotations;

public class CreateRequest
{
    [Required]
    public int ProductCode { get; set; }

    [Required]
    [MinLength(50)]
    public string ProductDescription { get; set; } = String.Empty;

    [Required]
    public int Price { get; set; }
    

    [Required]
    [MinLength(10)]
    public string Name { get; set; }

}
