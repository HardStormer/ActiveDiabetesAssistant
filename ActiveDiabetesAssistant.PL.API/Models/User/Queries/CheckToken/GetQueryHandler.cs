namespace ActiveDiabetesAssistant.PL.API.Models.User.Queries.CheckToken;

public class CheckTokenQueryHandler() : IRequestHandler<CheckTokenQuery, bool>
{
	public async Task<bool> Handle(CheckTokenQuery request, CancellationToken cancellationToken)
	{
		var result = TokenProcessor.GetUserLogin(request.Token);

		return result != null;
	}
}