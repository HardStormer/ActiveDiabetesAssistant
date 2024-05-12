namespace ActiveDiabetesAssistant.DAL.SQL;

public class UserRepository(IDbContextFactory<BaseDbContext> contextFactory) : BaseRepository<UserDto>(contextFactory), IUserRepository
{
	public async Task<UserDto?> GetAsync(string email)
	{
		await using BaseDbContext context = await ContextFactory.CreateDbContextAsync();

		var gets = await context.Set<UserDto>().Where(x => x.Email == email).FirstOrDefaultAsync();

		return gets;
	}
}