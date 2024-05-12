namespace ActiveDiabetesAssistant.PL.API.Models.User.Commands.Logout;

public class LogoutUserCommand :
	IRequest
{
	public Guid UserId { get; set; }
}