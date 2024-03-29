﻿using sm_backend.Models;
using Microsoft.EntityFrameworkCore;
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

        public async Task<Customer> GetAllCustomerById(int id)
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
                cust.TotalBill = customer.TotalBill;
                cust.Discount = customer.Discount;
            }
            await _dbContext.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer> PayementRcvAsync(Customer customer)
        {
            var cust = _dbContext.Customer.Where(x => x.Id == customer.Id).FirstOrDefault();
            var totalPay = customer.PaymentRcv + customer.Discount;
            PayementRecord PR = new PayementRecord();
            if (cust != null)
            {
                // cust.Name = customer.Name;
                // cust.Address = customer.Address;
                // cust.PhoneNo = customer.PhoneNo;
                // cust.IsActive = customer.IsActive;
                cust.PaymentRcv += customer.PaymentRcv;
                cust.PendingPayment -= totalPay;
                // cust.TotalBill = customer.TotalBill;
                cust.ProfitFromCustomer -= customer.Discount;
                cust.Discount += customer.Discount;
                PR.CustomerId = cust.Id;
                PR.PayementDate = DateTime.UtcNow.ToString();
                PR.PayementRcv = customer.PaymentRcv;
                PR.Discount = customer.Discount;
                PR.PendingAmount = cust.PendingPayment;

                _dbContext.PayementRecord.Add(PR);
            }
            await _dbContext.SaveChangesAsync();
            return customer;
        }


        public async Task<List<PayementRecord>> CustomerPayement()
        {
            return await _dbContext.PayementRecord.ToListAsync();
        }

        public async Task<List<PayementRecord>> CustomerPayementById(int id)
        {
            return await _dbContext.PayementRecord.Where(x => x.CustomerId == id).ToListAsync();

        }


    }
}
