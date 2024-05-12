using ActiveDiabetesAssistant.PL.API.Authentication;

namespace ActiveDiabetesAssistant.PL.API.Models.User.Commands.Register;

public class RegisterUserCommandHandler(
	IUserRepository service,
	IMapper mapper,
	IValidator<RegisterUserCommand> validator) : IRequestHandler<RegisterUserCommand, RegisterUserCommandResponce>
{
	public async Task<RegisterUserCommandResponce> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
	{
		await validator.ValidateAndThrowAsync(request, cancellationToken);

		var user = await service.GetAsync(request.Login);

		if (user != null)
			throw new ExpectedException("Login already exists", HttpStatusCode.Forbidden);

		var dto = mapper.Map<UserDto>(request);

		dto.Id = Guid.NewGuid();
		dto.Password = Additional.GetPasswordHash(dto.Password);
		dto.TokenExpiredAt = DateTime.UtcNow.AddDays(1);

		var result = await service.AddAsync(dto);

		var token = result.GetToken();

		var responce = new RegisterUserCommandResponce()
		{
			Token = token
		};

		return responce;
	}
}