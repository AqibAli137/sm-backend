using System.ComponentModel.DataAnnotations;

namespace sm_backend.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? PhoneNo { get; set; }
        public bool IsActive { get; set; }
        public decimal PaymentRcv { get; set; }
        public decimal PendingPayment { get; set; }
        public decimal TotalBill { get; set; }

        public decimal Discount { get; set; }

    }
}
