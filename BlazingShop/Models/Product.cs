using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace  BlazingShop.Models;

public class Product()
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

    [RegularExpression(@"^http(s)?://([\w-]+.)+[\w-]+(/[\w- ./?%&=])?$", ErrorMessage = "Url da imagem inválida")]
    public required string ImageUrl { get; set; }

    [Range(0, double.MaxValue, ErrorMessage = "Preço não pode ser negativo")]
    [DataType(DataType.Currency)]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal Price { get; set; }

    
    [Required(ErrorMessage = "Categoria é obrigatória")]
    public int CategoryId { get; set; }
    public Category? Category { get; set; }
}