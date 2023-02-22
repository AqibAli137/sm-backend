using Microsoft.EntityFrameworkCore;
using sm_backend.Models;
using sm_backend.Repository.Interfaces;

namespace sm_backend.Repository
{
    public class GatePassRepository : IGatePassRepository
    {
        private readonly SmContext _dbContext;

        public GatePassRepository(SmContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<GatePass>> GetAllGatePassAsync()
        {
            return await _dbContext.GatePass.ToListAsync();
        }

        public async Task<GatePass> GetGatePassAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<GatePass> PostGatePassAsync(GatePass pass)
        {
            _dbContext.GatePass.Add(pass);
            await _dbContext.SaveChangesAsync();
            return pass;
        }

        public async Task<GatePass> PutGatePassAsync(GatePass pass)
        {
           var pas = _dbContext.GatePass.Where(x => x.Id == pass.Id).FirstOrDefault();
            if (pas != null) 
            { 
                pas.GatePassDate = pass.GatePassDate;
            }
            await _dbContext.SaveChangesAsync();
            return pass;
        }
    }
}
