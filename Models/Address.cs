namespace CirzzarCurr.Models
{
    public class Address : IEntity<int>
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public int House { get; set; }
        public int? Floor { get; set; }
        public int? Flat { get; set; }

        public List<ApplicationUser> Users { get; set; } = new();
        public Address()
        {
            Street = string.Empty;
            City = string.Empty;
        }

        public Address(int id, string street, string city, int house, int? floor = null, int? flat = null)
        {
            Id = id;
            Street = street;
            City = city;
            House = house;
            Floor = floor;
            Flat = flat;
        }

        public override string ToString()
        {
            return $"{City} {Street} {House} ({Flat}/{Floor})";
        }
    }
}
