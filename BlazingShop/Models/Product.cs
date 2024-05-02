namespace  BlazingShop.Models;

public class Product(
    int id,
    string name,
    string description,
    string? imageUrl,
    decimal price,
    Category category
)
{
    public int Id { get; set; } = id;
    public string Name { get; set; } = name;
    public string Description { get; set; } = description;
    public string? ImageUrl { get; set; } = imageUrl;
    public decimal Price { get; set; } = price;
    public int CategoryId { get; set; } = category.Id;
    public Category Category { get; set; } = category;
}