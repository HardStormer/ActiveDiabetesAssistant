namespace ActiveDiabetesAssistant.PL.API.Models.User.Commands.Update;

public class UpdateUserCommandHandler(
	IUserRepository service,
	IValidator<UpdateUserPasswordCommand> validatorPassword,
	IValidator<UpdateUserNameCommand> validatorLogin) :
	IRequestHandler<UpdateUserPasswordCommand>,
	IRequestHandler<UpdateUserNameCommand>
{
	public async Task Handle(UpdateUserPasswordCommand request, CancellationToken cancellationToken)
	{
		await validatorPassword.ValidateAndThrowAsync(request, cancellationToken);

		var user = await service.GetAsync(request.UserId) ?? throw new NotFoundException(request.UserId.ToString(), request.UserId);

		if (user.Password != Additional.GetPasswordHash(request.OldPassword))
			throw new ExpectedException("Wrong password", HttpStatusCode.Forbidden);

		user.Password = Additional.GetPasswordHash(request.Password);

		await service.EditAsync(user);
	}

	public async Task Handle(UpdateUserNameCommand request, CancellationToken cancellationToken)
	{
		await validatorLogin.ValidateAndThrowAsync(request, cancellationToken);

		var user = await service.GetAsync(request.UserId)
			?? throw new NotFoundException(request.UserId.ToString(), request.UserId);

		user.Name = request.Name;

		await service.EditAsync(user);
	}
}