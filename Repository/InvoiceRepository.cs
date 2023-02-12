using Microsoft.EntityFrameworkCore;
using sm_backend.Models;
using sm_backend.Repository.Interfaces;

namespace sm_backend.Repository
{
    public class InvoiceRepository: IInvoiceRepository
    {
        private readonly SmContext _dbContext;

        public InvoiceRepository(SmContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Invoice>> GetAllInvoiceAsync()
        {
            return await _dbContext.Invoice.ToListAsync();
        }

        public async Task<Invoice> GetInvoiceAsync(int id)
        {
            return await _dbContext.Invoice.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Invoice> PostInvoiceAsync(Invoice invoice)
        {
            _dbContext.Invoice.Add(invoice);
            await _dbContext.SaveChangesAsync();
            return invoice;
        }

        public async Task<Invoice> PutInvoiceAsync(Invoice invoice)
        {
            var inv = _dbContext.Invoice.Where(x => x.Id == invoice.Id).FirstOrDefault();
            if (inv != null)
            {
                inv.Investment = invoice.Investment;
                inv.Sale = invoice.Sale;
                inv.Profit = invoice.Profit;
            }
            await _dbContext.SaveChangesAsync();
            return invoice;
        }
    }
}
