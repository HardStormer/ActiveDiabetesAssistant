namespace ActiveDiabetesAssistant.PL.API.Models.VisionOcr.Queries.GetText;

public class VisionOcrResponce
{
	public string Text { get; set; } = string.Empty;
	public string BestBlock { get; set; } = string.Empty;
	public string BiggestBlockText { get; set; } = string.Empty;
	public string MostSquareBlockText { get; set; } = string.Empty;
}