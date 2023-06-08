using CirzzarCurr.Models.Cart;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CirzzarCurr.Models
{
    public class ApplicationUser : IdentityUser, IEntity<string>
    {

        [PersonalData]
        [DataType(DataType.Date)]
        public DateOnly BirthDay { get; set; }

        [PersonalData]
        [DataType(DataType.Date)]
        public DateOnly RegistrationDate { get; set; }

        [PersonalData]
        public List<Address> Addresses { get; set; } = new();

        [PersonalData]
        public List<Order> Orders { get; set; } = new();

        public List<CartItem>? Cart { get; set; } = new();

    }
}