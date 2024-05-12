namespace ActiveDiabetesAssistant.PL.API.Models.User.Commands.Delete;

public class DeleteUserCommandHandler(IUserRepository service) :
	IRequestHandler<DeleteUserCommand>
{
	public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
	{
		await service.RemoveAsync(request.UserId, request.Soft);
	}
}