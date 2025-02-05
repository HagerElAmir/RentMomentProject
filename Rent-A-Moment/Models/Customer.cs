using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Rent_A_Moment.Models
{
    public class Customer
    {
        [Key]
        public int Cust_Id { get; set; }
        public string Name { get; set; }
        public string Email  { get; set; }
        public string Password { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public virtual IdentityUser User { get; set; }


    }
}
