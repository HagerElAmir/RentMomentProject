using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rent_A_Moment.Models
{
    public class Notification
    {
        [Key]
        public int Not_Id { get; set; }
        public string Message { get; set; }
        [ForeignKey("Order")]
        public int OrderId { get; set; }

        public virtual Order Order { get; set; }

    }
}
