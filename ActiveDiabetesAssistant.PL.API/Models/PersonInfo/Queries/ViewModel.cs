namespace ActiveDiabetesAssistant.PL.API.Models.PersonInfo.Queries;

public class PersonInfoViewModel : BaseViewModel
{
	public string Name { get; set; } = null!;
	public int Age { get; set; }
	public Sex Sex { get; set; }
	public DiabetesType DiabetesType { get; set; }
}