namespace ActiveDiabetesAssistant.PL.API.Models.GlucoseInfo.Commands.Delete;

public class DeleteGlucoseInfoCommandHandler(
	IGlucoseInfoRepository service,
	IPersonInfoRepository personService,
	IHttpContextAccessor contextAccessor) :
	IRequestHandler<DeleteGlucoseInfoCommand>
{
	public async Task Handle(DeleteGlucoseInfoCommand request, CancellationToken cancellationToken)
	{
		var user = contextAccessor.GetApiUser()
			?? throw new ExpectedException("User not found", HttpStatusCode.Forbidden);

		var currentPersonId = await personService.GetPersonId(user.Id)
			?? throw new ExpectedException("Person data not filled", HttpStatusCode.Forbidden);

		var needGlucoseInfo = await service.GetAsync(request.GlucoseInfoId)
			?? throw new NotFoundException(typeof(GlucoseInfoDto).Name, request.GlucoseInfoId);

		if (needGlucoseInfo.PersonInfoId != currentPersonId)
		{
			throw new ExpectedException("This glucose info do not belongs to you", HttpStatusCode.Forbidden);
		}

		await service.RemoveAsync(request.GlucoseInfoId, request.Soft);
	}
}