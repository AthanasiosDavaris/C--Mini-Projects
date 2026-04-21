/// <summary>
/// Represents a product in the inventory.
/// </summary>
public class Product
{
  public int ProductId { get; set; }
  public string Name { get; set; }
  public decimal Price { get; set; }
  public int StockQuantity { get; set; }

  public Product(int productId, string name, decimal price, int stockQuantity)
  {
    ProductId = productId;
    Name = name;
    Price = price;
    StockQuantity = stockQuantity;
  }

  public override string ToString()
  {
    return $"[ID: {ProductId}] {Name} | Price: ${Price:0.00} | Stock: {StockQuantity}";
  }
}