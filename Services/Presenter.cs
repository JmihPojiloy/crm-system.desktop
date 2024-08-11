using desktop.Data;
using desktop.Models;

namespace desktop.Services
{
    public class Presenter
    {
        private readonly ILeadRepository _leadRepository;
        private readonly string _token;
        public Presenter(string token)
        {
            _token = token;
            _leadRepository = new LeadRepository(_token);
        }

        public async Task<List<LeadModel>> GetAll() => await _leadRepository.GetAllAsync();
        public async Task<LeadModel> GetById(int id) => await _leadRepository.GetByIdAsync(id);
        public async Task<LeadModel> GetByName(string name) => await _leadRepository.GetByNameAsync(name);
        public async Task Update(LeadModel model) => await _leadRepository.UpdateAsync(model);
        public async Task Delete(int id) => await _leadRepository.DeleteAsync(id);
        public async Task Save() => await _leadRepository.SaveAsync();
    }
}
