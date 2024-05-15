using ActiveDiabetesAssistant.DAL.Entities.Vision;
using ActiveDiabetesAssistant.DAL.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ActiveDiabetesAssistant.DAL.VisionOCR;

public class VisionRepository : IVisionRepository
{
	public async Task<OcrResponse?> RecognizeText(RecognizeTextCommand recognizeTextCommand)
	{
		using var client = new HttpClient();

		var token = Environment.GetEnvironmentVariable("VISION_API_TOKEN");

		var folderId = Environment.GetEnvironmentVariable("VISION_API_FOLDER_ID");

		Uri baseUri = new(@"https://ocr.api.cloud.yandex.net");

		client.BaseAddress = baseUri;

		client.DefaultRequestHeaders.Add("authorization", $"Bearer {token}");
		client.DefaultRequestHeaders.Add("x-folder-id", folderId);

		DefaultContractResolver contractResolver = new()
		{
			NamingStrategy = new CamelCaseNamingStrategy()
		};

		var json = JsonConvert.SerializeObject(recognizeTextCommand, new JsonSerializerSettings()
		{
			ContractResolver = contractResolver
		});
		var content = new StringContent(json);

		var responce = await client.PostAsync(@"/ocr/v1/recognizeText", content);

		var resultContent = await responce.Content.ReadAsStringAsync();

		var ocrResponse = JsonConvert.DeserializeObject<OcrResponse>(resultContent);

		return ocrResponse;
	}
}