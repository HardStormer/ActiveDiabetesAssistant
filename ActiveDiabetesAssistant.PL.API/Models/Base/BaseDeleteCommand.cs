namespace ActiveDiabetesAssistant.PL.API.Models.Base;

public abstract class BaseDeleteCommand : BaseCommand, IRequest
{
	public bool Soft { get; set; } = false;
}