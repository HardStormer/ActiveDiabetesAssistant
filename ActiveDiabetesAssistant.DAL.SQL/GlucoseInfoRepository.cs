namespace ActiveDiabetesAssistant.DAL.SQL;

public class GlucoseInfoRepository(IDbContextFactory<BaseDbContext> contextFactory) : BaseRepository<GlucoseInfoDto>(contextFactory), IGlucoseInfoRepository
{
}