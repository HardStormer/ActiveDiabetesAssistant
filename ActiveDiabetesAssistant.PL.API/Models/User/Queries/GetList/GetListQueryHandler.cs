namespace ActiveDiabetesAssistant.PL.API.Models.User.Queries.GetList;

public class GetUserQueryListHandler(
	IUserRepository service,
	IMapper mapper) :
	IRequestHandler<GetUserListQuery, UserListViewModel>
{
	public async Task<UserListViewModel> Handle(GetUserListQuery request, CancellationToken cancellationToken)
	{
		int limit = request.Limit;
		int offset = request.Offset;
		Expression<Func<UserDto, bool>>? filter = null;
		IEnumerable<string> includeProperties = [];

		var wrapper = await service.GetAsync(limit, offset, filter, includeProperties);

		var entities = wrapper.Items;

		var models = mapper.Map<IEnumerable<UserViewModel>>(entities);

		var listView = new UserListViewModel
		{
			ModelList = models,
			TotalCount = wrapper.TotalCount
		};

		return listView;
	}
}