namespace CirzzarCurr.Models
{

    public class Order : IEntity<int>
    {
        public int Id { get; set; }
        public bool IsActive { get; set; } = true;
        public decimal Price { get; set; }
        public Address Address { get; set; } = new();
        public ApplicationUser? User { get; set; }
        public DateTime ReceiptTime { get; set; }
        public DateTime DeliveryTime { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
