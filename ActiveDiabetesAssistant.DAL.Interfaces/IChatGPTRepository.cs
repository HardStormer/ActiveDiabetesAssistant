namespace ActiveDiabetesAssistant.DAL.Interfaces;

public interface IChatGPTRepository
{
	public Task<string> GetResponseAsync(string prompt);
}