using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sm_backend.Models
{
    public class GatePass
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public string? GatePassDate { get; set; }
        public string? GatePassNo { get; set; }

    }
}
