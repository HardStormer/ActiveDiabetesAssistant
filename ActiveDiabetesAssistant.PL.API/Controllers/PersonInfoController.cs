using ActiveDiabetesAssistant.PL.API.Models.PersonInfo.Commands.Create;
using ActiveDiabetesAssistant.PL.API.Models.PersonInfo.Commands.Delete;
using ActiveDiabetesAssistant.PL.API.Models.PersonInfo.Commands.Update;
using ActiveDiabetesAssistant.PL.API.Models.PersonInfo.Queries;
using ActiveDiabetesAssistant.PL.API.Models.PersonInfo.Queries.Get;

namespace ActiveDiabetesAssistant.PL.API.Controllers;

public class PersonInfoController : BaseController
{
	public PersonInfoController()
	{
	}

	/// <summary>
	/// Получить данные персоны
	/// </summary>
	[HttpGet]
	public virtual async Task<ActionResult<PersonInfoViewModel>> GetMy([FromQuery] GetMyPersonInfoQuery query)
	{
		var result = await Mediator.Send(query);
		return Ok(result);
	}

	/// <summary>
	/// Создать данные персоны
	/// </summary>
	[HttpPost]
	public async Task<ActionResult<PersonInfoViewModel>> Create(CreateMyPersonInfoCommand createPersonInfoCommand)
	{
		var result = await Mediator.Send(createPersonInfoCommand);

		return Ok(result);
	}

	/// <summary>
	/// Обновить данные персоны
	/// </summary>
	[HttpPost]
	public async Task<ActionResult> Update(UpdateMyPersonInfoCommand updatePersonInfoCommand)
	{
		await Mediator.Send(updatePersonInfoCommand);

		return Ok();
	}

	/// <summary>
	/// Удалить данные персоны
	/// </summary>
	[HttpPost]
	public async Task<ActionResult> Delete(DeleteMyPersonInfoCommand deletePersonInfoCommand)
	{
		await Mediator.Send(deletePersonInfoCommand);

		return Ok();
	}
}