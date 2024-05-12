using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace ActiveDiabetesAssistant.PL.API.Authentication;

/// <summary>
/// Класс DefaultApiAuthenticationHandler является реализацией обработчика аутентификации для аутентификации по умолчанию в API.
/// </summary>
/// <remarks>
/// Конструктор класса, который принимает различные зависимости, необходимые для обработки аутентификации. Включает IUserRepository для доступа к хранилищу пользователей, IOptionsMonitor для получения параметров аутентификации, ILoggerFactory для логирования, UrlEncoder для кодирования URL, ISystemClock для доступа к текущему времени, и IOptions для получения настроек сериализатора JSON.
/// </remarks>
/// <param name="userRepo"></param>
/// <param name="options"></param>
/// <param name="logger"></param>
/// <param name="encoder"></param>
/// <param name="clock"></param>
/// <param name="serializerOptions"></param>
public class DefaultApiAuthenticationHandler(
	IUserRepository userRepo,
	IOptionsMonitor<DefaultApiAuthenticationOptions> options,
	ILoggerFactory logger,
	UrlEncoder encoder,
	ISystemClock clock,
	IOptions<JsonOptions> serializerOptions) : AuthenticationHandler<DefaultApiAuthenticationOptions>(options, logger, encoder, clock)
{
	private readonly JsonSerializerOptions serializerSettings = serializerOptions.Value.JsonSerializerOptions;

	/// <summary>
	/// Переопределенный метод, который выполняет аутентификацию пользователя на основе предоставленного токена аутентификации. Метод извлекает токен из заголовка "Authorization" запроса, проверяет его корректность и связывает его с соответствующим пользователем в хранилище пользователей. Если аутентификация проходит успешно, метод возвращает результат аутентификации с объектом ClaimsPrincipal, представляющим пользователя, и схемой аутентификации по умолчанию.
	/// </summary>
	/// <returns></returns>
	protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
	{
		string? token = null;
		if (Request.Headers.TryGetValue("Authorization", out Microsoft.Extensions.Primitives.StringValues value))
		{
			token = value.ToString();
			if (token.StartsWith("Bearer "))
			{
				token = token.Substring(7);
			}
		}
		if (token == null)
		{
			return AuthenticateResult.NoResult();
		}
		var login = TokenProcessor.GetUserLogin(token)!;

		var user = await userRepo.GetAsync(login!);
		if (user == null)
		{
			return AuthenticateResult.Fail("Incorrect token");
		}

		if (user.TokenExpiredAt < DateTime.UtcNow)
		{
			return AuthenticateResult.Fail("Token expired");
		}
		return AuthenticateResult.Success(new AuthenticationTicket(new ClaimsPrincipal(new ApiUserIdentity(user)),
			DefaultApiAuthenticationOptions.DefaultScheme));
	}

	/// <summary>
	/// Переопределенный метод, который обрабатывает ситуацию вызова вызова аутентификации, когда требуется аутентификация пользователя. В данном случае, метод вызывает метод HandleForbiddenAsync, чтобы вернуть ошибку 401 Unauthorized.
	/// </summary>
	/// <param name="properties"></param>
	/// <returns></returns>
	protected override Task HandleChallengeAsync(AuthenticationProperties properties)
	{
		return HandleForbiddenAsync(properties);
	}

	/// <summary>
	/// Переопределенный метод, который обрабатывает ситуацию, когда доступ к ресурсу запрещен из-за отсутствия аутентификации или недостаточных прав. Метод устанавливает статус кода ответа 401 Unauthorized и возвращает пустой JSON-ответ.
	/// </summary>
	/// <param name="properties"></param>
	/// <returns></returns>
	protected override async Task HandleForbiddenAsync(AuthenticationProperties properties)
	{
		Response.StatusCode = 401;
		await Response.WriteAsync(JsonConvert.SerializeObject(null));
	}
}