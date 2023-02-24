using Microsoft.EntityFrameworkCore;
using sm_backend.Models;
using sm_backend.Repository.Interfaces;

namespace sm_backend.Repository
{
    public class ItemRepository: IItemRepository
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
            _dbContext.Item.Add(item);
            await _dbContext.SaveChangesAsync();
            return item;
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
    }
}
