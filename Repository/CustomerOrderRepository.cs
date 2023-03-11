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
        public async Task<List<ItemProfit>> ItemProfit()
        {
            List<Item> itemRecord = await _dbContext.Item.ToListAsync();

            List<CustomerOrder> customerOrders = await _dbContext.CustomerOrders.ToListAsync();

            List<ItemProfit> Listobj = new List<ItemProfit>();



            foreach (var item in itemRecord)
            {
                ItemProfit obj = new ItemProfit();
                decimal Totalprofit = 0;
                foreach (var order in customerOrders)
                {
                    if (item.Id == order.ItemId)
                    {
                        Totalprofit += order.Profit;
                    }
                    obj.ItemId = item.Id;
                    obj.Profit = Totalprofit;
                }

                Listobj.Add(obj);

            }
            return Listobj;
        }
        public async Task<CustomerOrder> GetCustomerOrderAsync(int id)
        {
            return await _dbContext.CustomerOrders.Where(s => s.Id == id).FirstOrDefaultAsync();
        }


        private string RendomNumber()
        {
            var random = new Random();
            var value = random.Next(1, 999999);
            string startTime = "4/15/1999";
            var againValue = random.Next(4000, 1000000);
            var seconds = (DateTime.Now - DateTime.Parse(startTime)).TotalSeconds;
            var gatePassNumber = Convert.ToInt32(seconds % random.Next(0, 1000)) + value + againValue;
            return gatePassNumber.ToString();
        }

        public async Task<CustomerOrder> NewOrder(int customerId, List<CustomerOrder> orderList)
        {
            string rendomNo = RendomNumber();

            GatePass gatePass = new GatePass();
            gatePass.CustomerId = customerId;
            gatePass.GatePassDate = DateTime.UtcNow.ToString();
            gatePass.GatePassNo = rendomNo;
            _dbContext.GatePass.Add(gatePass);

            foreach (var order in orderList)
            {
                order.GatePassNumber = rendomNo;
                Item itemRecord = await _dbContext.Item.Where(s => s.Id == order.ItemId).FirstOrDefaultAsync();
                Customer customerRecord = await _dbContext.Customer.Where(s => s.Id == order.CustomerId).FirstOrDefaultAsync();

                var realCostOfOrder = itemRecord.RealItemCost * order.ItemQuantity;
                var fakeCostOfOrder = order.ItemQuantity * order.SetPrice;

                var realProfit = fakeCostOfOrder - realCostOfOrder;
                order.ItemName = itemRecord.ItemName;
                //    order.OrderDate=DateTime.UtcNow.ToString();
                order.OrderDate = order.OrderDate;
                // order.Profit = itemRecord.RealItemCost;
                order.Profit = realProfit;

                _dbContext.CustomerOrders.Add(order);

                itemRecord.TotalQuantity = itemRecord.TotalQuantity - order.ItemQuantity;
                itemRecord.TotalAmount = itemRecord.TotalAmount - realCostOfOrder;


                customerRecord.TotalBill += fakeCostOfOrder;
                customerRecord.PendingPayment += fakeCostOfOrder;
                customerRecord.ProfitFromCustomer += realProfit;
            }

            await _dbContext.SaveChangesAsync();
            return orderList[0];
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
