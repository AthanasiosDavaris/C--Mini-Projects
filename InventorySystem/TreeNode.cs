public class TreeNode
{
  public Product Data { get; set; }
  public TreeNode? Left { get; set; }
  public TreeNode? Right { get; set; }

  public TreeNode(Product product)
  {
    Data = product;
    Left = null;
    Right = null;
  }
}