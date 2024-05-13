using ActiveDiabetesAssistant.DAL.Entities.Vision;
using ActiveDiabetesAssistant.DAL.Interfaces;

namespace ActiveDiabetesAssistant.DAL.VisionOCR;

public class VisionRepository : IVisionRepository
{
	public async Task RecognizeText(RecognizeTextCommand recognizeTextCommand)
	{
		using var client = new HttpClient();

		Uri baseUri = new(@"https://ocr.api.cloud.yandex.net");

		client.BaseAddress = baseUri;

		client.DefaultRequestHeaders.Add("Authorization", "");

		var responce = client.PostAsync(@"/ocr/v1/recognizeTextAsync", null);
	}
}