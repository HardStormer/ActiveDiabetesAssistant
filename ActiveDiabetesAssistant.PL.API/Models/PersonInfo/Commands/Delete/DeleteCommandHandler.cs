namespace ActiveDiabetesAssistant.PL.API.Models.PersonInfo.Commands.Delete;

public class DeleteMyPersonInfoCommandHandler(
	IPersonInfoRepository service,
	IHttpContextAccessor contextAccessor) :
	IRequestHandler<DeleteMyPersonInfoCommand>
{
	public async Task Handle(DeleteMyPersonInfoCommand request, CancellationToken cancellationToken)
	{
		var user = contextAccessor.GetApiUser()
			?? throw new ExpectedException("User not found", HttpStatusCode.Forbidden);

		var currentPersonId = await service.GetPersonId(user.Id)
			?? throw new ExpectedException("Person data not filled", HttpStatusCode.NotFound);

		await service.RemoveAsync(currentPersonId, request.Soft);
	}
}