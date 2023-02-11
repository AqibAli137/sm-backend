
using Microsoft.EntityFrameworkCore;

namespace sm_backend.Models
{
    public class SmContext : DbContext
    {
        public SmContext(DbContextOptions<SmContext> options):base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerOrder> CustomerOrders { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Item> Items { get; set; }
    }
}
