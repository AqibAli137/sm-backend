using sm_backend.Models;
using Microsoft.AspNetCore.Mvc;
using sm_backend.Repository.Interfaces;

namespace sm_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemRepository _iItemRepository;

        public ItemController(IItemRepository iItemRepository)
        {
            _iItemRepository = iItemRepository;
        }

        [HttpGet]
        public async Task<List<Item>> GetAllItemAsync()
        {
            return await _iItemRepository.GetAllItemAsync();
        }

        [HttpPost]
        public async Task<IActionResult> PostItemAsync(Item item)
        {
            Item itm = await _iItemRepository.PostItemAsync(item);
            if(itm== null) 
            {
                return BadRequest("No Item Found");
            }
            return Ok(itm);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<Item> PutItemAsync(Item item)
        {
            return await _iItemRepository.PutItemAsync(item);
        }

    }
}
