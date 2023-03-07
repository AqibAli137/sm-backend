using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sm_backend.Models;
using sm_backend.Repository;
using sm_backend.Repository.Interfaces;

namespace sm_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReturnItemController : ControllerBase
    {
        private readonly IReturnItemRepository _ReturnItemRepository;

        public ReturnItemController(IReturnItemRepository ReturnItemRepository)
        {
            _ReturnItemRepository = ReturnItemRepository;
        }

        [HttpGet]
        public async Task<List<ReturnItem>> GetAllReturnItem()
        {
            return await _ReturnItemRepository.GetAllReturnItem();
        }

        [HttpPost]
        public async Task<IActionResult> PostReturnItem(ReturnItem ReturnItem)
        {
                ReturnItem ordr = await _ReturnItemRepository.PostReturnItemAsync(ReturnItem);

                return Ok(ordr);
            
        }

        [HttpPut]
        public async Task<ReturnItem> PutCustomerOderAsync(ReturnItem ReturnItem)
        {
            return await _ReturnItemRepository.PutReturnItemAsync(ReturnItem);
        }

    }
}
