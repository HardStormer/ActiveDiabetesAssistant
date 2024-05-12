namespace ActiveDiabetesAssistant.PL.API.Models.User.Queries.Get;

public class GetUserQueryHandler(
	IUserRepository service,
	IMapper mapper) : IRequestHandler<GetUserQuery, UserViewModel>
{
	public async Task<UserViewModel> Handle(GetUserQuery request, CancellationToken cancellationToken)
	{
		var entity = await service.GetAsync(request.Id)
			?? throw new NotFoundException(nameof(UserDto), request.Id);

		var model = mapper.Map<UserViewModel>(entity);

		return model;
	}
}