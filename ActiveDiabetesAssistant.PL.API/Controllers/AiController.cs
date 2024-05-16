using ActiveDiabetesAssistant.PL.API.Models.VisionOcr.Queries.GetText;

namespace ActiveDiabetesAssistant.PL.API.Controllers;

public class AiController : BaseController
{
	[HttpPost]
	[AllowAnonymous]
	public virtual async Task<ActionResult<string>> Ask([FromForm] AskAiQuery query)
	{
		var result = await Mediator.Send(query);
		return Ok(result);
	}
}