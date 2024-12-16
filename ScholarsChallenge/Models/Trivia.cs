using System.Text.Json.Serialization;

namespace ScholarsChallenge.Models
{
    public class Trivia
    {
        [JsonPropertyName("response_code")]
        public int? ResponseCode { get; set; }
        [JsonPropertyName("results")]
        public List<Result>? Results { get; set; }
    }
}
