using System.ComponentModel.DataAnnotations.Schema;

namespace sm_backend.Models
{
    public class PayementRecord
    {
        public int Id { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public string? PayementDate { get; set; }
        public decimal PayementRcv { get; set; }
        public decimal Discount { get; set; }
        public decimal PendingAmount { get; set; }
        public DateTime  SecondPeyementDate { get; set; }=DateTime.Now;

    }
}
