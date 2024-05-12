namespace ActiveDiabetesAssistant.PL.API.Models.GlucoseInfo.Commands.Update;

public class UpdateMessageCommandHandler(
	IGlucoseInfoRepository service,
	IPersonInfoRepository personService,
	IMapper mapper,
	IValidator<UpdateGlucoseInfoCommand> validator,
	IHttpContextAccessor contextAccessor) :
	IRequestHandler<UpdateGlucoseInfoCommand>
{
	public async Task Handle(UpdateGlucoseInfoCommand request, CancellationToken cancellationToken)
	{
		await validator.ValidateAndThrowAsync(request, cancellationToken);

		var user = contextAccessor.GetApiUser()
			?? throw new ExpectedException("User not found", HttpStatusCode.Forbidden);

		var currentPersonId = await personService.GetPersonId(user.Id)
			?? throw new ExpectedException("Person data not filled", HttpStatusCode.NotFound);

		var needGlucoseInfo = await service.GetAsync(request.GlucoseInfoId)
			?? throw new NotFoundException(typeof(GlucoseInfoDto).Name, request.GlucoseInfoId);

		if (needGlucoseInfo.PersonInfoId != currentPersonId)
		{
			throw new ExpectedException("This glucose info do not belongs to you", HttpStatusCode.Forbidden);
		}

		var dto = new GlucoseInfoDto
		{
			Id = request.GlucoseInfoId,
			GlucoseData = request.GlucoseData,
			StepsCount = request.StepsCount
		};

		await service.PatchAsync(dto);
	}
}