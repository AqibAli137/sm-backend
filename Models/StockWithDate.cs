using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sm_backend.Models
{
    public class StockWithDate
    {
        [Key]
        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }
    }
}
