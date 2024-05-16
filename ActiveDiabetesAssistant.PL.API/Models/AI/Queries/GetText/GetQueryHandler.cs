namespace ActiveDiabetesAssistant.PL.API.Models.VisionOcr.Queries.GetText;

public class AskAiQueryHandler(
	IChatGPTRepository service) :
	IRequestHandler<AskAiQuery, string>
{
	public async Task<string> Handle(AskAiQuery request, CancellationToken cancellationToken)
	{
		var result = await service.GetResponseAsync(request.Prompt);
		return result;
	}
}