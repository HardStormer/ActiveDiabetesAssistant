namespace ActiveDiabetesAssistant.PL.API.Models.GlucoseInfo.Queries;

public class GlucoseInfoViewModel : BaseViewModel
{
	public float GlucoseData { get; set; }
	public int? StepsCount { get; set; }
}