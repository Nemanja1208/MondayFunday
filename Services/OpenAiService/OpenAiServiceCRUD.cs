using System.Net.Http.Headers;
using System.Net.Http.Json;
using MondayFunday.Models;
using MondayFunday.Services.Interfaces;

namespace MondayFunday.Services.OpenAiService
{
    public class OpenAiServiceCRUD : IOpenAiInterface
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public OpenAiServiceCRUD(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<ChatResponse> Chat(string message)
        {
            var apiKey = _configuration["OpenAi:ApiKey"];
            if (string.IsNullOrEmpty(apiKey))
            {
                return new ChatResponse
                {
                    Response = "OpenAI API key is not configured. Add it to appsettings.json under OpenAi:ApiKey",
                    Model = "N/A",
                    TokensUsed = 0
                };
            }

            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", apiKey);

            var requestBody = new OpenAiChatRequest
            {
                Model = _configuration["OpenAi:Model"] ?? "gpt-4o-mini",
                Messages = new List<OpenAiMessage>
                {
                    new OpenAiMessage { Role = "user", Content = message }
                }
            };

            var response = await _httpClient.PostAsJsonAsync(
                "https://api.openai.com/v1/chat/completions",
                requestBody);

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<OpenAiChatResponse>();

            return new ChatResponse
            {
                Response = result?.Choices?.FirstOrDefault()?.Message?.Content ?? "No response",
                Model = result?.Model ?? "unknown",
                TokensUsed = result?.Usage?.Total_tokens ?? 0
            };
        }
    }
}
