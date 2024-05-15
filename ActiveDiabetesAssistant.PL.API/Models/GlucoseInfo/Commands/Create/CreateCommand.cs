using ActiveDiabetesAssistant.PL.API.Models.GlucoseInfo.Queries;

namespace ActiveDiabetesAssistant.PL.API.Models.GlucoseInfo.Commands.Create;

public class CreateGlucoseInfoCommand : BaseCreateCommand<GlucoseInfoViewModel>
{
	public float GlucoseData { get; set; }
	public int? StepsCount { get; set; }
}

public class CreateGlucoseInfoCommandValidator : AbstractValidator<CreateGlucoseInfoCommand>
{
	public CreateGlucoseInfoCommandValidator()
	{
	}
}