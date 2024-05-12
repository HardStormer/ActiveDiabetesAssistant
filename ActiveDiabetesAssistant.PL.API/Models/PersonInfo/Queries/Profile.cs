using ActiveDiabetesAssistant.PL.API.Models.PersonInfo.Commands.Create;
using ActiveDiabetesAssistant.PL.API.Models.PersonInfo.Commands.Update;

namespace ActiveDiabetesAssistant.PL.API.Models.PersonInfo.Queries;

public class PersonInfoProfile : Profile
{
	public PersonInfoProfile()
	{
		CreateMap<
			PersonInfoDto,
			PersonInfoViewModel>();
		CreateMap<
			PersonInfoViewModel,
			UpdateMyPersonInfoCommand>();
		CreateMap<
			UpdateMyPersonInfoCommand,
			PersonInfoDto>();
		CreateMap<
			CreateMyPersonInfoCommand,
			PersonInfoDto>();
	}
}