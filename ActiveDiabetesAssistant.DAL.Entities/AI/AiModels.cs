using Newtonsoft.Json;

namespace ActiveDiabetesAssistant.DAL.Entities.AI;

public class ChatGptRequest
{
	[JsonProperty("model")]
	public string Model { get; set; } = Environment.GetEnvironmentVariable("AI_API_MODEL") ?? string.Empty;

	[JsonProperty("messages")]
	public List<ChatGptMessage> Messages { get; set; } = [];
}

public class ChatGptMessage
{
	[JsonProperty("role")]
	public string Role { get; set; }

	[JsonProperty("content")]
	public string Content { get; set; }
}

public class ChatGptResponse
{
	[JsonProperty("choices")]
	public List<ChatGptChoice> Choices { get; set; } = [];
}

public class ChatGptChoice
{
	[JsonProperty("message")]
	public ChatGptMessage Message { get; set; }
}