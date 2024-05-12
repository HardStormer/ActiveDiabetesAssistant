namespace ActiveDiabetesAssistant.PL.API.Models.User.Commands.Login;

public class LoginUserCommandHandler(IUserRepository service, IValidator<LoginUserCommand> validator) :
	IRequestHandler<LoginUserCommand, LoginUserCommandResponce>
{
	public async Task<LoginUserCommandResponce> Handle(LoginUserCommand request, CancellationToken cancellationToken)
	{
		await validator.ValidateAndThrowAsync(request, cancellationToken);

		var user = await service.GetAsync(request.Email)
			?? throw new ExpectedException("Wrong login", HttpStatusCode.Forbidden);

		if (user.Password != Additional.GetPasswordHash(request.Password))
			throw new ExpectedException("Wrong password", HttpStatusCode.Forbidden);

		user.TokenExpiredAt = DateTime.UtcNow.AddDays(1);

		await service.EditAsync(user);

		var token = user.GetToken();

		var responce = new LoginUserCommandResponce()
		{
			Token = token,
		};

		return responce;
	}
}