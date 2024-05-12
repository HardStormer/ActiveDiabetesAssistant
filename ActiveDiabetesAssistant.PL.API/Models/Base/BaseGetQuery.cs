namespace ActiveDiabetesAssistant.PL.API.Models.Base;

public abstract class BaseGetQuery<TViewModel> : BaseCommand, IRequest<TViewModel>
	where TViewModel : BaseViewModel
{
	public Guid Id { get; set; }
}