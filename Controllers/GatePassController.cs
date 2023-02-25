using sm_backend.Models;
using Microsoft.AspNetCore.Mvc;
using sm_backend.Repository.Interfaces;
using sm_backend.Repository;

namespace sm_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GatePassController : ControllerBase
    {
        private readonly IGatePassRepository _gatePassRepository;

        public GatePassController(IGatePassRepository gatePassRepository)
        {
            _gatePassRepository = gatePassRepository;
        }

        [HttpGet]
        public async Task<List<GatePass>> GetAllGatePassAsync()
        {
            return await _gatePassRepository.GetAllGatePassAsync();
        }

        [HttpPost]
        public async Task<IActionResult> PostGatePassAsync(GatePass pass)
        {
            GatePass pas = await _gatePassRepository.PostGatePassAsync(pass);
            if (pas == null)
            {
                return BadRequest("No GatePass Found");
            }
            return Ok(pas);
        }

        [HttpPut]
        public async Task<GatePass> PutGatePassAsync(GatePass pass)
        {
            return await _gatePassRepository.PutGatePassAsync(pass);
        }
    }
}
