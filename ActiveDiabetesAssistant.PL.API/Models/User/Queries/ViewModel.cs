namespace ActiveDiabetesAssistant.PL.API.Models.User.Queries;

public class UserViewModel : BaseViewModel
{
	public string Email { get; set; } = string.Empty;
	public string Bio { get; set; } = string.Empty;
}