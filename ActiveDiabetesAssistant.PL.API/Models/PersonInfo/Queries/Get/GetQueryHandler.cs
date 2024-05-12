namespace ActiveDiabetesAssistant.PL.API.Models.PersonInfo.Queries.Get;

public class GetMyPersonInfoQueryHandler(
	IPersonInfoRepository service,
	IMapper mapper,
	IHttpContextAccessor contextAccessor) :
	IRequestHandler<GetMyPersonInfoQuery, PersonInfoViewModel>
{
	public async Task<PersonInfoViewModel> Handle(GetMyPersonInfoQuery request, CancellationToken cancellationToken)
	{
		var userId = contextAccessor.GetApiUserId()
			?? throw new ExpectedException("User not found", HttpStatusCode.Forbidden);

		var currentPersonId = await service.GetPersonId(userId)
			?? throw new ExpectedException("Person data not filled", HttpStatusCode.NotFound);

		var entity = await service.GetAsync(currentPersonId)
			?? throw new NotFoundException(nameof(PersonInfoDto), currentPersonId);

		var model = mapper.Map<PersonInfoViewModel>(entity);

		return model;
	}
}