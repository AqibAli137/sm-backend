﻿using Microsoft.EntityFrameworkCore;
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
            var ItemTotalCost=item.CostOfItem * item.TotalQuantity;
            item.TotalAmount= ItemTotalCost;
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
        public async Task<Item> StockAddAsync(Item item)
        {
            var existingItem =await _dbContext.Item.FirstOrDefaultAsync(x => x.Id == item.Id);

            if (existingItem != null)
            {
                var newStockAmount= item.CostOfItem * item.TotalQuantity;

                var amount=existingItem.TotalAmount + newStockAmount;
                var quantity=item.TotalQuantity + existingItem.TotalQuantity;

                existingItem.ItemName = existingItem.ItemName;
                existingItem.CostOfItem = item.CostOfItem;
                existingItem.RealItemCost = amount/quantity;
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
