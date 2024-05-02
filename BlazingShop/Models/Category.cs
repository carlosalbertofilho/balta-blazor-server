using System.ComponentModel.DataAnnotations;

namespace BlazingShop.Models;
public class Category()
{
    [Key]
    [Required(ErrorMessage = "Id é obrigatório")]
    public int Id { get; set; }
    [Required(ErrorMessage = "Nome é obrigatório")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Nome deve ter entre 3 e 50 caracteres")]
    public required string Name { get; set; } 
    [Required(ErrorMessage = "Descrição é obrigatória")]
    [MinLength(10, ErrorMessage = "Descrição deve ter no mínimo 10 caracteres")]
    public required string Description { get; set; }

    public List<Product> Products { get; set; } = [];
}