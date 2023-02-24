using sm_backend.Models;
using Microsoft.EntityFrameworkCore;
using sm_backend.Repository.Interfaces;

namespace sm_backend.Repository
{
    public class CustomerOrderRepository : ICustomerOrderRepository
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


        private string RendomNumber()
        {
             var random = new Random();
            var value = random.Next();
            string startTime = "15/04/1999";
            var againRendom=new Random();
            var againValue= againRendom.Next();
            var seconds = (DateTime.Now - DateTime.Parse(startTime)).TotalSeconds;
            var gatePassNumber = Convert.ToInt32(seconds % 100000000) + value + againValue;
            return gatePassNumber.ToString();
        }

        public async Task<CustomerOrder> NewOrder(List<CustomerOrder> orderList)
        {
          string rendomNo= RendomNumber();

            GatePass gatePass = new GatePass();
            gatePass.GatePassDate = DateTime.UtcNow.ToString();
            gatePass.GatePassNo=rendomNo;
            _dbContext.GatePass.Add(gatePass);

            foreach (var order in orderList)
            {
            order.GatePassNumber=rendomNo;
            _dbContext.CustomerOrders.Add(order);
            }
            await _dbContext.SaveChangesAsync();
           
           
            return orderList[1];

        }

        

        public async Task<CustomerOrder> PostCustomerOrderAsync(CustomerOrder oder)
        {
            _dbContext.CustomerOrders.Add(oder);
            await _dbContext.SaveChangesAsync();
            return (oder);
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
                data.OrderDate = order.OrderDate;
                data.SetPrice = order.SetPrice;
                data.GatePassNumber = order.GatePassNumber;
                data.Profit = order.Profit;
            }
            await _dbContext.SaveChangesAsync();
            return order;
        }
    }
}
