namespace ActiveDiabetesAssistant.PL.API.Models.PersonInfo.Commands.Update;

public class UpdateMessageCommandHandler(
	IPersonInfoRepository service,
	IMapper mapper,
	IValidator<UpdateMyPersonInfoCommand> validator,
	IHttpContextAccessor contextAccessor) :
	IRequestHandler<UpdateMyPersonInfoCommand>
{
	public async Task Handle(UpdateMyPersonInfoCommand request, CancellationToken cancellationToken)
	{
		await validator.ValidateAndThrowAsync(request, cancellationToken);

		var user = contextAccessor.GetApiUser()
			?? throw new ExpectedException("User not found", HttpStatusCode.Forbidden);

		var currentPersonId = await service.GetPersonId(user.Id)
			?? throw new ExpectedException("Person data not filled", HttpStatusCode.NotFound);

		var dto = new PersonInfoDto
		{
			Id = currentPersonId,
			Name = request.Name,
			Age = request.Age,
			Sex = request.Sex,
			DiabetesType = request.DiabetesType
		};

		await service.PatchAsync(dto);
	}
}