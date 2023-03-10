using sm_backend.Models;

namespace sm_backend.Repository.Interfaces
{
    public interface ICustomerOrderRepository
    {
        Task<List<CustomerOrder>> GetAllCustomerOrder();
        Task<CustomerOrder> GetCustomerOrderAsync(int id);
        Task<CustomerOrder> PostCustomerOrderAsync(CustomerOrder oder);
        Task<CustomerOrder> PutCustomerOrderAsync(CustomerOrder order);
        Task<CustomerOrder> NewOrder(int customerId,List<CustomerOrder> order);


        Task<List<ItemProfit>> ItemProfit();

    }
}
