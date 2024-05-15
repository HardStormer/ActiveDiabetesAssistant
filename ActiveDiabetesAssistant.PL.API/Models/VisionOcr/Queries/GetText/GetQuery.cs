namespace ActiveDiabetesAssistant.PL.API.Models.VisionOcr.Queries.GetText;

public class VisionOcrGetTextQuery : IRequest<VisionOcrResponce>
{
	public IFormFile FormFile { get; set; }
}