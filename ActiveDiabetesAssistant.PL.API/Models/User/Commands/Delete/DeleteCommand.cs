namespace ActiveDiabetesAssistant.PL.API.Models.User.Commands.Delete;

public class DeleteUserCommand : BaseDeleteCommand
{
	public Guid UserId { get; set; }
}