
using Microsoft.EntityFrameworkCore;

namespace sm_backend.Models
{
    public class SmContext : DbContext
    {
        public SmContext(DbContextOptions options): base(options)
        {

        }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<CustomerOrder> CustomerOrders { get; set; }
        public DbSet<Invoice> Invoice { get; set; }
        public DbSet<Item> Item { get; set; }
        public DbSet<GatePass> GatePass { get; set; }
        public DbSet<ReturnItem> ReturnItem { get; set; }
        public DbSet<ItemProfit> ItemProfit { get; set; }


    }
}
