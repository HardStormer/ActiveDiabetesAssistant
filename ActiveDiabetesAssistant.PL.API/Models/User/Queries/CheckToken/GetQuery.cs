namespace ActiveDiabetesAssistant.PL.API.Models.User.Queries.CheckToken;

public class CheckTokenQuery : IRequest<bool>
{
	public string Token { get; set; }
}