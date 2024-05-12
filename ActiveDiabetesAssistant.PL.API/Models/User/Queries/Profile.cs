using ActiveDiabetesAssistant.PL.API.Models.User.Commands.Register;

namespace ActiveDiabetesAssistant.PL.API.Models.User.Queries;

public class UserProfile : Profile
{
	public UserProfile()
	{
		CreateMap<
			UserDto,
			UserViewModel>();
		CreateMap<
			RegisterUserCommand,
			UserDto>();
	}
}