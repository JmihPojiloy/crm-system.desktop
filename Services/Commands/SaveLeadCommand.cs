
namespace desktop.Services.Commands
{
    public class SaveLeadCommand : Command
    {
        private readonly ApiService _apiService;

        public SaveLeadCommand(ApiService apiService)
        {
            _apiService = apiService;
        }

        public override async Task ExecuteAsync()
        {
            await _apiService.SaveAsync();
        }
    }
}
