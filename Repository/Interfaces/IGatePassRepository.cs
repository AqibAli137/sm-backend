using sm_backend.Models;

namespace sm_backend.Repository.Interfaces
{
    public interface IGatePassRepository
    {
        Task<List<GatePass>> GetAllGatePassAsync();
        Task<GatePass> GetGatePassAsync(int id);
        Task<GatePass> PostGatePassAsync(GatePass pass);
        Task<GatePass> PutGatePassAsync(GatePass pass);
    }
}
