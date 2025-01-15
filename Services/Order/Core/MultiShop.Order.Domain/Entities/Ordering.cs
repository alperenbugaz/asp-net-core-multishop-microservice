namespace MultiShop.Order.Core.Domain.Entities;

public class Ordering
{
    public int OrderingId { get; set; }
    public string UserId { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal TotalPrice { get; set; }
    public List<OrderDetail> OrderDetails { get; set; }
    
}