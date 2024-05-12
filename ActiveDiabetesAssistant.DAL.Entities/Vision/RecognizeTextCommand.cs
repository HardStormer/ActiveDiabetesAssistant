namespace ActiveDiabetesAssistant.DAL.Entities.Vision;

public class RecognizeTextCommand
{
	public string MimeType { get; set; } = null!;
	public List<string> LanguageCodes { get; set; } = [];
	public string Model { get; set; } = null!;
	public string Content { get; set; } = null!;
}