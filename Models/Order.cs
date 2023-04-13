namespace CirzzarCurr.Models
{
    public class Order
    {
        public int Id { get; protected set; }
        public bool IsActive { get; set; } = true;
        public decimal Price { get; protected set; }
        public Address Address { get; protected set; } = new();
        public ApplicationUser? User { get; protected set; }
        public DateTime ReceiptTime { get; protected set; }
        public DateTime DeliveryTime { get; protected set; }
        public List<Product> Products { get; protected set; } = new List<Product>();
    }
}
