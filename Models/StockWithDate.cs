using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sm_backend.Models
{
    public class StockWithDate
    {
        [Key]
        public string DateFrom { get; set; }

        public string DateTo { get; set; }
    }
}
