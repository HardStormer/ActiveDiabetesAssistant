using System.Security.Claims;

namespace ActiveDiabetesAssistant.PL.API.Authentication;

/// <summary>
/// Класс ApiUserIdentity представляет идентификацию пользователя в виде утверждений (Claims Identity) для использования в контексте аутентификации в API.
/// </summary>
/// <remarks>
/// Конструктор класса, который принимает объект UserDTO и тип аутентификации (по умолчанию "Default"). Он вызывает базовый конструктор ClaimsIdentity, передавая список утверждений (полученный из метода GetUserClaims) и тип аутентификации. Кроме того, конструктор устанавливает свойство UserData, содержащее данные пользователя.
/// </remarks>
/// <param name="userData"></param>
/// <param name="authenticationType"></param>
public class ApiUserIdentity(UserDto userData, string authenticationType = "Default") : ClaimsIdentity(GetUserClaims(userData), authenticationType)
{
	/// <summary>
	/// Свойство, представляющее объект UserDTO, содержащий данные пользователя, связанные с этой идентификацией.
	/// </summary>
	public UserDto UserData { get; set; } = userData;

	/// <summary>
	/// Внутренний статический метод, который преобразует данные пользователя (UserDTO) в список утверждений (Claims). Если данные пользователя равны null, метод возвращает пустой список утверждений. В противном случае, метод создает утверждение с типом ClaimTypes.Name, содержащее логин пользователя, и возвращает список с этим утверждением.
	/// </summary>
	/// <param name="userData"></param>
	/// <returns></returns>
	private static List<Claim> GetUserClaims(UserDto userData)
	{
		if (userData == null)
		{
			return [];
		}
		var result = new List<Claim>
		{
			new(ClaimTypes.Name, userData.Email!)
		};
		return result;
	}
}