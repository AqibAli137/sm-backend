using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sm_backend.Models;
using sm_backend.Repository;
using sm_backend.Repository.Interfaces;

namespace sm_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceRepository _invoiceRepository;

        public InvoiceController(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        [HttpGet]
        public async Task<List<Invoice>> GetAllInvoiceAsync()
        {
            return await _invoiceRepository.GetAllInvoiceAsync();
        }

        [HttpPost]
        public async Task<IActionResult> PostInvoiceAsync(Invoice invoice)
        {
            Invoice inv = await _invoiceRepository.PostInvoiceAsync(invoice);
            if (inv == null)
            {
                return BadRequest("No Invoice Found");
            }
            return Ok(inv);
        }

        [HttpPut]
        public async Task<Invoice> PutInvoiceAsync(Invoice invoice)
        {
            return await _invoiceRepository.PutInvoiceAsync(invoice);
        }
    }
}
