using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sm_backend.Models;
using sm_backend.Repository.Interfaces;

namespace sm_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }


        [HttpGet]
        public async Task<List<Customer>> GetAllCustomer()
        {
            return await _customerRepository.GetAllCustomer();
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<Customer> GetCustomersById(int id)
        {
            return await _customerRepository.GetAllCustomerById(id);
        }

        [HttpPost]
        public async Task<IActionResult> PostCustomerAsync(Customer item)
        {
            Customer itm = await _customerRepository.PostCustomerAsync(item);
            // if (itm == null)
            // {
            //     return BadRequest("No Item Found");
            // }
            return Ok(itm);
        }

        [HttpPut]
        public async Task<Customer> PutCustomerAsync(Customer item)
        {
            return await _customerRepository.PutCustomerAsync(item);
        }


        [HttpPut]
        [Route("PayementRcv")]
        public async Task<Customer> PayementRcvAsync(Customer item)
        {
            return await _customerRepository.PayementRcvAsync(item);
        }

        [HttpGet]
        [Route("Payement")]
        public async Task<List<PayementRecord>> CustomerPayement()
        {
            return await _customerRepository.CustomerPayement();
        }

         [HttpGet]
        [Route("PayementById")]
        public async Task<List<PayementRecord>> CustomerPayementById(int customerId)
        {
            return await _customerRepository.CustomerPayementById(customerId);
        }
    }
}
