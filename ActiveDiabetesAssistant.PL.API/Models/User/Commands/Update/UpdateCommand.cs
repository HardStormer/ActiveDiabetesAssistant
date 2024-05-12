namespace ActiveDiabetesAssistant.PL.API.Models.User.Commands.Update;

public class UpdateUserPasswordCommandRequest
{
	public string OldPassword { get; set; } = string.Empty;
	public string Password { get; set; } = string.Empty;
}

public class UpdateUserEmailCommandRequest
{
	public string? Email { get; set; }
}

public class UpdateUserPasswordCommand : BaseCommand,
	IRequest
{
	public Guid UserId { get; set; }
	public string OldPassword { get; set; } = string.Empty;
	public string Password { get; set; } = string.Empty;
}

public class UpdateUserEmailCommand : BaseCommand,
	IRequest
{
	public Guid UserId { get; set; }
	public string? Email { get; set; }
}

public class UpdateUserPasswordCommandValidator : AbstractValidator<UpdateUserPasswordCommand>
{
	private readonly Regex passwordRegex = new Regex(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,}$");

	public UpdateUserPasswordCommandValidator()
	{
		RuleFor(u => u.Password).NotEmpty()
			.WithMessage(
			"Пароль не должен быть пустым"
			);
		RuleFor(u => u.Password).Matches(passwordRegex)
			.WithMessage(
			"Пароль должен содержать хотя-бы одно число, спецсимвол, латинскую букву в верхнем и нижнем регистре и состоять не менее чем из 6 символов."
			);
	}
}

public class UpdateUserEmailCommandValidator : AbstractValidator<UpdateUserEmailCommand>
{
	private readonly Regex emailRegex = new Regex(@"^[A-Za-zА-Яа-яЁё\s'-]{1,50}$");

	public UpdateUserEmailCommandValidator()
	{
		RuleFor(u => u.Email).Matches(emailRegex)
			.WithMessage(
			"Имя должно содержать только буквы (как заглавные, так и строчные) на латинице и кириллице, пробелы, апострофы и дефисы в имени. Длина имени должна быть от 1 до 50 символов."
			);
	}
}