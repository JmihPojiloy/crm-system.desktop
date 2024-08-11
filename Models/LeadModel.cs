
using System.Text.Json.Serialization;

namespace desktop.Models
{
    public class LeadModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("date")]
        public DateTime Date { get; set; }
        [JsonPropertyName("clientName")]
        public string? ClientName { get; set; }
        [JsonPropertyName("clientQuestion")]
        public string? ClientQuestion { get; set; }
        [JsonPropertyName("contact")]
        public string? Contact { get; set; }
        [JsonPropertyName("status")]
        public Status Status { get; set; }
    }
}
