using System.ComponentModel.DataAnnotations.Schema;

namespace sm_backend.Models
{
    public class CustomerOrder
    {
        public int Id { get; set; }
        [ForeignKey("Item")]
        public int ItemId { get; set; }
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public string? ItemName { get; set; }
        public int ItemQuantity { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public decimal SetPrice { get; set; }
        public decimal Yourbill { get; set; }
    }
}
