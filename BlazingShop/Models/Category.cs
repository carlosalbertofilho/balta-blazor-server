using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazingShop.Models;
public class Category(
    string name = "",
    string description = "")
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required(ErrorMessage = "Nome é obrigatório")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Nome deve ter entre 3 e 50 caracteres")]
    public string Name { get; set; } = name;
    [Required(ErrorMessage = "Descrição é obrigatória")]
    [MinLength(10, ErrorMessage = "Descrição deve ter no mínimo 10 caracteres")]
    public string Description { get; set; } = description;

    public List<Product> Products { get; set; } = [];
}