namespace ActiveDiabetesAssistant.DAL.SQL.Contexts;

public sealed class BaseDbContext(DbContextOptions<BaseDbContext> options) : DbContext(options)
{
	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		base.OnConfiguring(optionsBuilder);
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
	}

	public DbSet<UserDto> Users { get; set; }
	public DbSet<PersonInfoDto> PersonInfos { get; set; }
	public DbSet<GlucoseInfoDto> GlucoseInfos { get; set; }
}