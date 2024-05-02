using BlazingShop.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazingShop.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
}