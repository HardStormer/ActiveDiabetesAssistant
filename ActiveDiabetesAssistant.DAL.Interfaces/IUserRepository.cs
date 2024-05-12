namespace ActiveDiabetesAssistant.DAL.Interfaces;

public interface IUserRepository : IBaseRepository<UserDto>
{
	Task<UserDto?> GetAsync(string email);
}