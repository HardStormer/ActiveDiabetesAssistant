namespace ActiveDiabetesAssistant.PL.API.Models.GlucoseInfo.Queries.GetList;

public class GetMessageQueryListHandler(
	IGlucoseInfoRepository service,
	IPersonInfoRepository personService,
	IMapper mapper,
	IHttpContextAccessor contextAccessor) :
	IRequestHandler<GetGlucoseInfoListQuery, GlucoseInfoListViewModel>,
	IRequestHandler<GetGlucoseInfoListByDateQuery, GlucoseInfoListViewModel>
{
	public async Task<GlucoseInfoListViewModel> Handle(GetGlucoseInfoListQuery request, CancellationToken cancellationToken)
	{
		var userId = contextAccessor.GetApiUserId()
			?? throw new ExpectedException("User not found", HttpStatusCode.Forbidden);

		var currentPersonId = await personService.GetPersonId(userId)
			?? throw new ExpectedException("Person data not filled", HttpStatusCode.NotFound);

		var limit = request.Limit;
		var offset = request.Offset;
		Expression<Func<GlucoseInfoDto, bool>>? filter = x => x.PersonInfoId == currentPersonId;
		IEnumerable<string> includeProperties = [];

		var wrapper = await service.GetAsync(limit, offset, filter, includeProperties);

		var entities = wrapper.Items;

		var models = mapper.Map<IEnumerable<GlucoseInfoViewModel>>(entities);

		var listView = new GlucoseInfoListViewModel
		{
			ModelList = models,
			TotalCount = wrapper.TotalCount
		};

		return listView;
	}

	public async Task<GlucoseInfoListViewModel> Handle(GetGlucoseInfoListByDateQuery request, CancellationToken cancellationToken)
	{
		var userId = contextAccessor.GetApiUserId()
			?? throw new ExpectedException("User not found", HttpStatusCode.Forbidden);

		var currentPersonId = await personService.GetPersonId(userId)
			?? throw new ExpectedException("Person data not filled", HttpStatusCode.NotFound);

		var limit = request.Limit;
		var offset = request.Offset;
		Expression<Func<GlucoseInfoDto, bool>> filter = x => x.PersonInfoId == currentPersonId && x.CreatedAt.Date == request.DateTime;
		IEnumerable<string> includeProperties = [];

		var wrapper = await service.GetAsync(limit, offset, filter, includeProperties);

		var entities = wrapper.Items;

		var models = mapper.Map<IEnumerable<GlucoseInfoViewModel>>(entities);

		var listView = new GlucoseInfoListViewModel
		{
			ModelList = models,
			TotalCount = wrapper.TotalCount
		};

		return listView;
	}
}