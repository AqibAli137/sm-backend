using sm_backend.Models;

namespace sm_backend.Repository.Interfaces
{
    public interface IInvoiceRepository
    {
        Task<List<Invoice>> GetAllInvoiceAsync();
        Task<Invoice> GetInvoiceAsync(int id);
        Task<Invoice> PostInvoiceAsync(Invoice invoice);
        Task<Invoice> PutInvoiceAsync(Invoice invoice);
    }
}
