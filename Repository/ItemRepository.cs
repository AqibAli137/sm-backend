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

        public Task<List<Item>> GetAllItemAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Item> GetItemAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Item> PostItemAsync(Item item)
        {
            throw new NotImplementedException();
        }

        public Task<Item> PutItemAsync(Item item)
        {
            throw new NotImplementedException();
        }
    }
}
