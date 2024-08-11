using desktop.Models;

namespace desktop.Services.Commands
{
    public class GetAllLeadsCommand : Command
    {
        private readonly ApiService _apiService;
        public List<LeadModel> Result { get; private set; }

        public GetAllLeadsCommand(ApiService apiService)
        {
            _apiService = apiService;
            Result = new List<LeadModel>();
        }

        public override async Task ExecuteAsync()
        {
            Result = await _apiService.GetLeadsAsync();
        }
    }
}
