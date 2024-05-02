namespace  BlazingShop.Models;

public class Product
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public string Image { get; set; } = "";
    public string Description { get; set; } = "";
    public int Price { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; } = new();
}