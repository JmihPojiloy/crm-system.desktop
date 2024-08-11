using desktop.Models;

namespace desktop.Services.Commands
{
    public class GetLeadByIdCommand : Command
    {
        private readonly ApiService _apiService;
        public int LeadId { get; }
        public LeadModel Result { get; private set; }

        public GetLeadByIdCommand(ApiService apiService, int id)
        {
            _apiService = apiService;
            LeadId = id;
        }

        public override async Task ExecuteAsync()
        {
            Result = await _apiService.GetLeadByIdAsync(LeadId);
        }
    }
}
