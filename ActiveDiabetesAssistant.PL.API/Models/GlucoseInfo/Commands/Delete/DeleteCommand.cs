namespace ActiveDiabetesAssistant.PL.API.Models.GlucoseInfo.Commands.Delete;

public class DeleteGlucoseInfoCommand : BaseDeleteCommand
{
	public Guid GlucoseInfoId { get; set; }
}