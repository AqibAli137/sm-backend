using System.Configuration;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using sm_backend.Models;
using sm_backend.Repository.Interfaces;


namespace sm_backend.Repository
{
    public class ItemRepository : IItemRepository
    {
        private readonly SmContext _dbContext;
        public ItemRepository(SmContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<List<Item>> GetAllItemAsync()
        {
            return await _dbContext.Item.ToListAsync();
        }

        public async Task<Item> GetItemAsync(int id)
        {
            return await _dbContext.Item.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Item> PostItemAsync(Item item)
        {
            var ItemTotalCost = item.CostOfItem * item.TotalQuantity;
            item.TotalAmount = ItemTotalCost;
            _dbContext.Item.Add(item);
            await _dbContext.SaveChangesAsync();
            return item;
        }

        public async Task<List<Item>> StockWithDate(StockWithDate dates)
        {

            List<CustomerOrder> orders = await _dbContext.CustomerOrders.ToListAsync();
            List<Item> items = await _dbContext.Item.ToListAsync();
            List<Item> ItemList = new List<Item>();
            List<CustomerOrder> co = new List<CustomerOrder>();

            DateTime startAt = DateTime.Parse(dates.DateFrom);
            DateTime endAt = DateTime.Parse(dates.DateTo);


            List<CustomerOrder> filteredList = orders.Where(obj => obj.SecondOrderDate >= startAt && obj.SecondOrderDate < endAt).ToList();



            foreach (var item in items)
            {
                decimal quantity = 0;
                decimal sale = 0;
                decimal profit = 0;
                // decimal avgPriceSet = 0;

                Item itemObj = new Item();
                foreach (var order in filteredList)
                {
                    if (order.ItemId == item.Id)
                    {
                        quantity += order.ItemQuantity;
                        sale += order.Yourbill;
                        // sale += order.SetPrice;
                        profit += order.Profit;
                    }
                }

                itemObj.ItemName = item.ItemName;
                itemObj.TotalAmount = sale;
                itemObj.TotalQuantity = quantity;
                itemObj.TypeOfItem = item.TypeOfItem;
                itemObj.CostOfItem = profit;

                ItemList.Add(itemObj);
            }

            return ItemList;

        }

        public async Task<Item> PutItemAsync(Item item)
        {
            var existingItem = _dbContext.Item.Where(x => x.Id == item.Id).FirstOrDefault();

            if (existingItem != null)
            {
                item.ItemName = item.ItemName;
                item.CostOfItem = item.CostOfItem;
                item.TotalQuantity += item.TotalQuantity;
                item.TotalAmount += item.TotalAmount;
                item.TypeOfItem = existingItem.TypeOfItem;
                _dbContext.Item.Add(item);
            }
            await _dbContext.SaveChangesAsync();
            return existingItem;
        }
        public async Task<Item> StockAddAsync(Item item)
        {
            var existingItem = await _dbContext.Item.FirstOrDefaultAsync(x => x.Id == item.Id);

            if (existingItem != null)
            {
                var newStockAmount = item.CostOfItem * item.TotalQuantity;

                var amount = existingItem.TotalAmount + newStockAmount;
                var quantity = item.TotalQuantity + existingItem.TotalQuantity;

                existingItem.ItemName = existingItem.ItemName;
                existingItem.CostOfItem = item.CostOfItem;
                existingItem.RealItemCost = amount / quantity;
                existingItem.TotalQuantity += item.TotalQuantity;
                existingItem.TotalAmount += newStockAmount;
                existingItem.TypeOfItem = existingItem.TypeOfItem;
                // _dbContext.Item.Add(item);
                await _dbContext.SaveChangesAsync();
            }
            return existingItem;
        }
    }
}
