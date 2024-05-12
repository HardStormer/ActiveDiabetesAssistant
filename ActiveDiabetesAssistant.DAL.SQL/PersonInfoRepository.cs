namespace ActiveDiabetesAssistant.DAL.SQL;

public class PersonInfoRepository(IDbContextFactory<BaseDbContext> contextFactory) : BaseRepository<PersonInfoDto>(contextFactory), IPersonInfoRepository
{
	public async Task<Guid?> GetPersonId(Guid userId)
	{
		await using var context = await ContextFactory.CreateDbContextAsync();
		var needPersonId = await context.PersonInfos.Select(x => new { x.Id, x.UserId }).FirstOrDefaultAsync(x => x.UserId == userId);

		return needPersonId?.Id;
	}
}