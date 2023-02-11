using System.ComponentModel.DataAnnotations;

namespace sm_backend.Models
{
    public class Invoice
    {
        [Key]
        public int Id { get; set; }
        public int Investment { get; set; }
        public int Sale { get; set; }
        public int Profit { get; set; }
    }
}
