using System.ComponentModel.DataAnnotations;

namespace sm_backend.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        public string? ItemName { get; set; }
        public decimal CostOfItem { get; set; }
        public decimal RealItemCost { get; set; }

        public int TotalQuantity { get; set; }
        public decimal TotalAmount { get; set; }
        public string? TypeOfItem { get; set; }

    }
}
