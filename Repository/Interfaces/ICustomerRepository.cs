﻿using sm_backend.Models;

namespace sm_backend.Repository.Interfaces
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetAllCustomer();
        Task<Customer> GetCustomerAsync(int id);
        Task<Customer> PostCustomerAsync(Customer item);
        Task<Customer> PutCustomerAsync(Customer item);
    }
}