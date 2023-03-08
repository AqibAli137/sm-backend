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
        public decimal ItemQuantity { get; set; }
        public string? OrderDate { get; set; }
        public decimal SetPrice { get; set; }
        public decimal Yourbill { get; set; }
        public string? GatePassNumber { get; set; }
        public decimal Profit { get; set; }
        public DateTime  SecondOrderDate { get; set; }=DateTime.Today;

    }
}
