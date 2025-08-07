namespace mvc.Models;

public class Kategori
{
    public int Id { get; set; }
    public string Name  { get; set; } = string .Empty;
    
    public decimal Price { get; set; }
    public int Stock { get; set; }
}