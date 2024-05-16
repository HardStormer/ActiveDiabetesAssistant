using ActiveDiabetesAssistant.PL.API.Models.User.Commands.Delete;
using ActiveDiabetesAssistant.PL.API.Models.User.Commands.Login;
using ActiveDiabetesAssistant.PL.API.Models.User.Commands.Logout;
using ActiveDiabetesAssistant.PL.API.Models.User.Commands.Register;
using ActiveDiabetesAssistant.PL.API.Models.User.Commands.Update;
using ActiveDiabetesAssistant.PL.API.Models.User.Queries;
using ActiveDiabetesAssistant.PL.API.Models.User.Queries.CheckToken;
using ActiveDiabetesAssistant.PL.API.Models.User.Queries.Get;
using ActiveDiabetesAssistant.PL.API.Models.User.Queries.GetMyProfile;

namespace ActiveDiabetesAssistant.PL.API.Controllers;

public class UserController : BaseController
{
	public UserController()
	{
	}

	[AllowAnonymous]
	[HttpGet]
	public virtual async Task<ActionResult<UserViewModel>> CheckToken([FromQuery] CheckTokenQuery query)
	{
		var result = await Mediator.Send(query);
		return Ok(result);
	}

	/// <summary>
	/// метод предназначен для получения отдельного элемента данных
	/// </summary>
	/// <param name="query">идентификатор типа Guid</param>
	/// <returns></returns>
	[HttpGet]
	public virtual async Task<ActionResult<UserViewModel>> Get([FromQuery] GetUserQuery query)
	{
		var result = await Mediator.Send(query);
		return Ok(result);
	}

	/// <summary>
	/// метод предназначен для получения отдельного элемента данных
	/// </summary>
	/// <param name="query">Ничего</param>
	/// <returns></returns>
	[HttpGet]
	public virtual async Task<ActionResult<UserViewModel>> GetMy([FromQuery] GetMyProfileQuery query)
	{
		var result = await Mediator.Send(query);
		return Ok(result);
	}

	/// <summary>
	/// Авторизация
	/// </summary>
	/// <param name="loginUserCommand"></param>
	/// <returns>Токен</returns>
	[HttpPost]
	[AllowAnonymous]
	public async Task<ActionResult<LoginUserCommandResponce>> LogIn(LoginUserCommand loginUserCommand)
	{
		var result = await Mediator.Send(loginUserCommand);

		return Ok(result);
	}

	/// <summary>
	/// Регистрация
	/// </summary>
	/// <param name="registerUserCommand"></param>
	/// <returns>Токен</returns>
	[HttpPost]
	[AllowAnonymous]
	public async Task<ActionResult<RegisterUserCommandResponce>> Register(RegisterUserCommand registerUserCommand)
	{
		var result = await Mediator.Send(registerUserCommand);

		return Ok(result);
	}

	/// <summary>
	/// Выход
	/// </summary>
	[HttpPost]
	public async Task<IActionResult> LogOut()
	{
		var user = this.GetApiUser();
		if (user == null)
			return BadRequest("Bad token");

		var logoutUserCommand = new LogoutUserCommand
		{
			UserId = user.Id,
		};
		await Mediator.Send(logoutUserCommand);

		return Ok();
	}

	/// <summary>
	/// Редактирование пароля
	/// </summary>
	[HttpPost]
	public async Task<IActionResult> ChangePassword(UpdateUserPasswordCommandRequest updateUserPasswordCommandRequest)
	{
		var user = this.GetApiUser();
		if (user == null)
			return BadRequest("Bad token");

		var updateUserPasswordCommand = new UpdateUserPasswordCommand
		{
			UserId = user.Id,
			OldPassword = updateUserPasswordCommandRequest.OldPassword,
			Password = updateUserPasswordCommandRequest.Password
		};

		await Mediator.Send(updateUserPasswordCommand);

		return Ok();
	}

	/// <summary>
	/// Редактирование почты
	/// </summary>
	[HttpPost]
	public async Task<IActionResult> ChangeEmail(UpdateUserEmailCommandRequest updateUserEmailCommandRequest)
	{
		var user = this.GetApiUser();
		if (user == null)
			return BadRequest("Bad token");

		var updateUserEmailCommand = new UpdateUserEmailCommand
		{
			UserId = user.Id,
			Email = updateUserEmailCommandRequest.Email
		};

		await Mediator.Send(updateUserEmailCommand);

		return Ok();
	}

	/// <summary>
	/// Удалить мой аккаунт
	/// </summary>
	[HttpPost]
	public async Task<IActionResult> DeleteMyAccount()
	{
		var user = this.GetApiUser();
		if (user == null)
			return BadRequest("Bad token");

		var deleteUserCommand = new DeleteUserCommand
		{
			UserId = user.Id
		};

		await Mediator.Send(deleteUserCommand);

		return Ok();
	}
}