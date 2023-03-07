using sm_backend.Models;

namespace sm_backend.Repository.Interfaces
{
    public interface IReturnItemRepository
    {
        Task<List<ReturnItem>> GetAllReturnItem();
        Task<ReturnItem> GetReturnItemAsync(int id);
        Task<ReturnItem> PostReturnItemAsync(ReturnItem oder);
        Task<ReturnItem> PutReturnItemAsync(ReturnItem order);
    }
}
