using ActiveDiabetesAssistant.PL.API.Models.User.Queries;
using ActiveDiabetesAssistant.PL.API.Models.VisionOcr.Queries.GetText;

namespace ActiveDiabetesAssistant.PL.API.Controllers;

public class VisionOcrController : BaseController
{
	/// <summary>
	/// определить текст в файле
	/// </summary>
	[HttpPost]
	[AllowAnonymous]
	public virtual async Task<ActionResult<UserViewModel>> RecognizeText([FromForm] VisionOcrGetTextQuery query)
	{
		var result = await Mediator.Send(query);
		return Ok(result);
	}
}