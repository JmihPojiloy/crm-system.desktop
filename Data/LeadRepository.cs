using desktop.Models;
using desktop.Services;
using desktop.Services.Commands;

namespace desktop.Data
{
    public class LeadRepository : ILeadRepository
    {
        private readonly ApiService _apiService;
        private readonly string _token;
        public LeadRepository(string token)
        {
            _token = token;
            _apiService = new ApiService(_token);
        }

        public async Task<List<LeadModel>> GetAllAsync()
        {
            var getAllCommand = new GetAllLeadsCommand(_apiService);
            await getAllCommand.ExecuteAsync();

            List<LeadModel> leadModels = [.. getAllCommand.Result];

            return leadModels;
        }

        public async Task<LeadModel> GetByIdAsync(int id)
        {
            var getByIdCommand = new GetLeadByIdCommand(_apiService, id);
            await getByIdCommand.ExecuteAsync();

            var lead = getByIdCommand.Result;
            if(lead == null) throw new ArgumentNullException(nameof(lead));

            return lead;
        }

        public async Task DeleteAsync(int id)
        {
            var deleteCommand = new DeleteLeadCommand(_apiService, id);
            await deleteCommand.ExecuteAsync();
        }

        public async Task UpdateAsync(LeadModel model)
        {
            var updateCommand = new UpdateLeadCommand(_apiService, model);
            await updateCommand.ExecuteAsync();
        }

        public async Task SaveAsync()
        {
            var saveCommand = new SaveLeadCommand(_apiService);
            await saveCommand.ExecuteAsync();
        }

        public Task<LeadModel> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }
    }
}
