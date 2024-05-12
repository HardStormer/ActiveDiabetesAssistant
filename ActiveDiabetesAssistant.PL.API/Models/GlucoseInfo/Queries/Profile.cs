using ActiveDiabetesAssistant.PL.API.Models.GlucoseInfo.Commands.Create;
using ActiveDiabetesAssistant.PL.API.Models.GlucoseInfo.Commands.Update;

namespace ActiveDiabetesAssistant.PL.API.Models.GlucoseInfo.Queries;

public class GlucoseInfoProfile : Profile
{
	public GlucoseInfoProfile()
	{
		CreateMap<
			GlucoseInfoDto,
			GlucoseInfoViewModel>();
		CreateMap<
			GlucoseInfoViewModel,
			UpdateGlucoseInfoCommand>();
		CreateMap<
			UpdateGlucoseInfoCommand,
			GlucoseInfoDto>();
		CreateMap<
			CreateGlucoseInfoCommand,
			GlucoseInfoDto>();
	}
}