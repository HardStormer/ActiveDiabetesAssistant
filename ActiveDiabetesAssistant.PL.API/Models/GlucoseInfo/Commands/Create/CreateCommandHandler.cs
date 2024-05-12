using ActiveDiabetesAssistant.PL.API.Models.GlucoseInfo.Queries;

namespace ActiveDiabetesAssistant.PL.API.Models.GlucoseInfo.Commands.Create;

public class CreateGlucoseInfoCommandHandler(
	IGlucoseInfoRepository service,
	IPersonInfoRepository personService,
	IMapper mapper,
	IValidator<CreateGlucoseInfoCommand> validator,
	IHttpContextAccessor contextAccessor) : IRequestHandler<CreateGlucoseInfoCommand, GlucoseInfoViewModel>
{
	public async Task<GlucoseInfoViewModel> Handle(CreateGlucoseInfoCommand request, CancellationToken cancellationToken)
	{
		await validator.ValidateAndThrowAsync(request, cancellationToken);
		var user = contextAccessor.GetApiUser()
			?? throw new ExpectedException("User not found", HttpStatusCode.Forbidden);

		var currentPersonId = await personService.GetPersonId(user.Id)
			?? throw new ExpectedException("Person data not filled", HttpStatusCode.Forbidden);

		var dto = mapper.Map<GlucoseInfoDto>(request);

		dto.Id = Guid.NewGuid();
		dto.PersonInfoId = currentPersonId;

		var resultDto = await service.AddAsync(dto);
		var result = mapper.Map<GlucoseInfoViewModel>(resultDto);
		return result;
	}
}