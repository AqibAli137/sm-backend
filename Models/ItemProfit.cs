using System.ComponentModel.DataAnnotations;

namespace sm_backend.Models
{
    public class ItemProfit
    {

        [Key]
        public int ItemId { get; set; }

        public decimal Profit { get; set; }


    }
}
