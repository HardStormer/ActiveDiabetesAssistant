namespace ActiveDiabetesAssistant.PL.API.Models.User.Commands.Logout;

public class LogoutUserCommandHandler(IUserRepository service) :
	IRequestHandler<LogoutUserCommand>
{
	public async Task Handle(LogoutUserCommand request, CancellationToken cancellationToken)
	{
		var user = await service.GetAsync(request.UserId)
			?? throw new NotFoundException(request.UserId.ToString(), request.UserId);

		user.TokenExpiredAt = DateTime.UtcNow;

		await service.EditAsync(user);
	}
}