namespace ActiveDiabetesAssistant.DAL.Entities.Wrappers;

public class BasicWrapper<TEnumerable>(TEnumerable? items, int totalCount)
	where TEnumerable : class, IEnumerable
{
	public TEnumerable? Items { get; set; } = items;

	public int TotalCount { get; set; } = totalCount;
}