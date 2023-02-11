using Microsoft.EntityFrameworkCore;
using sm_backend.Models;
using sm_backend.Repository.Interfaces;

namespace sm_backend.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly SmContext _dbContext;

        public CustomerRepository(SmContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Customer>> GetAllCustomer()
        {
            return await _dbContext.Customer.ToListAsync();
        }

        public async Task<Customer> GetCustomerAsync(int id)
        {
            return await _dbContext.Customer.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Customer> PostCustomerAsync(Customer customer)
        {
            _dbContext.Customer.Add(customer);
            await _dbContext.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer> PutCustomerAsync(Customer customer)
        {
            var cust = _dbContext.Customer.Where(x => x.Id == customer.Id).FirstOrDefault();
            if (cust != null)
            {
                cust.Name = customer.Name;
                cust.Address = customer.Address;
                cust.PhoneNo = customer.PhoneNo;
                cust.IsActive = customer.IsActive;
                cust.PaymentRcv = customer.PaymentRcv;
                cust.PendingPayment = customer.PendingPayment;
            }
            await _dbContext.SaveChangesAsync();
            return cust;
        }
    }
}
