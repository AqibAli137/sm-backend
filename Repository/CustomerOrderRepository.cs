using Microsoft.EntityFrameworkCore;
using sm_backend.Models;
using sm_backend.Repository.Interfaces;

namespace sm_backend.Repository
{
    public class CustomerOrderRepository: ICustomerOrderRepository
    {
        private readonly SmContext _dbContext;

        public CustomerOrderRepository(SmContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<CustomerOrder>> GetAllCustomerOrder()
        {
            return await _dbContext.CustomerOrders.ToListAsync();
        }

        public async Task<CustomerOrder> GetCustomerOrderAsync(int id)
        {
            return await _dbContext.CustomerOrders.Where(s => s.Id == id).FirstOrDefaultAsync();
        }

        public async Task<CustomerOrder> PostCustomerOrderAsync(CustomerOrder oder)
        {
            _dbContext.CustomerOrders.Add(oder);
            await _dbContext.SaveChangesAsync();
            return(oder);
        }

        public async Task<CustomerOrder> PutCustomerOrderAsync(CustomerOrder order)
        {
            var data = _dbContext.CustomerOrders.Where(x => x.Id == order.Id).FirstOrDefault();
            if (data != null)
            {
                data.Yourbill = order.Yourbill;
                data.ItemId = order.ItemId;
                data.CustomerId = order.CustomerId;
                data.ItemName = order.ItemName;
                data.ItemQuantity = order.ItemQuantity;
                data.OrderDate = order.OrderDate = DateTime.Now;
                data.SetPrice = order.SetPrice;
            }
            await _dbContext.SaveChangesAsync();
            return order;
        }
    }
}
    