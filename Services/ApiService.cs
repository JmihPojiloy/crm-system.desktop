using desktop.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace desktop.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "http://localhost:5124";
        private readonly string _jwtToken;

        public ApiService(string token)
        {
            _jwtToken = token;
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", _jwtToken);
        }

        public async Task<List<LeadModel>> GetLeadsAsync()
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/Lead");
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<LeadModel>>(responseContent);
        }

        public async Task<LeadModel> GetLeadByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/Lead/{id}");
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<LeadModel>(responseContent);
        }

        public async Task UpdateLeadAsync(int id, LeadModel lead)
        {
            var content = new StringContent(JsonSerializer.Serialize(lead), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"{_baseUrl}/Lead/{id}", content);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteLeadAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{_baseUrl}/Lead/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task SaveAsync()
        {
            var response = await _httpClient.PostAsync($"{_baseUrl}/Lead/Save", null);
            response.EnsureSuccessStatusCode();
        }
    }
}
