namespace ActiveDiabetesAssistant.PL.API.Models.GlucoseInfo.Commands.Update;

public class UpdateGlucoseInfoCommand : BaseUpdateCommand
{
	public Guid GlucoseInfoId { get; set; }
	public int GlucoseData { get; set; }
	public int? StepsCount { get; set; }
}

public class UpdateGlucoseInfoCommandValidator : AbstractValidator<UpdateGlucoseInfoCommand>
{
	public UpdateGlucoseInfoCommandValidator()
	{
	}
}