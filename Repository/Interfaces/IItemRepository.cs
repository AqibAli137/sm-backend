using sm_backend.Models;

namespace sm_backend.Repository.Interfaces
{
    public interface IItemRepository
    {
        Task<List<Item>> GetAllItemAsync();
        Task<Item> GetItemAsync(int id);
        Task<Item> PostItemAsync(Item item);
        Task<Item> PutItemAsync(Item item);
        Task<MixReturn> StockWithDate(StockWithDate dates);

        Task<Item> StockAddAsync(Item item);

    }
}
