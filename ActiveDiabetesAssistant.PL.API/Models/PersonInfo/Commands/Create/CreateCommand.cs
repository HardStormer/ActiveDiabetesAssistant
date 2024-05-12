using ActiveDiabetesAssistant.PL.API.Models.PersonInfo.Queries;

namespace ActiveDiabetesAssistant.PL.API.Models.PersonInfo.Commands.Create;

public class CreateMyPersonInfoCommand : BaseCreateCommand<PersonInfoViewModel>
{
	public string Name { get; set; } = null!;
	public int Age { get; set; }
	public Sex Sex { get; set; }
	public DiabetesType DiabetesType { get; set; }
}

public class CreateMyPersonInfoCommandValidator : AbstractValidator<CreateMyPersonInfoCommand>
{
	public CreateMyPersonInfoCommandValidator()
	{
	}
}