namespace ActiveDiabetesAssistant.PL.API.Models.Base;

public abstract class BaseCreateCommand<TViewModel> : BaseCommand, IRequest<TViewModel>
	where TViewModel : BaseViewModel
{
}