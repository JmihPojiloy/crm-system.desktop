using desktop.Models;

namespace desktop.Services
{
    public interface ILeadRepository
    {
        public Task<List<LeadModel>> GetAllAsync();
        public Task<LeadModel> GetByIdAsync(int id);
        public Task<LeadModel> GetByNameAsync(string name);
        public Task UpdateAsync (LeadModel model);
        public Task DeleteAsync(int id);
        public Task SaveAsync();
    }
}
