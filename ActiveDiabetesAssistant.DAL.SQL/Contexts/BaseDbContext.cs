using ActiveDiabetesAssistant.DAL.Entities;

namespace ActiveDiabetesAssistant.DAL.SQL.Contexts;

public sealed class BaseDbContext : DbContext
{
	public BaseDbContext(DbContextOptions<BaseDbContext> options)
		: base(options)
	{
		//Database.Migrate();
	}

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