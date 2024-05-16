using ActiveDiabetesAssistant.DAL.Entities.AI;
using ActiveDiabetesAssistant.DAL.Interfaces;
using Newtonsoft.Json;
using System.Text;

namespace ActiveDiabetesAssistant.DAL.ChatGPT;

public class ChatGPTRepository : IChatGPTRepository
{
	public async Task<ChatGptResponse> GetResponseAsync(ChatGptRequest request)
	{
		using var client = new HttpClient();

		var token = Environment.GetEnvironmentVariable("AI_API_TOKEN");
		var maxTokens = Environment.GetEnvironmentVariable("AI_API_MAX_TOKENS");
		if (token == null || maxTokens == null)
		{
			throw new ArgumentNullException(nameof(token));
		}
		var jsonRequestBody = JsonConvert.SerializeObject(request);
		var httpContent = new StringContent(jsonRequestBody, Encoding.UTF8, "application/json");

		client.DefaultRequestHeaders.Clear();
		client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

		var response = await client.PostAsync("https://api.openai.com/v1/chat/completions", httpContent);
		response.EnsureSuccessStatusCode();

		var jsonResponse = await response.Content.ReadAsStringAsync();

		var responce = JsonConvert.DeserializeObject<ChatGptResponse>(jsonResponse);

		return responce ?? throw new Exception("No ai response");
	}
}