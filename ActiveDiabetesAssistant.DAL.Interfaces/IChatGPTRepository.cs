using ActiveDiabetesAssistant.DAL.Entities.AI;

namespace ActiveDiabetesAssistant.DAL.Interfaces;

public interface IChatGPTRepository
{
	public Task<ChatGptResponse> GetResponseAsync(ChatGptRequest prompt);
}