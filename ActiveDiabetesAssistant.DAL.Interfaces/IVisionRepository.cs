using ActiveDiabetesAssistant.DAL.Entities.Vision;

namespace ActiveDiabetesAssistant.DAL.Interfaces;

public interface IVisionRepository
{
	public Task<OcrResponse?> RecognizeText(RecognizeTextCommand recognizeTextCommand);
}