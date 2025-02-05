using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rent_A_Moment.Models
{
    public class Order
    {
        [Key]
        public int Order_Id { get; set; }
        public string PaymentMethod { get; set; }
        public string Status { get; set; }
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }  
        public virtual Customer Customer { get; set; }
    }
}
