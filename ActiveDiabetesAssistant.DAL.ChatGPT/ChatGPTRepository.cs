using ActiveDiabetesAssistant.DAL.Interfaces;
using Newtonsoft.Json;
using System.Text;

namespace ActiveDiabetesAssistant.DAL.ChatGPT;

public class ChatGPTRepository : IChatGPTRepository
{
	public async Task<string> GetResponseAsync(string prompt)
	{
		using var client = new HttpClient();

		var token = Environment.GetEnvironmentVariable("AI_API_TOKEN");
		var model = Environment.GetEnvironmentVariable("AI_API_MODEL");
		var maxTokens = Environment.GetEnvironmentVariable("AI_API_MAX_TOKENS");
		if (token == null || model == null || maxTokens == null)
		{
			return "AI not configured";
		}
		var requestBody = new
		{
			model = model,
			prompt = prompt,
			max_tokens = int.Parse(maxTokens)
		};

		var jsonRequestBody = JsonConvert.SerializeObject(requestBody);
		var httpContent = new StringContent(jsonRequestBody, Encoding.UTF8, "application/json");

		client.DefaultRequestHeaders.Clear();
		client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

		var response = await client.PostAsync("https://api.openai.com/v1/completions", httpContent);
		response.EnsureSuccessStatusCode();

		var jsonResponse = await response.Content.ReadAsStringAsync();
		var responseObject = JsonConvert.DeserializeObject<dynamic>(jsonResponse);

		return jsonResponse;
		//return responseObject.choices[0].text.ToString();
	}
}