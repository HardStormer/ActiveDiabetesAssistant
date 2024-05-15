using ActiveDiabetesAssistant.DAL.Entities.Vision;

namespace ActiveDiabetesAssistant.PL.API.Models.VisionOcr.Queries.GetText;

public class VisionOcrGetTextQueryHandler(
	IVisionRepository service,
	IMapper mapper) :
	IRequestHandler<VisionOcrGetTextQuery, VisionOcrResponce>
{
	public async Task<VisionOcrResponce> Handle(VisionOcrGetTextQuery request, CancellationToken cancellationToken)
	{
		var content = string.Empty;
		using (var ms = new MemoryStream())
		{
			request.FormFile.CopyTo(ms);
			var fileBytes = ms.ToArray();
			content = Convert.ToBase64String(fileBytes);
		}
		var command = new RecognizeTextCommand
		{
			LanguageCodes = ["ru"],
			Model = "page",
			MimeType = request.FormFile.ContentType,
			Content = content
		};

		var ocrResponse = await service.RecognizeText(command);

		var result = new VisionOcrResponce();

		if (ocrResponse == null)
		{
			return result;
		}
		result.Text = ocrResponse.Result.TextAnnotation.FullText;

		Block? biggestBlock = null;
		Block? mostSquareBlock = null;
		Block? bestBlock = null;
		double maxArea = 0;
		double minSquareDifference = double.MaxValue;
		double bestScore = 0;

		foreach (var block in ocrResponse.Result.TextAnnotation.Blocks)
		{
			var vertices = block.BoundingBox.Vertices;
			int width = vertices[2].X - vertices[0].X;
			int height = vertices[1].Y - vertices[0].Y;
			double area = width * height;
			double squareDifference = Math.Abs(width - height);
			double score = area / (squareDifference + 1);

			if (score > bestScore)
			{
				bestScore = score;
				bestBlock = block;
			}

			if (area > maxArea)
			{
				maxArea = area;
				biggestBlock = block;
			}

			if (squareDifference < minSquareDifference)
			{
				minSquareDifference = squareDifference;
				mostSquareBlock = block;
			}
		}

		if (bestBlock != null)
		{
			result.BestBlock = bestBlock.Lines[0].Text;
		}

		if (biggestBlock != null)
		{
			result.BiggestBlockText = biggestBlock.Lines[0].Text;
		}

		if (mostSquareBlock != null)
		{
			result.MostSquareBlockText = mostSquareBlock.Lines[0].Text;
		}

		return result;
	}
}