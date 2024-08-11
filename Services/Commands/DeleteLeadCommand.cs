
namespace desktop.Services.Commands
{
    public class DeleteLeadCommand : Command
    {
        private readonly ApiService _apiService;
        public int LeadId { get; }

        public DeleteLeadCommand(ApiService apiService, int leadId)
        {
            _apiService = apiService;
            LeadId = leadId;
        }

        public override async Task ExecuteAsync()
        {
            await _apiService.DeleteLeadAsync(LeadId);
        }
    }
}
