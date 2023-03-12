using System.ComponentModel.DataAnnotations;

namespace sm_backend.Models
{
    public class MixReturn
    {
        public List<Item> ListItem { get; set; }
        public decimal TotalSale { get; set; }
        public decimal TotalProfit { get; set; }
    }

}