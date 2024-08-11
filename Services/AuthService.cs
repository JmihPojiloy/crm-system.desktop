using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace desktop.Services
{
    public class AuthService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "http://localhost:5124/Auth";

        public AuthService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<string> LiginAsync(string username, string password)
        {
            var loginModel = new
            {
                Username = username,
                Password = password
            };

            var content = new StringContent(JsonSerializer.Serialize(loginModel), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"{_baseUrl}/login", content);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var jsonResponse = JsonSerializer.Deserialize<JsonElement>(responseContent);

                if(jsonResponse.TryGetProperty("token", out var tokenProperty))
                {
                    return tokenProperty.ToString();
                }
            }

            return null;
        }
    }
}
