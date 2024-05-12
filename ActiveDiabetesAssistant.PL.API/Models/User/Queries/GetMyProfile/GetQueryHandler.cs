namespace ActiveDiabetesAssistant.PL.API.Models.User.Queries.GetMyProfile;

public class GetMyProfileQueryHandler(
	IUserRepository service,
	IMapper mapper,
	IHttpContextAccessor contextAccessor) : IRequestHandler<GetMyProfileQuery, UserViewModel>
{
	public async Task<UserViewModel> Handle(GetMyProfileQuery request, CancellationToken cancellationToken)
	{
		var user = contextAccessor.GetApiUser()
			?? throw new NotFoundException(nameof(UserDto), 1);

		var model = mapper.Map<UserViewModel>(user);

		return model;
	}
}