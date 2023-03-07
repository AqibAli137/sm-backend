using System.ComponentModel.DataAnnotations.Schema;

namespace sm_backend.Models
{
    public class ReturnItem
    {
        public int Id { get; set; }
        [ForeignKey("Item")]
        public int ItemId { get; set; }
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public decimal ReturnQuantity { get; set; }
        public decimal ReturnPrice {get;set;}
        public decimal TotalAmount {get;set;}

        public string? ReturnDate { get; set; }
    }
}
