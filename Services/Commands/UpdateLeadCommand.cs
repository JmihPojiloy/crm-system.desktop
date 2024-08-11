using desktop.Models;

namespace desktop.Services.Commands
{
    public class UpdateLeadCommand : Command
    {
        private readonly ApiService _apiService;
        public LeadModel Lead { get; }

        public UpdateLeadCommand(ApiService apiService, LeadModel lead)
        {
            _apiService = apiService;
            Lead = lead;
        }

        public override async Task ExecuteAsync()
        {
            await _apiService.UpdateLeadAsync(Lead.Id, Lead);
        }
    }
}
