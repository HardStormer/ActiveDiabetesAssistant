using ActiveDiabetesAssistant.PL.API.Models.PersonInfo.Queries;

namespace ActiveDiabetesAssistant.PL.API.Models.PersonInfo.Commands.Create;

public class CreateMyPersonInfoCommandHandler(
	IPersonInfoRepository service,
	IMapper mapper,
	IValidator<CreateMyPersonInfoCommand> validator,
	IHttpContextAccessor contextAccessor) : IRequestHandler<CreateMyPersonInfoCommand, PersonInfoViewModel>
{
	public async Task<PersonInfoViewModel> Handle(CreateMyPersonInfoCommand request, CancellationToken cancellationToken)
	{
		await validator.ValidateAndThrowAsync(request, cancellationToken);
		var user = contextAccessor.GetApiUser()
			?? throw new ExpectedException("User not found", HttpStatusCode.Forbidden);

		var currentPersonId = await service.GetPersonId(user.Id);

		if (currentPersonId != null)
		{
			throw new ExpectedException("Person info already exists", HttpStatusCode.Forbidden);
		}

		var dto = mapper.Map<PersonInfoDto>(request);

		dto.Id = Guid.NewGuid();
		dto.UserId = user.Id;

		var resultDto = await service.AddAsync(dto);
		var result = mapper.Map<PersonInfoViewModel>(resultDto);
		return result;
	}
}