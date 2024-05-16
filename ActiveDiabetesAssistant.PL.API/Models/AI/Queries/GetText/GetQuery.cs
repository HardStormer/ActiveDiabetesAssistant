namespace ActiveDiabetesAssistant.PL.API.Models.VisionOcr.Queries.GetText;

public class AskAiQuery : IRequest<string>
{
	public string Prompt { get; set; }
}