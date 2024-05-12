namespace ActiveDiabetesAssistant.PL.API.Models.User.Commands.Register;

public class RegisterUserCommand :
	IRequest<RegisterUserCommandResponce>
{
	public string Email { get; set; } = string.Empty;
	public string Password { get; set; } = string.Empty;
}

public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
{
	private readonly Regex emailRegex = new(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
	private readonly Regex passwordRegex = new(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,}$");

	public RegisterUserCommandValidator()
	{
		RuleFor(u => u.Email).NotEmpty()
			.WithMessage(
			"Логин не должен быть пустым"
			);
		RuleFor(u => u.Password).NotEmpty()
			.WithMessage(
			"Пароль не должен быть пустым"
			);
		RuleFor(u => u.Email).Matches(emailRegex)
			.WithMessage(
			"Почта невалидна"
			);
		RuleFor(u => u.Password).Matches(passwordRegex)
			.WithMessage(
			"Пароль должен содержать хотя-бы одно число, латинскую букву в верхнем и нижнем регистре и состоять не менее чем из 6 символов."
			);
	}
}