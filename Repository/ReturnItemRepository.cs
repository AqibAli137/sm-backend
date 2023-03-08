using sm_backend.Models;
using Microsoft.EntityFrameworkCore;
using sm_backend.Repository.Interfaces;

namespace sm_backend.Repository
{
    public class ReturnItemRepository : IReturnItemRepository
    {
        private readonly SmContext _dbContext;

        public ReturnItemRepository(SmContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ReturnItem>> GetAllReturnItem()
        {
            return await _dbContext.ReturnItem.ToListAsync();
        }

        public async Task<ReturnItem> GetReturnItemAsync(int id)
        {
            return await _dbContext.ReturnItem.Where(s => s.Id == id).FirstOrDefaultAsync();
        }

        public async Task<ReturnItem> PostReturnItemAsync(ReturnItem returnItem)
        {

            Item itemRecord = await _dbContext.Item.Where(s => s.Id == returnItem.ItemId).FirstOrDefaultAsync();
            Customer customerRecord = await _dbContext.Customer.Where(s => s.Id == returnItem.CustomerId).FirstOrDefaultAsync();

            List<CustomerOrder> allOrders = new List<CustomerOrder>();


            CustomerOrder lastOrder = await _dbContext.CustomerOrders.Where(s => s.CustomerId == returnItem.CustomerId && s.ItemId == returnItem.ItemId).OrderByDescending(c => c.Id).LastOrDefaultAsync();


            var realCostOfOrder = itemRecord.RealItemCost * returnItem.ReturnQuantity;
            // var fakeCostOfOrder = returnItem.ReturnQuantity * itemRecord.RealItemCost;

            //for Customer return price less from his total price
            var customerReturnPrice = returnItem.ReturnQuantity * lastOrder.SetPrice;
            var returnProfitPrice = customerReturnPrice - realCostOfOrder;

            itemRecord.TotalQuantity += returnItem.ReturnQuantity;
            itemRecord.TotalAmount += realCostOfOrder;


            customerRecord.TotalBill -= customerReturnPrice;
            customerRecord.PendingPayment -= customerReturnPrice;
            customerRecord.ProfitFromCustomer -= returnProfitPrice;




            returnItem.ReturnPrice=lastOrder.SetPrice;
            returnItem.TotalAmount=customerReturnPrice;
            
            _dbContext.ReturnItem.Add(returnItem);

            await _dbContext.SaveChangesAsync();
            return (returnItem);
        }

        public async Task<ReturnItem> PutReturnItemAsync(ReturnItem order)
        {
            var data = _dbContext.ReturnItem.Where(x => x.Id == order.Id).FirstOrDefault();
            if (data != null)
            {

            }
            await _dbContext.SaveChangesAsync();
            return order;
        }
    }
}
