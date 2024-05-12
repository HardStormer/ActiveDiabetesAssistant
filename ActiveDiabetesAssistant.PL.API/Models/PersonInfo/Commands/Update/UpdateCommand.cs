namespace ActiveDiabetesAssistant.PL.API.Models.PersonInfo.Commands.Update;

public class UpdateMyPersonInfoCommand : BaseUpdateCommand
{
	public string Name { get; set; } = null!;
	public int Age { get; set; }
	public Sex Sex { get; set; }
	public DiabetesType DiabetesType { get; set; }
}

public class UpdateMyPersonInfoCommandValidator : AbstractValidator<UpdateMyPersonInfoCommand>
{
	public UpdateMyPersonInfoCommandValidator()
	{
	}
}