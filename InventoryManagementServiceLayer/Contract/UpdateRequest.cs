namespace InventoryManagementApi.Models.Products;

using System.ComponentModel.DataAnnotations;

public class UpdateRequest
{
    [Required]
    public int ProductCode { get; set; }

    [Required]
    [MinLength(50)]
    public string ProductDescription { get; set; } = String.Empty;

    [Required]
    public int Price { get; set; }


    [Required]
    public bool Name { get; set; }
    public string ErrorMessage { get; set; }
}