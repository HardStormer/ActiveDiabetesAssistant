using ActiveDiabetesAssistant.PL.API.Models.GlucoseInfo.Commands.Create;
using ActiveDiabetesAssistant.PL.API.Models.GlucoseInfo.Commands.Delete;
using ActiveDiabetesAssistant.PL.API.Models.GlucoseInfo.Commands.Update;
using ActiveDiabetesAssistant.PL.API.Models.GlucoseInfo.Queries;
using ActiveDiabetesAssistant.PL.API.Models.GlucoseInfo.Queries.Get;
using ActiveDiabetesAssistant.PL.API.Models.GlucoseInfo.Queries.GetList;

namespace ActiveDiabetesAssistant.PL.API.Controllers;

public class GlucoseInfoController : BaseController
{
	public GlucoseInfoController()
	{
	}

	/// <summary>
	/// Получить данные о глюкозе
	/// </summary>
	[HttpGet]
	public virtual async Task<ActionResult<GlucoseInfoViewModel>> Get([FromQuery] GetGlucoseInfoQuery query)
	{
		var result = await Mediator.Send(query);
		return Ok(result);
	}

	/// <summary>
	/// Получить данные о глюкозе
	/// </summary>
	[HttpGet]
	public virtual async Task<ActionResult<IEnumerable<GlucoseInfoViewModel>>> GetList([FromQuery] GetGlucoseInfoListQuery query)
	{
		var result = await Mediator.Send(query);
		return Ok(result);
	}

	/// <summary>
	/// Получить данные о глюкозе
	/// </summary>
	[HttpGet]
	public virtual async Task<ActionResult<IEnumerable<GlucoseInfoViewModel>>> GetListByDate([FromQuery] GetGlucoseInfoListByDateQuery query)
	{
		var result = await Mediator.Send(query);
		return Ok(result);
	}

	/// <summary>
	/// Создать данные о глюкозе
	/// </summary>
	[HttpPost]
	public async Task<ActionResult<GlucoseInfoViewModel>> Create(CreateGlucoseInfoCommand createGlucoseInfoCommand)
	{
		var result = await Mediator.Send(createGlucoseInfoCommand);

		return Ok(result);
	}

	/// <summary>
	/// Обновить данные о глюкозе
	/// </summary>
	[HttpPost]
	public async Task<ActionResult> Update(UpdateGlucoseInfoCommand updateGlucoseInfoCommand)
	{
		await Mediator.Send(updateGlucoseInfoCommand);

		return Ok();
	}

	/// <summary>
	/// Удалить данные о глюкозе
	/// </summary>
	[HttpPost]
	public async Task<ActionResult> Delete(DeleteGlucoseInfoCommand deleteGlucoseInfoCommand)
	{
		await Mediator.Send(deleteGlucoseInfoCommand);

		return Ok();
	}
}