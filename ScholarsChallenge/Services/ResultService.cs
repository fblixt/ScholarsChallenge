using ScholarsChallenge.Models;
using System.Net;
using System.Net.Http.Json;

namespace ScholarsChallenge.Services
{
    public class ResultService
    {
        private readonly HttpClient _httpClient;
        public ResultService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<Result>> GetResults()
        {
            try
            {
                var url = "https://opentdb.com/api.php?amount=10";
                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var trivia = await response.Content.ReadFromJsonAsync<Trivia>();
                    if (trivia?.Results != null)
                    {
                        foreach (var result in trivia.Results)
                        {
                            result.Question = WebUtility.HtmlDecode(result.Question);
                            result.CorrectAnswer = WebUtility.HtmlDecode(result.CorrectAnswer);

                            if (result.IncorrectAnswers != null)
                            {
                                for (int i = 0; i < result.IncorrectAnswers.Count; i++)
                                {
                                    result.IncorrectAnswers[i] = WebUtility.HtmlDecode(result.IncorrectAnswers[i]);
                                }
                            }
                        }
                    }

                    return trivia?.Results ?? [];
                }
                else
                {
                    Console.WriteLine($"API returned an error: {response.StatusCode}");
                    return [];
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Request error: {ex.Message}");
                return [];
            }
        }
    }
}
