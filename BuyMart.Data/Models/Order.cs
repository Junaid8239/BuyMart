namespace BuyMart.Data.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string CustomerEmail { get; set; }
        public DateTime OrderDate { get; set; }

        // Navigation property
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }

}
