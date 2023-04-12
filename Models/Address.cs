namespace CirzzarCurr.Models
{
    public class Address
    {
        public int Id { get; protected set; }

        public string Street { get; protected set; }
        public string City { get; protected set; }
        public int House { get; protected set; }
        public int? Floor { get; protected set; }
        public int? Flat { get; protected set; }

        public List<ApplicationUser> Users { get; protected set; } = new();
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
