namespace ActiveDiabetesAssistant.PL.API.Models.GlucoseInfo.Queries.Get;

public class GetGlucoseInfoQueryHandler(
	IGlucoseInfoRepository service,
	IPersonInfoRepository personService,
	IMapper mapper,
	IHttpContextAccessor contextAccessor) :
	IRequestHandler<GetGlucoseInfoQuery, GlucoseInfoViewModel>
{
	public async Task<GlucoseInfoViewModel> Handle(GetGlucoseInfoQuery request, CancellationToken cancellationToken)
	{
		var userId = contextAccessor.GetApiUserId()
			?? throw new ExpectedException("User not found", HttpStatusCode.Forbidden);

		var currentPersonId = await personService.GetPersonId(userId)
			?? throw new ExpectedException("Person data not filled", HttpStatusCode.NotFound);

		var entity = await service.GetAsync(request.Id)
			?? throw new NotFoundException(nameof(GlucoseInfoDto), request.Id);

		if (entity.PersonInfoId != currentPersonId)
		{
			throw new ExpectedException("This glucose info do not belongs to you", HttpStatusCode.Forbidden);
		}

		var model = mapper.Map<GlucoseInfoViewModel>(entity);

		return model;
	}
}