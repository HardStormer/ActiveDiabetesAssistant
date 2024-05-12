namespace ActiveDiabetesAssistant.PL.API.Models.GlucoseInfo.Queries.GetList;

public class GetGlucoseInfoListByDateQuery : BaseGetListQuery<GlucoseInfoListViewModel, GlucoseInfoViewModel>
{
	public DateTime DateTime { get; set; }
}