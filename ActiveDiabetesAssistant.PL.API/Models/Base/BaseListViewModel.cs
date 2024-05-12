namespace ActiveDiabetesAssistant.PL.API.Models.Base;

public abstract class BaseListViewModel<TModel>
{
	public IEnumerable<TModel> ModelList { get; set; } = [];
	public int TotalCount { get; set; }
}