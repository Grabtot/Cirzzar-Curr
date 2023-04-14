using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CirzzarCurr.Models
{
    public class ApplicationUser : IdentityUser, IEntity<string>
    {

        [PersonalData]
        [DataType(DataType.Date)]
        public DateOnly BirthDay { get; protected set; }

        [PersonalData]
        [DataType(DataType.Date)]
        public DateOnly RegistrationDate { get; protected set; }

        [PersonalData]
        public List<Address> Addresses { get; protected set; } = new();

        [PersonalData]
        public List<Order> Orders { get; protected set; } = new();
        public List<Product> Cart { get; protected set; } = new();
    }
}