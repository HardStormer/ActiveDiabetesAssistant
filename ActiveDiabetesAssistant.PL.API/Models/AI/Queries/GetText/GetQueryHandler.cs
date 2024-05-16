using ActiveDiabetesAssistant.DAL.Entities.AI;

namespace ActiveDiabetesAssistant.PL.API.Models.VisionOcr.Queries.GetText;

public class AskAiQueryHandler(
	IChatGPTRepository service) :
	IRequestHandler<AskAiQuery, string>
{
	public async Task<string> Handle(AskAiQuery request, CancellationToken cancellationToken)
	{
		var aiRequest = new ChatGptRequest
		{
			Messages =
			[
				new()
				{
					Role = "user",
					Content = request.Prompt
				}
			]
		};
		var result = await service.GetResponseAsync(aiRequest);
		return result.Choices[0].Message.Content;
	}
}