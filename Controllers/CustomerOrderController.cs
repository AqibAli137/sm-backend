﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sm_backend.Models;
using sm_backend.Repository;
using sm_backend.Repository.Interfaces;

namespace sm_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerOrderController : ControllerBase
    {
        private readonly ICustomerOrderRepository _customerOrderRepository;

        public CustomerOrderController(ICustomerOrderRepository customerOrderRepository)
        {
            _customerOrderRepository = customerOrderRepository;
        }

        [HttpGet]
        public async Task<List<CustomerOrder>> GetAllCustomerOrder()
        {
            return await _customerOrderRepository.GetAllCustomerOrder();
        }

        [HttpPost]
        public async Task<IActionResult> PostCustomerOrder(CustomerOrder order)
            {
            try
            {
                 CustomerOrder ordr = await _customerOrderRepository.PostCustomerOrderAsync(order);

                 return Ok(ordr);
            }
            catch(System.Exception)
            {
                return BadRequest("Customer Order Not Found");
            }
        }

        // [HttpPut]
        // public async Task<CustomerOrder> PutCustomerOderAsync(CustomerOrder order)
        // {
        //     return await _customerOrderRepository.PutCustomerOrderAsync(order);
        // }


        [HttpPost]
        [Route("NewOrder/{customerId:int}")]
        public async Task<CustomerOrder> NewOrder(int customerId, List<CustomerOrder> order)
        {
            return await _customerOrderRepository.NewOrder(customerId,order);
        }


        [HttpGet]
        [Route("ItemProfit")]
        public async Task<List<ItemProfit>> ItemProfit()
        {
            return await _customerOrderRepository.ItemProfit();
        }
    }
}
